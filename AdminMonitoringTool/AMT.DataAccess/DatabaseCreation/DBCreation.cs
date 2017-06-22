using AMT.Logger;
using AMT.ReportingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMT.DataAccess
{
    public abstract class DBCreation : DBOperationBase, IDatabaseCreate
    {
       
        public abstract Boolean CreateDatabase ();

        public abstract Boolean CreateTables ();

        public abstract Boolean DoSupportiveOperations ();

        public abstract Boolean CleanNetWorkList ();
        

        public bool CreateApplicationDatabase (DBConnectionInfo ConnectionDetails)
        {

            Boolean result = false ;
            try
            {
                this.DatabaseConnectionDetails = ConnectionDetails;

                if (DatabaseConnect())
                {

                    if (CreateDatabase())
                    {

                        CreateTables();

                      
                    }

                    CleanNetWorkList();
                    DoSupportiveOperations();

                    DatabaseDisConnect();
                }

            }
           
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;

        }


        public Boolean CheckDatabaseConnection (DBConnectionInfo ConnectionDetails)
        {
            Boolean result = false;
            try
            {
                this.DatabaseConnectionDetails = ConnectionDetails;

                if (DatabaseConnect())
                {

                    result = true;

                    DatabaseDisConnect();
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
