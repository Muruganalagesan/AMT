using AMT.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AMT.DataAccess;
using AMT.ReportingInterfaces;
namespace AMT.Manager
{
    public class InitailizeApp
    {


        public Boolean CreateDatabases (DBConnectionInfo inputConnection)
        {
            Boolean result = false;

            try
            {
              result =  new ApplicationFactory().InitApplicationDatabase(inputConnection);
                    
                 
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }


        public Boolean CheckDatabaseConnection (DBConnectionInfo inputConnection)
        {
            Boolean result = false;

            try
            {
              result =  new ApplicationFactory().CheckDatabaseConnectvity(inputConnection);


            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        public List<ReportUIInit> InitReportWindow (DBConnectionInfo inputConnection)
        {
            List<ReportUIInit> result = null;
            try
            {

              result=  new ApplicationFactory().InitReportWindow(inputConnection);
                

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

    }
}
