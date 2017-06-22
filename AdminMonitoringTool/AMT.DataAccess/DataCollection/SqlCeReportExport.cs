using AMT.DataAccess.Export;
using AMT.DataAccess.Factory;
using AMT.Logger;
using AMT.ReportingInterfaces.Export;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMT.DataAccess.DataCollection
{
   public  class SqlCeReportExport : DBExportBase
    {
        SqlCeConnection connection = new SqlCeConnection();
        public SqlCeReportExport (ExportInfo input) : base(input) { }


        ExportBase objExportbase = null;

      


        public override bool DatabaseConnect ()
        {

            Boolean result = false;
            try
            {
                connection = new SqlCeConnection(BuildConnectionString());
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                    result = true;



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
                
                

                String dbFilepath = Path.Combine(ReportExportInfo.MachineInfo.MachineConnectionInfo.DatabaseConnectionInfo.DBPath, ReportExportInfo.MachineInfo.MachineConnectionInfo.DatabaseConnectionInfo.DatabaseName + ".sdf");

                connectionString = @"Data Source = " + dbFilepath;

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return connectionString;

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

               

                SqlCeCommand command= new SqlCeCommand(base.ReportExportInfo.MachineInfo.MachineConnectionInfo.TableQuery ,connection );

                using (SqlCeDataReader datareader = command.ExecuteReader())
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

