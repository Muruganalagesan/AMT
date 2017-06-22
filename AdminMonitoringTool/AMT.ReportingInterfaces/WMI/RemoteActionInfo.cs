
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
   public class RemoteActionInfo
    {

       public EnumHelper.RemoteAction RemoteAction { get; set; }

       public String RemoteActionCaption { get; set; }

       public List<MachineInfo> Machines = new List<MachineInfo>();

       public String ActionName { get; set; }

       public String ActionDescription { get; set; }

       public String RemoteShareLocation { get; set; }

       public String RemoteActionName { get; set; }

     

    }

   
}
