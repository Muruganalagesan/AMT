using AMT.DataAccess.Export;
using AMT.ReportingInterfaces.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using AMT.Logger;
using DocumentFormat.OpenXml.Drawing;
using AMT.Common;

namespace AMT.DataAccess.Factory
{
  public   class ExportFactory
    {

      ExportBase export = null;

      public  ExportBase ExportFactoryInit (ExportInfo exportInfo)
      {
          try
          {
              if (exportInfo != null)
              {
                 

                  if (exportInfo.ReportDetails.ExportFormat == ReportingInterfaces.EnumHelper.ExportFormat.EXCEL.ToString())
                      export = new ExcelExport(exportInfo);
                  else if (exportInfo.ReportDetails.ExportFormat == ReportingInterfaces.EnumHelper.ExportFormat.CSV.ToString())
                      export = new CSVExport(exportInfo);
                  else if (exportInfo.ReportDetails.ExportFormat == ReportingInterfaces.EnumHelper.ExportFormat.HTML.ToString())
                      export = new HtmLExport(exportInfo);
              }
              else
                  AMTLogger.WriteToLog("Export Info is null", MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Info);
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return export;
      }

    }
}
