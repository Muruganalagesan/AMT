using AMT.Common.Win32Api;
using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMT.DataAccess.WMI
{
   public  class NTFSShares :WMIActionBase 
    {
       List<ShareInfo> productInfoItems = new List<ShareInfo>();



        public override bool CollectReportData()
        {

            Boolean result = false;
            try
            {

                productInfoItems = new NetShareWrapper().EnumNetSharesWithPermission(MachineDetails.ServerName);

                result = true;

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        public override bool StoreData(DbStorageBase inputType, WMIConnectionInfo ConnectionInfo)
        {

            Boolean result = false;
            try
            {

                inputType.StoreData<ShareInfo >(productInfoItems, ConnectionInfo);

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }




        public override DataTable GetReportData()
        {

            DataTable result = null;
            try
            {
                result = AMT.Common.WMI.WMIQueryBuilder.ToDataTable<ShareInfo>(productInfoItems);
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }





        public override bool DoAction()
        {
            try
            {

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return true;
        }
    }
}
