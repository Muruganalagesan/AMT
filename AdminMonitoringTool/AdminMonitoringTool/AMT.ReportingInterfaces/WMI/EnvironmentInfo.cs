using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
   public  class EnvironmentInfo
    {

       public String TimeStamp = String.Empty;

       public String SystemName = String.Empty;

       [DisplayName("Caption")]
       public String Caption { get; set; }

        [DisplayName("Description")]
       public String Description { get; set; }

        [DisplayName("Name")]
       public String Name { get; set; }

        [DisplayName("SystemVariable")]
       public String SystemVariable { get; set; }

        [DisplayName("UserName")]
       public String UserName { get; set; }

        [DisplayName("VariableValue")]
       public String VariableValue { get; set; }
       
        
    }
}
