using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces
{
   public  class DBConnectionInfo:DBInfo 
    {

       public EnumHelper.Authentication AuthenticationType { get; set; }

       public EnumHelper.Databases DatabaseType { get; set; }

       public String DatabaseName { get; set; }

       public String DBPath { get; set; }

       public String QueryFilePath { get; set; }
       


    }
}
