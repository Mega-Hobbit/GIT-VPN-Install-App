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
    public partial class InstallingOpenConnect : Form
    {

        int ProcessQuit = 0;
        public InstallingOpenConnect()
        {
            InitializeComponent();
        }

        private void InstallingOpenConnect_Load(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();



            var process = Process.Start("C:\\RDP\\VPNInstallations\\openconnect-gui-1.5.3-win64.exe");
            Debug.WriteLine("Running Forticlient");


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


        }





        public void KillInstaller()
        {
            if (ProcessQuit == 1)
                Debug.WriteLine("Finished installing Forticlient. Returning to Installer");


            InstallOpenConnect InstallOpenConnectForm = new InstallOpenConnect(); //Change this
            InstallOpenConnectForm.Show(); //Change this
            this.Close();
        }
    }
}
