﻿using AMT.Common.WMI;
using AMT.Logger;
using AMT.ReportingInterfaces;
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
    public class WMIProductInfo : WMIActionBase
    {
      

        List<ProductInfo> productInfoItems = new List<ProductInfo>();

     

        public override bool CollectReportData ()
        {

            Boolean result = false;
            try
            {



            // productInfoItems.Clear();



                //List<String> test = InputConnectionInfo.DatabaseFields;

                foreach (ManagementObject mo in searcher.Get().AsParallel())
                {
                   

                    ProductInfo productInfo = new ProductInfo() { };
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

                inputType.StoreData<ProductInfo>(productInfoItems, ConnectionInfo);

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

   
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
                result = AMT.Common.WMI.WMIQueryBuilder.ToDataTable<ProductInfo>(productInfoItems  );
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }



        public override bool DoAction ()
        {
            throw new NotImplementedException();
        }
    }
}
