using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces
{
    public class ShareInfo
    {
        public String Name { get; set; }
        public String Remark { get; set; }
        public int Permissions { get; set; }
        public int Maxuses { get; set; }
        public int CurrentUses { get; set; }
        public String Path { get; set; }
        public String ServerName { get; set; }
        public int Reserved { get; set; }

        public IntPtr SecurityDescriptor { get; set; }

        public int Type { get; set; }

        public List<SharePermission> SharePermissions { get; set; }

    }


    public class SharePermission
    {
        public String UserName { get; set; }

        public String Permission { get; set; }

        public String SID { get; set; }

        public String AcessType { get; set; }

        public String DomainName { get; set; }
    }


    public class BaseShareInfo
    {
        public String ShareName { get; set; }

        public String SharePath { get; set; }

        public String ServerName { get; set; }
        public String DomainName { get; set; }
    }

}
