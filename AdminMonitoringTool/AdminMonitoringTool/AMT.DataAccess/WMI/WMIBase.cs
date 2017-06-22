using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.Export;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;

namespace AMT.DataAccess.WMI
{
   public abstract class WMIBase :IWMIInit
    {
       public ConnectionOptions connectionOptions = null;

       public ManagementObjectSearcher searcher = null;

       public ManagementPath managmentPath = null;

       public ManagementClass managmentClass = null;

       public ManagementObjectCollection instances = null;

       public  MachineInfo MachineDetails { get; set; }

       public DbStorageBase dbOperationBase = null;

       public DBExportBase dbExportBase = null;

       


       public abstract bool CollectReportData ();

       public abstract Boolean  StoreData(DbStorageBase input,WMIConnectionInfo ConnectionInfo);

      // public  bool WMIDisConnect ();

       public abstract DataTable GetReportData ();

       public WMIMachineInfo MachineInfo { get; set; }

       public  WMIConnectionInfo InputConnectionInfo { get; set; }



       public  bool WMIConnect ()
       {
           Boolean result = false;
           try
           {
               connectionOptions = new ConnectionOptions();

               if (!string.IsNullOrEmpty(MachineDetails.UserName))
               {
                   connectionOptions.Username = MachineDetails.UserName;
                   connectionOptions.Password = MachineDetails.Password;


               }

               connectionOptions.Impersonation = ImpersonationLevel.Impersonate;

               connectionOptions.EnablePrivileges = true;
               ManagementScope scope =
                    new ManagementScope(string.Format(@"\\{0}\{1}", MachineDetails.ServerName, Common.Constants.WMIConstants.WMICIMPath), connectionOptions);
               scope.Connect();

               if (MachineInfo != null)
               {
                   if (MachineInfo.CommandMode == EnumHelper.Mode.Collection)
                   {
                       searcher = new ManagementObjectSearcher(scope, new ObjectQuery(InputConnectionInfo.WMIQuery));
                   }

                   else if (MachineInfo.CommandMode == EnumHelper.Mode.Action)
                   {
                       managmentPath = new ManagementPath(InputConnectionInfo.WMIClass);
                       managmentClass = new ManagementClass(scope, managmentPath, null);
                   }

               }

               result = true;
           }
           catch (Exception ex)
           {

               //InputConnectionInfo.ErrorInfo.Add("Machine-->" + MachineDetails.ServerName + "Error=" + ex.Message);

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }
           return result;
       }


       public  bool WMIDisConnect ()
       {

           Boolean result = false;
           try
           {
               searcher.Dispose();
               result = true;

           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }
       
       public bool CollectData (WMIMachineInfo wmiMachineInfo)
       {
           Boolean result = false;
           try
           {

               this.MachineInfo = wmiMachineInfo;

               foreach (var item in wmiMachineInfo.ServersList)
               {
                   this.MachineDetails = item;

                   this.InputConnectionInfo = wmiMachineInfo.MachineConnectionInfo;



                   if (WMIConnect())
                   {

                       CollectReportData();

                       WMIDisConnect();

                     

                   }
               }
               DBInitiate();

           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }
           return result;
       }
       

       public bool DBInitiate ()
       {

           Boolean result = false;

           if (InputConnectionInfo.DatabaseConnectionInfo.DatabaseType == EnumHelper.Databases.SQLServer)
           {

               dbOperationBase = new DataCollection.SqlReportStorage(this.InputConnectionInfo);
           }

           else if (InputConnectionInfo.DatabaseConnectionInfo.DatabaseType == EnumHelper.Databases.SQLServerCE)
           {
               dbOperationBase = new DataCollection.SqlCeReportStorage(this.InputConnectionInfo);
           }

           dbOperationBase.DatabaseConnectionDetails = this.InputConnectionInfo.DatabaseConnectionInfo;


           dbOperationBase.DatabaseConnect();

           StoreData(dbOperationBase,InputConnectionInfo );

           dbOperationBase.DatabaseDisConnect();

           return result ;
               

       }

       public DataTable GetReportDataTable (WMIMachineInfo wmiConnectionInfo)
       {
           DataTable result = new DataTable();
           try
           {
               result = GetReportData();
           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }



       bool IWMIInit.ExportData (ExportInfo ExportInfo)
       {
           Boolean result = false;

           try
           {
               if (InputConnectionInfo.DatabaseConnectionInfo.DatabaseType == EnumHelper.Databases.SQLServer)
               {

                   dbExportBase = new DataCollection.SqlReportExport(ExportInfo);
               }

               else if (InputConnectionInfo.DatabaseConnectionInfo.DatabaseType == EnumHelper.Databases.SQLServerCE)
               {
                   dbExportBase = new DataCollection.SqlCeReportExport(ExportInfo);
               }

               //dbExportBase.exportInfo = ExportInfo;


               dbExportBase.DatabaseConnect();

               dbExportBase.ExportReportData();

               dbExportBase.DatabaseDisConnect();
           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }
          

           return result;
       }


    
    }

   public abstract class WMIActionBase :WMIBase 
   {

       public abstract bool DoAction ();

       public Boolean IsCancelRequested { get; set; }

     //  public String ActionName { get; set; }

      

       public Boolean DoWMIAction (WMIMachineInfo wmimachineInfo)
       {
           Boolean result = false;
           try
           {
               this.MachineInfo = wmimachineInfo;

               foreach (var item in wmimachineInfo.ServersList)
               {
                   this.MachineDetails = item;

                   

                   this.InputConnectionInfo = wmimachineInfo.MachineConnectionInfo;


                   if (WMIConnect())
                   {

                       DoAction();

                       WMIDisConnect();



                   }
               }
               DBInitiate();

           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }

       public void UpdateStatus (String status)
       {
           try
           {
               if (base.InputConnectionInfo.ReportMode == EnumHelper.OperationMode.Interactive)
               {

                   IsCancelRequested = base.MachineInfo.backgroundWorker.CancellationPending;

                   base.MachineInfo.backgroundWorker.ReportProgress(1, "Processing..." + status);
               }
           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }
       }


     
   }

}
