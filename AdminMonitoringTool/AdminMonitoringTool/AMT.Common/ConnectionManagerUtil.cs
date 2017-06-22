using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.Common.Constants;

namespace AMT.Common
{
    public static class ConnectionManagerUtil
    {

       static List<ProfileConnectionInfo> ProfileConnectionInfo = new List<ProfileConnectionInfo>();

      public static DataTable ProfileTable= new DataTable ();

       static  ConnectionManagerUtil ()
      {
          InitializeProfileTable();


          
          LoadProfileTableWithValues();
      }


      public static Boolean  InitializeProfileTable()
      {
          Boolean result = false;

          try
          {
              if (ProfileTable.Columns.Count == 0)
              {
                  ProfileTable.Columns.AddRange( new DataColumn[] { new DataColumn{ColumnName ="DomainName" },
                                                                    new DataColumn{ColumnName ="ServerName" },
                                                                    new DataColumn{ColumnName ="UserName" },
                                                                       
                                                                         new DataColumn{ColumnName ="LastConnected" },
                                                                          new DataColumn{ColumnName ="Status" }

                  
                  
                  }   );
              }




          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return result;
         
      }

      public static Boolean LoadProfileTableWithValues()
      {

        
          Boolean result = false;
          try
          {
              ProfileTable.Rows.Clear(); 

              foreach (var item in ProfileConnectionInfo)
              {
                  DataRow row = ProfileTable.NewRow();

                   row["DomainName"] = item.DomainName;
                   row["ServerName"]=item.ServerName ;
                   row["UserName"]=item.UserName ;
                   row["Status"] = item.ConnectionStatus;
                   row["LastConnected"]=item.LastConnectTime ;

                    ProfileTable.Rows.Add(row);

                                    
              }

          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return result;
      }

      public static Boolean ReloadProfileTableWithValues ()
      {


          Boolean result = false;
          try
          {
              ProfileTable.Rows.Clear();

              foreach (var item in ProfileConnectionInfo)
              {
                  DataRow row = ProfileTable.NewRow();

                  row["DomainName"] = item.DomainName;
                  row["ServerName"] = item.ServerName;
                  row["UserName"] = item.UserName;
                  row["Status"] = item.ConnectionStatus;
                  row["LastConnected"] = item.LastConnectTime;

                  ProfileTable.Rows.Add(row);


              }

          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return result;
      }

      public static Boolean IsProfileConnected(String DomainName, String ServerName)
      {
          Boolean result = false;
          try
          {
             var item= ProfileConnectionInfo.Where(t => t.DomainName == DomainName && t.ServerName == ServerName).FirstOrDefault();

             if (item != null)
             {
                 result = item.IsConnected;
             }
              
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return result;
      }

      public static Boolean AddProfile(ProfileConnectionInfo profileConnection)
      {

          Boolean result = false;
          try
          {
              var item = ProfileConnectionInfo.Where(t => t.DomainName == profileConnection.DomainName && t.ServerName == profileConnection.ServerName).Count();


              if (item == 0)
              {
                  if (!ProfileConnectionInfo.Contains(profileConnection))
                      ProfileConnectionInfo.Add(profileConnection);
              }
              result = true;


              ReloadProfileTableWithValues();

          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return result;
      }


      public static Boolean EditProfile(ProfileConnectionInfo profileConnection)
      {

          Boolean result = false;
          try
          {
              var item = ProfileConnectionInfo.Where(t => t.DomainName == profileConnection.DomainName && t.ServerName == profileConnection.ServerName).FirstOrDefault ();

              if(item !=null)
              item = profileConnection;
              ReloadProfileTableWithValues();
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return result;
      }

      public static Boolean DeleteProfile(ProfileConnectionInfo profileConnection)
      {

          Boolean result = false;
          try
          {
              var item = ProfileConnectionInfo.Where(t => t.DomainName == profileConnection.DomainName && t.ServerName == profileConnection.ServerName).FirstOrDefault();


             
                  if (ProfileConnectionInfo.Contains(item))
                      ProfileConnectionInfo.Remove(profileConnection);

                  result = true;

                  ReloadProfileTableWithValues();

          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return result;
      }

      public static DataTable GetConnections ()
      {
          return ProfileTable;
      }

      public static Boolean ChangeProfileConnectionStatus (ProfileConnectionInfo connectionInfo)
      {
          Boolean result = false;
          try
          {

              ProfileConnectionInfo resultItem= ProfileConnectionInfo.Where(t => t.DomainName == connectionInfo.DomainName && t.ServerName == connectionInfo.ServerName).FirstOrDefault();
              if (resultItem != null)
              {
                  resultItem.IsLocalConnection  = connectionInfo.IsLocalConnection ;
                 
                  resultItem.ConnectionStatus =connectionInfo.ConnectionStatus;
                      resultItem.DomainName =connectionInfo.DomainName;
                          resultItem.IsConnected =connectionInfo.IsConnected;
                              resultItem.LastConnectTime =connectionInfo.LastConnectTime;
                                   resultItem.Password =connectionInfo.Password;
                                       resultItem.ServerName =connectionInfo.ServerName;
                                       resultItem.UserName = connectionInfo.UserName;
                                            
                 
              }


              
              result = true;


          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return result;
      
      }

      public static List<ProfileConnectionInfo > GetProfileConnectionInfo ()
      {
          return ProfileConnectionInfo;
      }

      public static void   SetProfileConnectionInfo (List<ProfileConnectionInfo > items)
      {
          ProfileConnectionInfo = items;
      }

      public static MachineInfo GetConnectionDetails (String DomainName, String ServerName)
      {

          MachineInfo objMachineInfo = new MachineInfo();
          try
          {
             
ProfileConnectionInfo resultItem= ProfileConnectionInfo.Where(t => t.DomainName == DomainName && t.ServerName == ServerName).FirstOrDefault();
              if (resultItem != null)
              {
                  objMachineInfo = new MachineInfo() { DomainName = resultItem.DomainName ,
                                                    ServerName = resultItem.ServerName ,
                                                       UserName = resultItem.UserName ,
                                                    Password = resultItem.Password ,
                                                    IsLocalConnection = resultItem.IsLocalConnection  };
              }

              
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return objMachineInfo;
      }


    }
}
