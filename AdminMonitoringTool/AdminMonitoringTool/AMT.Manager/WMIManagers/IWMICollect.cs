using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.Manager
{
  
    public interface IWMICollect
    {
        bool CollectWMIData (WMIMachineInfo wmiConnectionInfo);

      //  bool DoWMIAction (WMIMachineInfo wmiConnectionInfo);
    }



  
}
