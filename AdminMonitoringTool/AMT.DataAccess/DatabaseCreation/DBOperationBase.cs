using AMT.DataAccess.Factory;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.Export;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.DataAccess
{
    public abstract class DBOperationBase 
    {
        public abstract Boolean DatabaseConnect ();

        public abstract Boolean DatabaseDisConnect ();

        public  DBConnectionInfo DatabaseConnectionDetails { get; set; }

    }

    public abstract class DbStorageBase : DBOperationBase
    {
        public DbStorageBase (WMIConnectionInfo connection)
        {
            this.connectionInfo = connection;

        }

        public WMIConnectionInfo connectionInfo { get; set; }

        public abstract Boolean StoreData<T> (List<T> reportData, WMIConnectionInfo ConnectionInfo);

    }


    public abstract class DBExportBase : DBOperationBase
    {
       // public DBExportBase dbExportBase = null;

        public DBExportBase (ExportInfo exportInfo)
        {
            this.ReportExportInfo = exportInfo;
        }
        public ExportInfo ReportExportInfo { get; set; }

       public abstract Boolean ExportReportData ();

    }



    
}
