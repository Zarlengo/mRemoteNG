using System;
using System.Runtime.Versioning;
using mRemoteNG.Resources.Language;

namespace mRemoteNG.UI.Forms.OptionsPages.ExternalConnectors
{
    [SupportedOSPlatform("windows")]
    public sealed partial class ExternalConnectorsPage : OptionsPage
    {
        private readonly BitwardenConnectorControl _bitwardenControl;

        public ExternalConnectorsPage()
        {
            InitializeComponent();
            ApplyTheme();
            PageIcon = Resources.ImageConverter.GetImageAsIcon(Properties.Resources.Key_16x);

            // Initialize connector controls
            _bitwardenControl = new BitwardenConnectorControl
            {
                Dock = System.Windows.Forms.DockStyle.Fill
            };
            _bitwardenControl.SettingsChanged += (s, e) => HasChanges = true;
            
            tabBitwarden.Controls.Add(_bitwardenControl);
        }

        public override string PageName
        {
            get => "External Connectors";
            set { }
        }

        public override void ApplyLanguage()
        {
            base.ApplyLanguage();

            // Main title
            lblExternalConnectors.Text = "External Credential Providers";

            // Tab titles
            tabBitwarden.Text = "Bitwarden";
            tabOnePassword.Text = "1Password";
            
            // 1Password placeholder
            lblOnePasswordInfo.Text = "1Password CLI integration settings will be available here.";
        }

        public override void LoadSettings()
        {
            _bitwardenControl.LoadSettings();
            // Future: Load other connector settings
        }

        public override void SaveSettings()
        {
            _bitwardenControl.SaveSettings();
            // Future: Save other connector settings
        }
    }
}
