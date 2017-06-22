using AMT.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AMT.ReportingInterfaces;
namespace AMT.DataAccess
{

   
   public class ApplicationFactory
    {

       public Boolean InitApplicationDatabase (DBConnectionInfo dbServerDetails)
       {

           Boolean result = false;

           IDatabaseCreate databaseCreate=null;
           try
           {

               if (dbServerDetails.DatabaseType == EnumHelper.Databases.SQLServer)
                   databaseCreate = new SQLDBCreation();
               else if (dbServerDetails.DatabaseType == EnumHelper.Databases.SQLServerCE)
                   databaseCreate = new SqlCeDBCreation();

               databaseCreate.CreateApplicationDatabase(dbServerDetails);
            



           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;

          
       }


       public Boolean CheckDatabaseConnectvity (DBConnectionInfo dbServerDetails)
       {

           Boolean result = false;

           IDatabaseCreate databaseCreate = null;
           try
           {

               if (dbServerDetails.DatabaseType == EnumHelper.Databases.SQLServer)
                   databaseCreate = new SQLDBCreation();
               else if (dbServerDetails.DatabaseType == EnumHelper.Databases.SQLServerCE)
                   databaseCreate = new SqlCeDBCreation();

            result =   databaseCreate.CheckDatabaseConnection(dbServerDetails);




           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;


       }



       public List<ReportUIInit> InitReportWindow (DBConnectionInfo dbServerDetails)
       {
           List<ReportUIInit> result = null;
           ReportOperation reportOperation = null;

           try
           {
               if (dbServerDetails.DatabaseType == EnumHelper.Databases.SQLServer)
                   reportOperation = new SQlReportOperation ();
               else if (dbServerDetails.DatabaseType == EnumHelper.Databases.SQLServerCE)
                   reportOperation = new SQlCEReportOperation();

             result=  reportOperation.InitReportWindow(dbServerDetails);

           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;


       }

    }
}
