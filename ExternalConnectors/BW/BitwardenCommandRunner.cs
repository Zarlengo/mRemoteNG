using System.Diagnostics;

namespace ExternalConnectors.BW;

internal class BitwardenCommandRunner
{
    private const string BitwardenCliExecutable = "bw.exe";
    private const int CommandTimeoutS = 30;

    public static void RunCommand(
        IReadOnlyCollection<string> arguments,
        out string output,
        IDictionary<string, string>? environmentVariables = null
    )
    {
        output = string.Empty;
        var processStartInfo = new ProcessStartInfo
        {
            FileName = BitwardenCliExecutable,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        foreach (var argument in arguments)
        {
            processStartInfo.ArgumentList.Add(argument);
        }                                                
        NotificationBridge.ShowDebug?.Invoke($"Bitwarden: Running command {ObfuscateCommand(arguments)}");

        if (environmentVariables != null)
        {
            foreach (var kvp in environmentVariables)
            {
                processStartInfo.EnvironmentVariables[kvp.Key] = kvp.Value;
            }
        }

        using var process = new Process();
        process.StartInfo = processStartInfo;
        try
        {
            process.Start();
        }
        catch (System.ComponentModel.Win32Exception ex)
        {
            NotificationBridge.ShowError?.Invoke($"Bitwarden: Could not find or execute {BitwardenCliExecutable}. Ensure it's installed and in PATH.", false);
            throw new BitwardenCliException($"Failed to start Bitwarden CLI: {ex.Message}");
        }

        var outputTask = process.StandardOutput.ReadToEndAsync();
        var errorTask = process.StandardError.ReadToEndAsync();

        bool completed = process.WaitForExit(CommandTimeoutS * 1000);

        if (!completed)
        {
            try
            {
                process.Kill(entireProcessTree: true);
            }
            catch
            {
                // Ignore cleanup errors
            }
            NotificationBridge.ShowError?.Invoke($"Bitwarden: Running command timed out after {CommandTimeoutS} seconds", false);
            return;
        }

        if (process.ExitCode != 0)
        {
            NotificationBridge.ShowError?.Invoke($"Bitwarden: Running command failed with exit code {process.ExitCode}", false);
            throw new BitwardenCliException(
                $"Bitwarden command failed: {errorTask.Result}",
                ObfuscateCommand(arguments));
        }               

        output = outputTask.Result;
        NotificationBridge.ShowDebug?.Invoke($"Bitwarden: Running command {ObfuscateCommand(arguments)}");
    }

    private static string ObfuscateCommand(IReadOnlyCollection<string> arguments)
    {
        var obfuscatedArgs = new List<string>();
        bool obfuscateNext = false;

        foreach (var arg in arguments)
        {
            if (obfuscateNext)
            {
                obfuscatedArgs.Add("***");
                obfuscateNext = false;
            }
            else if (arg == "--session" || arg == "--password" || arg == "--passwordenv")
            {
                obfuscatedArgs.Add(arg);
                obfuscateNext = true;
            }
            else
            {
                obfuscatedArgs.Add(arg);
            }
        }

        return $"{BitwardenCliExecutable} {string.Join(' ', obfuscatedArgs)}";
    }
}
