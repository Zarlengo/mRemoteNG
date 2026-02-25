using Microsoft.Win32;

namespace ExternalConnectors.BW;

internal class BitwardenRegistryManager
{
    private const string HKeyID = @"SOFTWARE\mRemoteNGBitwarden";
    private const string HKeyMethod = "BW_METHOD";
    private const string HKeySession = "BW_SESSION";
    private const string HKeySSO = "BW_SSO";
    private const string HKeyPasswordFile = "BW_PASSWORD_FILE";

    public static string GetMethod() => GetRegistryValue(HKeyMethod);
    public static void SaveMethod(string method) => SaveRegistryValue(HKeyMethod, method);
    public static void DeleteMethod() => DeleteRegistryValue(HKeyMethod);

    public static string GetToken() => GetRegistryValue(HKeySession);
    public static void SaveToken(string token) => SaveRegistryValue(HKeySession, token);
    public static void DeleteToken() => DeleteRegistryValue(HKeySession);

    public static string GetSSO() => GetRegistryValue(HKeySSO);
    public static void SaveSSO(string ssoIdentifier) => SaveRegistryValue(HKeySSO, ssoIdentifier);
    public static void DeleteSSO() => DeleteRegistryValue(HKeySSO);

    public static string GetPasswordFile() => GetRegistryValue(HKeyPasswordFile);
    public static void SavePasswordFile(string filePath) => SaveRegistryValue(HKeyPasswordFile, filePath);
    public static void DeletePasswordFile() => DeleteRegistryValue(HKeyPasswordFile);

    private static string GetRegistryValue(string valueName)
    {
        RegistryKey? key = null;

        try
        {
            key = Registry.CurrentUser.CreateSubKey(HKeyID);
            return key.GetValue(valueName) as string ?? string.Empty;
        }
        finally
        {
            key?.Close();
        }
    }

    private static void SaveRegistryValue(string valueName, string value)
    {
        RegistryKey? key = null;

        try
        {
            key = Registry.CurrentUser.CreateSubKey(HKeyID);
            key.SetValue(valueName, value);
        }
        finally
        {
            key?.Close();
        }
    }

    private static void DeleteRegistryValue(string valueName)
    {
        RegistryKey? key = null;

        try
        {
            key = Registry.CurrentUser.CreateSubKey(HKeyID);
            key.DeleteValue(valueName, throwOnMissingValue: false);
        }
        finally
        {
            key?.Close();
        }
    }
}
