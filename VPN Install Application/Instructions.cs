using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPN_Install_Application
{
    public partial class Instructions : Form
    {
        int ExitStatus = 0;
        int InstructionCount = 1;
        public Instructions()
        {
            InitializeComponent();
        }
       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainActivity MainMenu = new MainActivity();
            var CancelConfirm = MessageBox.Show("Cancel Installation", "Are you sure you want to cancel?", MessageBoxButtons.YesNo);
            if (CancelConfirm == DialogResult.Yes)
            {
                MainMenu.Show();
                ExitStatus = 1;
                this.Close();
            }
        }

        private void Instructions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExitStatus == 1)
            {

            }
            if (ExitStatus == 0)
            {
                e.Cancel = true;
            }
        }

        private void Instructions_Load(object sender, EventArgs e)
        {
            btnPrevious.Enabled = false;
            picInstructions.Image = Image.FromFile(@"Instructions\Step1.jpg");
        }

        private void ButtonEnabling()
        {
            if (InstructionCount > 1)
            {
                btnPrevious.Enabled = true;
            }
            else btnPrevious.Enabled = false;

            if (InstructionCount < 7)
            {
                btnNextInstruction.Enabled = true;
            }
            else btnNextInstruction.Enabled = false;

            if (InstructionCount == 7)
            {
                btnNextInstruction.Text = "Finish";
                btnNextInstruction.Enabled = true;
                btnCancel.Enabled = false;
            }
            else btnNextInstruction.Text = "Next Instruction";

        }

        public void btnNextInstruction_Click(object sender, EventArgs e)
        {

            InstructionCount = InstructionCount + 1;
            if (InstructionCount <= 7)
            {
                picInstructions.Image = Image.FromFile(@"Instructions\Step" + InstructionCount + ".jpg");
                picInstructions.Refresh();
                System.Diagnostics.Debug.WriteLine("Count= " + InstructionCount);
                ButtonEnabling();
            }
            else if (InstructionCount == 8)
            {
                Environment.Exit(Environment.ExitCode);
                ExitStatus = 1;
                this.Close();
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            InstructionCount = InstructionCount - 1;
            if (InstructionCount == 1)
            {
                picInstructions.Image = Image.FromFile(@"Instructions\Step1.jpg");
                picInstructions.Refresh();
                ButtonEnabling();
            }
            if (InstructionCount == 2)
            {
                picInstructions.Image = Image.FromFile(@"Instructions\Step2.jpg");
                picInstructions.Refresh();
                ButtonEnabling();
            }
            if (InstructionCount == 3)
            {
                picInstructions.Image = Image.FromFile(@"Instructions\Step3.jpg");
                picInstructions.Refresh();
                ButtonEnabling();
            }
            if (InstructionCount == 4)
            {
                picInstructions.Image = Image.FromFile(@"Instructions\Step4.jpg");
                picInstructions.Refresh();
                ButtonEnabling();
            }
            if (InstructionCount == 5)
            {
                picInstructions.Image = Image.FromFile(@"Instructions\Step5.jpg");
                picInstructions.Refresh();
                ButtonEnabling();
            }
            if (InstructionCount == 6)
            {
                picInstructions.Image = Image.FromFile(@"Instructions\Step6.jpg");
                picInstructions.Refresh();
                ButtonEnabling();
            }
        }
    }
}
