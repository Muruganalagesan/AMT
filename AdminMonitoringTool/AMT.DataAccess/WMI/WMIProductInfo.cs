using AMT.Common.WMI;
using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace AMT.DataAccess.WMI
{
    public class WMIProductInfo : WMIActionBase
    {
      

        List<ProductInfo> productInfoItems = new List<ProductInfo>();

     

        public override bool CollectReportData ()
        {

            Boolean result = false;
            try
            {



            // productInfoItems.Clear();



                //List<String> test = InputConnectionInfo.DatabaseFields;

                foreach (ManagementObject mo in searcher.Get().AsParallel())
                {
                   

                    ProductInfo productInfo = new ProductInfo() { };
                    foreach (String itemProp in InputConnectionInfo.WMIFields)
                    {
                       
                        productInfo.GetType().GetProperty(itemProp).SetValue(productInfo, (WMIQueryBuilder.GetValue(mo, itemProp)), null);

                    }
                    productInfo.TimeStamp = InputConnectionInfo.TimeStamp;
                    productInfo.SystemName = MachineDetails.ServerName;

                    UpdateStatus(productInfo.Name);

                    productInfoItems.Add(productInfo);
                    if (IsCancelRequested)
                        break;
                }

                result = true;

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        public override bool StoreData (DbStorageBase inputType, WMIConnectionInfo ConnectionInfo)
        {

            Boolean result = false;
            try
            {

                inputType.StoreData<ProductInfo>(productInfoItems, ConnectionInfo);

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

   
        //public override WMIConnectionInfo InputConnectionInfo
        //{
        //    get;
        //    set;
        //}



        //public override MachineInfo MachineDetails
        //{
        //    get;
        //    set;
        //}


        public override DataTable GetReportData ()
        {

            DataTable result = null;
            try
            {
                result = AMT.Common.WMI.WMIQueryBuilder.ToDataTable<ProductInfo>(productInfoItems  );
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }



        public override bool DoAction ()
        {
            Boolean result=false ;

            try
            {
                UpdateRemoteActionStatus("Performing action for " + MachineDetails.ServerName);

                RemoteMSI(base.MachineDetails.ServerName, base.MachineInfo.RemoteActionInfo.RemoteShareLocation, "", base.MachineDetails.UserName, base.MachineDetails.Password, base.MachineDetails.DomainName);
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }


        public void RemoteMSI(string computerName, string msiPath, string commandline, string username, string password, string domainName)
        {
            ManagementScope scope = null;
            try
            {

                ConnectionOptions connection =

                new ConnectionOptions();

                // connection.Authority = "kerberos:" + domain + @"\" + machine;
                if (!string.IsNullOrEmpty(username))
                {
                    connection.Username = username;

                    if (!string.IsNullOrEmpty(password))
                        connection.Password = password;

                    connection.Impersonation = ImpersonationLevel.Impersonate;

                    connection.Authentication = AuthenticationLevel.Default;

                    connection.EnablePrivileges = true;

                    if (domainName == null || domainName == string.Empty)
                    {

                        /// connection.Username = computerName + "\\" + username;

                        connection.Authority = null;

                    }

                    else
                    {

                        //connection.Username = username;

                        connection.Authority = "NTLMdomain:" + domainName;

                    }

                    scope = new ManagementScope(@"\\" + computerName + @"\root\CIMV2", connection);
                }

                else
                {

                    scope = new ManagementScope(@"\\" + computerName + @"\root\CIMV2");
                }
                scope.Connect();

                //define path for the WMI class

                ManagementPath p =

                new ManagementPath("Win32_Product");

                //define new instance

                ManagementClass classInstance = new ManagementClass(scope, p, null);

                // Obtain in-parameters for the method

                ManagementBaseObject inParams = classInstance.GetMethodParameters("Install");

                // Add the input parameters.

                inParams["AllUsers"] = true; //to install for all users

                inParams["Options"] = commandline; //paramters must be in the format “property=setting“

                inParams["PackageLocation"] = msiPath; //source file must be on the remote machine

                // Execute the method and obtain the return values.

               ManagementBaseObject outParams = classInstance.InvokeMethod("Install", inParams, null);

                // List outParams

                UpdateRemoteActionStatus("Attempting installation action.");

               string retVal = outParams["ReturnValue"].ToString();


               // string retVal = "0";
               

                string msg = null;

                switch (retVal)
                {

                    case "0":

                        msg = "The installation completed successfully.";

                        break;

                    case "2":

                        msg = "The system cannot find the specified file. \n\r\n\r" + msiPath;

                        break;

                    case "3":

                        msg = "The system cannot find the path specified. \n\r\n\r" + msiPath;

                        break;

                    case "1619":

                        msg = "This installation package \n\r\n\r " + msiPath + "\n\r\n\rcould not be opened, please verify that it is accessible.";

                        break;

                    case "1620":

                        msg = "This installation package \n\r\n\r " + msiPath + "\n\r\n\rcould not be opened, please verify that it is a valid MSI package.";

                        break;

                    default:

                        msg = "Please see... \n\r\n\r http://msdn.microsoft.com/library/default.asp?url=/library/en-us/msi/setup/error_codes.asp \n\r\n\rError code: " + retVal;

                        break;




                }
                UpdateRemoteActionStatus("Status-->" + msg);

                // Display outParams
                AMTLogger.WriteToLog("Installation report-->" + msg);
                //  MessageBox.Show(msg, "Installation report");

            }

            catch (ManagementException me)
            {

                UpdateRemoteActionStatus("Error-->" + me.Message);
                AMTLogger.WriteToLog(me.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);

                // MessageBox.Show(me.Message, "Management Exception");

            }

            catch (COMException ioe)
            {
                UpdateRemoteActionStatus("Error-->" + ioe.Message);
                AMTLogger.WriteToLog(ioe.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
                // MessageBox.Show(ioe.Message, "COM Exception");

            }

            catch (Exception e)
            {
                UpdateRemoteActionStatus("Error-->" + e.Message);
                AMTLogger.WriteToLog(e.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

        }

    }
}
