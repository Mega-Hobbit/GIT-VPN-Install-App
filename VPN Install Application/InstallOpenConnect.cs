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
    public partial class InstallOpenConnect : Form
    {
        public InstallOpenConnect()
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
                this.Close();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            InstallingOpenConnect OpenConnectInstallEnabled = new InstallingOpenConnect(); 
            OpenConnectInstallEnabled.Show(); 


        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            GlobalProtectInstall formGlobalProtect = new GlobalProtectInstall(); //Change this
            formGlobalProtect.Show(); //Change this
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            KerioInstall formKerio = new KerioInstall();
            formKerio.Show();
        }
    }
}