using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ExternalConnectors.BW;

public class BitwardenSessionManager
{
    private static string _sessionToken = "";

    private record BitwardenStatus(string ServerUrl, DateTime LastSync, string UserEmail, string UserId, string Status);

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static bool UserProvidedValidCredentials()
    {
        try
        {
            if (SessionTokenDoesNotExists())
            {
                if (!GetCredentaialsFromUser())
                    return false;
            }

            if (SessionTokenIsValid())
            {
                return true;
            }
        }
        catch
        {
        }

        return false;
    }

    public static string GetCurrentSessionToken() => _sessionToken;

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

    private static bool GetCredentaialsFromUser()
    {
        try
        {
            BWConnectionForm f = new();
            bool loopIsRunning = true;

            while (loopIsRunning)
            {
                _ = f.ShowDialog();

                if (f.DialogResult != DialogResult.OK)
                    return false;

                if (f.bwUseSSO.Checked)
                {
                    BitwardenRegistryManager.SaveSSO(f.bwUseSSO.Checked.ToString());
                    _sessionToken = BitwardenOperations.Unlock();
                    loopIsRunning = false;
                }
                else if (!string.IsNullOrEmpty(f.bwPassword.Text))
                {                                                  
                    _sessionToken = BitwardenOperations.Unlock("password", f.bwPassword.Text);
                    loopIsRunning = false;
                }
                else if (!string.IsNullOrEmpty(f.bwAccessToken.Text))
                {
                    _sessionToken = f.bwAccessToken.Text;
                    loopIsRunning = false;
                }
                else if (!string.IsNullOrEmpty(f.bwPasswordFile.Text))
                {
                    BitwardenRegistryManager.SavePasswordFile(f.bwPasswordFile.Text);
                    _sessionToken = BitwardenOperations.Unlock("PasswordFile", f.bwPassword.Text);
                }
                else
                {
                    return false;
                }

                if (f.bwSync.Checked)
                {
                    BitwardenOperations.Sync();
                    loopIsRunning = false;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        return true;
    }

    private static bool SessionTokenIsValid()
    {
        if (string.IsNullOrEmpty(_sessionToken))
        {
            throw new BitwardenCliException($"Error reading Access Token", "");
        }

        string status = BitwardenOperations.GetStatus();

        if (status != "unlocked")
        {                                       
            BitwardenRegistryManager.DeleteToken();
            Console.Out.WriteLine("invalid token");
            return false;
        }                                                  

        string currentToken = BitwardenRegistryManager.GetToken();

        if (currentToken != _sessionToken)
        {
            BitwardenRegistryManager.SaveToken(_sessionToken);
        }

        return true;
    }
}
