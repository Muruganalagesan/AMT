using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMT.DataAccess.DataCollection
{
    public class SqlReportStorage : DbStorageBase
    {

        SqlConnection connection= new SqlConnection ();

        public SqlReportStorage (WMIConnectionInfo input) : base(input) { }

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

        public override bool StoreData<T> (List<T> reportData, WMIConnectionInfo ConnectionInfo)
        {

            base.connectionInfo = ConnectionInfo;

            Boolean result = false;

            List<String> DbFields = new List<string>();
            try
            {
                foreach (var ReportItem in reportData)
                {
                    try
                    {
                        SqlCommand cmdIns = new SqlCommand(connectionInfo.InsertQuery, connection);

                        foreach (var item in ConnectionInfo.DatabaseFields)
                        {
                           

                            var resultValue = ReportItem.GetType().GetProperty(item).GetValue(ReportItem, null);

                            if (resultValue.ToString()  == "True")
                                resultValue = "Yes";
                            if (resultValue.ToString() == "False")
                                resultValue = "No";

                            cmdIns.Parameters.Add(new SqlParameter() { Value = resultValue, ParameterName = item });

                        }

                        foreach (var item in ConnectionInfo.CustomFields)
                        {
                            var resultValue = ReportItem.GetType().GetField(item).GetValue(ReportItem);
                            cmdIns.Parameters.Add(new SqlParameter() { Value = resultValue, ParameterName = item });
                        }
                        cmdIns.ExecuteNonQuery(); 
                    }
                    catch (Exception ex)
                    {

                        AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
                    }

                    
                }

                


              
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
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
                connectionBuilder.DataSource = connectionInfo.DatabaseConnectionInfo.ServerName;

                if (connectionInfo.DatabaseConnectionInfo.AuthenticationType == EnumHelper.Authentication.SQLAuthentication)
                {

                    connectionBuilder.UserID = connectionInfo.DatabaseConnectionInfo.UserName;
                    connectionBuilder.Password = DatabaseConnectionDetails.Password;
                    connectionBuilder.IntegratedSecurity = false;
                }
                else
                {
                    connectionBuilder.IntegratedSecurity = true;
                }


                connectionString = connectionBuilder.ConnectionString;

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
                connection.ChangeDatabase(connectionInfo.DatabaseConnectionInfo.DatabaseName);

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
        }

    }


    

}
