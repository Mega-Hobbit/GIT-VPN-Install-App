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
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        public void btnInstall_Clicked(object sender, EventArgs e)
        {

           
            frmInstaller newform = new frmInstaller();
            
            newform.Show();
            this.Hide();

        }
        private void btnQuit_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
