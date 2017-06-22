using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces
{
    public class CredentialInfo
    {

        public CredentialInfo ()
            {

            }


        public CredentialInfo (String UserName, String Password, String Description, String target, DateTime ModifiedDate)
            {
            this.UserName = UserName;
            this.Password = Password;
            this.Description = Description;
            this.Target = target;

            this.ModifiedDate = ModifiedDate;

            }

        public String UserName { get; set; }

        public String Password { get; set; }

        public String Description { get; set; }

        public String Target { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
