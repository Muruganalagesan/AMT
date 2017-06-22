using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMT.ReportingInterfaces;
namespace AMT.ReportingInterfaces
{
  public class ReportOperationInfo
    {

      public String ReportCategory { get; set; }

      public EnumHelper.OperationMode ReportMode { get; set; }

      public List<MachineInfo> ServersList { get; set; }

      public String TimeStamp { get; set; }

     

    }
}
