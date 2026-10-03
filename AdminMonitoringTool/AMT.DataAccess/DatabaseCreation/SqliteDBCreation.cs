using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.Sqlite;
using System.IO;
using AMT.Logger;
using System.Reflection;
using System.Text.RegularExpressions;
using AMT.Common;
using AMT.Common.Constants;
namespace AMT.DataAccess
{
   public  class SqliteDBCreation :DBCreation 
    {
       SqliteConnection connection = null;
       SqliteCommand command = null;
       List<String> SortOrder = new List<string>() { "Tables", "SP" };
        public override bool CreateDatabase ()
        {

            Boolean result = true ;
            String dbFilepath = Path.Combine(base.DatabaseConnectionDetails.DBPath, base.DatabaseConnectionDetails.DatabaseName + ".db");
            string connStr = @"Data Source = " + dbFilepath;
            try
            {

              var  command = new SqliteCommand(@"SELECT Count(*) FROM sqlite_master WHERE type = 'table' AND name = 'Service'", connection);

            var count = command.ExecuteScalar ();
            if(Convert.ToInt64(count) == 1){
                result = false;
    //table exists
                }

              


             
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            return result;
           
        }

        public override bool CreateTables ()
        {
            Boolean result = false;
            try
            {
                //ChangeDatabase();

                foreach (var queryCategory in SortOrder)
                {
                    foreach (var item in Directory.GetFiles(Path.Combine ( base.DatabaseConnectionDetails.QueryFilePath), queryCategory + "*.sql"))
                    {
                    
                        try
                        {
                            Regex Mtsregexpattern = new Regex("###SEP###");

                           
                            using (StreamReader queryReader = new StreamReader(item))
                            {
                                List<String> Queries = Mtsregexpattern.Split(queryReader.ReadToEnd()).ToList();

                              //  while (!queryReader.EndOfStream)
                               // {
                                   // String query = queryReader.ReadLine().Trim ();



                                foreach (var quertItem in Queries)
                                {
                                    try
                                    {
                                        if (!String.IsNullOrEmpty(quertItem))
                                        {
                                            command = new SqliteCommand(quertItem, connection);
                                            command.ExecuteNonQuery();
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                        AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
                                    }
                                   
                                }
                                    
                         }
                            //}
                        
                        }

                    
                
                        catch (Exception ex)
                        {

                            AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
                        }


                    }
            }

                
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        public override bool DoSupportiveOperations ()
        {
            Boolean result = false;
            try
            {
                var deletecommand = new SqliteCommand("delete from NetworkList", connection);

                deletecommand.ExecuteNonQuery();



                foreach (var item in new Common.Win32Api.NetServerAPIWrapper().GetNetworkList())
	            {
                    foreach (var serverName in item.Severs)
                    
                       
	                {

                        

        //String test = Common.WMI.WMIQueryBuilder.GetQuery<AMT.ReportingInterfaces.ServerInfo>(serverName, ReportingInterfaces.EnumHelper.QueryType.Database);
		 //  String commandText= "Insert into NetworkList("+ item.DomainName + "," + serverName.ServerName + "," + serverName.ServerType + "," + serverName.MajorVersion + "," + serverName.MinorVersion + "," + serverName.PlatformId + "," + serverName.Comment  + "," +DateTime.Now.ToLocalTime  ()  + ")";

                        String commandText = "Insert into NetworkList values(" + Utility.Quotes(item.DomainName) + "," + Utility.Quotes(serverName.ServerName) + "," + Utility.Quotes(serverName.ServerType.ToString()) + "," + Utility.Quotes(serverName.MajorVersion.ToString()) + "," + Utility.Quotes(serverName.MinorVersion.ToString()) + "," + Utility.Quotes(serverName.PlatformId.ToString()) + "," + Utility.Quotes(serverName.Comment) + "," + Utility.Quotes(DateTime.Now.ToLocalTime().ToString()) + ")";
                    SqliteCommand command = new SqliteCommand(commandText, connection); 

                    command.ExecuteNonQuery();
	    }

                  

		 
	            } 

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        public override bool DatabaseConnect ()
        {
            Boolean result = false;

            String dbFilepath = Path.Combine(base.DatabaseConnectionDetails.DBPath, base.DatabaseConnectionDetails.DatabaseName + ".db");
            string connStr = @"Data Source = " + dbFilepath;
            try
            {
                Directory.CreateDirectory(base.DatabaseConnectionDetails.DBPath);

                connection = new SqliteConnection(connStr);
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                    result = true;
                base.DatabaseConnectionDetails.QueryFilePath = Path.Combine(ApplicationInfo.ApplicationDocumentPath , "Queries", "SQLITE");

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

        public override bool CleanNetWorkList ()
        {
            Boolean result = false;
            try
            {
                String commandText = "Delete from NetworkList";
                SqliteCommand command = new SqliteCommand(commandText, connection);

                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }
    }
}
