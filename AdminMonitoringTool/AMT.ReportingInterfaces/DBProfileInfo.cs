using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces
{
   public  class DBProfileInfo
    {
       public EnumHelper.Databases DatabaseType { get; set; }

       public String ServerName { get; set; }

       public EnumHelper.Authentication AuthenticationType { get; set; }

       public String UserName { get; set; }

       public String Password { get; set; }

       public String HashSalt { get; set; }

    }
}
