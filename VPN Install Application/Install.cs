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

        public ExeInstaller()
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader(@"C:\mtivpnconfig.ini"))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();

                    strArray = str.Split(',');
                    Source = new DirectoryInfo(strArray[0]);
                    Debug.WriteLine("Original Folder is set to " + Source);
                    Target = new DirectoryInfo(strArray[1]);
                    Debug.WriteLine("Final Folder is set to " + Target);
                }
            }

            Thread CopyThead = new Thread(() => Copyfiles(Source,Target));
            CopyThead.IsBackground = true;
            CopyThead.Start();
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




        public void Copyfiles(DirectoryInfo filesource, DirectoryInfo filetarget)
        {
            Directory.CreateDirectory(filetarget.FullName);

            try
            {
                foreach (DirectoryInfo diSourceSubDir in filesource.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir =
                    filetarget.CreateSubdirectory(diSourceSubDir.Name);
                    Copyfiles(diSourceSubDir, nextTargetSubDir);
                    
                foreach (FileInfo fi in filesource.GetFiles())
                {
                    string CopyLine1 = @"Copying: ";
                    string CopyLine2 = filetarget.FullName;
                    string CopyLine3 = fi.Name;

                    Debug.WriteLine(CopyLine1, CopyLine2, CopyLine3);

                    fi.CopyTo(Path.Combine(filetarget.FullName, fi.Name), true);

                    string CopyLineFull = CopyLine1 + CopyLine2 + CopyLine3;

                        Debug.WriteLine("\r\nLog Entry : ");
                        Debug.WriteLine(CopyLine1 + CopyLine2 + CopyLine3);
                    AppendTextBox(CopyLine1 + CopyLine2 + CopyLine3 + "\r\n");
                        }
                    }
            }
            catch (Exception)
            {}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to cancel the installation?", "Cancel Installation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }


}





