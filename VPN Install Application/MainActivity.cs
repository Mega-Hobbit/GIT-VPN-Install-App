using System;
using System.Windows.Forms;




namespace VPN_Install_Application
{
    public partial class MainActivity : Form
    {
        int ExitStatus = 0;
        bool ANZ = false;
        bool NA = false;
        bool UK = false;
        bool EU = false;

        public MainActivity()
        {
            InitializeComponent();
            Install.Enabled = false;
        }

        private void Exit_Click(object sender, System.EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            ExitStatus = 1;
            this.Close();
        }

        public void Install_Click(object sender, System.EventArgs e)
        {
            
            ExeInstaller newExeInstaller = new ExeInstaller(ANZ, NA, UK, EU);
            ExitStatus = 1;
            newExeInstaller.Show();
            this.Hide();
            frmDecider FormDecider = new frmDecider(ANZ, NA, UK, EU);


        }

        private void MainActivity_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExitStatus == 1)
            {

            }
            if (ExitStatus == 0)
            {
                e.Cancel = true;
            }
        }

        public void InstallEnabled()
        {
            int InstallEnabled = 0;
            if (chkANZ.Checked == false && chkNA.Checked == false && chkUK.Checked == false && chkEU.Checked == false)
            {
                InstallEnabled = 0;
            }
            else InstallEnabled = 1;

            if (InstallEnabled == 1)
            {
                Install.Enabled = true;
            }
            else Install.Enabled = false;
        }

        private void chkANZ_CheckedChanged(object sender, EventArgs e)
        {
            InstallEnabled();
            if (chkANZ.Checked == true)
            {
                ANZ = true;
            }
            else ANZ = false;
        }

        private void chkNA_CheckedChanged(object sender, EventArgs e)
        {
            InstallEnabled();
            if (chkNA.Checked == true)
            {
                NA = true;
            }
            else NA = false;
        }

        private void chkUK_CheckedChanged(object sender, EventArgs e)
        {
            InstallEnabled();
            if (chkUK.Checked == true)
            {
                UK = true;
            }
            else UK = false;
        }

        private void chkEU_CheckedChanged(object sender, EventArgs e)
        {
            InstallEnabled();
            if (chkEU.Checked == true)
            {
                EU = true;
            }
            else EU = false;
        }
    }
}