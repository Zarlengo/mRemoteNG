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
            btnCancel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label4 = new Label();
            bwAccessToken = new TextBox();
            label2 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            bwSync = new CheckBox();
            label5 = new Label();
            btnOK = new Button();
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
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Left;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(255, 48);
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
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(bwAccessToken, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(bwPassword, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(480, 133);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(5, 100);
            label4.Margin = new Padding(5);
            label4.Name = "label4";
            label4.Size = new Size(158, 28);
            label4.TabIndex = 6;
            label4.Text = "Bitwarden Access Token";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bwAccessToken
            // 
            bwAccessToken.Dock = DockStyle.Fill;
            bwAccessToken.Location = new Point(173, 105);
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
            label2.Text = "Enter one set of credentials";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 93F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 94F));
            tableLayoutPanel2.Controls.Add(bwSync, 2, 0);
            tableLayoutPanel2.Controls.Add(label5, 0, 0);
            tableLayoutPanel2.Controls.Add(btnOK, 1, 1);
            tableLayoutPanel2.Controls.Add(btnCancel, 3, 1);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(0, 140);
            tableLayoutPanel2.Margin = new Padding(4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel2.Size = new Size(480, 82);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // bwSync
            // 
            bwSync.AutoSize = true;
            bwSync.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bwSync.Location = new Point(233, 3);
            bwSync.Margin = new Padding(5, 3, 3, 3);
            bwSync.Name = "bwSync";
            bwSync.Size = new Size(15, 32);
            bwSync.TabIndex = 9;
            bwSync.Text = " ";
            bwSync.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(label5, 2);
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(5, 5);
            label5.Margin = new Padding(5);
            label5.Name = "label5";
            label5.Size = new Size(218, 28);
            label5.TabIndex = 8;
            label5.Text = "Sync on connection";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Right;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(136, 48);
            btnOK.Margin = new Padding(4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(88, 23);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // BWConnectionForm
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 222);
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
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox bwPassword;
        public System.Windows.Forms.TextBox bwAccessToken;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Button btnOK;
        public CheckBox bwSync;
        private Label label5;
    }
}