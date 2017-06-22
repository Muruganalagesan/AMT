using AMT.DataAccess.Factory;
using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.Export;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMT.DataAccess.DataCollection
{
   public  class SqlReportExport : DBExportBase
    {
       SqlConnection connection = new SqlConnection();
        public SqlReportExport (ExportInfo input) : base(input) { }

        ExportBase objExportbase = null;

        public override bool DatabaseConnect ()
        {

            Boolean result = false;
            try
            {
                connection = new SqlConnection(BuildConnectionString());
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                    result = true;

                ChangeDatabase();

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;

        }


        public override bool DatabaseDisConnect ()
        {
            Boolean result = false;
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            finally
            {
                connection.Dispose();
            }
            return result;
        }

   

        private String BuildConnectionString ()
        {

            String connectionString = String.Empty;
            try
            {
                SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();

                connectionBuilder.InitialCatalog = "Master";

                connectionBuilder.ConnectTimeout = 60;
                connectionBuilder.DataSource = ReportExportInfo.MachineInfo.MachineConnectionInfo.DatabaseConnectionInfo.ServerName;

                if (ReportExportInfo.MachineInfo.MachineConnectionInfo.DatabaseConnectionInfo.AuthenticationType == EnumHelper.Authentication.SQLAuthentication)
                {

                    connectionBuilder.UserID = ReportExportInfo.MachineInfo.MachineConnectionInfo.DatabaseConnectionInfo.UserName;
                    connectionBuilder.Password = ReportExportInfo.MachineInfo.MachineConnectionInfo.DatabaseConnectionInfo.Password;
                    connectionBuilder.IntegratedSecurity = false;
                }
                else
                {
                    connectionBuilder.IntegratedSecurity = true;
                }


                connectionString = connectionBuilder.ConnectionString;

                ChangeDatabase();

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return connectionString;

        }

        private void ChangeDatabase ()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                connection.ChangeDatabase(ReportExportInfo.MachineInfo.MachineConnectionInfo.DatabaseConnectionInfo.DatabaseName);

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
        }


        public override bool ExportReportData ()
        {
            Boolean result = false;

            try
            {


                objExportbase = new ExportFactory().ExportFactoryInit(ReportExportInfo);


                BuildDataReader();

                objExportbase.SaveReport();

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }


        public Boolean BuildDataReader ()
        {
            Boolean result = false;
            try
            {

                SqlCommand command = new SqlCommand(base.ReportExportInfo.MachineInfo.MachineConnectionInfo.TableQuery, connection);

                using (SqlDataReader datareader = command.ExecuteReader())
                {
                    while (datareader.Read())
                    {
                        objExportbase.StartExport(datareader);

                        objExportbase.ExportReportData(datareader);



                    }

                }


                objExportbase.EndExport();
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }


    }
}
