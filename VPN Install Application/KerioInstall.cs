﻿using System;
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
    public partial class KerioInstall : Form
    {
        public KerioInstall()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //show install activated form and hide this one
            {
                this.Hide();
                InstallingKerio KerioInstallEnabled = new InstallingKerio();
                KerioInstallEnabled.Show();
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)

            //closes this form and opens the next installer
        {
            InstallOpenConnect formOpenConnect = new InstallOpenConnect(); 
            formOpenConnect.Show(); 
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)

            //quits installation
        {
            MainActivity MainMenu = new MainActivity();
            var CancelConfirm = MessageBox.Show("Cancel Installation", "Are you sure you want to cancel?", MessageBoxButtons.YesNo);
            if (CancelConfirm == DialogResult.Yes)
            {
                MainMenu.Show();
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            GlobalProtectInstall formGlobalProtect = new GlobalProtectInstall();
            formGlobalProtect.Show();
        }
    }
}