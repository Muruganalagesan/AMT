using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
  public class BootConfigInfo
    {

        public String TimeStamp = String.Empty;

        public String SystemName = String.Empty;


        [DisplayName("BootDirectory")]
        public String BootDirectory { get; set; }

        [DisplayName("Caption")]
        public String Caption { get; set; }

        [DisplayName("ConfigurationPath")]
        public String ConfigurationPath { get; set; }

        [DisplayName("Description")]
        public String Description { get; set; }

        [DisplayName("LastDrive")]
        public String LastDrive { get; set; }

        [DisplayName("Name")]
        public String Name { get; set; }

        [DisplayName("ScratchDirectory")]
        public String ScratchDirectory { get; set; }

        [DisplayName("TempDirectory")]
        public String TempDirectory { get; set; }


    }
}
