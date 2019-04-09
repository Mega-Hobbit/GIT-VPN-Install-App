using System;
using System.Windows.Forms;




namespace VPN_Install_Application
{
    public partial class MainActivity : Form
    {
        int ExitStatus = 0;

        public MainActivity()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, System.EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            ExitStatus = 1;
            this.Close();
        }

        private void Install_Click(object sender, System.EventArgs e)
        {
            ExeInstaller newExeInstaller = new ExeInstaller();
            ExitStatus = 1;
            newExeInstaller.Show();
            this.Hide();
            
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
    }
}