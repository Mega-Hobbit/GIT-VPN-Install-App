using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPN_Install_Application
{
    public partial class InstallingOpenVPN : Form
    {
        int ProcessQuit = 0;

        public InstallingOpenVPN()
        {
            InitializeComponent();
        }

        private void InstallingOpenVPN_Load(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();


            //Start Installer
            var process = Process.Start("C:\\RDP\\VPNInstallations\\openvpn-install-2.4.6-I602.exe");
            Debug.WriteLine("Running OpenVPN");


            do
            {
                if (!process.HasExited)
                {
                    process.WaitForExit();

                }


            } while (!process.HasExited);

            process.WaitForExit();
            ProcessQuit = 1;
            KillInstaller();

            //Wait until OpenVPN quits, then run Kill Installer
        }

        public void KillInstaller()
        {
            if (ProcessQuit == 1)
                Debug.WriteLine("Finished installing OpenVPN. Returning to Installer");


            InstallShrewSoft formShrewSoft = new InstallShrewSoft(); 
            formShrewSoft.Show(); 
            this.Close();
        }
    }
}
