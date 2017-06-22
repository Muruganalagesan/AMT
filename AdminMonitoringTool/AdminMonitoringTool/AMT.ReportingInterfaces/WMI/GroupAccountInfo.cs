using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
   public class GroupAccountInfo
   {
       public String SystemName = string.Empty;

       public string TimeStamp = String.Empty;


       [DisplayName("Caption")]
       public string Caption { get; set; }

       [DisplayName("Description")]
       public string Description { get; set; }

       [DisplayName("Domain")]
       public string Domain { get; set; }

       [DisplayName("InstallDate")]
       public String InstallDate { get; set; }

       [DisplayName("LocalAccount")]
       public String LocalAccount { get; set; }

       [DisplayName("Name")]
       public String Name { get; set; }

       [DisplayName("SID")]
       public String SID { get; set; }

       [DisplayName("SIDType")]
       public String SIDType { get; set; }

       [DisplayName("Status")]
       public string Status { get; set; }
    }
}
