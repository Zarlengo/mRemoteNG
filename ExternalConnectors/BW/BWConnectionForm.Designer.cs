namespace ExternalConnectors.BW
{
    partial class BWConnectionForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BWConnectionForm));
            label3 = new Label();
            bwPassword = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label5 = new Label();
            label4 = new Label();
            bwAccessToken = new TextBox();
            label2 = new Label();
            label1 = new Label();
            bwSync = new CheckBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(5, 62);
            label3.Margin = new Padding(5);
            label3.Name = "label3";
            label3.Size = new Size(158, 28);
            label3.TabIndex = 0;
            label3.Text = "Bitwarden Login Password";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bwPassword
            // 
            bwPassword.Dock = DockStyle.Fill;
            bwPassword.Location = new Point(173, 67);
            bwPassword.Margin = new Padding(5, 10, 5, 5);
            bwPassword.Name = "bwPassword";
            bwPassword.Size = new Size(302, 23);
            bwPassword.TabIndex = 1;
            bwPassword.UseSystemPasswordChar = true;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Right;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(136, 10);
            btnOK.Margin = new Padding(4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(88, 23);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Left;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(255, 10);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(bwAccessToken, 1, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(bwPassword, 1, 1);
            tableLayoutPanel1.Controls.Add(bwSync, 1, 4);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.Size = new Size(480, 211);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(25, 183);
            label5.Margin = new Padding(25, 5, 5, 5);
            label5.Name = "label5";
            label5.Size = new Size(138, 28);
            label5.TabIndex = 7;
            label5.Text = "Sync on connection";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(25, 145);
            label4.Margin = new Padding(25, 5, 5, 5);
            label4.Name = "label4";
            label4.Size = new Size(138, 28);
            label4.TabIndex = 6;
            label4.Text = "Bitwarden Access Token";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bwAccessToken
            // 
            bwAccessToken.Dock = DockStyle.Fill;
            bwAccessToken.Location = new Point(173, 150);
            bwAccessToken.Margin = new Padding(5, 10, 5, 5);
            bwAccessToken.Name = "bwAccessToken";
            bwAccessToken.Size = new Size(302, 23);
            bwAccessToken.TabIndex = 2;
            bwAccessToken.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label2, 2);
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 5);
            label2.Margin = new Padding(5);
            label2.Name = "label2";
            label2.Size = new Size(470, 47);
            label2.TabIndex = 4;
            label2.Text = "Enter password or token";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label1, 2);
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(25, 100);
            label1.Margin = new Padding(25, 5, 5, 5);
            label1.Name = "label1";
            label1.Size = new Size(450, 35);
            label1.TabIndex = 3;
            label1.Text = "This is used to get an access token (bw login)\r\nThe access token is then saved in the registry.";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bwSync
            // 
            bwSync.AutoSize = true;
            bwSync.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bwSync.Location = new Point(171, 181);
            bwSync.Name = "bwSync";
            bwSync.Size = new Size(48, 32);
            bwSync.TabIndex = 8;
            bwSync.Text = " ";
            bwSync.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 93F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 94F));
            tableLayoutPanel2.Controls.Add(btnOK, 1, 0);
            tableLayoutPanel2.Controls.Add(btnCancel, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(0, 218);
            tableLayoutPanel2.Margin = new Padding(4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(480, 44);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // BWConnectionForm
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 262);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "BWConnectionForm";
            Text = "Bitwarden Login Data";
            Activated += BWConnectionForm_Activated;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox bwPassword;
        public System.Windows.Forms.TextBox bwAccessToken;
        public System.Windows.Forms.CheckBox bwSync;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}