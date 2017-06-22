using AMT.Common.Constants;
using AMT.Logger;
using AMT.ReportingInterfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMT.Common
{
  public static class Utility
    {
      public static String GetReportGuid ()
      {

          String timeStamp = String.Empty;
          try
          {
              //timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssf");
              //Console.WriteLine("old-->"+timeStamp);

         //timeStamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss",
         //                                   CultureInfo.InvariantCulture);

         timeStamp = Guid.NewGuid().ToString (); 
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }
          return timeStamp;
      }
      //localhost-2014-03-06_02-24-27-PM

      public static String GetTimeStamp ()
      {
          String timeStamp = String.Empty;
          try
          {

              //yyyyMMddHHmmssffff
               timeStamp= DateTime.Now .ToString("yyyy-MM-dd_HH-mm-ss-tt");
 
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return timeStamp;
      }

      public static String Quotes (String data)
      {
          String result = data;
          try
          {
              if (data == null || String.IsNullOrEmpty(data))
              {
                  result = "''";

              }
          result= "'" + data + "'";
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return result;
         
      }


      public static DBConnectionInfo LoadDbConnectionInfo ()
      {

          DBConnectionInfo connectioninfo = new DBConnectionInfo();
          try
          {
              DBProfileInfo dbProfileInfo = new DBProfileInfo();


              if (File.Exists(ApplicationInfo.DBProfileName))
              {
                  XMLSerializer<DBProfileInfo>.DeSerializeInputs<DBProfileInfo>(ApplicationInfo.DBProfileName, ref dbProfileInfo);

                  connectioninfo.AuthenticationType = dbProfileInfo.AuthenticationType;
                  connectioninfo.DatabaseName = ApplicationInfo.DatabaseName;
                  connectioninfo.DatabaseType = dbProfileInfo.DatabaseType;
                  connectioninfo.DBPath = ApplicationInfo.ApplicationDocumentPath;
                  connectioninfo.Password = dbProfileInfo.Password;
                  connectioninfo.UserName = dbProfileInfo.UserName;
                  connectioninfo.ServerName = dbProfileInfo.ServerName;

              }

          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }
          return connectioninfo;
      }

      public static DBProfileInfo GetDBProfileInfo ()
      {

          DBProfileInfo dbProfileInfo = new DBProfileInfo();
          try
          {



              if (File.Exists(ApplicationInfo.DBProfileName))
              {
                  XMLSerializer<DBProfileInfo>.DeSerializeInputs<DBProfileInfo>(ApplicationInfo.DBProfileName, ref dbProfileInfo);


              }

          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }
          return dbProfileInfo;
      }

      public static DBConnectionInfo GetConnectionInfoFromProfile (DBProfileInfo dbProfileInfo)
      {
          DBConnectionInfo connectioninfo = new DBConnectionInfo();
          try
          {
              connectioninfo.AuthenticationType = dbProfileInfo.AuthenticationType;
              connectioninfo.DatabaseName = ApplicationInfo.DatabaseName;
              connectioninfo.DatabaseType = dbProfileInfo.DatabaseType;
              connectioninfo.DBPath = ApplicationInfo.ApplicationDocumentPath;
              connectioninfo.Password = dbProfileInfo.Password;
              connectioninfo.UserName = dbProfileInfo.UserName;
              connectioninfo.ServerName = dbProfileInfo.ServerName;
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }
          return connectioninfo;

      }




    }
}
