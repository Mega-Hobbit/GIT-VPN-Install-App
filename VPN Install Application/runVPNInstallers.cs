using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace VPN_Install_Application
{
    public partial class runVPNInstallers : Form
    {
        List<string> list;
        int installer_order = 0;
        int config_order = 0;
        int installerlength;
        int configlength;
        string[] vpnsubdirs;
        string statefile;

        public runVPNInstallers(List<string> passed_list, string passed_statefile)
        {
            InitializeComponent();
            list = passed_list;
            statefile = passed_statefile;

            if (File.Exists(statefile))
            {
                using (StreamReader sr = new StreamReader(statefile))
                {
                    string[] stateArray;
                    string statestr = sr.ReadToEnd();
                    Debug.WriteLine(statestr);
                    stateArray = statestr.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    installer_order = Convert.ToInt32(stateArray[0]);
                    config_order = Convert.ToInt32(stateArray[1]);
                    installerlength = Convert.ToInt32(stateArray[2]);
                    configlength = Convert.ToInt32(stateArray[3]);
                    list = stateArray[4].Split(',').ToList();
                    vpnsubdirs = stateArray[5].Split(',');
                }
                File.Delete(statefile);

                var rWrite = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);
                rWrite.DeleteValue("mtivpninstaller");
                File.Delete(statefile);

                change_appstate();
                nextCounter();
                readConfig();
            }
            else
            {
                change_appstate();
                readConfig();
            }

        }

        public void change_appstate()
        {
            string selected_conf = list[config_order];

            using (StreamReader sr = new StreamReader(selected_conf))
            {
                string[] configArray;
                string configstr = sr.ReadLine();

                configArray = configstr.Split(',');
                string vpnconfigregion = configArray[0];
                Debug.WriteLine(vpnconfigregion);

                string vpninstallerfolder = vpnconfigregion + "\\installers\\";
                Debug.WriteLine(vpninstallerfolder);

                vpnsubdirs = Directory.GetDirectories(vpninstallerfolder, "*", System.IO.SearchOption.AllDirectories);

                installerlength = vpnsubdirs.Length - 1;
                configlength = list.Count - 1;
            }
        }
    

        public void readConfig()
        {
            Debug.WriteLine("Reading config: " + vpnsubdirs[installer_order] + "\\config.ini");
            Debug.WriteLine("Page " + installer_order + " of " + config_order);

            if (File.Exists(vpnsubdirs[installer_order] + "\\config.ini"))
            {
                using (StreamReader read = new StreamReader(vpnsubdirs[installer_order] + "\\config.ini"))

                {
                    string str;
                    string[] readArray;
                    str = read.ReadLine();

                    readArray = str.Split('|');
                    installer = vpnsubdirs[installer_order] + "\\" + readArray[0];
                    pictureBox2.Image = Image.FromFile(vpnsubdirs[installer_order] + "\\" + readArray[1]);

                    textBox1.Text = readArray[2];
                }
            }

            if (installer_order == 0 && config_order == 0)
            { btnBack.Enabled = false; }
            else { btnBack.Enabled = true; }
        }

        public void nextCounter()
        {
            if (config_order <= configlength  && installer_order < installerlength)
            {
                installer_order = installer_order + 1;
                while (!File.Exists(vpnsubdirs[installer_order] + "\\config.ini"))
                {
                    if (installer_order < installerlength)
                    {
                        installer_order = installer_order + 1;
                    }
                    else
                    {
                        config_order = config_order + 1;
                        installer_order = 0;
                        change_appstate();
                    }
                }
            }
            else if (config_order < configlength)
            {
                config_order = config_order + 1;
                installer_order = 0;
                change_appstate();
            }
            else
            {
                Instructions inst = new Instructions();
                inst.Show();
                buttonWasClicked = true;
                this.Hide();
            }
            Debug.WriteLine("nextcounter " + config_order + " of " + configlength);
        }

        private string installer;


        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                var process = Process.Start(installer);
                string liststring = string.Join(",", list.ToArray());
                string vpnsubdirsString = string.Join(",", vpnsubdirs.ToArray());
                string[] state = {installer_order.ToString(),config_order.ToString(),installerlength.ToString(),configlength.ToString(), liststring, vpnsubdirsString};

                File.WriteAllLines(statefile, state);

                //Task scheduler will be coded here
                var rWrite = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);

                rWrite.SetValue("mtivpninstaller", Path.GetFullPath(Application.ExecutablePath));

                this.Hide();
                process.WaitForExit();
                File.Delete(statefile);
                rWrite.DeleteValue("mtivpninstaller");
                this.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to run" + installer);
            }

            change_appstate();
            nextCounter();
            readConfig();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            change_appstate();
            nextCounter();
            readConfig();
            }


        private void btnBack_Click(object sender, EventArgs e)
        {
            if (installer_order > 0)
            {installer_order = installer_order - 1;}
            else
            {
                if (config_order > 0)
                {
                    config_order = config_order - 1;
                    change_appstate();
                    installer_order = installerlength;
                }
                else
                {
                    btnBack.Enabled = false;
                }
            }


            while (!File.Exists(vpnsubdirs[installer_order] + "\\config.ini"))
            {
                if(installer_order >= 0)
                {installer_order = installer_order - 1;}
            else
            {
                    if (config_order > 0)
                    {
                        change_appstate();
                        config_order = config_order - 1;
                        installer_order = installerlength;
                    }
                }
            }
            change_appstate();
            readConfig();
        }
    

        

        private bool buttonWasClicked = false;

        //Hides this form, opens main form after dialog box yes. If no then do nothing.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to cancel the installation?", "Cancel Installation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                MainActivity MainMenuForm = new MainActivity();
                MainMenuForm.Show();
                buttonWasClicked = true;
                this.Close();
            }
        }

        //ensures when user clicks X nothing happens
        private void runVPNnstall_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!buttonWasClicked)
            { e.Cancel = true; }
        }
    }
}
