using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using KeePass.UI;
using log4net.Core;
using SeafClient;

namespace KeeAnywhere.StorageProviders.Seafile
{
    public partial class SeafileAccountForm : Form
    {
        public SeafileAccountForm()
        {
            InitializeComponent();            
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            GlobalWindowManager.AddWindow(this);

            this.Icon = PluginResources.Icon_Seafile_16x16;

            BannerFactory.CreateBannerEx(this, m_bannerImage,
                PluginResources.Seafile_48x48, "Authorize to a Seafile server",
                "Please enter your Seafile server account details.");

        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalWindowManager.RemoveWindow(this);
        }

        private async void OnTest(object sender, EventArgs e)
        {
            await TestConnection();
        }

        private async Task TestConnection()
        {
            if (this.TestResult != null) return;

            m_lblTestResult.Visible = true;

            if (string.IsNullOrEmpty(this.Server) ||string.IsNullOrEmpty(this.Username))
            {
                m_lblTestResult.Text = "Please enter server address and your username";
                return;
            }

            this.Enabled = false;
            m_lblTestResult.Text = "Testing Connection...";

            this.TestResult = null;
            
            try
            {
                var session = await SeafSession.Establish(new Uri(this.Server), this.Username, this.Password.ToCharArray());
                if (session != null)
                {
                    m_lblTestResult.Text = "Connection succeeded.";
                    this.TestResult = true;
                }
            }
            catch (Exception ex)
            {
                m_lblTestResult.Text = "Connection failed!";
                this.TestResult = false;
            }
            finally
            {
                this.Enabled = true;
            }
        }

        public void ClearTestResult()
        {
            if (this.TestResult == null) return;

            this.TestResult = null;
            m_lblTestResult.Text = null;
            m_lblTestResult.Visible = false;
        }

        public string Server { get { return m_txtServer.Text.Trim(); } }
        public string Username { get { return m_txtUsername.Text.Trim(); } }
        public string Password { get { return m_txtPassword.Text.Trim(); } }        

        protected bool? TestResult { get; set; }

        private void OnTextChanged(object sender, EventArgs e)
        {
            ClearTestResult();
        }


        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                return;

            if (this.TestResult == null || !this.TestResult.Value)
                e.Cancel = true;
        }

        private async void OnOk(object sender, EventArgs e)
        {
            await TestConnection();

            if (this.TestResult != null && this.TestResult.Value)
                this.DialogResult = DialogResult.OK;
        }
    }
}
