using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
namespace AMT.ReportingInterfaces.Export
{
   public  abstract class  ExportBase
    {

       public ExportBase(ExportInfo input)
       {
           this.ExportItemsInfo = input;
       }

       public Boolean IsReportStarted { get; set; }

       public ExportInfo ExportItemsInfo { get; set; }

        public abstract Boolean StartExport (DbDataReader reader);

        public abstract Boolean ExportReportData (DbDataReader reader);

        public abstract Boolean EndExport ();

        public abstract Boolean SaveReport ();

    }
}
