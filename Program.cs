using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsFormsApplication2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            //rkApp.SetValue("Reminder", Application.ExecutablePath.ToString());

            ///
            /// 

            // Check to see the current state (running at startup or not)

            if (rkApp.GetValue("Reminder") == null)
            {

                // The value doesn't exist, the application is not set to run at startup

                //chkRun.Checked = false;
                rkApp.SetValue("Reminder", Application.ExecutablePath.ToString());
               // MessageBox.Show("Reminder");

            }

            else
            {

                // The value exists, the application is set to run at startup

                //chkRun.Checked = true;
                //MessageBox.Show("yap");

            }

            /// 
            ///
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new REMINDER());
            REMINDER f = new REMINDER();
           /*
            countdown cn = new countdown();
            int newmin;
            newmin=cn.show(Form1.minute);
            MessageBox.Show(newmin.ToString());
            */
        }
    }
}
