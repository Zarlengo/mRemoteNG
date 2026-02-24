using System.Diagnostics;
using System.Text.Json;

namespace ExternalConnectors.BW;

public class BitwardenOperations
{
    private const string BitwardenCliExecutable = "bw.exe";
    private const string DomainLabel = "Domain";
    private const string SshKeyLabel = "SSHKey";

    private record BitwardenField(string Name, string Value);

    private record BitwardenLogin(string Username, string Password);

    private record BitwardenItem(BitwardenLogin Login, BitwardenField[] Fields);

    private record BitwardenStatus(string ServerUrl, DateTime LastSync, string UserEmail, string UserId, string Status);

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static void GetItem(string uuid, string sessionToken, out string username, out string password, out string domain, out string privateKey)
    {
        var getItem = new List<string> { "get", "item", uuid, "--session", sessionToken };
        string commandLine = BitwardenCliExecutable + " " + string.Join(' ', getItem);
        int exitCode = BitwardenCommandRunner.RunCommand(BitwardenCliExecutable, getItem, out string output, out string error);
        if (exitCode != 0)
        {
            username = string.Empty;
            password = string.Empty;
            privateKey = string.Empty;
            domain = string.Empty;
            throw new BitwardenCliException($"Error running bw item get: {error}",
                commandLine);
        }

        var item = JsonSerializer.Deserialize<BitwardenItem>(output, JsonSerializerOptions) ??
                    throw new BitwardenCliException("Bitwarden returned null", $"bw get item {uuid}");

        username = item.Login?.Username ?? string.Empty;
        if (string.IsNullOrEmpty(username))
        {
            throw new BitwardenCliException("No username found in Bitwarden. Review field with label: Username.", $"bw get item {uuid}");
        }

        password = item.Login?.Password ?? string.Empty;
        if (string.IsNullOrEmpty(password))
        {
            throw new BitwardenCliException("No secret found in Bitwarden. Review field with label: Password.", $"bw get item {uuid}");
        }

        domain = FindField(item, DomainLabel);

        privateKey = FindField(item, SshKeyLabel);
    }

    public static void Sync(string sessionToken)
    {
        var syncCommand = new List<string> { "sync", "--session", sessionToken };
        int exitCode = BitwardenCommandRunner.RunCommand(BitwardenCliExecutable, syncCommand, out string output, out string error);
        if (exitCode != 0)
        {
            throw new BitwardenCliException($"Error syncing with Bitwarden: {error}", $"bw sync");
        }
        Console.Out.WriteLine(output);
    }

    public static string GetStatus(string sessionToken)
    {
        try
        {
            var arguments = new List<string> { "status", "--session", sessionToken };
            int exitCode = BitwardenCommandRunner.RunCommand(BitwardenCliExecutable, arguments, out string output, out string error);
            if (exitCode != 0)
            {
                throw new BitwardenCliException($"Error validating token: {error}", "bw status");
            }

            var status = JsonSerializer.Deserialize<BitwardenStatus>(output, JsonSerializerOptions) ??
                throw new BitwardenCliException("Bitwarden returned null", $"bw status");

            return status.Status;
        }
        catch (Exception ex)
        {
            throw new BitwardenCliException($"Error getting status: {ex.Message}", $"bw status");
        }
    }

    public static void Login(string sessionToken)
    {
        var loginCommand = new List<string> { "login", "--session", sessionToken };
        int exitCode = BitwardenCommandRunner.RunCommand(BitwardenCliExecutable, loginCommand, out string output, out string error);
        if (exitCode != 0)
        {
            throw new BitwardenCliException($"Error logging into Bitwarden: {error}", $"bw login");
        }
        Console.Out.WriteLine(output);
    }

    private static string FindField(BitwardenItem item, string customFieldName)
    {
        BitwardenField? matchingField = item.Fields?.FirstOrDefault(x => x.Name == customFieldName);
        return matchingField?.Value ?? string.Empty;
    }
}
