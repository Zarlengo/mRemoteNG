using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ExternalConnectors.BW;
internal class BitwardenSessionManager
{
    private static string _sessionToken = "";

    private record BitwardenStatus(string ServerUrl, DateTime LastSync, string UserEmail, string UserId, string Status);

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static bool LoadedCredentials()
    {
        try
        {
            // 1) Check if session token is already in memory
            if (!string.IsNullOrEmpty(_sessionToken))
            {
                return true;
            }

            // 2) Try to load token from registry
            string storedToken = BitwardenRegistryManager.GetToken();
            if (!string.IsNullOrEmpty(storedToken))
            {
                _sessionToken = storedToken;
                return true;
            }

            // 3) Check if SSO/ApiKey is configured
            string ssoValue = BitwardenRegistryManager.GetSSO();
            if (!string.IsNullOrEmpty(ssoValue) && bool.TryParse(ssoValue, out bool useSso) && useSso)
            {
                try
                {
                    _sessionToken = BitwardenOperations.Unlock();      
                    return SessionTokenIsValid();
                }
                catch (Exception ex)
                {
                    _sessionToken = "";
                    NotificationBridge.ShowWarning?.Invoke($"SSO unlock failed: {ex.Message}", true);
                }
            }

            // 4) Check if password file is configured
            string passwordFile = BitwardenRegistryManager.GetPasswordFile();
            if (!string.IsNullOrEmpty(passwordFile))
            {
                try
                {
                    _sessionToken = BitwardenOperations.Unlock("PasswordFile", passwordFile);   
                    return SessionTokenIsValid();
                }
                catch (Exception ex)
                {
                    _sessionToken = "";
                    NotificationBridge.ShowWarning?.Invoke($"Password file unlock failed: {ex.Message}", true);
                }
            }

        }
        catch (Exception ex)
        {
            NotificationBridge.ShowError?.Invoke($"Error loading Bitwarden credentials: {ex.Message}", true);
            _sessionToken = "";
        }
        return false;
    }

    public static string GetCurrentSessionToken() => _sessionToken;
    public static void ClearCurrentSessionToken() { _sessionToken = ""; }

    public static bool GetCredentaialsFromUser()
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

                if (!string.IsNullOrEmpty(f.bwPassword.Text))
                {                                                  
                    _sessionToken = BitwardenOperations.Unlock("Password", f.bwPassword.Text);
                    loopIsRunning = false;
                }
                else if (!string.IsNullOrEmpty(f.bwAccessToken.Text))
                {
                    _sessionToken = f.bwAccessToken.Text;
                    loopIsRunning = false;
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
        return SessionTokenIsValid();
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
            _sessionToken = "";
            BitwardenRegistryManager.DeleteToken();
            NotificationBridge.ShowWarning?.Invoke("Bitwarden session token is invalid and has been cleared.", true);
            return false;
        }                                                  

        string currentToken = BitwardenRegistryManager.GetToken();

        if (currentToken != _sessionToken)
        {
            BitwardenRegistryManager.SaveToken(_sessionToken);
            NotificationBridge.ShowInformation?.Invoke("Bitwarden session token has been updated.", true);
        }

        return true;
    }
}
