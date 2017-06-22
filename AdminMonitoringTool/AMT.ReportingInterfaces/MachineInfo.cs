using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces
{
   public class MachineInfo :DBInfo 
    {
       public String DomainName { get; set; }

       public Boolean IsLocalConnection { get; set; }

    }


   public class DBInfo
   {

       public String UserName { get; set; }

       public String Password
       {
           get;
           set;



       }

       public String ServerName { get; set; }

     

   }


  

}
