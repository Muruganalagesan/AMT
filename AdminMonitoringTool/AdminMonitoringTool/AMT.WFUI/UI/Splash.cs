using AMT.ReportingInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using AMT.Logger;
using System.IO;
using AMT.Common.Constants;
using AMT.WFUI.Common;
namespace AMT.WFUI
{
    public partial class Splash : Form
    {
        public Splash ()
        {
            InitializeComponent();
        }


       

        private void Splash_Load (object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            finally
            {
                this.Close();
            }
           
           
        }
    }
}
