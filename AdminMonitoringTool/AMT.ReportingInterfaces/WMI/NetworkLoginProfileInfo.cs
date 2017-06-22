using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
  public   class NetworkLoginProfileInfo
    {

      public String SystemName = string.Empty;

      public string TimeStamp = String.Empty;

       [DisplayName("BadPasswordCount")]
        public String BadPasswordCount { get; set; }

       [DisplayName("Caption")]
      public String Caption { get; set; }

       [DisplayName("Comment")]
      public String Comment { get; set; }

       [DisplayName("Description")]
      public String Description { get; set; }

       [DisplayName("Flags")]
      public String Flags { get; set; }

       [DisplayName("FullName")]
      public String FullName { get; set; }

       [DisplayName("LastLogoff")]
      public String LastLogoff { get; set; }

       [DisplayName("LastLogon")]
      public String LastLogon { get; set; }

       [DisplayName("LogonHours")]
      public String LogonHours { get; set; }

       [DisplayName("LogonServer")]
      public String LogonServer { get; set; }

       [DisplayName("MaximumStorage")]
      public String MaximumStorage { get; set; }

       [DisplayName("Name")]
      public String Name { get; set; }

       [DisplayName("NumberOfLogons")]
      public String NumberOfLogons { get; set; }

       [DisplayName("PasswordAge")]
      public String PasswordAge { get; set; }

       [DisplayName("PasswordExpires")]
      public String PasswordExpires { get; set; }

       [DisplayName("PrimaryGroupId")]
      public String PrimaryGroupId { get; set; }

       [DisplayName("Privileges")]
      public String Privileges { get; set; }

       [DisplayName("UnitsPerWeek")]
      public String UnitsPerWeek { get; set; }

       [DisplayName("UserComment")]
      public String UserComment { get; set; }

       [DisplayName("UserId")]
      public String UserId { get; set; }

       [DisplayName("UserType")]
      public String UserType { get; set; }
      
    }
}
