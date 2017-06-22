using AMT.ReportingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMT.DataAccess.Factory;
using AMT.Logger;
using System.Reflection;

namespace AMT.Manager.WMIManagers
{
   public class WMIConnectivityManager
    {
       MachineInfo ConnectivityMachineInfo { get; set; }
       WMIFactory wmiFactory = new WMIFactory();

       public Boolean CheckConnectivity (MachineInfo inputMachineInfo)
       {
           Boolean result = false;
           try
           {
               this.ConnectivityMachineInfo = inputMachineInfo;

            result=   wmiFactory.CheckConnectivity(inputMachineInfo);

             //  result = true;
           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }
    }
}
