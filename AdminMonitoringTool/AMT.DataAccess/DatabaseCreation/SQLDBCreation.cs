using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient ;
using AMT.ReportingInterfaces;
using AMT.Logger;
using System.Reflection;
using System.IO;
using AMT.Common;
using AMT.Common.Constants;
using System.Text.RegularExpressions;
namespace AMT.DataAccess
{
   public class SQLDBCreation : DBCreation 
    {
       SqlConnection connection = null;

       SqlCommand command = null;

       //DBConnectionInfo connectionDetails = null;

       List<String> SortOrder = new List<string>() {"Tables","SP" };

        public override bool DatabaseConnect ()
        {

            Boolean result = false;
            try
            {
                connection = new SqlConnection(BuildConnectionString());
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                    result = true;

                base.DatabaseConnectionDetails.QueryFilePath = Path.Combine(ApplicationInfo.ApplicationDocumentPath, "Queries", "SQL");

              // base.DatabaseName = "AMTTest1";
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
            
        }


        private Boolean IsDatabaseExist ()
        {
            Boolean result = false ;
            var command = new SqlCommand(@"SELECT COUNT(*) FROM sys.databases where name='" + ApplicationInfo.DatabaseName + "';", connection);

            var count = command.ExecuteScalar();
            if (count.Equals(1))
            {
                result = true;
                //table exists
            }

            return result;
        }

        public override bool CreateDatabase ()
        {
            Boolean result = false;
            try
            {
                if (!IsDatabaseExist())
                {
                    command = new SqlCommand("Create database [" + base.DatabaseConnectionDetails.DatabaseName + "]", connection);
                    command.ExecuteNonQuery();
                    result = true;
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
                ChangeDatabase();

                foreach (var queryCategory in SortOrder)
                {
                    foreach (var item in Directory.GetFiles(base.DatabaseConnectionDetails.QueryFilePath, queryCategory + "*.sql"))
                    {
                        try
                        {
                            Regex Mtsregexpattern = new Regex("###SEP###");
                            using (StreamReader queryReader = new StreamReader(item))
                            {
                                List<String> Queries = Mtsregexpattern.Split(queryReader.ReadToEnd()).ToList();

                              

                                foreach (var queryItem in Queries)
                                {
                                    try
                                    {
                                        if (!String.IsNullOrEmpty(queryItem))
                                        {
                                            AMTLogger.WriteToLog("Executing query--->" + queryItem);

                                            command = new SqlCommand(queryItem, connection);
                                            command.ExecuteNonQuery();
                                        }
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


                    }

                }



            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            finally
            {
                command.Dispose();
            }
            return result;
        }

        public override bool DoSupportiveOperations ()
        {

            Boolean result = false;
            try
            {
                ChangeDatabase();

                 foreach (var item in new Common.Win32Api.NetServerAPIWrapper().GetNetworkList())
	            {
                    foreach (var serverName in item.Severs)
                    
                       
	                {
                        //String commandText = "Insert into NetworkList values(" + Utility.Quotes(item.DomainName) + "," + Utility.Quotes(serverName.ServerName) + "," + Utility.Quotes(serverName.ServerType.ToString()) + "," + Utility.Quotes(serverName.MajorVersion.ToString()) + "," + Utility.Quotes(serverName.MinorVersion.ToString()) + "," + Utility.Quotes(serverName.PlatformId.ToString()) + "," + Utility.Quotes(serverName.Comment) + "," + Utility.Quotes(DateTime.Now.ToLocalTime().ToString()) + ")";

                        String commandText = "Insert into NetworkList values(" + Utility.Quotes(item.DomainName) + "," + Utility.Quotes(serverName.ServerName) + "," + Utility.Quotes(serverName.ServerType.ToString()) + "," + Utility.Quotes(serverName.MajorVersion.ToString()) + "," + Utility.Quotes(serverName.MinorVersion.ToString()) + "," + Utility.Quotes(serverName.PlatformId.ToString()) + "," + Utility.Quotes(serverName.Comment) + "," + Utility.Quotes(DateTime.Now.ToLocalTime().ToString()) + ")";
                    SqlCommand command = new SqlCommand(commandText, connection); 

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

       


        public override bool DatabaseDisConnect ()
        {
            Boolean result = false;
            try
            {
                if(connection.State ==System.Data.ConnectionState.Open )
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
                
                connectionBuilder.ConnectTimeout =5;
                connectionBuilder.DataSource = base.DatabaseConnectionDetails.ServerName;

                if (base.DatabaseConnectionDetails.AuthenticationType == EnumHelper.Authentication.SQLAuthentication)
                {

                    connectionBuilder.UserID = base.DatabaseConnectionDetails.UserName;
                    connectionBuilder.Password = DatabaseConnectionDetails.Password;
                    connectionBuilder.IntegratedSecurity = false;
                }
                else
                {
                    connectionBuilder.IntegratedSecurity = true;
                }


                connectionString = connectionBuilder.ConnectionString;

                AMTLogger.WriteToLog("Connection String-->" + connectionString);

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
                AMTLogger.WriteToLog("Connection String-->" + base.DatabaseConnectionDetails.DatabaseName);
                if(connection.State==System.Data.ConnectionState.Open )
                connection.ChangeDatabase(base.DatabaseConnectionDetails.DatabaseName);

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
        }

        public override bool CleanNetWorkList ()
        {
            Boolean result = false;
            try
            {
                ChangeDatabase();
                String commandText = "Delete from NetworkList;";
                SqlCommand command = new SqlCommand(commandText, connection);

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
