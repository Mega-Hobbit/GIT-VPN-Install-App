using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace VPN_Install_Application
{
    public partial class MainActivity : Form
    {
        string configpath = Path.GetDirectoryName(Application.ExecutablePath);
        string statefile = Path.GetFileName(Application.ExecutablePath + "\\state.temp") ;
        List<string> install_list = new List<string>();

        public MainActivity()
        {
            InitializeComponent();
            PopulateListBox(checkedListBox1, configpath , "*config.ini");
            if (File.Exists(statefile))
            {
                Debug.WriteLine("State file " + statefile + " detected, reloading state.");
                runVPNInstallers runNext = new runVPNInstallers(install_list, statefile);
                runNext.Show();
                this.WindowState = FormWindowState.Minimized;
            }
        }

    

    private void PopulateListBox(ListBox lsb, string Folder, string FileType)
    {
        DirectoryInfo dinfo = new DirectoryInfo(Folder);
        FileInfo[] Files = dinfo.GetFiles(FileType);
        foreach (FileInfo file in Files)
        {
            lsb.Items.Add(file.Name.Replace("config.ini", "").ToUpper());
        }
    }


    private void Exit_Click(object sender, System.EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        public void Install_Click(object sender, System.EventArgs e)
        {

            foreach(object checkeditems in checkedListBox1.CheckedItems)
            {
                install_list.Add(checkeditems.ToString() + "config.ini");
            }

            ExeInstaller newExeInstaller = new ExeInstaller(install_list, statefile);
            newExeInstaller.Show();
            this.Hide();
        }

        private void MainActivity_FormClosing(object sender, FormClosingEventArgs e)
        {
                e.Cancel = true;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("CheckBoxIndexChanged:" + checkedListBox1.CheckedIndices.Count);
            if (checkedListBox1.CheckedIndices.Count > 0)
            {
                Install.Enabled = true;
            }
            else { Install.Enabled = false; }
        }
    }
}