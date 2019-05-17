using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VPN_Install_Application
{
    public partial class Instructions : Form
    {
        int count = 0;
        List<string> imglist = new List<string>();

        public Instructions()
        {
            InitializeComponent();
            try
            {
                DirectoryInfo d = new DirectoryInfo(Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "\\Instructions\\"));
                FileInfo[] Files = d.GetFiles ("*.jpg");
                foreach (FileInfo file in Files)
                {
                    imglist.Add(d.ToString() + file);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Instructions folder not readable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainActivity MainMenu = new MainActivity();
            var CancelConfirm = MessageBox.Show("Cancel Installation", "Are you sure you want to cancel?", MessageBoxButtons.YesNo);
            if (CancelConfirm == DialogResult.Yes)
            {
                MainMenu.Show();
                buttonWasClicked = true;
                this.Close();
            }
        }


        private void Instructions_Load(object sender, EventArgs e)
        {
            btnPrevious.Enabled = false;
            picInstructions.Image = Image.FromFile(imglist[count].ToString());
            Debug.WriteLine("Count = " + count);
            
        }

        private void ButtonEnabling()
        {
            btnCancel.Enabled = true;
            if (count > 0)
            {
                btnPrevious.Enabled = true;
            }
            else btnPrevious.Enabled = false;

            if (count < imglist.Count -1)
            {
                btnNextInstruction.Enabled = true;
            }
            else btnNextInstruction.Enabled = false;

            if (count == imglist.Count -1)
            {
                btnNextInstruction.Text = "Finish";
                btnNextInstruction.Enabled = true;
                btnCancel.Enabled = false;
            }
            else btnNextInstruction.Text = "Next Instruction";

        }

        public void btnNextInstruction_Click(object sender, EventArgs e)
        {
            if (count < imglist.Count -1)
            {
                count = count + 1;
                picInstructions.Image = Image.FromFile(imglist[count].ToString());
                picInstructions.Refresh();
                Debug.WriteLine("Count = " + count);
                
            }
            else
            {
                Environment.Exit(Environment.ExitCode);
                buttonWasClicked = true;
                this.Close();
            }
            ButtonEnabling();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count = count - 1;
                picInstructions.Image = Image.FromFile(imglist[count].ToString());
                picInstructions.Refresh();
                Debug.WriteLine("Count = " + count);
            }
            ButtonEnabling();
        }


        bool buttonWasClicked = false;
        private void Instructions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!buttonWasClicked)
            { e.Cancel = true; }
        }

    }
}
