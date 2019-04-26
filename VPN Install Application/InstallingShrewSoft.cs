using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPN_Install_Application
{
    public partial class InstallingShrewSoft : Form
    {
        int ProcessQuit = 0;

        DirectoryInfo Source;
        DirectoryInfo Target;


        Thread runWorkerThreadThread;

        public InstallingShrewSoft()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("shrewconfig.ini"))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();

                    strArray = str.Split(',');
                    Source = new DirectoryInfo(@"C:\RDP\VPNInstallations\sites");
                    //  Source = new DirectoryInfo(strArray[0]);
                    Debug.WriteLine("Source Folder is set to " + Source);
                    Target = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Shrew Soft VPN\sites");
                    // Target = new DirectoryInfo(strArray[1]);
                    Debug.WriteLine("Target Folder is set to " + Target);

                }
            }

            runWorkerThreadThread = new Thread(() => WorkerThread());
            runWorkerThreadThread.IsBackground = true;
            runWorkerThreadThread.Start();
        }

        public void WorkerThread()
        {
            CopyFiles(Source, Target);



            //RunInstallers();
        }

        public void CopyFiles(DirectoryInfo filesource, DirectoryInfo filetarget)
        {
            Directory.CreateDirectory(filetarget.FullName);

            try
            {
                //Copy files from Source Folder to Target
                foreach (DirectoryInfo diSourceSubDir in filesource.GetDirectories())
                {
                    Debug.WriteLine("Creating Directory: " + diSourceSubDir);

                    DirectoryInfo nextTargetSubDir =
                    filetarget.CreateSubdirectory(diSourceSubDir.Name);
                    CopyFiles(diSourceSubDir, nextTargetSubDir);
                }

                foreach (FileInfo fi in filesource.GetFiles())
                {
                    Debug.WriteLine("Copying file: " + filetarget.FullName + fi.Name);

                    fi.CopyTo(Path.Combine(filetarget.FullName, fi.Name), true);

                }
            }
            catch (Exception)
            { }
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


            InstallNetExtender formNetExtender = new InstallNetExtender(); 
            formNetExtender.Show();
            this.Close();
        }
    }
    
}
