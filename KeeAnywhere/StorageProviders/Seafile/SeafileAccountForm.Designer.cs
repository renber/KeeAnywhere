namespace KeeAnywhere.StorageProviders.Seafile
{
    partial class SeafileAccountForm
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
            this.m_bannerImage = new System.Windows.Forms.PictureBox();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_lblServer = new System.Windows.Forms.Label();
            this.m_txtServer = new System.Windows.Forms.TextBox();
            this.m_lblUsername = new System.Windows.Forms.Label();
            this.m_txtUsername = new System.Windows.Forms.TextBox();
            this.m_lblPassword = new System.Windows.Forms.Label();
            this.m_btnTest = new System.Windows.Forms.Button();
            this.m_lblTestResult = new System.Windows.Forms.Label();
            this.m_txtPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_bannerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // m_bannerImage
            // 
            this.m_bannerImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_bannerImage.Location = new System.Drawing.Point(0, 0);
            this.m_bannerImage.Name = "m_bannerImage";
            this.m_bannerImage.Size = new System.Drawing.Size(354, 60);
            this.m_bannerImage.TabIndex = 5;
            this.m_bannerImage.TabStop = false;
            // 
            // m_btnOK
            // 
            this.m_btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnOK.Location = new System.Drawing.Point(186, 170);
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.Size = new System.Drawing.Size(75, 23);
            this.m_btnOK.TabIndex = 6;
            this.m_btnOK.Text = "OK";
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.OnOk);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Location = new System.Drawing.Point(267, 170);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.m_btnCancel.TabIndex = 7;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_lblServer
            // 
            this.m_lblServer.AutoSize = true;
            this.m_lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblServer.Location = new System.Drawing.Point(12, 69);
            this.m_lblServer.Name = "m_lblServer";
            this.m_lblServer.Size = new System.Drawing.Size(92, 13);
            this.m_lblServer.TabIndex = 0;
            this.m_lblServer.Text = "Server address";
            // 
            // m_txtServer
            // 
            this.m_txtServer.Location = new System.Drawing.Point(135, 66);
            this.m_txtServer.Name = "m_txtServer";
            this.m_txtServer.Size = new System.Drawing.Size(207, 20);
            this.m_txtServer.TabIndex = 1;
            this.m_txtServer.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // m_lblUsername
            // 
            this.m_lblUsername.AutoSize = true;
            this.m_lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblUsername.Location = new System.Drawing.Point(12, 95);
            this.m_lblUsername.Name = "m_lblUsername";
            this.m_lblUsername.Size = new System.Drawing.Size(63, 13);
            this.m_lblUsername.TabIndex = 2;
            this.m_lblUsername.Text = "Username";
            // 
            // m_txtUsername
            // 
            this.m_txtUsername.Location = new System.Drawing.Point(135, 92);
            this.m_txtUsername.Name = "m_txtUsername";
            this.m_txtUsername.Size = new System.Drawing.Size(207, 20);
            this.m_txtUsername.TabIndex = 3;
            this.m_txtUsername.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // m_lblPassword
            // 
            this.m_lblPassword.AutoSize = true;
            this.m_lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblPassword.Location = new System.Drawing.Point(12, 122);
            this.m_lblPassword.Name = "m_lblPassword";
            this.m_lblPassword.Size = new System.Drawing.Size(61, 13);
            this.m_lblPassword.TabIndex = 4;
            this.m_lblPassword.Text = "Password";
            // 
            // m_btnTest
            // 
            this.m_btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnTest.Location = new System.Drawing.Point(12, 170);
            this.m_btnTest.Name = "m_btnTest";
            this.m_btnTest.Size = new System.Drawing.Size(75, 23);
            this.m_btnTest.TabIndex = 5;
            this.m_btnTest.Text = "&Test";
            this.m_btnTest.UseVisualStyleBackColor = true;
            this.m_btnTest.Click += new System.EventHandler(this.OnTest);
            // 
            // m_lblTestResult
            // 
            this.m_lblTestResult.Location = new System.Drawing.Point(12, 143);
            this.m_lblTestResult.Name = "m_lblTestResult";
            this.m_lblTestResult.Size = new System.Drawing.Size(330, 24);
            this.m_lblTestResult.TabIndex = 9;
            this.m_lblTestResult.Text = "TestResult";
            this.m_lblTestResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblTestResult.Visible = false;
            // 
            // m_txtPassword
            // 
            this.m_txtPassword.Location = new System.Drawing.Point(135, 119);
            this.m_txtPassword.Name = "m_txtPassword";
            this.m_txtPassword.PasswordChar = '*';
            this.m_txtPassword.Size = new System.Drawing.Size(207, 20);
            this.m_txtPassword.TabIndex = 4;
            // 
            // SeafileAccountForm
            // 
            this.AcceptButton = this.m_btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 205);
            this.Controls.Add(this.m_txtPassword);
            this.Controls.Add(this.m_lblTestResult);
            this.Controls.Add(this.m_btnTest);
            this.Controls.Add(this.m_lblPassword);
            this.Controls.Add(this.m_txtUsername);
            this.Controls.Add(this.m_lblUsername);
            this.Controls.Add(this.m_txtServer);
            this.Controls.Add(this.m_lblServer);
            this.Controls.Add(this.m_btnOK);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_bannerImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeafileAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seafile Account Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.m_bannerImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_bannerImage;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Label m_lblServer;
        private System.Windows.Forms.TextBox m_txtServer;
        private System.Windows.Forms.Label m_lblUsername;
        private System.Windows.Forms.TextBox m_txtUsername;
        private System.Windows.Forms.Label m_lblPassword;
        private System.Windows.Forms.Button m_btnTest;
        private System.Windows.Forms.Label m_lblTestResult;
        private System.Windows.Forms.TextBox m_txtPassword;
    }
}