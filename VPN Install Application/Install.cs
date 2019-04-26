using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
//using System.Globalization.Culture;

namespace VPN_Install_Application
{
    

    public partial class ExeInstaller : Form
    {
        //ANZ
        DirectoryInfo SourceANZ;
        DirectoryInfo TargetANZ;
        DirectoryInfo InstallersANZ;
        //NA
        DirectoryInfo SourceNA;
        DirectoryInfo TargetNA;
        DirectoryInfo InstallersNA;
        //UK
        DirectoryInfo SourceUK;
        DirectoryInfo TargetUK;
        DirectoryInfo InstallersUK;
        //EU
        DirectoryInfo SourceEU;
        DirectoryInfo TargetEU;
        DirectoryInfo InstallersEU;


        Thread runWorkerThreadThread;

        string CopyProgress = "0";

        bool ExitStatus = false;

        public ExeInstaller(bool ANZ, bool NA, bool UK, bool EU)
        {
            InitializeComponent();

           if (ANZ)
            {
                using (StreamReader sr = new StreamReader("anzconfig.ini"))
                {
                    while (sr.Peek() >= 0)
                    {

                        string str;
                        string[] strArray;
                        str = sr.ReadLine();

                        strArray = str.Split(',');
                        SourceANZ = new DirectoryInfo(strArray[0]);
                        Debug.WriteLine("Source Folder is set to " + SourceANZ);
                        TargetANZ = new DirectoryInfo(strArray[1]);
                        Debug.WriteLine("Target Folder is set to " + TargetANZ);
                        InstallersANZ = new DirectoryInfo(strArray[2]);
                        Debug.WriteLine("Installer Folder is set to " + InstallersANZ);
                    }
                }
            }
           if (NA)
            {
                using (StreamReader sr = new StreamReader("naconfig.ini"))
                {
                    while (sr.Peek() >= 0)
                    {

                        string str;
                        string[] strArray;
                        str = sr.ReadLine();

                        strArray = str.Split(',');
                        SourceNA = new DirectoryInfo(strArray[0]);
                        Debug.WriteLine("Source Folder is set to " + SourceNA);
                        TargetNA = new DirectoryInfo(strArray[1]);
                        Debug.WriteLine("Target Folder is set to " + TargetNA);
                        InstallersNA = new DirectoryInfo(strArray[2]);
                        Debug.WriteLine("Installer Folder is set to " + InstallersNA);
                    }
                }
            }
           if (UK)
            {
                using (StreamReader sr = new StreamReader("ukconfig.ini"))
                {
                    while (sr.Peek() >= 0)
                    {

                        string str;
                        string[] strArray;
                        str = sr.ReadLine();

                        strArray = str.Split(',');
                        SourceUK = new DirectoryInfo(strArray[0]);
                        Debug.WriteLine("Source Folder is set to " + SourceUK);
                        TargetUK = new DirectoryInfo(strArray[1]);
                        Debug.WriteLine("Target Folder is set to " + TargetUK);
                        InstallersUK = new DirectoryInfo(strArray[2]);
                        Debug.WriteLine("Installer Folder is set to " + InstallersUK);
                    }
                }
            }
            if (EU)
            {
                using (StreamReader sr = new StreamReader("euconfig.ini"))
                {
                    while (sr.Peek() >= 0)
                    {

                        string str;
                        string[] strArray;
                        str = sr.ReadLine();

                        strArray = str.Split(',');
                        SourceEU = new DirectoryInfo(strArray[0]);
                        Debug.WriteLine("Source Folder is set to " + SourceEU);
                        TargetEU = new DirectoryInfo(strArray[1]);
                        Debug.WriteLine("Target Folder is set to " + TargetEU);
                        InstallersEU = new DirectoryInfo(strArray[2]);
                        Debug.WriteLine("Installer Folder is set to " + InstallersEU);
                    }
                }
            }


            runWorkerThreadThread = new Thread(() => WorkerThread(ANZ, NA, UK, EU));
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



        public void WorkerThread(bool ANZ, bool NA, bool UK, bool EU)
        {
            
            if (ANZ)
            {
                CopyFiles(SourceANZ, TargetANZ);
                CopyProgress = "1";
                EnableNext(CopyProgress);
                
            }
            if (NA)
            {
                CopyFiles(SourceNA, TargetNA);
                CopyProgress = "1";
                EnableNext(CopyProgress);
               
            }
            if (UK)
            {
                CopyFiles(SourceUK, TargetUK);
                CopyProgress = "1";
                EnableNext(CopyProgress);
                
            }
            if (EU)
            {
                CopyFiles(SourceEU, TargetEU);
                CopyProgress = "1";
                EnableNext(CopyProgress);
                
            }


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

                    string Containing = fi.FullName;
                    if (Containing.Contains(".txt"))
                   // culture.CompareInfo.IndexOf(paragraph, word, CompareOptions.IgnoreCase) >= 0
                    {
                        Debug.WriteLine("Copying file: " + filetarget.FullName + fi.Name);
                        fi.CopyTo(Path.Combine(filetarget.FullName, fi.Name), true);
                        AppendTextBox("Copying file: " + filetarget.FullName + fi.Name + "\r\n");
                    }
                    if (Containing.Contains(".rdp"))
                    {
                        Debug.WriteLine("Copying file: " + filetarget.FullName + fi.Name);
                        fi.CopyTo(Path.Combine(filetarget.FullName, fi.Name), true);
                        AppendTextBox("Copying file: " + filetarget.FullName + fi.Name + "\r\n");
                    }
                    if (Containing.Contains(".TXT"))  
                    {
                        Debug.WriteLine("Copying file: " + filetarget.FullName + fi.Name);
                        fi.CopyTo(Path.Combine(filetarget.FullName, fi.Name), true);
                        AppendTextBox("Copying file: " + filetarget.FullName + fi.Name + "\r\n");
                    }
                    if (Containing.Contains(".RDP"))
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




        private void btnNext_Click(object sender2, EventArgs e2)
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
    





