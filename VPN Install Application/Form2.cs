using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Timers;
namespace VPN_Install_Application
{
    

    public partial class frmInstaller : Form
    {
   

    
      


      
        CopyRDP CopyPaste = new CopyRDP();

       
        public frmInstaller()
        {

            InitializeComponent();
        }

        public void frmInstaller_Load(object sender, EventArgs e)
        {

            
            Thread CopyRDPFolder = new Thread(new ThreadStart(CopyRDP.Copy))
            {
                IsBackground = true

            };
            CopyRDPFolder.Start();
          
            Thread WriteToTxtBox = new Thread(new ThreadStart(CopyRDP.WriteToTxtBox));

            



            }
        public void UpdateStatusTextBox(string text)
        {
            TextReader tr = new StreamReader("log.txt");
            txtOutput.Text = tr.ReadLine();
        }
            

            //Thread InstallGlobalProtect = new Thread(new ThreadStart(CopyRDP.GlobalProtectInstall))
            //{
            //    IsBackground = true
            //};
            // InstallGlobalProtect.Start();





        


       

        public void btnCancel_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to cancel the installation?", "Cancel Installation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        void Read(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new EventHandler(Read), new object[2] { sender, e });
            else
            {
                txtOutput.Text = "Wuddup Homie";
            }
        }

    
    }
}





