using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMT.Manager ;
using AMT.ReportingInterfaces;
using AMT.Manager.ReportManagers;
using AMT.ReportingInterfaces.WMI;
using AMT.Common;
using System.Data;
using AMT.ReportingInterfaces.Export;
using System.IO;
namespace AMT.Scheduler
{
   public  class TaskInitiator
    {
       String taskName { get; set; }

       EnumHelper.WMIReportCategory  ReportCategory { get; set; }

       InitializeWMICollection ReportObject = null;

       WMIMachineInfo wmiMachineInfo = new WMIMachineInfo();

       public TaskInitiator (String taskName)
       {
           this.taskName = taskName;
       }


       private  void GetTaskDetails (String taskName)
       {
           try
           {
               wmiMachineInfo = new WMIMachineInfo()
               {

                   ServersList = new List<MachineInfo>() { new MachineInfo(){DomainName ="Workgroup",ServerName="WIN-SW2OU9PMIRD" ,UserName="administrator", Password ="corent123$$" } ,
                                                            new MachineInfo(){DomainName ="Workgroup",ServerName="WIN-NLOJWL4JWAU" ,UserName="administrator", Password ="corent123$$" }
                   
                   },


                   MachineConnectionInfo = new WMIConnectionInfo()
                   {
                       ReportCategory = this.ReportCategory,
                       ReportMode = EnumHelper.OperationMode.Schedule,

                       TimeStamp = this.ReportCategory.ToString() + Utility.GetReportGuid(),
                       DatabaseConnectionInfo = Utility.LoadDbConnectionInfo()

                   },
                   IsRefresh = true,
                   // CommandMode= EnumHelper.Mode.Action  
                   CommandMode = EnumHelper.Mode.Collection

               };

           }
           catch (Exception)
           {
               
               throw;
           }
       }


       public Boolean InitManager (EnumHelper.WMIReportCategory reportCategory)
       {
           Boolean result = false;
           try
           {
               this.ReportCategory = reportCategory;

               ReportObject = new AMT.Manager.ReportManagers.InitializeWMICollection();

               GetTaskDetails(taskName);

              result = ReportObject.CollectReport(wmiMachineInfo);

                ExportInfo exportInfo = new ExportInfo()
                    {


                        ReportDetails = new ReportInfo() { ExportFormat = EnumHelper.ExportFormat.HTML.ToString(), ReportName = ReportCategory.ToString (), GeneratorName = "Adminstrator", ProductName = "AMT", ReportDate = DateTime.Now.ToString(), ExportPath = Path.Combine(@"C:\Users\Public\Documents\AMT\Preview") },
                        MachineInfo = wmiMachineInfo
                    };


                exportInfo.ReportDetails.ExportPath = System.IO.Path.Combine(exportInfo.ReportDetails.ExportPath, Utility.GetTimeStamp());

                if (!System.IO.Directory.Exists(exportInfo.ReportDetails.ExportPath))
                    System.IO.Directory.CreateDirectory(exportInfo.ReportDetails.ExportPath);

                ReportObject.ExportReportData(exportInfo);




           }
           catch (Exception)
           {
               
               throw;
           }

           return result;

       }


    }
}
