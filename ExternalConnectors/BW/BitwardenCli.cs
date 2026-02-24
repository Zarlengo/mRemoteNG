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
 * - Get hostname & port from BW
 * - login with api key                 bw login --apikey
 * - login with sso                     bw login --sso
 * - login with alias                   alias bw-personal="BITWARDENCLI_APPDATA_DIR=~/.config/Bitwarden\ CLI\ Personal /path/to/bw $@"
                                        alias bw-work="BITWARDENCLI_APPDATA_DIR=~/.config/Bitwarden\ CLI\ Work /path/to/bw $@"
 * - revoke session token
 * - password file                      --passwordenv <passwordenv> or --passwordfile <passwordfile>
 * - BW options from settings
 */

namespace ExternalConnectors.BW;

public class BitwardenCliException(string message, string? arguments = null) : Exception(message)
{
    public string Arguments { get; } = arguments ?? "";
}

public class BitwardenCli
{
    public static void ReadPassword(string uuid, out string username, out string password, out string domain, out string privateKey)
    {
        if (!(Guid.TryParse(uuid, out Guid _)))
        {
            throw new BitwardenCliException($"Error reading UserViaAPI, not in a recognized uuid format", uuid);
        }

        if (!BitwardenSessionManager.UserProvidedValidCredentials())
        {
            Console.Out.WriteLine("Invalid session, please try again.");
            username = string.Empty;
            password = string.Empty; 
            domain = string.Empty;
            privateKey = string.Empty;
            return;
        }

        BitwardenOperations.GetItem(uuid, out username, out password, out domain, out privateKey);
    }
}