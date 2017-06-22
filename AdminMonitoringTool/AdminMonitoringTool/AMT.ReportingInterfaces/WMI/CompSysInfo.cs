using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
  public class CompSysInfo
    {
        public String TimeStamp = String.Empty;

        [DisplayName("Caption")]
        public String Caption { get; set; }

        [DisplayName("Description")]
        public String Description { get; set; }

        [DisplayName("DNSHostName")]
        public String DNSHostName { get; set; }

        [DisplayName("Domain")]
        public String Domain { get; set; }

        [DisplayName("DomainRole")]
        public String DomainRole { get; set; }

        [DisplayName("Manufacturer")]
        public String Manufacturer { get; set; }

        [DisplayName("Model")]
        public String Model { get; set; }

        [DisplayName("Name")]
        public String Name { get; set; }

        [DisplayName("NetworkServerModeEnabled")]
        public String NetworkServerModeEnabled { get; set; }

        [DisplayName("NumberOfLogicalProcessors")]
        public String NumberOfLogicalProcessors { get; set; }

        [DisplayName("NumberOfProcessors")]
        public String NumberOfProcessors { get; set; }

        [DisplayName("PartOfDomain")]
        public String PartOfDomain { get; set; }

        [DisplayName("PrimaryOwnerName")]
        public String PrimaryOwnerName { get; set; }

        [DisplayName("Roles")]
        public String Roles { get; set; }

        [DisplayName("SystemType")]
        public String SystemType { get; set; }

        [DisplayName("TotalPhysicalMemory")]
        public String TotalPhysicalMemory { get; set; }

        [DisplayName("UserName")]
        public String UserName { get; set; }

        [DisplayName("Workgroup")]
        public String Workgroup { get; set; }

    }
}
