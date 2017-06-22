using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.Export
{
    public  class ReportInfo
    {

        public String ReportName { get; set; }

        public List<ReportHeader> ReportHeaders { get; set; }

        public String ReportDate { get; set; }

        public String GeneratorName { get; set; }

        public String ProductName { get; set; }


        public String ExportFormat { get; set; }

        public String ExportPath { get; set; }

    }

    public class ReportHeader
    {
        public String Name { get; set; }

        public String Value { get; set; }
    }

}
