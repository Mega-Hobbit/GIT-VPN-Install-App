using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VPN_Install_Application
{
    public partial class runVPNInstallers : Form
    {

        int looporder = 0;
        
        public runVPNInstallers(List<string> passed_list)
        {
            InitializeComponent();
            runInstaller(passed_list);
            next = passed_list;
            
        }

        public void runInstaller(List<string> install_list)
        {
            change_appstate(install_list[looporder]);
            looporder = looporder + 1;
        }

        public void change_appstate(string selected_conf)
        {

            using (StreamReader sr = new StreamReader(selected_conf))
            {

                while (sr.Peek() >= 0)
                {

                    string configstr;
                    string[] configArray;
                    configstr = sr.ReadLine();

                    configArray = configstr.Split(',');
                    string vpnconfigregion = configArray[0];
                    Debug.WriteLine(vpnconfigregion);

                    string vpninstallerfolder = vpnconfigregion + "\\installers\\";
                    Debug.WriteLine(vpninstallerfolder);

                    List<string> vpnsubdirs = Directory.GetDirectories(vpninstallerfolder, "*", SearchOption.AllDirectories).ToList();
                    Debug.WriteLine(vpnsubdirs[0]);

                    foreach (string item in vpnsubdirs)
                    {
                        using (StreamReader read = new StreamReader(item + "\\config.ini"))

                                {
                                    string str;
                                    string[] readArray;
                                    str = read.ReadLine();

                                    readArray = str.Split(',');
                                    installer = vpnsubdirs + "\\" + readArray[0];
                                    Debug.WriteLine("Install path " + vpnsubdirs +"\\" + installer);
                                    pictureBox2.Image = Image.FromFile(vpnsubdirs + "\\" + readArray[1]);
                                    Debug.WriteLine("Icon path " + vpnsubdirs +"\\" + readArray[1]);
                                    textBox1.Text = readArray[2];
                                }
                    }
                }
            }

        }


        //opens next form, hides this one

        private void btnSkip_Click(object sender, EventArgs e)
        {

            this.Close();
        }


        //Hides current form and opens previous form
        private void btnBack_Click(object sender, EventArgs e)
        {

        }


        private List<string> next;
        private string installer;

        //Opens installer form for this and hides current form

        private void btnNext_Click(object sender, EventArgs e)
        {
            {
                var process = Process.Start(installer);
                process.WaitForExit();
                runInstaller(next);
            }

        }
        

        private bool buttonWasClicked = false;

        //Hides this form, opens main form after dialog box yes. If no then do nothing.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainActivity MainScreen = new MainActivity();
            var CancelConfirm = MessageBox.Show("Cancel Installation", "Are you sure you want to cancel?", MessageBoxButtons.YesNo);
            if (CancelConfirm == DialogResult.No)
            {

            }
            if (CancelConfirm == DialogResult.Yes)

            {
                MainScreen.Show();
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
