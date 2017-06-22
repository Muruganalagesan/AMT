using AMT.ReportingInterfaces.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common ;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.Reflection;
using AMT.Logger;
using AMT.Common.Constants;
using DocumentFormat.OpenXml.Drawing;
using System.IO;
namespace AMT.DataAccess.Export
{
  public  class ExcelExport :ExportBase
    {
      public ExcelExport (ExportInfo item) : base(item) { }

      SpreadsheetDocument spreadsheetDocument = null;

      WorksheetPart worksheetPart = null;
      Worksheet worksheet = null;
      SheetData sheetData = null;
        public override bool StartExport (DbDataReader input)
        {
            Boolean result = false;
            try
            {
                if (!IsReportStarted)
                {
                    spreadsheetDocument = SpreadsheetDocument.Create(System.IO.Path.Combine(base.ExportItemsInfo.ReportDetails.ExportPath , base.ExportItemsInfo.ReportDetails.ReportName + ".xlsx"), SpreadsheetDocumentType.Workbook);
           // Add a WorkbookPart to the document.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();

            // Add a WorksheetPart to the WorkbookPart.
            worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet()
            {   Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1, Name =  base.ExportItemsInfo.ReportDetails.ReportName
            };
            sheets.Append(sheet);


          worksheet = new Worksheet();
          sheetData = new SheetData();
            Row row = new Row();
          

                    for (int i = 0; i < input.VisibleFieldCount; i++)
                    {
                          Cell cell = new Cell(){ DataType = CellValues.String,CellValue = new CellValue(input.GetName(i)) };
                      
                         row.Append(cell);
                    }


                 sheetData.Append(row);

         
                    
                    IsReportStarted =true ;
                    
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

                Row row = new Row();
                for (int i = 0; i < input.VisibleFieldCount; i++)
                {

                    Cell cell = new Cell() { DataType = CellValues.String, CellValue = new CellValue(input.GetValue(i).ToString()) };

                        row.Append(cell);
                    
                  

                }
                sheetData.Append(row);
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
                worksheet.Append(sheetData);


                worksheetPart.Worksheet = worksheet;
                // Close the document.

                spreadsheetDocument.WorkbookPart.Workbook.Save();
               
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
                spreadsheetDocument.Close();
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
           
        }


        





    }
}
