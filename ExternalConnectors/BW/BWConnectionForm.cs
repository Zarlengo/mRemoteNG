namespace ExternalConnectors.BW
{
    public partial class BWConnectionForm : Form
    {
        public BWConnectionForm()
        {
            InitializeComponent();
            Load += BWConnectionForm_Load;
        }

        private void BWConnectionForm_Load(object? sender, EventArgs e)
        {
            // Load saved SSO checkbox state
            string ssoValue = BitwardenRegistryManager.GetSSO();
            if (!string.IsNullOrEmpty(ssoValue))
            {
                bwUseSSO.Checked = bool.TryParse(ssoValue, out bool isSso) && isSso;
            }

            // Load saved password file path
            string passwordFile = BitwardenRegistryManager.GetPasswordFile();
            if (!string.IsNullOrEmpty(passwordFile))
            {
                bwPasswordFile.Text = passwordFile;
            }
        }

        private void BWConnectionForm_Activated(object sender, EventArgs e)
        {
            bwPassword.Focus();
        }
    }
}
