using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaK_v1._0.utilities
{
    static class PrinterManager
    {
        private static string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;

        public static void Print(String vDocFullPath)
        {
            try
            {
                if (Boolean.Parse(System.Configuration.ConfigurationManager.AppSettings["SilentPrint"]))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    //startInfo.FileName = Path.Combine(appRootDir + "\\sbin", System.Configuration.ConfigurationManager.AppSettings["PrintExecutable"]);
                    startInfo.FileName = Path.Combine(appRootDir, System.Configuration.ConfigurationManager.AppSettings["PrintExecutable"]);
                    startInfo.Arguments = "-print-to-default " + vDocFullPath;
                    System.Diagnostics.Process.Start(startInfo);
                }
                else
                {
                    string process = vDocFullPath;
                    System.Diagnostics.Process.Start(process);
                }
            }
            catch
            {
                MessageBox.Show("The print fuction is not configured correctly");
            }
           

        }
    }
}
