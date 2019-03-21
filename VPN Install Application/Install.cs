using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VPN_Install_Application
{


    public partial class ExeInstaller : Form
    {
        DirectoryInfo Source;
        DirectoryInfo Target;
        DirectoryInfo Installers;

        Thread runWorkerThreadThead;

        public ExeInstaller()
        {
            InitializeComponent();



            using (StreamReader sr = new StreamReader("mtivpnconfig.ini"))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();

                    strArray = str.Split(',');
                    Source = new DirectoryInfo(strArray[0]);
                    Debug.WriteLine("Source Folder is set to " + Source);
                    Target = new DirectoryInfo(strArray[1]);
                    Debug.WriteLine("Target Folder is set to " + Target);
                    Installers = new DirectoryInfo(strArray[2]);
                    Debug.WriteLine("Installer Folder is set to " + Installers);
                }
            }

            runWorkerThreadThead = new Thread(() => WorkerThread());
            runWorkerThreadThead.IsBackground = true;
            runWorkerThreadThead.Start();
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            txtOutput.AppendText(value);
        }




        public void WorkerThread()
        {
            CopyFiles(Source,Target);
            RunInstallers();
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

                    foreach (FileInfo fi in filesource.GetFiles())
                    { 
                        Debug.WriteLine("Copying file: " + filetarget.FullName + fi.Name);

                        fi.CopyTo(Path.Combine(filetarget.FullName, fi.Name), true);
                        AppendTextBox("Copying file: " + filetarget.FullName + fi.Name + "\r\n");
                    }

                   

                }
            }
            catch (Exception)
            { }
        }

        public void RunInstallers()
        {
            //Read Installer files and run
            FileInfo[] InstallerFiles = Installers.GetFiles("*.exe");
            //string str = "";
            foreach (FileInfo file in InstallerFiles)
            {
                AppendTextBox("Running " + Installers + @"\" + file.Name);
                //str = str + ", " + file.Name;
                Debug.WriteLine("Running " + Installers + @"\" + file.Name);
                var process = Process.Start(Installers + @"\" + file.Name);
                while (!process.HasExited)
                {
                    Debug.WriteLine("Waiting: " + Installers + @"\" + file.Name);
                    //update UI
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to cancel the installation?", "Cancel Installation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
                runWorkerThreadThead.Abort();
                this.Close();
            }
        }
    }





