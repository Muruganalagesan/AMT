using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
   public  class OperatingSystemInfo
    {
        public String TimeStamp = String.Empty;

        public String SystemName = String.Empty;

        [DisplayName("BootDevice")]
        public String BootDevice { get; set; }


        [DisplayName("BuildNumber")]
        public String BuildNumber { get; set; }


        [DisplayName("BuildType")]
        public String BuildType { get; set; }

        [DisplayName("Caption")]
        public String Caption { get; set; }

        [DisplayName("CSDVersion")]
        public String CSDVersion { get; set; }

        [DisplayName("FreePhysicalMemory")]
        public String FreePhysicalMemory { get; set; }

        [DisplayName("FreeSpaceInPagingFiles")]
        public String FreeSpaceInPagingFiles { get; set; }

        [DisplayName("FreeVirtualMemory")]
        public String FreeVirtualMemory { get; set; }

        [DisplayName("InstallDate")]
        public String InstallDate { get; set; }

        [DisplayName("LastBootUpTime")]
        public String LastBootUpTime { get; set; }


        [DisplayName("LocalDateTime")]

        public String LocalDateTime { get; set; }

        [DisplayName("Manufacturer")]
        public String Manufacturer { get; set; }

        [DisplayName("MaxProcessMemorySize")]
        public String MaxProcessMemorySize { get; set; }

        [DisplayName("MUILanguages")]
        public String MUILanguages { get; set; }

        [DisplayName("Name")]
        public String Name { get; set; }

        //        [DisplayName("NumberOfProcesses")]
        //public String NumberOfProcesses  {get; set;}

        [DisplayName("OSArchitecture")]
        public String OSArchitecture { get; set; }

        [DisplayName("NumberOfUsers")]
        public String NumberOfUsers { get; set; }

        [DisplayName("RegisteredUser")]
        public String RegisteredUser { get; set; }

        [DisplayName("SerialNumber")]
        public String SerialNumber { get; set; }

        [DisplayName("ServicePackMajorVersion")]
        public String ServicePackMajorVersion { get; set; }

        [DisplayName("ServicePackMinorVersion")]
        public String ServicePackMinorVersion { get; set; }

        [DisplayName("SizeStoredInPagingFiles")]
        public String SizeStoredInPagingFiles { get; set; }

        [DisplayName("SystemDevice")]
        public String SystemDevice { get; set; }

        [DisplayName("SystemDirectory")]
        public String SystemDirectory { get; set; }

        [DisplayName("SystemDrive")]
        public String SystemDrive { get; set; }

        [DisplayName("TotalVirtualMemorySize")]
        public String TotalVirtualMemorySize { get; set; }

        [DisplayName("TotalVisibleMemorySize")]
        public String TotalVisibleMemorySize { get; set; }

        [DisplayName("Version")]
        public String Version { get; set; }

        [DisplayName("WindowsDirectory")]
        public String WindowsDirectory { get; set; }


    }
}
