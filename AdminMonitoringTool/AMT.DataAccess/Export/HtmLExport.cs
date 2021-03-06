﻿using AMT.ReportingInterfaces.Export;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using AMT.Logger;

namespace AMT.DataAccess.Export
{
    public class HtmLExport : ExportBase
    {
        public HtmLExport (ExportInfo item) : base(item) { }

        StringBuilder htmlBuilder = new StringBuilder();

        public override bool StartExport (DbDataReader input)
        {
            Boolean result = false;
            try
            {
                if (!IsReportStarted)
                {

                    

                    //Create Top Portion of HTML Document
                    htmlBuilder.Append("<html>");
                    htmlBuilder.Append("<head>");
                    htmlBuilder.Append("<title>");
                    htmlBuilder.Append(base.ExportItemsInfo.ReportDetails.ReportName);

                    

                    //htmlBuilder.Append(Guid.NewGuid().ToString());
                    htmlBuilder.Append("</title>");
                    htmlBuilder.Append("</head>");
                    htmlBuilder.Append("<body>");
                    htmlBuilder.Append("<table>");
                   // htmlBuilder.Append("style='font-family:arial;color:black;font-size:20px';>");
                  //  htmlBuilder.Append("<B>");
                    

                    if (base.ExportItemsInfo.ReportDetails.ProductName != null)
                    {
                        htmlBuilder.Append("<tr>");
                        htmlBuilder.Append("<td>");
                        htmlBuilder.Append("Product Name:" + base.ExportItemsInfo.ReportDetails.ProductName);
                        htmlBuilder.Append("</td>");
                        htmlBuilder.Append("</tr>");
                    }

                   
                    


                    if (base.ExportItemsInfo.ReportDetails.ReportName!=null)
                    {
                        htmlBuilder.Append("<tr>");
                        htmlBuilder.Append("<td>");
                        htmlBuilder.Append("Report Name:" + base.ExportItemsInfo.ReportDetails.ReportName);
                        htmlBuilder.Append("</td>");
                        htmlBuilder.Append("</tr>");
                    }



                    if (base.ExportItemsInfo.ReportDetails.ReportDate != null)
                    {
                        htmlBuilder.Append("<tr>");
                        htmlBuilder.Append("<td>");
                        htmlBuilder.Append("Date:" + base.ExportItemsInfo.ReportDetails.ReportDate);
                        htmlBuilder.Append("</td>");
                        htmlBuilder.Append("</tr>");
                    }

               


                    if (base.ExportItemsInfo.ReportDetails.GeneratorName!=null)
                    {
                        htmlBuilder.Append("<tr>");
                        htmlBuilder.Append("<td>");
                        htmlBuilder.Append("Generated By:" + base.ExportItemsInfo.ReportDetails.GeneratorName);
                        htmlBuilder.Append("</td>");
                        htmlBuilder.Append("</tr>");
                    }


                    if (ExportItemsInfo.ReportDetails.ReportHeaders != null)
                    {
                        htmlBuilder.Append("<tr>");
                        foreach (var item in base.ExportItemsInfo.ReportDetails.ReportHeaders)
                        {
                            htmlBuilder.Append("<td>");
                            htmlBuilder.Append(item.Name + ":" + item.Value);

                            htmlBuilder.Append("</td>");
                        }

                        htmlBuilder.Append("</tr>");
                    }


                  //  htmlBuilder.Append("</B>");

                    htmlBuilder.Append("</table>");
                    htmlBuilder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
                    htmlBuilder.Append("style='border: solid 1px Black; font-size: small;'>");

                    //Create Header Row
                    htmlBuilder.Append("<tr align='left' valign='top'>");


                    for (int i = 0; i < input.VisibleFieldCount; i++)
                    {

                        htmlBuilder.Append("<td align='left' valign='top'>");
                        htmlBuilder.Append(input.GetName(i) );
                        htmlBuilder.Append("</td>");
                    }
                    

                    htmlBuilder.Append("</tr>");

                    IsReportStarted = true;

                }

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        public override bool ExportReportData (DbDataReader input)
        {
            Boolean result = false;
            try
            {
                htmlBuilder.Append("<tr align='left' valign='top'>");
                  for (int i = 0; i < input.VisibleFieldCount; i++)
                    
                {
                   

                    //foreach (DataColumn targetColumn in targetTable.Columns)
                    //{
                        htmlBuilder.Append("<td align='left' valign='top'>");
                        htmlBuilder.Append( input.GetValue (i).ToString ());
                        htmlBuilder.Append("</td>");
                    //}

                   
                }

                  htmlBuilder.Append("</tr>");
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        public override bool EndExport ()
        {
            Boolean result = false;
            try
            {
                //Create Bottom Portion of HTML Document
                htmlBuilder.Append("</table>");
                htmlBuilder.Append("</body>");
                htmlBuilder.Append("</html>");

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        public override bool SaveReport ()
        {

            Boolean result = false;
            try
            {

                File.WriteAllText(System.IO.Path.Combine(base.ExportItemsInfo.ReportDetails.ExportPath,base.ExportItemsInfo.ReportDetails.ReportName + "." + base.ExportItemsInfo.ReportDetails.ExportFormat.ToString ()), htmlBuilder.ToString());

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }
    }
}
