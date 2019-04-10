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
    public partial class InstallShrewSoft : Form
    {
        int ExitStatus = 0;

        public InstallShrewSoft()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainActivity MainMenu = new MainActivity();
            var CancelConfirm = MessageBox.Show("Cancel Installation", "Are you sure you want to cancel?", MessageBoxButtons.YesNo);
            if (CancelConfirm == DialogResult.Yes)
            {
                MainMenu.Show();
                ExitStatus = 1;
                this.Close();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ExitStatus = 1;
            this.Close();
            InstallingShrewSoft ShrewSoftInstallEnabled = new InstallingShrewSoft();
            ShrewSoftInstallEnabled.Show();


        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            InstallNetExtender formNetExtender = new InstallNetExtender(); 
            formNetExtender.Show();
            ExitStatus = 1;
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ExitStatus = 1;
            this.Close();
            InstallOpenVPN formOpenVPN = new InstallOpenVPN();
            formOpenVPN.Show();
        }

        private void InstallOpenConnect_FormClosing(object sender, FormClosingEventArgs e)
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
