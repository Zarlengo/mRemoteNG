/*
 * NOTES:
 * 
 * Testing methods:
 * 1) Not logged into Bitwarden CLI - fails with message to login
 * 2) Logged into Bitwarden CLI but no hkey - prompts for access token
 * 3) Logged into Bitwarden CLI with hkey - works without prompt
 * 4) Hkey session invalid (lock/logout) - prompts for access token?
 * 5) BW credentials includes domain
 * 6) BW credentials includes SSH key
 * 
 * TODO:
 * - test sso
 * - login with alias                   alias bw-personal="BITWARDENCLI_APPDATA_DIR=~/.config/Bitwarden\ CLI\ Personal /path/to/bw $@"
                                        alias bw-work="BITWARDENCLI_APPDATA_DIR=~/.config/Bitwarden\ CLI\ Work /path/to/bw $@"
        The alias_uuid is going to be either (1) a uuid or (2) an alias:uuid which should be parsed into the two elements
         1) 2d9223d0-14f7-492f-90a5-b3ce0124fca8
         2) bw-personal:8b5104e3-efcc-4644-8e5d-b3ce0004f3b5
         3) bw-work:9db2bdc1-c37a-4038-99dd-b3cc014d392e
 */

namespace ExternalConnectors.BW;

public class BitwardenCliException(string message, string? arguments = null) : Exception(message)
{
    public string Arguments { get; } = arguments ?? "";
}

public class BitwardenCli
{
    public static void ReadPassword(string uuid_name, out string username, out string password, out string domain, out string privateKey)
    {
        NotificationBridge.ShowInformation?.Invoke("Bitwarden: Reading password...", true);
        if (!BitwardenSessionManager.LoadedCredentials() && !BitwardenSessionManager.GetCredentaialsFromUser())
        {
            NotificationBridge.ShowWarning?.Invoke("Bitwarden session is invalid. Please re-authenticate.", false);
            username = string.Empty;
            password = string.Empty; 
            domain = string.Empty;
            privateKey = string.Empty;
            return;
        }

        NotificationBridge.ShowInformation?.Invoke("Successfully retrieved credentials from Bitwarden", true);
        BitwardenOperations.GetItem(uuid_name, out username, out password, out domain, out privateKey);
        NotificationBridge.ShowInformation?.Invoke("Bitwarden: Reading password completed", true);
    }

    public static IDictionary<string, string>  GetSettings()
    {
        var settings = new Dictionary<string, string>
        {
            { "ssoEnabled", BitwardenRegistryManager.GetSSO() ?? "false" },
            { "passwordFile", BitwardenRegistryManager.GetPasswordFile() ?? "" }
        };
        return settings;
    }

    public static void UpdateSSOBoolean(bool useSSO)
    {
        if (useSSO)
        {
            BitwardenRegistryManager.SaveSSO(useSSO.ToString());
            NotificationBridge.ShowInformation?.Invoke("Bitwarden SSO/ApiKey enabled.", false);
            return;
        }
        BitwardenRegistryManager.DeleteSSO();
        NotificationBridge.ShowInformation?.Invoke("Bitwarden SSO/ApiKey disabled.", false);
    }

    public static void UpdatePasswordFilePath(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            BitwardenRegistryManager.DeletePasswordFile();
            NotificationBridge.ShowInformation?.Invoke("Bitwarden password filepath deleted.", false);
            return;
        }
        BitwardenRegistryManager.SavePasswordFile(filePath);
        NotificationBridge.ShowInformation?.Invoke("Bitwarden password filepath added.", false);
    }

    public static void ClearSessionToken()
    {
        NotificationBridge.ShowInformation?.Invoke("Bitwarden: Clearing session token...", true);
        BitwardenOperations.Lock();
        BitwardenSessionManager.ClearCurrentSessionToken();
        BitwardenRegistryManager.DeleteToken();
        NotificationBridge.ShowInformation?.Invoke("Bitwarden session cleared.", false);
    }

    public static bool TestConnection(out string status)
    {
        status = string.Empty;
        NotificationBridge.ShowInformation?.Invoke("Bitwarden options: Button pressed - Test connection", false);

        // Check if credentials exist
        if (BitwardenSessionManager.LoadedCredentials())
        {
            status = BitwardenOperations.GetStatus();
            NotificationBridge.ShowInformation?.Invoke("Bitwarden options: Testing connection completed", true);
            return true;
        }

        // Prompt user to enter credentials               
        NotificationBridge.ShowInformation?.Invoke("Bitwarden options: No credentials loaded, prompting user", true);
        bool getCredentials = BitwardenSessionManager.GetCredentaialsFromUser();
        NotificationBridge.ShowInformation?.Invoke("Bitwarden options: User prompted for credentials completed", true);
        return getCredentials;
    }

    public static bool EnterCredentials()
    {
        NotificationBridge.ShowInformation?.Invoke("Bitwarden options: Button pressed - Enter credentials", true);
        bool getCredentials = BitwardenSessionManager.GetCredentaialsFromUser();
        NotificationBridge.ShowInformation?.Invoke("Bitwarden options: Enter credentials completed", true);
        return getCredentials;
    }

    public static bool SyncVault()
    {
        NotificationBridge.ShowInformation?.Invoke("Bitwarden options: Button pressed - Sync vault", true);
        if (!BitwardenSessionManager.LoadedCredentials())
        {
            NotificationBridge.ShowInformation?.Invoke("Bitwarden: Credentials not loaded", true);
            return false;
        }
        bool sync = BitwardenOperations.Sync();
        NotificationBridge.ShowInformation?.Invoke("Bitwarden options: Sync vault completed", true);
        return sync;
    }
}