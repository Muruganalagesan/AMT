﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using AMT.Common.WMI;
using AMT.DataAccess.Factory;
using AMT.Logger;
using AMT.ReportingInterfaces.Export;
using AMT.ReportingInterfaces.WMI;
using AMT.ReportingInterfaces;

namespace AMT.Manager.WMIManagers
{
   

    public class WMIUsersManager : WMIManagerBase
    {

        //WMI Win32_UserAccount

        //Table Users


        WMIFactory reportFactory = new WMIFactory();


        public override string TableName
        {
            get
            {
                return "Users";
            }

        }

        public override string TableQuery
        {
            get
            {
                return "Select " + WMIQueryBuilder.GetReportQuery<UserAccountInfo>(new UserAccountInfo(), ReportingInterfaces.EnumHelper.QueryType.Database) + " from " + TableName;
            }

        }

        public override string WMIQuery
        {
            get
            {
                return "Select " + WMIQueryBuilder.GetQuery<UserAccountInfo>(new UserAccountInfo(), ReportingInterfaces.EnumHelper.QueryType.WMI) + " from " + WMIClass;
            }


        }

        public override WMIMachineInfo wmiMachineInfo
        {
            get;
            set;

        }

        public override bool Collect()
        {
            Boolean result = false;

            try
            {
                this.wmiMachineInfo.MachineConnectionInfo.TableName = TableName;
                this.wmiMachineInfo.MachineConnectionInfo.TableQuery = TableQuery + WhereQuery;
                this.wmiMachineInfo.MachineConnectionInfo.WMIClass = WMIClass;
                this.wmiMachineInfo.MachineConnectionInfo.WMIQuery = WMIQuery;
                this.wmiMachineInfo.MachineConnectionInfo.DatabaseFields = DatabaseFields;
                this.wmiMachineInfo.MachineConnectionInfo.WMIFields = WMIFields;

                this.wmiMachineInfo.MachineConnectionInfo.InsertQuery = InsertQuery;
                this.wmiMachineInfo.MachineConnectionInfo.CustomFields = CustomFields;


                reportFactory.InitWMIDataCollection(this.wmiMachineInfo);

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        public override string WMIClass
        {
            get
            {
                return "Win32_UserAccount";
            }

        }

        public override List<string> WMIFields
        {
            get
            {
                return WMIQueryBuilder.GetProperties<UserAccountInfo>(new UserAccountInfo(), ReportingInterfaces.EnumHelper.QueryType.WMI);
            }

        }

        public override List<string> DatabaseFields
        {
            get
            {
                return WMIQueryBuilder.GetProperties<UserAccountInfo>(new UserAccountInfo(), ReportingInterfaces.EnumHelper.QueryType.Database);
            }

        }

        public override string InsertQuery
        {
            get
            {
                return "Insert into " + TableName + "(" + WMIQueryBuilder.GetQuery<UserAccountInfo>(new UserAccountInfo(), ReportingInterfaces.EnumHelper.QueryType.Database) + " ) values(" + WMIQueryBuilder.GetQuery<UserAccountInfo>(new UserAccountInfo(), ReportingInterfaces.EnumHelper.QueryType.Database, "@") + ")";
            }

        }

        public override List<string> ReportTabs
        {
            get
            {
                return new List<string>() { "Applications", "Managment" };
            }

        }

        public override System.Data.DataTable FetchReportData()
        {
            DataTable results = new DataTable();
            try
            {
                results = reportFactory.GetWMIReportData(this.wmiMachineInfo);
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return results;
        }

        public override List<string> CustomFields
        {
            get
            {

                return WMIQueryBuilder.GetFields<UserAccountInfo>(new UserAccountInfo(), ReportingInterfaces.EnumHelper.QueryType.Database);
            }
        }




        public override bool ExportReportData(ExportInfo exportInfo)
        {
            Boolean result = false;

            try
            {
                reportFactory.ExportReportData(exportInfo);
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }


        public override string WhereQuery
        {
            get
            {

                return " Where TimeStamp=" + Common.Utility.Quotes(wmiMachineInfo.MachineConnectionInfo.TimeStamp);

            }
        }
        public override Dictionary<String, String> ReportCategories
        {
            get
            {

                return new Dictionary<String, String>() { 
                {"Applications",EnumHelper.WMIReportCategory.Application.ToString () },
                {"HotFixes",EnumHelper.WMIReportCategory.QuickFix.ToString () }
               
                };
                // return new List<string>() { "Applications", "HotFixes" };
            }

        }


    }
}
