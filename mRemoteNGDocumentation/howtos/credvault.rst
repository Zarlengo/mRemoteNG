**************************
Credential Vault Connector
**************************

mRemote supports fetching credentials from external credential vaults. This allows providing credentials to the connection without storing sensitive information in the config file, which has numerous benefits (security, auditing, rotating passwords, etc).
These password vaults are currently supported:

- Delinea Secret Server
- Clickstudios Passwordstate
- 1Password
- Bitwarden

The feature is implemented for RDP, RDP Gateway and SSH connections.

Before initiating a connection mRemote will access your Password Vault API and fetch the secret. For this to work the API endpoint URL and access credentials need to be specified. A popup will show up if this information has not yet been set.

.. figure:: /images/credvault02.png


Instead of setting username/password/domain directly in mRemote, leave these fields empty and specify the secret id instead: 

.. figure:: /images/credvault01.png

The secret id is the unique identifier of your secret.


Delinea Secret Server
---------------------

The secret ID can be found in the url of your secret: https://cred.domain.local/SecretServer/app/#/secret/3318/general  -> the secret id is 3318

Authentication works with WinAuth/SSO (OnPremise) and Username/Password (OnPremise, Cloud). MFA via OTP is supported.


Clickstudios PasswordState
--------------------------

The secred ID can be found in the UI after enabling "toggle visibility of web API IDs" in the "List Administrator Actions" dropdown

.. figure:: /images/credvault03.png

Authentication works with WinAuth/SSO and list-based API-Keys. MFA via OTP is supported.

- There is currently no support for token authentication, so if your API has MFA enabled, you need to specify a fresh OTP code quite frequently
- If you are using list-based API keys to access the vault, only one API key can currently be specified in the connector configuration


1Password
---------

The secret reference uses the 1Password URL format. Specify the secret in the mRemote ``UserViaAPI`` field using this format:

    ``op://vault-name/item-name``
    ``op:///item-name``

Or with an optional account parameter:

    ``op://vault-name/item-name?account=account-name``

Where:

- ``vault-name`` is the name or id of your 1Password vault
- ``item-name`` is the name or id of the item containing the credentials
- ``account-name`` (optional) specifies which 1Password account to use if you have multiple accounts

Field Mapping
~~~~~~~~~~~~~

The 1Password integration retrieves the following fields from your 1Password item:

- **Username**: Fields with purpose "USERNAME" or label "username"
- **Password**: Fields with purpose "PASSWORD" or label "password"
- **Domain**: String fields with label "domain"
- **SSH Private Key**: Fields of type "SSHKEY"

At least a password or SSH private key must be present in the item.

Prerequisites
~~~~~~~~~~~~~

The 1Password CLI (``op.exe``) must be installed and available in your system PATH. You can download it from https://1password.com/downloads/command-line/

The CLI requires the GUI application to run, because the GUI provides the authentication prompt. You can verify authentication by running:

    ``op signin``

Configuration Notes
~~~~~~~~~~~~~~~~~~~

- Server category items and some other item types may not have the ``purpose`` metadata set on their username/password fields. In these cases, the integration will fall back to matching by field label ("username" and "password").
- You can modify field labels in 1Password to match the expected conventions if needed.
- The domain field is optional and should be a string field with the label "domain".


Bitwarden
---------

The secret reference uses the Bitwarden item UUID format. Specify the secret in the mRemote ``UserViaAPI`` field using the UUID of your Bitwarden item:

    ``2d9223d0-14f7-492f-90a5-b3ce0124fca8``

Where:

- The UUID is the unique identifier of the item in your Bitwarden vault

Finding the Item UUID
~~~~~~~~~~~~~~~~~~~~~

To find the UUID of a Bitwarden item:

1. Open the Bitwarden web vault or desktop application
2. Select the item you want to use
3. Look at the URL in the browser address bar (for web vault) - the UUID is the identifier in the URL
4. Or use the Bitwarden CLI: ``bw list items --search "item-name"`` to find items and their UUIDs

Field Mapping
~~~~~~~~~~~~~

The Bitwarden integration retrieves the following fields from your Bitwarden item:

- **Username**: The ``username`` field from the item's login section
- **Password**: The ``password`` field from the item's login section  
- **Domain**: String custom field with the label "Domain"
- **SSH Private Key**: String custom field with the label "SSHKey"

At least a password must be present in the item. Username is also required.

Custom Fields
~~~~~~~~~~~~~

To add custom fields for Domain or SSH Private Key:

1. Edit your Bitwarden item
2. In the "Custom Fields" section, add a new text field
3. Set the field name to exactly "Domain" or "SSHKey" (case-sensitive)
4. Enter the value

Prerequisites
~~~~~~~~~~~~~

The Bitwarden CLI (``bw.exe``) must be installed and available in your system PATH. You can download it from https://bitwarden.com/help/cli/

Authentication Methods
~~~~~~~~~~~~~~~~~~~~~~

The Bitwarden connector supports multiple authentication methods:

**Master Password**
    Enter your Bitwarden master password when prompted. The session token will be stored securely in the Windows registry for future use.

**Access Token**
    Provide a session token directly. You can obtain a session token by running ``bw unlock`` in the command line. The token will be reused until it expires or the vault is locked.

**Password File**
    Configure a file path containing your master password in the connector settings. The password will be read from this file automatically when unlocking the vault.

**SSO/API Key**
    Enable SSO in the connector settings if your Bitwarden account uses SSO authentication.

Configuration
~~~~~~~~~~~~~

On first use, mRemote will prompt for your Bitwarden credentials. You can configure the following options:

- **Sync on connection**: Optionally sync your vault with the Bitwarden server before retrieving credentials
- **SSO Enabled**: Enable SSO/API Key authentication (stored in registry at ``HKCU\SOFTWARE\mRemoteNGBitwarden``)
- **Password File**: Path to a file containing your master password for automatic unlocking

Session Management
~~~~~~~~~~~~~~~~~~

The Bitwarden connector manages session tokens automatically:

- Session tokens are stored in the Windows registry for persistence across mRemote restarts
- If a session expires or becomes invalid, you will be prompted to authenticate again
- Use the "Clear Session" option in the connector settings to manually clear stored credentials

Configuration Notes
~~~~~~~~~~~~~~~~~~~

- The connector uses the Bitwarden CLI (``bw.exe``) which must be in your system PATH
- All CLI commands have a 30-second timeout
- Session tokens remain valid until the vault is locked or logged out
- The registry location for settings is ``HKEY_CURRENT_USER\SOFTWARE\mRemoteNGBitwarden``

