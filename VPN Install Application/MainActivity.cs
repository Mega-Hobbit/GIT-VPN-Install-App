using System.Windows.Forms;




namespace VPN_Install_Application
{
    public partial class MainActivity : Form
    {

        public MainActivity()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void Install_Click(object sender, System.EventArgs e)
        {
            ExeInstaller newExeInstaller = new ExeInstaller();
            newExeInstaller.Show();
        }
    }
}