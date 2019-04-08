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
    public partial class InstallingKerio : Form
    {

        int ProcessQuit = 0;
        public InstallingKerio()
        {
            InitializeComponent();
        }

        private void InstallingKerio_Load(object sender, EventArgs e)
        {
            {
                this.Show();
                this.BringToFront();


                //Start Kerio
                var process = Process.Start("C:\\RDP\\VPNInstallations\\kerio-control-vpnclient-9.2.7-2921-win64.exe");
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

                //Wait until Kerio quits, then run Kill Installer
            }



        }
        //Kills current form and shows next one
            public void KillInstaller()
            {
                if (ProcessQuit == 1)
                    Debug.WriteLine("Finished installing Forticlient. Returning to Installer");


                InstallOpenConnect formOpenConnect = new InstallOpenConnect();
                formOpenConnect.Show(); //change
                this.Close();
            }
        
    }
}
