using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
  public class WMIConnectionInfo
    {

      public EnumHelper.WMIReportCategory ReportCategory { get; set; }

      public EnumHelper.OperationMode ReportMode { get; set; }

      public String TimeStamp { get; set; }

      public DBConnectionInfo DatabaseConnectionInfo { get; set; }

      public  String TableName { get; set; }

      public  String TableQuery { get; set; }

      public  String WMIQuery { get;  set;}

      public String WMIClass { get; set; }

      public List<String> ErrorInfo { get; set; }

      public String InsertQuery { get; set; }

      public List<String> WMIFields { get; set; }

      public List<String> DatabaseFields { get; set; }

      public List<String> CustomFields { get; set; }

      public Boolean IsRefresh { get; set; }
   

    }


  public class WMIMachineInfo 
  {
      public WMIConnectionInfo MachineConnectionInfo { get; set; }


      public List<MachineInfo> ServersList { get; set; }

      public Boolean IsRefersh { get; set; }

      public EnumHelper.Mode CommandMode { get; set; }

      public BackgroundWorker backgroundWorker { get; set; }

      public IntPtr OwnerHandle { get; set; }

      public String ActionName { get; set; }

  

  }
}
