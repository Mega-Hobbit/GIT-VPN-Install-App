using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

namespace VPN_Install_Application
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Timers;
    
    public class CopyRDP
    {

        

        System.Threading.Thread thread;
        delegate void OutputTextBoxDelegate(string CopyOutput);

        public static int CopyTxtNumber = 0;

        public static void Copy()
        {
            //string sourceDirectoryRDP = @"H:\Support\_ANZ";
            //string targetDirectoryRDP = @"C:\RDP";

            DirectoryInfo diSource = new DirectoryInfo(@"H:\Support\_ANZ");
            DirectoryInfo diTarget = new DirectoryInfo(@"C:\RDP");
            Debug.WriteLine("This is working.");
            CopyAll(diSource, diTarget);
            

        }

        

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            
               Directory.CreateDirectory(target.FullName);

            

            // Copy each file into the new directory.
            try
            {
                
                    
                
                
                    foreach (FileInfo fi in source.GetFiles())
                    {


                    string CopyLine1 = @"Copying {0}\{1}";
                    string CopyLine2 = target.FullName;
                    string CopyLine3 = fi.Name;


                    frmInstaller InstallerForm = new frmInstaller();
                    Debug.WriteLine(CopyLine1, CopyLine2, CopyLine3);
                   
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);

                    string CopyLineFull = CopyLine1 + CopyLine2 + CopyLine3;
                    

                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        Log("Log", w);
                    }

                   // using (StreamWriter r = File.OpenText("log.txt"))
                  //  {
                 //       DumpLog(r)
                   // }

                    void Log(string logMessage, TextWriter w)
                    {
                        w.Write("\r\nLog Entry : ");
                        w.WriteLine(CopyLine1 + CopyLine2 + CopyLine3);
                    }

                    void DumpLog(StreamReader r)
                    {
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }


                    
                    }


                    foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                    {
                        DirectoryInfo nextTargetSubDir =
                            target.CreateSubdirectory(diSourceSubDir.Name);
                        CopyAll(diSourceSubDir, nextTargetSubDir);
                    
                }
                
                
              
            }
            catch(Exception CopyFail)
            {
                Debug.Write("Task failed successfully");
                var ExceptionResult = MessageBox.Show("Error copying RDP folders. Either the path was not found or there are permission errors. Delete any folders created in RDP folder on C drive and try again.",
                        "Error Copying", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ExceptionResult == DialogResult.OK)
                {
                    Application.Exit();
                }
            }

            
            

            // Copy each subdirectory using recursion.
            
            
        }

       
        

        public static void WriteToTxtBox()
        {
            if(CopyTxtNumber != 0)
            {
                frmInstaller InstallerForm = new frmInstaller();
                InstallerForm.Refresh();
            }

        }


        // Output will vary based on the contents of the source directory.
    }
}
