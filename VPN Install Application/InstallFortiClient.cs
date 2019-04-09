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
    public partial class InstallFortiClient : Form
    {

        public InstallFortiClient()
        {
            InitializeComponent();


        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            GlobalProtectInstall formGlobalProtect = new GlobalProtectInstall();
            formGlobalProtect.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainActivity MainMenu = new MainActivity();
            var CancelConfirm = MessageBox.Show("Cancel Installation", "Are you sure you want to cancel?", MessageBoxButtons.YesNo);
            if (CancelConfirm == DialogResult.Yes)
            {
                MainMenu.Show();
                this.Hide();
            }
                
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstallingFortiClient FortiClientInstallEnabled = new InstallingFortiClient();
            FortiClientInstallEnabled.Show();


        }

        private void InstallFortiClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
