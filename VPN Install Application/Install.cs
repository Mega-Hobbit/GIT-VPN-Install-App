using System;
using System.Collections.Generic;
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
        string statefile;

        Thread CopyThread;

        public ExeInstaller(List<string> install_list, string passed_statefile)
        {
            InitializeComponent();
            pass_list = install_list;
            statefile = passed_statefile;
            CopyThread = new Thread(() => checker(install_list)); CopyThread.IsBackground = true; CopyThread.Start();
        }

        public void checker(List<string> install_list)
        {
            foreach (string items in install_list)
            {
                try
                {
                    Copy(items);
                }
                catch (Exception) { }
            }

            AppendTextBox("\r\nCopying completed, click next to continue.");
            //if (ANZ) { Copy("anz"); }
            //if (NA) { Copy("na");}
            //if (UK) { Copy("uk");}
            //if (EU) { Copy("eu"); }
        }

        public void Copy(string selecteditem)
        {
            AppendNextButton(false);
            using (StreamReader sr = new StreamReader(selecteditem))
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
                CopyFiles(Source, Target);
                AppendTextBox("\r\nRegion " + selecteditem + " copy completed. \r\n");
                AppendNextButton(true);

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

        public void AppendNextButton(bool value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(AppendNextButton), new object[] { value });
                return;
            }

            if (value) { btnNext.Enabled = true;  } else { btnNext.Enabled = false; }

        }

        public void CopyFiles(DirectoryInfo filesource, DirectoryInfo filetarget)
        {
            try
            {
                Directory.CreateDirectory(filetarget.FullName);
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
                    if (Containing.Contains(".txt") || Containing.Contains(".rdp") || Containing.Contains(".TXT") || Containing.Contains(".RDP"))
                    {
                        Debug.WriteLine("Copying file: " + filetarget.FullName + fi.Name);
                        fi.CopyTo(Path.Combine(filetarget.FullName, fi.Name), true);
                        AppendTextBox("\r\nCopying file: " + filetarget.FullName + fi.Name + "\r\n");
                    }

                }
            }
            catch (Exception)
            { }
        }

        private bool buttonWasClicked = false;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to cancel the installation?", "Cancel Installation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                CopyThread.Abort();
                MainActivity MainMenuForm = new MainActivity();
                MainMenuForm.Show();
                buttonWasClicked = true;
                this.Close();
            }
            }

        private List<string> pass_list;

        private void btnNext_Click(object sender2, EventArgs e)
        {
             runVPNInstallers runNext = new runVPNInstallers(pass_list, statefile);
             runNext.Show();
            buttonWasClicked = true;
            this.Close(); 
        }

        private void ExeInstaller_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!buttonWasClicked)
            { e.Cancel = true; }
        }
    }


}
    





