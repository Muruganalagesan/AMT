using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces
{

    //TaskName,ReportCategory,OperationMode,Path,ExportFormat,DBType
//Machines
    [Serializable ]
   public class ScheduleTaskInfo
    {
       public String TaskName { get; set; }

       public EnumHelper.WMIReportCategory ReportCategory { get; set; }

       public String Path { get; set; }

       public EnumHelper.ExportFormat ExportFormat { get; set; }

       public EnumHelper.Databases DatabaseType { get; set; }

       public List<MachineInfo> Machines = new List<MachineInfo>();

       public TaskTimeInfo taskTimeInfo { get; set; }
    }


    public class TaskTimeInfo
    {
        

        public String RunAsUser { get; set; }

        public String RunAsPassword { get; set; }

        
    }
}
