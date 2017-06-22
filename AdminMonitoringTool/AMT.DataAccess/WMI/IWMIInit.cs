using AMT.ReportingInterfaces.Export;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMT.DataAccess.WMI
{
   public  interface IWMIInit
    {

        bool CollectData (WMIMachineInfo  wmiConnectionInfo);

        DataTable GetReportDataTable (WMIMachineInfo wmiConnectionInfo);

        bool ExportData (ExportInfo ExportInfo);

    }


  
}
