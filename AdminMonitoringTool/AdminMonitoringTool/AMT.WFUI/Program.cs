using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AMT.WFUI.UI;

namespace AMT.WFUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           
            
          Application.Run(new Splash ());
         // Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
           //Application.Run(new ConnectionManager());

         // Application.Run(new RealTimeMonitoring());
          AMTMain main = new AMTMain();
          main.ShowDialog();

       


        }

    }
}
