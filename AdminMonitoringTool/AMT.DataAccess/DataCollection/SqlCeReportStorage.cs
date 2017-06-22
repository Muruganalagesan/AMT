using AMT.Logger;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMT.DataAccess.DataCollection
{
    public class SqlCeReportStorage : DbStorageBase
    {

         SqlCeConnection connection= new SqlCeConnection ();

         public SqlCeReportStorage (WMIConnectionInfo input) : base(input) { }

        public override bool DatabaseConnect ()
        {

            Boolean result = false;
            try
            {
                connection = new SqlCeConnection(BuildConnectionString());
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
                        SqlCeCommand cmdIns = new SqlCeCommand(connectionInfo.InsertQuery, connection);

                        foreach (var item in ConnectionInfo.DatabaseFields)
                        {
                           

                            var resultValue = ReportItem.GetType().GetProperty(item).GetValue(ReportItem, null);

                            if (resultValue.ToString()  == "True")
                                resultValue = "Yes";
                            if (resultValue.ToString() == "False")
                                resultValue = "No";

                            cmdIns.Parameters.Add(new SqlCeParameter() { Value = resultValue, ParameterName = item });

                        }


                        if (connectionInfo.CustomFields != null)
                        {
                            foreach (var item in ConnectionInfo.CustomFields)
                            {
                                var resultValue = ReportItem.GetType().GetField(item).GetValue(ReportItem);
                                cmdIns.Parameters.Add(new SqlCeParameter() { Value = resultValue, ParameterName = item });
                            }
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
              // SqlCeConnectionStringBuilder connectionBuilder = new SqlCeConnectionStringBuilder();

                String dbFilepath = Path.Combine(DatabaseConnectionDetails.DBPath, DatabaseConnectionDetails.DatabaseName + ".sdf");

                connectionString = @"Data Source = " + dbFilepath;

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
                //connection.ChangeDatabase(connectionInfo.dbConnectionInfo.DatabaseName);

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
        }

    }
}
