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
        int ExitStatus = 0;

        public GlobalProtectInstall()
        {
            InitializeComponent();
            

        }
        //ensures when user clicks X nothing happens
        private void GlobalProtectInstall_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExitStatus == 1)
            {

            }
            if (ExitStatus == 0)
            {
                e.Cancel = true;
            }

        }

        //opens next form, hides this one

        private void btnSkip_Click(object sender, EventArgs e)
        {
            KerioInstall formKeiroInstall = new KerioInstall();
            formKeiroInstall.Show();
            ExitStatus = 1;
            this.Close();
        }

        //Hides this form, opens main form after dialog box yes. If no then do nothing.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainActivity MainScreen = new MainActivity();
            var CancelConfirm = MessageBox.Show("Cancel Installation", "Are you sure you want to cancel?", MessageBoxButtons.YesNo);
            if (CancelConfirm == DialogResult.No)
            {
              
            }
            if (CancelConfirm == DialogResult.Yes)

            {
                MainScreen.Show();
                ExitStatus = 1;
                this.Close();
               
            }
        }
        //Opens installer form for this and hides current form
        private void btnNext_Click(object sender, EventArgs e)
        {
            {
                ExitStatus = 1;
                this.Close();
                InstallingGlobalProtect GlobalProtectInstallEnabled = new InstallingGlobalProtect();
                GlobalProtectInstallEnabled.Show();
            }

        }
        //Hides current form and opens previous form
        private void btnBack_Click(object sender, EventArgs e)
        {
            ExitStatus = 1;
            this.Close();
            InstallFortiClient FortiClientForm = new InstallFortiClient();
            FortiClientForm.Show();
        }

    }
}
