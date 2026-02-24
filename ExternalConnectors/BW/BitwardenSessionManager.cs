using System.Diagnostics;
using System.Text.Json;

namespace ExternalConnectors.BW;

public class BitwardenSessionManager
{
    private const string BitwardenCliExecutable = "bw.exe";
    private const string PasswordEnv = "BW_PENV";

    private static string _sessionToken = "";

    private record BitwardenStatus(string ServerUrl, DateTime LastSync, string UserEmail, string UserId, string Status);

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static bool TryGetValidSessionToken(out string token)
    {
        token = string.Empty;

        try
        {
            if (SessionTokenDoesNotExists())
            {
                GetAccessTokenFromUser();
            }

            if (SessionTokenIsValid())
            {
                token = _sessionToken;
                return true;
            }
        }
        catch
        {
        }

        return false;
    }

    private static bool SessionTokenDoesNotExists()
    {
        if (!string.IsNullOrEmpty(_sessionToken))
        {
            return false;
        }

        string storedToken = BitwardenRegistryManager.GetToken();
        if (!string.IsNullOrEmpty(storedToken))
        {
            _sessionToken = storedToken;
            return false;
        }

        return true;
    }

    private static void GetAccessTokenFromUser()
    {
        try
        {
            BWConnectionForm f = new();
            bool loopIsRunning = true;

            while (loopIsRunning)
            {
                _ = f.ShowDialog();

                if (f.DialogResult != DialogResult.OK)
                    return;

                if (!string.IsNullOrEmpty(f.bwPassword.Text))
                {
                    _sessionToken = f.bwPassword.Text;
                    loopIsRunning = false;
                }
                else if (!string.IsNullOrEmpty(f.bwAccessToken.Text))
                {
                    GetTokenFromPassword(f.bwPassword.Text);
                    loopIsRunning = false;
                }

                if (f.bwSync.Checked)
                {
                    BitwardenOperations.Sync(_sessionToken);
                    loopIsRunning = false;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static void GetTokenFromPassword(string password)
    {
        var unlockArgs = new List<string> { "unlock", "--passwordenv", PasswordEnv };
        var environment = new Dictionary<string, string> { { PasswordEnv, password } };

        int exitCode = BitwardenCommandRunner.RunCommand(BitwardenCliExecutable, unlockArgs, out string output, out string error, environment);
        if (exitCode != 0)
        {
            throw new BitwardenCliException($"Error getting token: {error}", "bw unlock");
        }
        Console.Out.WriteLine(output);

        var status = JsonSerializer.Deserialize<BitwardenStatus>(output, JsonSerializerOptions) ??
            throw new BitwardenCliException("Bitwarden returned null", $"bw status");

        BitwardenRegistryManager.SaveToken(_sessionToken);

        _sessionToken = password;
    }

    private static bool SessionTokenIsValid()
    {
        if (string.IsNullOrEmpty(_sessionToken))
        {
            throw new BitwardenCliException($"Error reading Access Token", "");
        }

        var getStatus = new List<string> { "status", "--session", _sessionToken };
        int exitCode = BitwardenCommandRunner.RunCommand(BitwardenCliExecutable, getStatus, out string output, out string error);
        if (exitCode != 0)
        {
            throw new BitwardenCliException($"Error validating token: {error}", "bw status");
        }
        Console.Out.WriteLine(output);

        var status = JsonSerializer.Deserialize<BitwardenStatus>(output, JsonSerializerOptions) ??
            throw new BitwardenCliException("Bitwarden returned null", $"bw status");

        string currentToken = BitwardenRegistryManager.GetToken();

        if (status.Status != "unlocked")
        {
            if (currentToken == _sessionToken)
            {
                BitwardenRegistryManager.DeleteToken();
            }
            Console.Out.WriteLine("invalid token");
            return false;
        }

        if (currentToken != _sessionToken)
        {
            BitwardenRegistryManager.SaveToken(_sessionToken);
        }

        return true;
    }
}
