using ExternalConnectors.BW;
using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace mRemoteNG.UI.Forms.OptionsPages.ExternalConnectors
{
    [SupportedOSPlatform("windows")]
    public partial class BitwardenConnectorControl : UserControl
    {
        public event EventHandler? SettingsChanged;

        public BitwardenConnectorControl()
        {
            InitializeComponent();
        }

        public void LoadSettings()
        {
            IDictionary<string, string> settings = BitwardenCli.GetSettings();

            // Load SSO checkbox state
            if (settings.TryGetValue("ssoEnabled", out string ssoValue))
            {
                chkUseSSO.Checked = bool.TryParse(ssoValue, out bool isSso) && isSso;
            }

            // Load password file path
            if (settings.TryGetValue("passwordFile", out string passwordFile))
            {
                txtPasswordFile.Text = passwordFile;
            }
        }

        public void SaveSettings()
        {
            // SSO checkbox
            BitwardenCli.UpdateSSOBoolean(chkUseSSO.Checked);

            // Password file path
            BitwardenCli.UpdatePasswordFilePath(txtPasswordFile.Text);
        }

        private void BtnBrowsePasswordFile_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.Title = "Select Bitwarden Password File";
            openFileDialog.CheckFileExists = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPasswordFile.Text = openFileDialog.FileName;
                OnSettingsChanged();
            }
        }

        private void BtnClearPasswordFile_Click(object sender, EventArgs e)
        {
            txtPasswordFile.Text = string.Empty;
            OnSettingsChanged();
        }

        private void BtnClearToken_Click(object sender, EventArgs e)
        {
            lblActionStatus.Text = "Deleting session token...";
            lblActionStatus.ForeColor = System.Drawing.Color.Blue;

            BitwardenCli.ClearSessionToken();
            btnTestConnection.Enabled = false;

            lblActionStatus.Text = "Bitwarden session token has been cleared.";
            lblActionStatus.ForeColor = System.Drawing.Color.Green;
        }

        private void ChkUseSSO_CheckedChanged(object sender, EventArgs e)
        {
            OnSettingsChanged();
        }

        private void TxtPasswordFile_TextChanged(object sender, EventArgs e)
        {
            OnSettingsChanged();
        }

        private async void BtnTestConnection_Click(object sender, EventArgs e)
        {
            lblActionStatus.Text = "Testing connection...";
            lblActionStatus.ForeColor = System.Drawing.Color.Blue;
            btnTestConnection.Enabled = false;

            await System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    bool connection = BitwardenCli.TestConnection(out string status);
                    if (!connection)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            lblActionStatus.Text = "⚠ Unable to authenticate. Please check your credentials.";
                            lblActionStatus.ForeColor = System.Drawing.Color.Orange;
                        });
                        return;
                    }

                    // Credentials loaded successfully, report status
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (status == "unlocked")
                        {
                            lblActionStatus.Text = "✓ Connection successful! Vault is unlocked.";
                            lblActionStatus.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblActionStatus.Text = $"⚠ Connection successful but vault status is: {status}";
                            lblActionStatus.ForeColor = System.Drawing.Color.Orange;
                        }
                    });
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblActionStatus.Text = $"✗ Connection failed: {ex.Message}";
                        lblActionStatus.ForeColor = System.Drawing.Color.Red;
                    });
                }
                finally
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        btnTestConnection.Enabled = true;
                    });
                }
            });
        }

        private void BtnOpenCredentials_Click(object sender, EventArgs e)
        {
            try
            {
                lblActionStatus.Text = "Opening credentials dialog...";
                lblActionStatus.ForeColor = System.Drawing.Color.Blue;

                bool success = BitwardenCli.EnterCredentials();

                if (success)
                {
                    lblActionStatus.Text = "✓ Credentials entered successfully.";
                    lblActionStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblActionStatus.Text = "Credentials dialog cancelled.";
                    lblActionStatus.ForeColor = System.Drawing.Color.Gray;
                }
            }
            catch (Exception ex)
            {
                lblActionStatus.Text = $"✗ Error opening credentials: {ex.Message}";
                lblActionStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private async void BtnSyncVault_Click(object sender, EventArgs e)
        {
            lblActionStatus.Text = "Syncing vault...";
            lblActionStatus.ForeColor = System.Drawing.Color.Blue;
            btnSyncVault.Enabled = false;

            await System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    bool sync = BitwardenCli.SyncVault();

                    this.Invoke((MethodInvoker)delegate
                    {
                        if (sync)
                        {
                            lblActionStatus.Text = "✓ Vault synced successfully!";
                            lblActionStatus.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblActionStatus.Text = ("Bitwarden session is invalid. Please re-authenticate.");
                            lblActionStatus.ForeColor = System.Drawing.Color.Orange;
                        }
                    });
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblActionStatus.Text = $"✗ Sync failed: {ex.Message}";
                        lblActionStatus.ForeColor = System.Drawing.Color.Red;
                    });
                }
                finally
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        btnSyncVault.Enabled = true;
                    });
                }
            });
        }

        private void OnSettingsChanged()
        {
            SettingsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
