using System.ComponentModel;
using System.Windows.Forms;

namespace mRemoteNG.UI.Forms.OptionsPages.ExternalConnectors
{
    sealed partial class ExternalConnectorsPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblExternalConnectors = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBitwarden = new System.Windows.Forms.TabPage();
            this.tabOnePassword = new System.Windows.Forms.TabPage();
            this.lblOnePasswordInfo = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabOnePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblExternalConnectors
            // 
            this.lblExternalConnectors.AutoSize = true;
            this.lblExternalConnectors.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblExternalConnectors.Location = new System.Drawing.Point(10, 10);
            this.lblExternalConnectors.Name = "lblExternalConnectors";
            this.lblExternalConnectors.Size = new System.Drawing.Size(280, 21);
            this.lblExternalConnectors.TabIndex = 0;
            this.lblExternalConnectors.Text = "External Credential Providers";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabBitwarden);
            this.tabControl.Controls.Add(this.tabOnePassword);
            this.tabControl.Location = new System.Drawing.Point(10, 40);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(580, 450);
            this.tabControl.TabIndex = 1;
            // 
            // tabBitwarden
            // 
            this.tabBitwarden.Location = new System.Drawing.Point(4, 24);
            this.tabBitwarden.Name = "tabBitwarden";
            this.tabBitwarden.Padding = new System.Windows.Forms.Padding(3);
            this.tabBitwarden.Size = new System.Drawing.Size(572, 422);
            this.tabBitwarden.TabIndex = 0;
            this.tabBitwarden.Text = "Bitwarden";
            this.tabBitwarden.UseVisualStyleBackColor = true;
            // 
            // tabOnePassword
            // 
            this.tabOnePassword.Controls.Add(this.lblOnePasswordInfo);
            this.tabOnePassword.Location = new System.Drawing.Point(4, 24);
            this.tabOnePassword.Name = "tabOnePassword";
            this.tabOnePassword.Padding = new System.Windows.Forms.Padding(3);
            this.tabOnePassword.Size = new System.Drawing.Size(572, 422);
            this.tabOnePassword.TabIndex = 1;
            this.tabOnePassword.Text = "1Password";
            this.tabOnePassword.UseVisualStyleBackColor = true;
            // 
            // lblOnePasswordInfo
            // 
            this.lblOnePasswordInfo.AutoSize = true;
            this.lblOnePasswordInfo.Location = new System.Drawing.Point(20, 20);
            this.lblOnePasswordInfo.Name = "lblOnePasswordInfo";
            this.lblOnePasswordInfo.Size = new System.Drawing.Size(380, 15);
            this.lblOnePasswordInfo.TabIndex = 0;
            this.lblOnePasswordInfo.Text = "1Password CLI integration settings will be available here.";
            // 
            // ExternalConnectorsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblExternalConnectors);
            this.Name = "ExternalConnectorsPage";
            this.Size = new System.Drawing.Size(600, 500);
            this.tabControl.ResumeLayout(false);
            this.tabOnePassword.ResumeLayout(false);
            this.tabOnePassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExternalConnectors;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBitwarden;
        private System.Windows.Forms.TabPage tabOnePassword;
        private System.Windows.Forms.Label lblOnePasswordInfo;
    }
}
