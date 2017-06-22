using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace AMT.ReportingInterfaces.WMI
{

//Create Table [Service]([ReportStamp]nvarchar(255) ,[SystemName] nvarchar(255),[Name] nvarchar(255),[Caption] nvarchar(50),[Description] nvarchar(255),[State]nvarchar(10),[StartMode]nvarchar(10),[RunAsAccount] nvarchar(255),[ProcessId] nvarchar(255),[PathName] nvarchar(max),[Started]nvarchar(10),[AcceptPause] nvarchar(10), [AcceptStop] nvarchar(10) ,[DesktopInteract]nvarchar(5),[ServiceType] nvarchar(10) ,PRIMARY KEY (ReportStamp,SystemName,Name))

    

  public class ServiceInfo
    {
        //[DisplayName("ReportStamp")]
        //public String ReportStamp { get; set; }

//      Create Table [Service]([AcceptPause] nvarchar(10), [AcceptStop] nvarchar(10) ,[Caption] nvarchar(50), [Description] nvarchar(255), [DesktopInteraction]nvarchar(5),[DisplayName]nvarchar(255),[Name] nvarchar(255),[Path] nvarchar(max),[ProcessId] nvarchar(255),[ServiceType] nvarchar(10) ,[Started]nvarchar(10),[StartMode]nvarchar(10) ,[RunAsAccount] nvarchar(255),[State]nvarchar(10),[Status]nvarchar(10),[SystemName] nvarchar(255))

      public String TimeStamp = String.Empty;

        [DisplayName("SystemName")]
        public string SystemName { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Caption")]
        public string Caption { get; set; }

        [DisplayName("DisplayName")]
        public string DisplayName { get; set; }

        //[DisplayName("Description")]
        //public string Description { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("StartMode")]
        public string StartMode { get; set; }

        [DisplayName("StartName")]
        public string StartName { get; set; }

        [DisplayName("ProcessId")]
        public string ProcessId { get; set; }

        [DisplayName("PathName")]
        public string PathName { get; set; }

        [DisplayName("Started")]
        public string Started { get; set; }

        [DisplayName("AcceptPause")]
        public string AcceptPause { get; set; }

        [DisplayName("AcceptStop")]
        public string AcceptStop { get; set; }

        [DisplayName("DesktopInteract")]
        public string DesktopInteract { get; set; }

        [DisplayName("ServiceType")]
        public string ServiceType { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

    }
}
