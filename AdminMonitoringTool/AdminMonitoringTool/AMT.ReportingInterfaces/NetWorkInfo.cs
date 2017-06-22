using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces
{
   public class DomainInfo
    {
       public String DomainName { get; set; }

       public List<ServerInfo> Severs { get; set; }
    }


   public class ServerInfo
   {
       public String ServerName { get; set; }

       public UInt32 ServerType { get; set; }

       public UInt32 MajorVersion { get; set; }

       public UInt32 MinorVersion { get; set; }

       public UInt32 PlatformId { get; set; }

       public String Comment { get; set; }
      
      
   }

    public enum ServerType
    {
        DomainController=0,
        WorkStation=1
    }


}
