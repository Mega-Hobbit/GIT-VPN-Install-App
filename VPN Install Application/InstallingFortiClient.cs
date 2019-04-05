using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPN_Install_Application
{
    public partial class InstallingFortiClient : Form
    {
        int ProcessQuit = 0;
        public InstallingFortiClient()
        {
            InitializeComponent();
        }

        public void InstallingFortiClient_Load(object sender, EventArgs e)
        {
            
            this.Show();
            this.BringToFront();

            
            
            var process = Process.Start("C:\\RDP\\VPNInstallations\\FortiClientOnlineInstaller_6.0.0.exe");
            Debug.WriteLine("Running Forticlient");


            do
            {
                if (!process.HasExited) { 
                    process.WaitForExit();

                }


            } while (!process.HasExited);

            process.WaitForExit();
            ProcessQuit = 1;
            KillInstaller();


        }

        public void KillInstaller()
        {
            if (ProcessQuit == 1)
            Debug.WriteLine("Finished installing Forticlient. Returning to Installer");


            GlobalProtectInstall InstallGlobalProtect = new GlobalProtectInstall();
            InstallGlobalProtect.Show();
            this.Close();
        }

    }
}
