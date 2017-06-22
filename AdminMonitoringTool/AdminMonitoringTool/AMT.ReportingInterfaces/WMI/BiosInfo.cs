using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
   public  class BiosInfo
    {

        public String TimeStamp = String.Empty;

        public String SystemName = String.Empty;


        [DisplayName("BIOSVersion")]
        public String BIOSVersion { get; set; }

        [DisplayName("Manufacturer")]
        public String Manufacturer { get; set; }

        [DisplayName("Name")]
        public String Name { get; set; }

        [DisplayName("PrimaryBIOS")]
        public String PrimaryBIOS { get; set; }

        [DisplayName("ReleaseDate")]
        public String ReleaseDate { get; set; }

        [DisplayName("SerialNumber")]
        public String SerialNumber { get; set; }

        [DisplayName("SMBIOSBIOSVersion")]
        public String SMBIOSBIOSVersion { get; set; }

        [DisplayName("SMBIOSMajorVersion")]
        public String SMBIOSMajorVersion { get; set; }

        [DisplayName("SMBIOSMinorVersion")]
        public String SMBIOSMinorVersion { get; set; }

        [DisplayName("SMBIOSPresent")]
        public String SMBIOSPresent { get; set; }

        [DisplayName("Version")]
        public String Version { get; set; }
    }
}
