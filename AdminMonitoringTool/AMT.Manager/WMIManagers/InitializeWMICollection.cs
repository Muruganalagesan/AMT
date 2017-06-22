using AMT.Logger;
using AMT.ReportingInterfaces.Export;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

using AMT.Manager.WMIManagers;
using System.ComponentModel;

namespace AMT.Manager.ReportManagers
{
   public  class InitializeWMICollection
    {

       IWMICollect wmicollect = null;


     //progressUpdater.progressDialog.DoWork += new ProgressDialog.DoWorkEventHandler(form_DoWork);
               

       WMIMachineInfo wmimachineInfo { get; set; }

    

      

       public Boolean  CollectReport (WMIMachineInfo  inputMachineInfo)
       {

           Boolean result = false;
           try
           {
               wmimachineInfo = inputMachineInfo;
              result= ManagerInitializer(inputMachineInfo);
           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
        
       }

       private bool ManagerInitializer(WMIMachineInfo inputMachineInfo)
       {
           Boolean result = false;



           try
           {
               InitManagers(inputMachineInfo.MachineConnectionInfo.ReportCategory );


               // if (inputMachineInfo.CommandMode == ReportingInterfaces.EnumHelper.Mode.Collection)
               wmicollect.CollectWMIData(inputMachineInfo);
               //else
               //    wmicollect.DoWMIAction(inputMachineInfo);

           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }

       private void InitManagers (AMT.ReportingInterfaces.EnumHelper.WMIReportCategory ReportCategory)
       {
           try
           {


               if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.Services)
               wmicollect = new WMIServiceManager();

               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.Application)
               wmicollect = new WMIManagers.WMIProductManager();

               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.QuickFix)
               wmicollect = new WMIManagers.WMIQuickFixManager();

               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.LogicalDisk)
               wmicollect = new WMIManagers.WMILogicalDiskManager();

               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.ComputerSystem)
               wmicollect = new WMIManagers.WMICompSysManager();

               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.BIOS)
               wmicollect = new WMIManagers.WMIBiosManager();

               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.BootConfiguration)
               wmicollect = new WMIManagers.WMIBootConfigManager();


               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.OperatingSystem)
               wmicollect = new WMIManagers.WMIOSManager();

               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.EnvironmentVaraiable)
               wmicollect = new WMIManagers.WMIEnvironmentManager();

               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.NetworkAdapter)
               wmicollect = new WMIManagers.WMINetworkAdapterManager();


               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.NetworkLoginProfile)
               wmicollect = new WMIManagers.WMINetworkLoginProfile();


               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.Groups)
               wmicollect = new WMIManagers.WMIGroupManager();

               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.Users)
               wmicollect = new WMIManagers.WMIUsersManager();

               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.Shares)
                   wmicollect = new WMIManagers.WMIShareManagercs ();

               else if (ReportCategory == ReportingInterfaces.EnumHelper.WMIReportCategory.SharesNTFS )
                   wmicollect = new WMIManagers.WMIShareNTFSManager ();
           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }
       }

       public DataTable  GetReportData ()
       {

           DataTable result = null;
           try
           {
               if (wmicollect is WMIManagerBase)
               {
                   result=((WMIManagerBase)wmicollect).FetchReportData();

               }
               //Console.WriteLine(wmicollect);
           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }


       public Boolean ExportReportData (ExportInfo exportInfo)
       {
           Boolean result = false;
           try
           {
               if (wmicollect is WMIManagerBase)
               {
                   result = ((WMIManagerBase)wmicollect).ExportReportData(exportInfo );

               }
           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }


       public Dictionary<String,String> GetReportTabs (AMT.ReportingInterfaces.EnumHelper.WMIReportCategory ReportCategory)
       {
           Dictionary<String, String> tabsToLoad = new Dictionary<String, String>();
           try
           {
               InitManagers(ReportCategory);

               tabsToLoad = ((WMIManagerBase)wmicollect).ReportCategories;

           }
           catch (Exception)
           {
               
               throw;
           }

           return tabsToLoad; 
       }

       


     
    }
}
