using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
   public  class UserAccountInfo
    {

        public String SystemName = string.Empty;

        public string TimeStamp = String.Empty;

         [DisplayName("AccountType")]
       public String AccountType { get; set; }

       [DisplayName("Caption")]
       public String Caption { get; set; }

       [DisplayName("Description")]
       public String Description { get; set; }

       [DisplayName("Disabled")]
       public String Disabled { get; set; }

       [DisplayName("Domain")]
       public String Domain { get; set; }


       [DisplayName("FullName")]
       public String FullName { get; set; }


       [DisplayName("InstallDate")]
       public String InstallDate { get; set; }


       [DisplayName("LocalAccount")]
       public String LocalAccount { get; set; }


       [DisplayName("Lockout")]
       public String Lockout { get; set; }

       [DisplayName("Name")]
       public String Name { get; set; }

       [DisplayName("PasswordChangeable")]
       public String PasswordChangeable { get; set; }

       [DisplayName("PasswordExpires")]
       public String PasswordExpires { get; set; }

       [DisplayName("PasswordRequired")]
       public String PasswordRequired { get; set; }

       [DisplayName("SID")]
       public String SID { get; set; }

       [DisplayName("SIDType")]
       public String SIDType { get; set; }

       [DisplayName("Status")]
       public String Status { get; set; }
    }
}
