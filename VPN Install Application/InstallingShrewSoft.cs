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
    public partial class InstallingShrewSoft : Form
    {
        int ProcessQuit = 0;

        public InstallingShrewSoft()
        {
            InitializeComponent();
        }

        private void InstallingShrewSoft_Load(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();


            //Start Installer
            var process = Process.Start("C:\\RDP\\VPNInstallations\\vpn-client-2.2.2-release.exe");
            Debug.WriteLine("Running ShrewSoft");


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

            //Wait until ShrewSoft quits, then run Kill Installer
        }

        public void KillInstaller()
        {
            if (ProcessQuit == 1)
                Debug.WriteLine("Finished installing ShrewSoft. Returning to Installer");


            InstallOpenConnect formOpenConnect = new InstallOpenConnect(); //Change
            formOpenConnect.Show(); //change
            this.Close();
        }
    }
    
}
