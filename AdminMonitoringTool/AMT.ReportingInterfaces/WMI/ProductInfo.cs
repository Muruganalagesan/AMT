using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
   public  class ProductInfo
    {
       public String TimeStamp = String.Empty;

       //[DisplayName("SystemName")]
       public String SystemName = String.Empty;
        [DisplayName("Caption")]
        public String Caption { get; set; }

        [DisplayName("InstallDate")]
        public String InstallDate { get; set; }

        [DisplayName("InstallSource")]
        public String InstallSource { get; set; }

        [DisplayName("Name")]
        public String Name { get; set; }

        [DisplayName("RegCompany")]
        public String RegCompany { get; set; }

        [DisplayName("RegOwner")]
        public String RegOwner { get; set; }

        [DisplayName("URLInfoAbout")]
        public String URLInfoAbout { get; set; }

        [DisplayName("URLUpdateInfo")]
        public String URLUpdateInfo { get; set; }

        [DisplayName("Vendor")]
        public String Vendor { get; set; }

        [DisplayName("Version")]
        public String Version { get; set; }
    }
}
