using AMT.Logger;
using AMT.ReportingInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;

namespace AMT.Common.WMI
{
    public static  class WMIQueryBuilder
    {
        public static String GetQuery<T> (T inputType, EnumHelper.QueryType input,String precedString="")
        {
            String itemQuery = String.Empty;
            List<String> tempString = new List<string>();
            try
            {


                PropertyDescriptorCollection properties =
                   TypeDescriptor.GetProperties(typeof(T));

                foreach (PropertyDescriptor prop in properties)
                {
                    // wmiitems.Add(prop.DisplayName);

                    if (input == EnumHelper.QueryType.Database)
                        tempString.Add(precedString + prop.DisplayName);

                    else if (input == EnumHelper.QueryType.WMI)
                        tempString.Add(precedString+prop.Name);

                }

                foreach (var item in  typeof(T).GetFields () )
                {
                    if (input == EnumHelper.QueryType.Database)
                     tempString.Add(precedString+item.Name);
                }

                if (String.IsNullOrEmpty(precedString))
                itemQuery = String.Join(",", tempString.ToArray());

                else
                    itemQuery = String.Join(","  , tempString.ToArray());

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return itemQuery;

        }

        public static String GetReportQuery<T> (T inputType, EnumHelper.QueryType input, String precedString = "")
        {
            String itemQuery = String.Empty;
            List<String> tempString = new List<string>();
            try
            {


                PropertyDescriptorCollection properties =
                   TypeDescriptor.GetProperties(typeof(T));

                foreach (PropertyDescriptor prop in properties)
                {
                    // wmiitems.Add(prop.DisplayName);

                    if (input == EnumHelper.QueryType.Database)
                        tempString.Add(precedString + prop.DisplayName);

                    else if (input == EnumHelper.QueryType.WMI)
                        tempString.Add(precedString + prop.Name);

                }
                tempString.Add(precedString + "SystemName");
                //foreach (var item in typeof(T).GetFields())
                //{
                //    if (input == EnumHelper.QueryType.Database)
                //        tempString.Add(precedString + item.Name);
                //}

                if (String.IsNullOrEmpty(precedString))
                    itemQuery = String.Join(",", tempString.ToArray());

                else
                    itemQuery = String.Join(",", tempString.ToArray());

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return itemQuery;

        }


        public static List<String> GetProperties<T> (T inputType, EnumHelper.QueryType input)
        {
            String itemQuery = String.Empty;
            List<String> propertyList = new List<string>();
            try
            {


                PropertyDescriptorCollection properties =
                   TypeDescriptor.GetProperties(typeof(T));

                foreach (PropertyDescriptor prop in properties)
                {
                    // wmiitems.Add(prop.DisplayName);

                    if (input == EnumHelper.QueryType.Database)
                        propertyList.Add(prop.DisplayName);

                    else if (input == EnumHelper.QueryType.WMI)
                        propertyList.Add(prop.Name);

                }


            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return propertyList ;

        }

        public static List<String> GetFields<T> (T inputType, EnumHelper.QueryType input)
        {
            String itemQuery = String.Empty;
            List<String> propertyList = new List<string>();
            try
            {



                foreach (var prop in typeof (T).GetFields ())
                {
                    // wmiitems.Add(prop.DisplayName);

                    if (input == EnumHelper.QueryType.Database)
                        propertyList.Add(prop.Name);

                    

                }


            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return propertyList;

        }

        public static String GetValue (ManagementObject input, string propertyName)
        {
            String result = String.Empty;
            try
            {
                if (input[propertyName] != null)
                {

                    var resultType = input[propertyName];

                    if (resultType.GetType().Name  == "String[]")
                    {
                       // ((String[])resultType).AsEnumerable ().Join( 

                       result= String.Join (",",(String[])resultType);

                      
                    }
                    else
                        result = resultType.ToString ();
                    
                }
                else
                    result = String.Empty;
                if (result.Contains("_"))
                    result = result.Replace("_", " ");

              //  result = input[propertyName] != null ? input[propertyName].ToString() : String.Empty;
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            return result;
        }


        public static String GetPropertyValue<T> (T inputType,String Name)
        {

            String result = String.Empty;

            result = inputType.GetType().GetProperty(Name).GetRawConstantValue().ToString();

            return result;

        }

        public static DataTable ToDataTable<T> (List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

           // long length=0;
            try
            {
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                FieldInfo field = typeof(T).GetField("SystemName");

                if(field!=null )
                dataTable.Columns.Add("SystemName");
               
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names

                    dataTable.Columns.Add(prop.Name);
                }

                long index = Props.Length;
               // long StartIndex = 0;

                Boolean IsSpecial = false;

                if (field != null)
                {
                    index = index + 1;
                    //StartIndex = 1;
                    IsSpecial = true;
                }
                foreach (T item in items)
                {
                   

                    var values = new object[index];

                    if (field != null)
                    {
                        values[0] = field.GetValue(item);
                      
                    }



                    for (long i = 0; i < Props.Length; i++)
                    {
                        long tempindex = i;
                        //inserting property values to datatable rows
                        if (IsSpecial)
                            tempindex = i + 1;
                        values[tempindex] = Props[i].GetValue(item, null);
                    }
               

                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
           
            return dataTable;
        }

        public static DataTable FlipDataTable (DataTable myDataTable )
        {
            DataTable table = new DataTable();

            try
            {
                table.Columns.Add("Name");

                table.Columns.Add("Value");


                for (int i = 0; i <= myDataTable.Rows.Count-1; i++)
                {

                    DataRow r;
                    for (int k = 0; k < myDataTable.Columns.Count; k++)
                    {
                        r = table.NewRow();
                        r[0] = myDataTable.Columns[k].ToString();
                        for (int j = 1; j <= myDataTable.Rows.Count; j++)
                        { r[j] = myDataTable.Rows[j - 1][k]; }
                        table.Rows.Add(r);
                    }
                    
                }
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
           
               



                return table;
        }


    }
}
