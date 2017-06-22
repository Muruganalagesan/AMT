using AMT.Common.Constants;
using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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

                  connectioninfo.Password = Utility.Decrypt(dbProfileInfo.Password, dbProfileInfo.HashSalt); 
                //  connectioninfo.Password = dbProfileInfo.Password;
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
         


              connectioninfo.Password = Utility.Decrypt(dbProfileInfo.Password, dbProfileInfo.HashSalt); 
              connectioninfo.UserName = dbProfileInfo.UserName;
              connectioninfo.ServerName = dbProfileInfo.ServerName;
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }
          return connectioninfo;

      }



      private const int PBKDF2IterCount = 100000; // default for Rfc2898DeriveBytes
      private const int PBKDF2SubkeyLength = 1024 / 8; // 256 bits
      private const int SaltSize = 1024 / 8; // 128 bits

      public static string HashPassword(string password)
      {
          byte[] salt;
          byte[] subkey;
          byte[] outputBytes = null;

          try
          {
              using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, PBKDF2IterCount))
              {
                  salt = deriveBytes.Salt;
                  subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
              }

            outputBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
              Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
              Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, PBKDF2SubkeyLength);
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }
          
          return Convert.ToBase64String(outputBytes);
      }

      public static bool VerifyHashedPassword(string hashedPassword, string password)
      {
          byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);

          // Wrong length or version header.
          if (hashedPasswordBytes.Length != (1 + SaltSize + PBKDF2SubkeyLength) || hashedPasswordBytes[0] != 0x00)
              return false;

          byte[] salt = new byte[SaltSize];
          Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, SaltSize);
          byte[] storedSubkey = new byte[PBKDF2SubkeyLength];
          Buffer.BlockCopy(hashedPasswordBytes, 1 + SaltSize, storedSubkey, 0, PBKDF2SubkeyLength);

          byte[] generatedSubkey;
          using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, PBKDF2IterCount))
          {
              generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
          }
          return storedSubkey.SequenceEqual(generatedSubkey);
      }


      static public string Encrypt(string password, string salt)
      {
          byte[] cipherBytes = null;
          try
          {
              byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
              byte[] saltBytes = Encoding.Unicode.GetBytes(salt);

              cipherBytes = ProtectedData.Protect(passwordBytes, saltBytes, DataProtectionScope.CurrentUser);

             
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }
          return Convert.ToBase64String(cipherBytes);
        
      }

      static public string Decrypt(string cipher, string salt)
      {
          byte[] passwordBytes = null;
          String result = String.Empty;
          try
          {
              if (!String.IsNullOrWhiteSpace(cipher))
              {
                  byte[] cipherBytes = Convert.FromBase64String(cipher);
                  byte[] saltBytes = Encoding.Unicode.GetBytes(salt);

                  passwordBytes = ProtectedData.Unprotect(cipherBytes, saltBytes, DataProtectionScope.CurrentUser);

                  result = Encoding.Unicode.GetString(passwordBytes);
              }
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }
          return result;

      }

        #region MyRegion

      public static List<RemoteActionInfo> LoadRemoteActions()
      {
          List<RemoteActionInfo> remoteActionInfo = new List<RemoteActionInfo>();
          try
          {
              if (File.Exists(ApplicationInfo.RemoteActionFile))
                  XMLSerializer<List<RemoteActionInfo>>.DeSerializeInputs(ApplicationInfo.RemoteActionFile, ref remoteActionInfo);
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return remoteActionInfo;
          

      }

      public static Boolean RemoveRemoteAction(String ActionName)
       {
           Boolean result = false;
           List<RemoteActionInfo> remoteActionList = new List<RemoteActionInfo>();
           try
           {
               remoteActionList=LoadRemoteActions();
               RemoteActionInfo remoteAction = remoteActionList.Where(t => t.ActionName == ActionName).FirstOrDefault();
               if (remoteAction != null)
               {
                   remoteActionList.Remove(remoteAction);

                   if (File.Exists(ApplicationInfo.RemoteActionFile))
                       XMLSerializer<List<RemoteActionInfo>>.SerializeInputs(ApplicationInfo.RemoteActionFile, remoteActionList);

               }

               result = true;



           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }

      public static RemoteActionInfo GetRemoteAction(String ActionName)
      {
          RemoteActionInfo remoteAction = null;
          List<RemoteActionInfo> remoteActionList = new List<RemoteActionInfo>();
          try
          {
              remoteActionList = LoadRemoteActions();
               remoteAction = remoteActionList.Where(t => t.ActionName == ActionName).FirstOrDefault();
          
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return remoteAction;
      }
        #endregion



    }
}
