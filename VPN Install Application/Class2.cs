using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VPN_Install_Application
{
    using System;
    using System.IO;
    using System.Threading;
    class InstallVPN
    {

        public static void GlobalProtectInstall()
        {
            Process.Start("C:\\RDP\\CCN - Sydney\\VPN Client-winx64-msi-5.0.07.0290-k9\\GlobalProtect64.msi");
            frmInstaller InstallerForm = new frmInstaller();
            
        }

    }
}
