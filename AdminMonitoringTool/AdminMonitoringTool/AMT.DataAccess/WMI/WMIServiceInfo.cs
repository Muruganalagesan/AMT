using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using AMT.Common;
using AMT.Common.WMI;
using System.ComponentModel;
using System.Data;
namespace AMT.DataAccess.WMI
{
    public class WMIServiceInfo : WMIActionBase
    
    {


        List<ServiceInfo> serviceInfoItems = new List<ServiceInfo>();

        

        public override bool CollectReportData ()
        {
           
            Boolean result = false;
            try
            {
                

                
              //  serviceInfoItems.Clear();



                //List<String> test = InputConnectionInfo.DatabaseFields;

                foreach (ManagementObject mo in searcher.Get().AsParallel ())
                {
                    ServiceInfo serviceInfo = new ServiceInfo() { };
                    foreach (String itemProp in InputConnectionInfo.WMIFields)
                        {
                           
                            serviceInfo.GetType().GetProperty(itemProp).SetValue(serviceInfo, (WMIQueryBuilder.GetValue(mo, itemProp)), null);
             
                        }

                  //  base.MachineInfo.backgroundWorker.ReportProgress(1, "Collecting details... " + serviceInfo.Name);
                    serviceInfo.TimeStamp = InputConnectionInfo.TimeStamp;
                    UpdateStatus(serviceInfo.Name);
                    serviceInfoItems.Add(serviceInfo);
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

                inputType.StoreData<ServiceInfo>(serviceInfoItems,ConnectionInfo );

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        //public override bool WMIDisConnect ()
        //{

        //    Boolean result = false;
        //    try
        //    {
        //        searcher.Dispose ();
        //        result = true;

        //    }
        //    catch (Exception ex)
        //    {

        //        AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
        //    }

        //    return result;
        //}

        //public override WMIConnectionInfo InputConnectionInfo
        //{
        //    get;
        //    set;
        //}

       

        //public override MachineInfo MachineDetails
        //{
        //    get;
        //    set;
        //}


        public override DataTable GetReportData ()
        {

            DataTable result = null;
            try
            {
                result = AMT.Common.WMI.WMIQueryBuilder.ToDataTable<ServiceInfo>(serviceInfoItems);
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }



        public  bool ExportData (WMIConnectionInfo ConnectionInfo, ReportingInterfaces.Export.ExportInfo ExportInfo)
        {
            throw new NotImplementedException();
        }

        public override bool DoAction ()
        {
            throw new NotImplementedException();
        }
    }
}
