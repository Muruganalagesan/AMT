using AMT.DataAccess.WMI;
using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.Export;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMT.DataAccess.Factory
{
   public class WMIFactory
    {
       IWMIInit wmiInit = null;

       public Boolean InitWMIDataCollection (WMIMachineInfo  wmiMachineInfo)
       {

           Boolean result = false;

          // IWMIInit wmiInit = null;
           try
           {

               if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.Services)
                   wmiInit = new WMIServiceInfo();

               else if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.Application)
                   wmiInit = new WMIProductInfo();

               else if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.QuickFix )
                   wmiInit = new WMI.WMIQuickFixInfo();

               else if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.LogicalDisk )
                   wmiInit = new WMI.WMILogicalDiskInfo ();

               else if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.ComputerSystem )
                   wmiInit = new WMI.WMICompSysInfo();

               else if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.BIOS)
                   wmiInit = new WMI.WMIBiosInfo();

               else if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.BootConfiguration)
                   wmiInit = new WMI.WMIBootInfo();


               else if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.OperatingSystem)
                   wmiInit = new WMI.WMIOSInfo();

               else if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.EnvironmentVaraiable)
                   wmiInit = new WMI.WMIEnvInfo ();

               else if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.NetworkAdapter)
                   wmiInit = new WMI.WMINetworkAdapter();

               else if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.NetworkLoginProfile)
                   wmiInit = new WMI.WMINetworkLoginProfile();


               else if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.Groups)
                   wmiInit = new WMI.WMIGroups ();

               else if (wmiMachineInfo.MachineConnectionInfo.ReportCategory == EnumHelper.WMIReportCategory.Users)
                   wmiInit = new WMI.WMIUsers ();

               if (wmiMachineInfo.CommandMode == EnumHelper.Mode.Collection)
                   wmiInit.CollectData(wmiMachineInfo);
               else
               {
                   ((WMIActionBase)(wmiInit)).DoWMIAction (wmiMachineInfo);

                 // wmiInit.InitAction(wmiMachineInfo);
               }
             

               



           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;


       }


       public DataTable GetWMIReportData (WMIMachineInfo wmiMachineInfo)
       {

           DataTable result = null;

        
           try
           {

               result=wmiInit.GetReportDataTable(wmiMachineInfo);


           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;


       }


       public Boolean ExportReportData ( ExportInfo exportInfo)
       {
           Boolean result =false ;


           try
           {

               result = wmiInit.ExportData(exportInfo);


           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }


       public Boolean CheckConnectivity (MachineInfo machineInfo)
       {

           Boolean result = false;
           try
           {
               IWMIInit wmiInit = new WMIServiceInfo();
               ((WMIBase)wmiInit).MachineDetails = machineInfo;
               if (((WMIBase)wmiInit).WMIConnect())
               {
                   result = true;
               }
           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }

      


    }
}
