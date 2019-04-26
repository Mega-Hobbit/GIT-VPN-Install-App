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
    public partial class InstallNetExtender : Form
    {
        int ExitStatus = 0;

        public InstallNetExtender()
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
            InstallingNetExtender NetExtenderInstallEnabled = new InstallingNetExtender();
            NetExtenderInstallEnabled.Show();


        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            Instructions InstructionsForm = new Instructions();
            InstructionsForm.Show();
            ExitStatus = 1;
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ExitStatus = 1;
            this.Close();
            InstallShrewSoft formShrewSoft = new InstallShrewSoft();
            formShrewSoft.Show();
        }

        private void InstallNetExtender_FormClosing(object sender, FormClosingEventArgs e)
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
