using AMT.ReportingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.DataAccess
{
    interface IDatabaseCreate
    {

        Boolean CreateApplicationDatabase (DBConnectionInfo connectionDetails);

        Boolean CheckDatabaseConnection (DBConnectionInfo connectionDetails);
    }

    interface IReportInit
    {
        List<ReportUIInit> InitReportWindow (DBConnectionInfo connectionDetails);
    }
}
