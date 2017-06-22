using AMT.ReportingInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AMT.WFUI
{
    public partial class Splash : Form
    {
        public Splash ()
        {
            InitializeComponent();
        }


        public void InitApplication ()
        {
            try
            {
                new AMT.Manager.InitailizeApp().CreateDatabases(new DBConnectionInfo() { DatabaseType = EnumHelper.Databases.SQLServerCE, DatabaseName = "AMTTest",DBPath=AppDomain.CurrentDomain.BaseDirectory  });

                //new AMT.Manager.InitailizeApp().CreateDatabases(new DBConnectionInfo()
                //{
                //    AuthenticationType = EnumHelper.Authentication.SQLAuthentication,
                //    DatabaseName = "AMTTest3",
                //    DatabaseType = EnumHelper.Databases.SQLServer,
                //    ServerName = "192.168.0.35",
                //    UserName = "sa",
                //    Password = "MSSQL35$"
                //});

            }
            catch ( Exception ex) 
            {
                
                throw ex;
            }
        }

        private void Splash_Load (object sender, EventArgs e)
        {
            try
            {
                InitApplication();
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                this.Close();
            }
           
           
        }
    }
}
