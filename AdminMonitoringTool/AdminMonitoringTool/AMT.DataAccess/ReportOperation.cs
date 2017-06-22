using AMT.ReportingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient ;
using AMT.Logger;
using System.Reflection;
using System.Data.SqlServerCe;
using System.IO;
namespace AMT.DataAccess
{
   public abstract  class ReportOperation :DBOperationBase ,IReportInit 
    {
       public abstract List<ReportUIInit> GetReportUIDetails ();

       public DBConnectionInfo ConnectionInfo { get; set; }

        public List<ReportUIInit> InitReportWindow (ReportingInterfaces.DBConnectionInfo connectionDetails)
        {
            List<ReportUIInit> result = new List<ReportUIInit>();

            try
            {
                this.ConnectionInfo = connectionDetails;

                DatabaseConnect();

              result=  GetReportUIDetails();

                DatabaseDisConnect();

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }
    }

   public class SQlReportOperation : ReportOperation
   {
       SqlConnection connection = null;

       private String BuildConnectionString ()
       {

           String connectionString = String.Empty;
           try
           {
               SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();

               connectionBuilder.InitialCatalog = "Master";

               connectionBuilder.ConnectTimeout = 60;
               connectionBuilder.DataSource = ConnectionInfo.ServerName;

               if (ConnectionInfo.AuthenticationType == EnumHelper.Authentication.SQLAuthentication)
               {

                   connectionBuilder.UserID = ConnectionInfo.UserName;
                   connectionBuilder.Password = ConnectionInfo.Password;
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
               connection.ChangeDatabase(ConnectionInfo.DatabaseName);

           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }
       }

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

       public override List<ReportUIInit> GetReportUIDetails ()
       {
           List<ReportUIInit> items = new List<ReportUIInit>();
           try
           {

               SqlCommand command= new SqlCommand ("Select * from [NetworkList]",connection );

               using (SqlDataReader datareader = command.ExecuteReader())
               {

                   if (datareader.HasRows)
                   {
                       while (datareader.Read())
                       {
                           ReportUIInit reportInfo = new ReportUIInit();

                           reportInfo.DomainName = datareader.GetString(0);
                           reportInfo.ServerName = datareader.GetString(1);

                           items.Add(reportInfo);


                       }



                   }
               }

               //datareader.Close();

           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return items;
       }
   }


   public class SQlCEReportOperation : ReportOperation
   {
       SqlCeConnection connection = null;

       private String BuildConnectionString ()
       {

           String connectionString = String.Empty;
           try
           {
              // SqlCeConnectionStringBuilder connectionBuilder = new SqlCeConnectionStringBuilder();

               String dbFilepath = Path.Combine(ConnectionInfo.DBPath, ConnectionInfo.DatabaseName + ".sdf");
               
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
              // connection.ChangeDatabase(ConnectionInfo.DatabaseName);

           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }
       }

       public override bool DatabaseConnect ()
       {
           Boolean result = false;
           try
           {
               connection = new SqlCeConnection(BuildConnectionString());
               connection.Open();
               if (connection.State == System.Data.ConnectionState.Open)
                   result = true;

             //  ChangeDatabase();

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

       public override List<ReportUIInit> GetReportUIDetails ()
       {
           List<ReportUIInit> items = new List<ReportUIInit>();
           try
           {

               SqlCeCommand command = new SqlCeCommand("Select * from [NetworkList]", connection);

               using (SqlCeDataReader datareader = command.ExecuteReader())
               {

                   //if (datareader.HasRows)
                   //{
                       while (datareader.Read())
                       {
                           ReportUIInit reportInfo = new ReportUIInit();

                           reportInfo.DomainName = datareader.GetString(0);
                           reportInfo.ServerName = datareader.GetString(1);

                           items.Add(reportInfo);


                       }



                   //}
               }

               //datareader.Close();

           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return items;
       }
   }


}
