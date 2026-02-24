namespace ExternalConnectors.BW
{
    public partial class BWConnectionForm : Form
    {
        public BWConnectionForm()
        {
            InitializeComponent();
        }

        private void BWConnectionForm_Activated(object sender, EventArgs e)
        {
            bwPassword.Focus();
        }
    }
}
