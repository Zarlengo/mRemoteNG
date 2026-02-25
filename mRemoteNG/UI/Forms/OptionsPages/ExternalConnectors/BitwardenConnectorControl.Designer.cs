namespace mRemoteNG.UI.Forms.OptionsPages.ExternalConnectors
{
    partial class BitwardenConnectorControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.grpBitwardenActions = new System.Windows.Forms.GroupBox();
            this.lblActionStatus = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnOpenCredentials = new System.Windows.Forms.Button();
            this.btnSyncVault = new System.Windows.Forms.Button();
            this.grpBitwardenSession = new System.Windows.Forms.GroupBox();
            this.lblSessionTokenInfo = new System.Windows.Forms.Label();
            this.btnClearToken = new System.Windows.Forms.Button();
            this.grpBitwardenAuth = new System.Windows.Forms.GroupBox();
            this.chkUseSSO = new System.Windows.Forms.CheckBox();
            this.lblPasswordFile = new System.Windows.Forms.Label();
            this.txtPasswordFile = new System.Windows.Forms.TextBox();
            this.btnClearPasswordFile = new System.Windows.Forms.Button();
            this.btnBrowsePasswordFile = new System.Windows.Forms.Button();
            this.lblPasswordFileWarning = new System.Windows.Forms.Label();
            this.grpBitwardenActions.SuspendLayout();
            this.grpBitwardenSession.SuspendLayout();
            this.grpBitwardenAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBitwardenActions
            // 
            this.grpBitwardenActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBitwardenActions.Controls.Add(this.lblActionStatus);
            this.grpBitwardenActions.Controls.Add(this.btnTestConnection);
            this.grpBitwardenActions.Controls.Add(this.btnOpenCredentials);
            this.grpBitwardenActions.Controls.Add(this.btnSyncVault);
            this.grpBitwardenActions.Location = new System.Drawing.Point(0, 290);
            this.grpBitwardenActions.Name = "grpBitwardenActions";
            this.grpBitwardenActions.Size = new System.Drawing.Size(535, 120);
            this.grpBitwardenActions.TabIndex = 2;
            this.grpBitwardenActions.TabStop = false;
            this.grpBitwardenActions.Text = "Actions";
            // 
            // lblActionStatus
            // 
            this.lblActionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActionStatus.Location = new System.Drawing.Point(15, 65);
            this.lblActionStatus.Name = "lblActionStatus";
            this.lblActionStatus.Size = new System.Drawing.Size(505, 45);
            this.lblActionStatus.TabIndex = 3;
            this.lblActionStatus.Text = "";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(15, 25);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(150, 30);
            this.btnTestConnection.TabIndex = 0;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.BtnTestConnection_Click);
            // 
            // btnOpenCredentials
            // 
            this.btnOpenCredentials.Location = new System.Drawing.Point(185, 25);
            this.btnOpenCredentials.Name = "btnOpenCredentials";
            this.btnOpenCredentials.Size = new System.Drawing.Size(150, 30);
            this.btnOpenCredentials.TabIndex = 1;
            this.btnOpenCredentials.Text = "Enter Credentials";
            this.btnOpenCredentials.UseVisualStyleBackColor = true;
            this.btnOpenCredentials.Click += new System.EventHandler(this.BtnOpenCredentials_Click);
            // 
            // btnSyncVault
            // 
            this.btnSyncVault.Location = new System.Drawing.Point(355, 25);
            this.btnSyncVault.Name = "btnSyncVault";
            this.btnSyncVault.Size = new System.Drawing.Size(150, 30);
            this.btnSyncVault.TabIndex = 2;
            this.btnSyncVault.Text = "Sync Vault";
            this.btnSyncVault.UseVisualStyleBackColor = true;
            this.btnSyncVault.Click += new System.EventHandler(this.BtnSyncVault_Click);
            // 
            // grpBitwardenSession
            // 
            this.grpBitwardenSession.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBitwardenSession.Controls.Add(this.lblSessionTokenInfo);
            this.grpBitwardenSession.Controls.Add(this.btnClearToken);
            this.grpBitwardenSession.Location = new System.Drawing.Point(0, 190);
            this.grpBitwardenSession.Name = "grpBitwardenSession";
            this.grpBitwardenSession.Size = new System.Drawing.Size(535, 90);
            this.grpBitwardenSession.TabIndex = 1;
            this.grpBitwardenSession.TabStop = false;
            this.grpBitwardenSession.Text = "Session Management";
            // 
            // lblSessionTokenInfo
            // 
            this.lblSessionTokenInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSessionTokenInfo.Location = new System.Drawing.Point(15, 20);
            this.lblSessionTokenInfo.Name = "lblSessionTokenInfo";
            this.lblSessionTokenInfo.Size = new System.Drawing.Size(505, 25);
            this.lblSessionTokenInfo.TabIndex = 0;
            this.lblSessionTokenInfo.Text = "Clear the stored session token to force re-authentication on next connection.";
            // 
            // btnClearToken
            // 
            this.btnClearToken.Location = new System.Drawing.Point(15, 48);
            this.btnClearToken.Name = "btnClearToken";
            this.btnClearToken.Size = new System.Drawing.Size(150, 30);
            this.btnClearToken.TabIndex = 1;
            this.btnClearToken.Text = "Clear Session Token";
            this.btnClearToken.UseVisualStyleBackColor = true;
            this.btnClearToken.Click += new System.EventHandler(this.BtnClearToken_Click);
            // 
            // grpBitwardenAuth
            // 
            this.grpBitwardenAuth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBitwardenAuth.Controls.Add(this.chkUseSSO);
            this.grpBitwardenAuth.Controls.Add(this.lblPasswordFile);
            this.grpBitwardenAuth.Controls.Add(this.txtPasswordFile);
            this.grpBitwardenAuth.Controls.Add(this.btnClearPasswordFile);
            this.grpBitwardenAuth.Controls.Add(this.btnBrowsePasswordFile);
            this.grpBitwardenAuth.Controls.Add(this.lblPasswordFileWarning);
            this.grpBitwardenAuth.Location = new System.Drawing.Point(0, 0);
            this.grpBitwardenAuth.Name = "grpBitwardenAuth";
            this.grpBitwardenAuth.Size = new System.Drawing.Size(535, 180);
            this.grpBitwardenAuth.TabIndex = 0;
            this.grpBitwardenAuth.TabStop = false;
            this.grpBitwardenAuth.Text = "Authentication Settings";
            // 
            // chkUseSSO
            // 
            this.chkUseSSO.AutoSize = true;
            this.chkUseSSO.Location = new System.Drawing.Point(15, 25);
            this.chkUseSSO.Name = "chkUseSSO";
            this.chkUseSSO.Size = new System.Drawing.Size(180, 19);
            this.chkUseSSO.TabIndex = 0;
            this.chkUseSSO.Text = "Logged in with SSO/ApiKey";
            this.chkUseSSO.UseVisualStyleBackColor = true;
            this.chkUseSSO.CheckedChanged += new System.EventHandler(this.ChkUseSSO_CheckedChanged);
            // 
            // lblPasswordFile
            // 
            this.lblPasswordFile.AutoSize = true;
            this.lblPasswordFile.Location = new System.Drawing.Point(15, 55);
            this.lblPasswordFile.Name = "lblPasswordFile";
            this.lblPasswordFile.Size = new System.Drawing.Size(109, 15);
            this.lblPasswordFile.TabIndex = 1;
            this.lblPasswordFile.Text = "Password File Path:";
            // 
            // txtPasswordFile
            // 
            this.txtPasswordFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswordFile.Location = new System.Drawing.Point(15, 75);
            this.txtPasswordFile.Name = "txtPasswordFile";
            this.txtPasswordFile.Size = new System.Drawing.Size(360, 23);
            this.txtPasswordFile.TabIndex = 2;
            this.txtPasswordFile.TextChanged += new System.EventHandler(this.TxtPasswordFile_TextChanged);
            // 
            // btnClearPasswordFile
            // 
            this.btnClearPasswordFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearPasswordFile.Location = new System.Drawing.Point(381, 74);
            this.btnClearPasswordFile.Name = "btnClearPasswordFile";
            this.btnClearPasswordFile.Size = new System.Drawing.Size(60, 23);
            this.btnClearPasswordFile.TabIndex = 3;
            this.btnClearPasswordFile.Text = "Clear";
            this.btnClearPasswordFile.UseVisualStyleBackColor = true;
            this.btnClearPasswordFile.Click += new System.EventHandler(this.BtnClearPasswordFile_Click);
            // 
            // btnBrowsePasswordFile
            // 
            this.btnBrowsePasswordFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowsePasswordFile.Location = new System.Drawing.Point(446, 74);
            this.btnBrowsePasswordFile.Name = "btnBrowsePasswordFile";
            this.btnBrowsePasswordFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowsePasswordFile.TabIndex = 4;
            this.btnBrowsePasswordFile.Text = "Browse...";
            this.btnBrowsePasswordFile.UseVisualStyleBackColor = true;
            this.btnBrowsePasswordFile.Click += new System.EventHandler(this.BtnBrowsePasswordFile_Click);
            // 
            // lblPasswordFileWarning
            // 
            this.lblPasswordFileWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPasswordFileWarning.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblPasswordFileWarning.Location = new System.Drawing.Point(15, 105);
            this.lblPasswordFileWarning.Name = "lblPasswordFileWarning";
            this.lblPasswordFileWarning.Size = new System.Drawing.Size(506, 65);
            this.lblPasswordFileWarning.TabIndex = 4;
            this.lblPasswordFileWarning.Text = "WARNING: If you use the --passwordfile option, protect your password file by locking access down to only the user who needs to run bw unlock and only providing read access to that user.";
            // 
            // BitwardenConnectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBitwardenActions);
            this.Controls.Add(this.grpBitwardenSession);
            this.Controls.Add(this.grpBitwardenAuth);
            this.Name = "BitwardenConnectorControl";
            this.Size = new System.Drawing.Size(535, 420);
            this.grpBitwardenActions.ResumeLayout(false);
            this.grpBitwardenSession.ResumeLayout(false);
            this.grpBitwardenAuth.ResumeLayout(false);
            this.grpBitwardenAuth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBitwardenAuth;
        private System.Windows.Forms.CheckBox chkUseSSO;
        private System.Windows.Forms.Label lblPasswordFile;
        private System.Windows.Forms.TextBox txtPasswordFile;
        private System.Windows.Forms.Button btnClearPasswordFile;
        private System.Windows.Forms.Button btnBrowsePasswordFile;
        private System.Windows.Forms.Label lblPasswordFileWarning;
        private System.Windows.Forms.GroupBox grpBitwardenSession;
        private System.Windows.Forms.Label lblSessionTokenInfo;
        private System.Windows.Forms.Button btnClearToken;
        private System.Windows.Forms.GroupBox grpBitwardenActions;
        private System.Windows.Forms.Label lblActionStatus;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnOpenCredentials;
        private System.Windows.Forms.Button btnSyncVault;
    }
}
