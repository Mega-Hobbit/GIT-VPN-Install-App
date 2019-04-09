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


        Thread runWorkerThreadThread;

        string CopyProgress = "0";

        bool ExitStatus = false;

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

            runWorkerThreadThread = new Thread(() => WorkerThread());
            runWorkerThreadThread.IsBackground = true;
            runWorkerThreadThread.Start();



            if(CopyProgress == "1")
            
                btnNext.Enabled = true;

            else btnNext.Enabled = false;

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
        public void EnableNext(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(EnableNext), new object[] { value });
                return;
            }
            txtOutput.Text = "Copying complete. Click Next to continue";
            btnNext.Enabled = true;
        }



        public void WorkerThread()
        {
            CopyFiles(Source,Target);          
            CopyProgress = "1";
                EnableNext(CopyProgress);

            
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
                    AppendTextBox("Copying file: " + filetarget.FullName + fi.Name + "\r\n");
                }
            }
            catch (Exception)
            { }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            var confirmResult = MessageBox.Show("Are you sure you want to cancel the installation?", "Cancel Installation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                runWorkerThreadThread.Abort();
                MainActivity MainMenuForm = new MainActivity();
                MainMenuForm.Show();
                runWorkerThreadThread.Abort();
                ExitStatus = true;
                this.Close();
            }
               
            }

        private void btnNext_Click(object sender, EventArgs e)
        {
            InstallFortiClient FortiClientForm = new InstallFortiClient();
            FortiClientForm.Show();
            ExitStatus = true;
            this.Close();
           
        }

        private void ExeInstaller_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExitStatus == true)
            {

            }
            if (ExitStatus == false)
            {
                e.Cancel = true;
            }
           
        }
    }


}
    





