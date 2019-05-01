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
        List<string> list;
        int installer_order = 0;
        int config_order = 0;
        
        
        public runVPNInstallers(List<string> passed_list)
        {
            InitializeComponent();
            list = passed_list;
            goNext();
        }

        public void goNext()
        {
            if (installer_order > 0)
            {
                btnBack.Enabled = true;
            }
            change_appstate(list[config_order]);
        }

        public void change_appstate(string selected_conf)
        {

            using (StreamReader sr = new StreamReader(selected_conf))
            {
                try
                {
                        string configstr;
                        string[] configArray;
                        configstr = sr.ReadLine();

                        configArray = configstr.Split(',');
                        string vpnconfigregion = configArray[0];
                        Debug.WriteLine(vpnconfigregion);

                        string vpninstallerfolder = vpnconfigregion + "\\installers\\";
                        Debug.WriteLine(vpninstallerfolder);

                        //List<string> vpnsubdirs = Directory.GetDirectories(vpninstallerfolder, "*", SearchOption.AllDirectories).ToList();

                        string[] vpnsubdirs = Directory.GetDirectories("C:\\Users\\Wilfred\\Desktop\\test", "*", System.IO.SearchOption.AllDirectories);
                        Debug.WriteLine(vpnsubdirs[0]);

                            using (StreamReader read = new StreamReader(vpnsubdirs[installer_order] + "\\config.ini"))

                            {
                                string str;
                                string[] readArray;
                                str = read.ReadLine();

                                readArray = str.Split(',');
                                installer = vpnsubdirs[installer_order] + "\\" + readArray[0];
                                pictureBox2.Image = Image.FromFile(vpnsubdirs[installer_order] + "\\" + readArray[1]);
                                
                                textBox1.Text = readArray[2];
                            }

                    length = vpnsubdirs.Length;
                    if (installer_order >= vpnsubdirs.Length)
                    {
                            config_order = config_order + 1;
                            installer_order = 0;
                    }
                }
                catch (Exception) {
                    Instructions inst = new Instructions();
                    inst.Show();
                    buttonWasClicked = true;
                    this.Close();
                }

                
                
            }

        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            installer_order = installer_order + 1;
            {
                try
                {
                    goNext();
                }
                catch (Exception)
                {
                    Instructions inst = new Instructions();
                    inst.Show();
                    buttonWasClicked = true;
                    this.Close();
                }
            }
        }

        private int length;
        private void btnBack_Click(object sender, EventArgs e)
        {
            installer_order = installer_order - 1;

            if (installer_order == 0)
            {
                if (config_order > 0)
                {
                    config_order = config_order - 1;
                    installer_order = length;
                    goNext();
                }
                else
                {
                    btnBack.Enabled = false;
                    goNext();
                }
            } else { 
                installer_order = installer_order - 1;
                goNext();
            }


        }


        
        private string installer;

        //Opens installer form for this and hides current form

        private void btnNext_Click(object sender, EventArgs e)
        {
            installer_order = installer_order + 1;
                    try { 
                    var process = Process.Start(installer);
                    this.Hide();
                    process.WaitForExit();
                    this.Show();
                    goNext();
                } catch (Exception)
                    { }

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
