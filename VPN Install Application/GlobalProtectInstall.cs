using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VPN_Install_Application
{
    public partial class GlobalProtectInstall : Form
    {

        public GlobalProtectInstall()
        {
            InitializeComponent();


        }

        //opens next form, closes this one

        private void btnSkip_Click(object sender, EventArgs e)
        {
            KerioInstall formKeiroInstall = new KerioInstall();
            formKeiroInstall.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainActivity MainMenu = new MainActivity();
            var CancelConfirm = MessageBox.Show("Cancel Installation", "Are you sure you want to cancel?", MessageBoxButtons.YesNo);
            if (CancelConfirm == DialogResult.Yes)
            {
                MainMenu.Show();
                this.Close();
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            {
                this.Hide();
                InstallingGlobalProtect GlobalProtectInstallEnabled = new InstallingGlobalProtect();
                GlobalProtectInstallEnabled.Show();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstallFortiClient FortiClientForm = new InstallFortiClient();
            FortiClientForm.Show();
        }



        /* private void InstallerClosing(object sender, FormClosedEventArgs e)
         {
             MainActivity MainScreen = new MainActivity();
             if (string.Equals((sender as Button).Name, @"CloseButton"))
             {

                 if (MessageBox.Show("Are you sure you want to cancel the installation?", "Cancel Installation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                 {
                     MainScreen.Show();
                     this.Close();
                 }
                 else
                 {
                     MainScreen.Show();
                     this.Close();
                 }
             }
        }*/

    }
}
