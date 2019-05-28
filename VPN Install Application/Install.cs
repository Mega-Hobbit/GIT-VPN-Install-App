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
                    Copy(items);
            }
            AppendTextBox("\r\nAll actions completed, click next to continue.");
        }

        public void Copy(string selecteditem)
        {
            AppendNextButton(false);

            try
            {
            using (StreamReader sr = new StreamReader(selecteditem))
            {

                while (sr.Peek() >= 0)
                {

                    string str;
                    string[] strArray;
                    str = sr.ReadLine();

                    strArray = str.Split(',');
                    Source = new DirectoryInfo(Environment.ExpandEnvironmentVariables(strArray[0]));
                    Debug.WriteLine("Source Folder is set to " + Source);
                    Target = new DirectoryInfo(Environment.ExpandEnvironmentVariables(strArray[1]));
                    Debug.WriteLine("Target Folder is set to " + Target);
                    Installers = new DirectoryInfo(Environment.ExpandEnvironmentVariables(strArray[2]));
                    Debug.WriteLine("Installer Folder is set to " + Installers);
                }


            }
                CopyFiles(Source, Target);
                AppendTextBox("\r\nRegion " + selecteditem + " copy completed. \r\n");
                AppendNextButton(true);
            }
                catch (Exception)
                    {
                        MessageBox.Show("There is a problem with the file or it does not exist. \r\n" + selecteditem, "Problem reading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        closeform(true);
                    }
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

        public void closeform(bool value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(closeform), new object[] { value });
                return;
            }

            if (value)
            {
                buttonWasClicked = true;
                MainActivity MainMenuForm = new MainActivity();
                MainMenuForm.Show();
                this.Close();
            } else {
                buttonWasClicked = true;
                runVPNInstallers runNext = new runVPNInstallers(pass_list, statefile);
                runNext.Show();
                this.Opacity = 0.0f;
                this.ShowInTaskbar = false;
            }
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
                    if (Containing.Contains(".txt") || Containing.Contains(".rdp") || Containing.Contains(".ps1") ||
                        Containing.Contains(".rcf") ||
                        Containing.Contains(".bat") || Containing.Contains(".lnk") || Containing.Contains(".pfx") ||
                        Containing.Contains(".TXT") || Containing.Contains(".RDP") || Containing.Contains(".PS1") ||
                        Containing.Contains(".BAT") || Containing.Contains(".LNK") || Containing.Contains(".PFX") ||
                        Containing.Contains(".RCF"))
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
                closeform(true);
            }
            }

        private List<string> pass_list;

        private void btnNext_Click(object sender2, EventArgs e)
        {
            closeform(false);
        }

        private void ExeInstaller_FormClosing(object sender, FormClosingEventArgs e)
        {
            CopyThread.Abort();
            if (!buttonWasClicked)
            { e.Cancel = true; }
        }
    }
}
    





