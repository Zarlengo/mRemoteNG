using Microsoft.Win32;

namespace ExternalConnectors.BW;

public class BitwardenRegistryManager
{
    private const string HKeyID = @"SOFTWARE\mRemoteNGBitwarden";
    private const string HKeyName = "BW_SESSION";

    public static string GetToken()
    {
        RegistryKey? key = null;

        try
        {
            key = Registry.CurrentUser.CreateSubKey(HKeyID);
            return key.GetValue(HKeyName) as string ?? string.Empty;
        }
        finally
        {
            key?.Close();
        }
    }

    public static void SaveToken(string token)
    {
        RegistryKey? key = null;

        try
        {
            key = Registry.CurrentUser.CreateSubKey(HKeyID);
            key.SetValue(HKeyName, token);
        }
        finally
        {
            key?.Close();
        }
    }

    public static void DeleteToken()
    {
        RegistryKey? key = null;

        try
        {
            key = Registry.CurrentUser.CreateSubKey(HKeyID);
            key.DeleteValue(HKeyName, throwOnMissingValue: false);
        }
        finally
        {
            key?.Close();
        }
    }
}
