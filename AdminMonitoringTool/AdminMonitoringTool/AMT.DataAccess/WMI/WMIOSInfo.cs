using AMT.Common.WMI;
using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace AMT.DataAccess.WMI
{
    public class WMIOSInfo : WMIActionBase 
    {

      

      

        List<OperatingSystemInfo> productInfoItems = new List<OperatingSystemInfo>();

     

        public override bool CollectReportData ()
        {

            Boolean result = false;
            try
            {



               // productInfoItems.Clear();



                //List<String> test = InputConnectionInfo.DatabaseFields;

                foreach (ManagementObject mo in searcher.Get().AsParallel())
                {
                    OperatingSystemInfo productInfo = new OperatingSystemInfo() { };
                    foreach (String itemProp in InputConnectionInfo.WMIFields)
                    {

                        productInfo.GetType().GetProperty(itemProp).SetValue(productInfo, (WMIQueryBuilder.GetValue(mo, itemProp)), null);

                    }
                    productInfo.TimeStamp = InputConnectionInfo.TimeStamp;
                    productInfo.SystemName = MachineDetails.ServerName;
                    UpdateStatus(productInfo.Name);
                    productInfoItems.Add(productInfo);
                    if (IsCancelRequested)
                        break;
                }

                result = true;

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        public override bool StoreData (DbStorageBase inputType, WMIConnectionInfo ConnectionInfo)
        {

            Boolean result = false;
            try
            {

                inputType.StoreData<OperatingSystemInfo>(productInfoItems, ConnectionInfo);

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        

        public override DataTable GetReportData ()
        {

            DataTable result = null;
            try
            {
                result = AMT.Common.WMI.WMIQueryBuilder.ToDataTable<OperatingSystemInfo >(productInfoItems);
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }



        public override bool DoAction ()
        {

            Boolean result = false;
            try
            {
                instances = managmentClass.GetInstances();
            }
            catch (UnauthorizedAccessException exception)
            {
                throw new Exception("Not permitted to reboot the host: " + MachineDetails.ServerName, exception);
            }
            catch (COMException exception)
            {
                if (exception.ErrorCode == -2147023174)
                {
                    throw new Exception("Could not reach the target host: " + MachineDetails.ServerName, exception);
                }
                throw; // Unhandled
            }
            foreach (ManagementObject instance in instances)
            {

                //"Reboot"
                try
                {
                    //object shutDownResult = instance.InvokeMethod("Shutdown", new object[] {5 });
                    //uint returnValue = (uint)shutDownResult;
                    //Shutdown

                    object shutDownResult = instance.InvokeMethod(base.MachineInfo.ActionName  , new object[] { });
                    uint returnValue = (uint)shutDownResult;

                    if (returnValue != 0)
                    {
                        throw new Exception("Failed to reboot host: " + MachineDetails.ServerName);
                    }
                }
                catch (Exception ex)
                {

                    AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
                }

            }

            return result;
        }
    }
}
