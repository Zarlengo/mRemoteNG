using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ExternalConnectors.BW;
internal partial class BitwardenOperations
{
    private const string DomainLabel = "Domain";
    private const string SshKeyLabel = "SSHKey";
    private const string PasswordEnv = "BW_PENV";

    [GeneratedRegex(@"BW_SESSION=""([^""]+)""")]
    private static partial Regex SessionTokenRegex();

    private record BitwardenField(string Name, string Value);

    private record BitwardenLogin(string Username, string Password);

    private record BitwardenItem(BitwardenLogin Login, BitwardenField[] Fields);

    private record BitwardenStatus(string ServerUrl, DateTime LastSync, string UserEmail, string UserId, string Status);

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static void GetItem(string uuid, out string username, out string password, out string domain, out string privateKey)
    {
        var getItem = new List<string> { "get", "item", uuid, "--session", BitwardenSessionManager.GetCurrentSessionToken() };
        BitwardenCommandRunner.RunCommand(getItem, out string output);

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

    public static void Sync()
    {
        var syncCommand = new List<string> { "sync", "--session", BitwardenSessionManager.GetCurrentSessionToken() };
        BitwardenCommandRunner.RunCommand(syncCommand, out _);
    }

    public static string Unlock(string method = "Password", string? input = null)
    {
        NotificationBridge.ShowInformation?.Invoke("Bitwarden unlocking.", false);
        var unlockArgs = new List<string> { "unlock" };
        var environment = new Dictionary<string, string> { };
        if (method == "Password")
        {
            unlockArgs.Add("--passwordenv");
            unlockArgs.Add(PasswordEnv);
            environment.Add(PasswordEnv, input!);
        }
        else if (method == "SSO")
        {

        }
        else if (method == "PasswordFile")
        {                               
            unlockArgs.Add("--passwordfile");
            unlockArgs.Add(input!);

        }

        BitwardenCommandRunner.RunCommand(unlockArgs, out string output, environment);
        /**
         * Pattern matches: BW_SESSION="<token>"
         * Example output:
         *   "Your vault is now unlocked!\n\nTo unlock your vault, set your session key to the `BW_SESSION` environment variable. ex:\n$ export BW_SESSION=\"<TOKEN>\"\n> $env:BW_SESSION=\"<TOKEN>\"\n\nYou can also pass the session key to any command with the `--session` option. ex:\n$ bw list items --session <TOKEN>"
         */
        Match match = SessionTokenRegex().Match(output);
        if (!match.Success)
        {
            throw new BitwardenCliException("Failed to extract session token from unlock output", "bw unlock");
        }

        return match.Groups[1].Value;
    }        

    public static void Lock()
    {
        var lockArgs = new List<string> { "lock" };

        BitwardenCommandRunner.RunCommand(lockArgs, out string output);
    }

    public static string GetStatus()
    {
        try
        {
            var arguments = new List<string> { "status", "--session", BitwardenSessionManager.GetCurrentSessionToken() };
            BitwardenCommandRunner.RunCommand(arguments, out string output);

            var status = JsonSerializer.Deserialize<BitwardenStatus>(output, JsonSerializerOptions) ??
                throw new BitwardenCliException("Bitwarden returned null", $"bw status");

            return status.Status;
        }
        catch (Exception ex)
        {
            throw new BitwardenCliException($"Error getting status: {ex.Message}", $"bw status");
        }
    }

    private static string FindField(BitwardenItem item, string customFieldName)
    {
        BitwardenField? matchingField = item.Fields?.FirstOrDefault(x => x.Name == customFieldName);
        return matchingField?.Value ?? string.Empty;
    }
}
