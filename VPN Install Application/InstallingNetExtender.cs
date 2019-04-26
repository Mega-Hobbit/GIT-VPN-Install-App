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
    public partial class InstallingNetExtender : Form
    {
        int ProcessQuit = 0;

        public InstallingNetExtender()
        {
            InitializeComponent();
        }

        private void InstallingNetExtender_Load(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();



            var process = Process.Start("C:\\RDP\\VPNInstallations\\NXSetupU.exe");
            Debug.WriteLine("Running Net Extender");


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
                Debug.WriteLine("Finished installing Net Extender. Returning to Installer");


            Instructions InstructionsForm = new Instructions(); 
            InstructionsForm.Show(); 
            this.Close();
        }

    }
}
