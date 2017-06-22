using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMT.Common;
using AMT.ReportingInterfaces.WMI;
using AMT.Logger;
using AMT.ReportingInterfaces;
namespace Utilitytester
    {
    class Program
        {
        static void Main (string[] args)
            {
               // ProfileManagerTestCase();


               // LoggingTestCase();

               // PromptTestCase();

              //  NetworkList();

              //  var test= new AMT.Common.Win32Api.NetShareWrapper().EnumNetShares("192.168.1.107");
             //   var test2 = new AMT.Common.Win32Api.NetShareWrapper().EnumNetShares("192.168.0.20");
             //  var test3 = new AMT.Common.Win32Api.NetShareWrapper().EnumNetSharesWithPermission("192.168.1.107");

                //var createdb = new AMT.Manager.InitailizeApp().CreateDatabases(new DBConnectionInfo() {AuthenticationType=EnumHelper.Authentication.SQLAuthentication,DatabaseType=EnumHelper.Databases.SQLServer ,
                //ServerName ="192.168.1.107",UserName ="sa", Password ="corent@123",DatabaseName="AMTTest3"
                //});

                //for (int i = 0; i < 100; i++)
                //{
                //    var time = Utility.GetReportGuid();

                //    Console.WriteLine(time);
                //}
             

                var collectServiceDatat = new AMT.Manager.ReportManagers.InitializeWMICollection().CollectReport(


                    new WMIMachineInfo()
                {
                     ServersList = new List<MachineInfo>() {
                        new MachineInfo { ServerName = "192.168.1.47", UserName = "optra", Password = "!optra!", DomainName = "workgroup" } ,
                            //new MachineInfo { ServerName = "localhost", UserName = "", Password = "", DomainName = "workgroup" }
                     },
                    MachineConnectionInfo = new WMIConnectionInfo()
                    {
                        ReportCategory = EnumHelper.WMIReportCategory.Services,
                        ReportMode = EnumHelper.OperationMode.Interactive,
                           TimeStamp = "Service" + Utility.GetReportGuid (),
                     DatabaseConnectionInfo = new DBConnectionInfo()
                        {
                            AuthenticationType = EnumHelper.Authentication.SQLAuthentication,
                            DatabaseName = "AMTTest",
                            DatabaseType = EnumHelper.Databases.SQLServer,
                            ServerName = "192.168.1.107",
                            UserName = "sa",
                            Password = "corent@123"
                        }
                    
                    }
                        
                   

                });

            //   var newshare = new AMT.Common.Win32Api.NetShareWrapper().EnumNetShares("192.168.1.107");

              // var test13 = new AMT.Common.Win32Api.NetShareWrapper().EnumNetShares("192.168.1.47");
            //  var test131 = new AMT.Common.Win32Api.NetShareWrapper().EnumNetShares("192.168.0.53");
            //    var test4 = new AMT.Common.Win32Api.NetShareWrapper().EnumNetShares("192.168.1.99");

            //  PrintShare(test3);
           //   PrintShare(test131);
              // PrintShare(test131);
             //   AMT.Common.Win32Api.MainConsole.GetSharePermission("192.168.1.107", "c$");

                Console.ReadLine();
            }



        public static  void PrintShare (List< ShareInfo> input)
        {
            Console.WriteLine("*********");
            foreach (var item in input)
            {
                Console.WriteLine(item.Name  );

                //foreach (var perm in item.SharePermissionList)
                //{
                //    Console.WriteLine(perm.Permission);
                    
                //}
                
            }
            Console.WriteLine("*********");
        }


        private static void NetworkList ()
        {
            var test = new AMT.Common.Win32Api.NetServerAPIWrapper().GetNetworkList();


            foreach (var item in test)
            {
                Console.WriteLine("Domain Name-->" + item.DomainName);

                foreach (var item1 in item.Severs)
                {
                    Console.WriteLine("Server Name-->" + item1.ServerName);
                }

            }

            test.Select(t =>
            {

                Console.WriteLine(t.DomainName);
                t.Severs.Select(y =>
                {
                    Console.WriteLine(y.ServerName);
                    return true;

                });


                return true;


            });
        }

        private static void PromptTestCase ()
        {
           // new AMT.Common.ProfileManagment().ShowWindowsCredentialDialog();
        }

        private static void LoggingTestCase ()
        {

            for (int i = 0; i < 10; i++)
            {
                AMTLogger.WriteToLog("Sample for writing", "", 0, AMTLogger.LogInfo.Error);

                AMTLogger.WriteToLog("Sample for writing with Info");
            }
        }

        private static void ProfileManagerTestCase ()
        {
            new AMT.Common.ProfileManagment().AddCredentials("myuser", "myuser", "this is sample");
            new AMT.Common.ProfileManagment().AddCredentials("myuser1", "myuser1", "this is sample1");
            new AMT.Common.ProfileManagment().AddCredentials("myuser2", "myuser2", "this is sample2");


            var testupdate = new AMT.Common.ProfileManagment().UpdateProfile("myuser2", "myuser2", "testing update process");

            var test = new AMT.Common.ProfileManagment().GetCredentials("myuser");

            var ty = new AMT.Common.ProfileManagment().GetCredentialList();

            new AMT.Common.ProfileManagment().DeleteProfile("myuser2");
        }
        }
    }
