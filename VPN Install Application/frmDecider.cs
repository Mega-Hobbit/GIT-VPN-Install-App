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
    public partial class frmDecider : Form
    {
        public frmDecider(bool ANZ, bool UK, bool NA, bool EU)
        {
            InitializeComponent();

            if (ANZ)
            {
                InstallFortiClient FortiClientForm = new InstallFortiClient();
                FortiClientForm.Show();
                this.Close();
            }
            else if (UK)
            {

            }
            else if (NA)
            {

            }
            else if (EU)
            {

            }
        }
    }
}
