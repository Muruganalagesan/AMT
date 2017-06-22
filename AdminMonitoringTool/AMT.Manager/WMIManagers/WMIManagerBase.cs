using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.Export;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMT.Manager
{
    public abstract class WMIManagerBase : IWMICollect
    {
        public abstract String TableName { get; }

        public abstract String TableQuery { get; }

        public abstract String WMIQuery { get; }

        public abstract String WMIClass { get; }

        public abstract List<String> WMIFields { get; }

        public abstract List<String> DatabaseFields { get; }

        public abstract List<String> CustomFields { get; }

        public abstract WMIMachineInfo wmiMachineInfo { get; set; }

        public abstract Boolean Collect ();

        public abstract String InsertQuery { get; }

        public abstract List<String> ReportTabs { get; }

        public abstract Dictionary<String,String> ReportCategories { get; }

        public abstract DataTable FetchReportData ();

        public abstract Boolean ExportReportData (ExportInfo exportInfo);

       // public abstract Boolean DoAction ();


        public abstract String WhereQuery { get; }

        public String GetWMIQuery ()
        {
            String wmiQuery = String.Empty;

            try
            {
                wmiQuery = "Select " + WMIQuery + " from " + WMIClass;
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return wmiQuery;
        }

        public bool CollectWMIData (WMIMachineInfo wmiConnectionInfo)
        {
            Boolean result = false;
            try
            {
                this.wmiMachineInfo = wmiConnectionInfo;
                Collect();

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }





        //public bool DoWMIAction (WMIMachineInfo wmiConnectionInfo)
        //{
        //    Boolean result = false;
        //    try
        //    {
        //        this.wmiMachineInfo = wmiConnectionInfo;

        //        DoAction();

        //       // IWMIAction
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }

        //    return result;

        //}
    }
    
}
