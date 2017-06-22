using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces
{
   public class ProfileConnectionInfo : MachineInfo
    {

     //  public String ServerName { get; set; }

       public String ProfileName { get; set; }

      // public String UserName { get; set; }

       public String ConnectionStatus { get; set; }

       public String Hash { get; set; }

       public Boolean  IsConnected { get; set; }

     //  public Boolean IsLocalConnection { get; set; }

       public DateTime LastConnectTime { get; set; }
    }
}
