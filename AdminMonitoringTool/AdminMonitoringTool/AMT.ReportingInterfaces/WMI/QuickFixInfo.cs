using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
   public  class QuickFixInfo
    {

       public String TimeStamp = String.Empty;


       public String SystemName = String.Empty;

//       Fixcomments

//csname=systemname






       

        [DisplayName("CSName")]
       public string CSName { get; set; }

        [DisplayName("Description")]
       public string Description { get; set; }

       // [DisplayName("FixComments")]
       //public string FixComments { get; set; }

        [DisplayName("HotFixID")]
       public string HotFixID { get; set; }

       // [DisplayName("InstallDate")]
       //public String InstallDate { get; set; }

        [DisplayName("InstalledBy")]
       public string InstalledBy { get; set; }

        [DisplayName("InstalledOn")]
       public string InstalledOn { get; set; }

        [DisplayName("Caption")]
        public string Caption { get; set; }

       // [DisplayName("Name")]
       //public string Name { get; set; }

       // [DisplayName("ServicePackInEffect")]
       //public string ServicePackInEffect { get; set; }

       // [DisplayName("Status")]
       //public string Status { get; set; }

    }
}
