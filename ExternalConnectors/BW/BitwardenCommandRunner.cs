using System.Diagnostics;

namespace ExternalConnectors.BW;

public class BitwardenCommandRunner
{
    public static int RunCommand(string command, IReadOnlyCollection<string> arguments, out string output,
        out string error, IDictionary<string, string>? environmentVariables = null)
    {
        var processStartInfo = new ProcessStartInfo
        {
            FileName = command,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        foreach (var argument in arguments)
        {
            processStartInfo.ArgumentList.Add(argument);
        }

        if (environmentVariables != null)
        {
            foreach (var kvp in environmentVariables)
            {
                processStartInfo.EnvironmentVariables[kvp.Key] = kvp.Value;
            }
        }

        using var process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();

        var outputTask = process.StandardOutput.ReadToEndAsync();
        var errorTask = process.StandardError.ReadToEndAsync();

        bool completed = process.WaitForExit(30000);

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
            output = string.Empty;
            error = string.Empty;
            throw new BitwardenCliException("Bitwarden command timed out after 30 seconds", $"{command} {string.Join(' ', arguments)}");
        }

        output = outputTask.Result;
        error = errorTask.Result;
        return process.ExitCode;
    }
}
