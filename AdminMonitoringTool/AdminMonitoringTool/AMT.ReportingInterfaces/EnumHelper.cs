using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces
{
   public static class EnumHelper
    {
       public enum OperationMode
       {
           Interactive = 0,
           Schedule = 1
       }

       public enum Authentication
       {
           Windows=0,
           SQLAuthentication=1
       }

       public enum Databases
       {
           SQLServer=0,
           SQLServerCE=1
       }

       public enum WMIReportCategory
       {
           Services,
           Application,
           QuickFix,
           LogicalDisk,
           ComputerSystem,
           BootConfiguration,
           BIOS,
           OperatingSystem,
           EnvironmentVaraiable,
           NetworkAdapter,
           NetworkLoginProfile,
           Users,
           Groups,
           Shares,
           SharesNTFS

       }

       public enum QueryType
       {
           WMI,
           Database
       }

       public enum ExportFormat
       {
           CSV,
           HTML,
           EXCEL
       }

       public enum Mode
       {
           Action,
           Collection

       }

       
       public enum ProgressBarStyle
       {
           
           Blocks = 0,
          
           Continuous = 1,
          
           Marquee = 2,
       }

    }
}
