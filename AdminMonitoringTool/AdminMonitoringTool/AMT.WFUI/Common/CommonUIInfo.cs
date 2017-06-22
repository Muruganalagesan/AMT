using AMT.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AMT.Common;
using AMT.Common.Win32Api;
using AMT.Common.Constants;
using System.IO;
using AMT.ReportingInterfaces;
using AMT.WFUI.UI;
namespace AMT.WFUI.Common
{
   public  class CommonUIInfo
    {


       public Boolean LoadDomains (List<ReportingInterfaces.ReportUIInit> InputItems,TreeView inputTree,ImageList imageItems)
       {
           Boolean result = false;
           try
           {
               inputTree.ImageList = imageItems;
               if (!inputTree.Nodes.ContainsKey("Networks"))
               {
                   inputTree.Nodes.Add("Networks", "Networks", 2, 2);
                
               }
             //  inputTree.Nodes.Add( RootItem);

               foreach (var item in  InputItems )
               {
                  TreeNode domainItem= new TreeNode(item.DomainName );
                  // domainItem 
                  domainItem.ImageKey = "domain";
                  domainItem.ImageIndex = 0;
                  domainItem.SelectedImageIndex = 0;
                  domainItem.Name = ReportConstants.DomainKey + item.DomainName;

                  if (!inputTree.Nodes["Networks"].Nodes.ContainsKey(domainItem.Name))
                  {
                    
                      domainItem.Nodes.Add("Loading servers", "enum");
                      inputTree.Nodes["Networks"].Nodes.Add(domainItem);
                      inputTree.Nodes["Networks"].Expand();
                  }
                   
               }
               

            //   LoadMockUpServer(inputTree);


           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }

       private static void LoadMockUpServer (TreeView inputTree)
       {

          
         //  TreeNode RootItem = new TreeNode("Networks");

          // RootItem.ImageKey = "root";
           if(!inputTree.Nodes.ContainsKey("Networks") )
           inputTree.Nodes.Add("Networks", "Networks").ImageKey ="root";

          

           foreach (var item in new List<String>() { "Home", "Test", "Challenger", "Discovery" })
           {
               TreeNode domainItem = new TreeNode(item);
               // domainItem 
               domainItem.ImageKey = "domain";
               domainItem.ImageIndex = 0;
               domainItem.Name = ReportConstants.DomainKey + item;

               domainItem.Nodes.Add("Loading servers", "enum");
               inputTree.Nodes["Networks"].Nodes.Add(domainItem);

               // inputTree.Nodes.Add(item, item,"domain");

           }
       }

       public Boolean EnumerateDomain (List<ReportingInterfaces.ReportUIInit> InputItems,String DomainName, TreeNode domainNode,String key)
       {

           Boolean result = false;
           try
           {

               if (key.Contains(ReportConstants.DomainKey))
               {
                   foreach (var serverInfo in InputItems.Where (t=>t.DomainName ==DomainName ))
                   {
                       if (!domainNode.Nodes.ContainsKey( ReportConstants.CustomScanKey + ReportConstants.CustomScan))
                           domainNode.Nodes.Add( ReportConstants.CustomScanKey + ReportConstants.CustomScan, ReportConstants.CustomScan, 3, 3);


                       if (!domainNode.Nodes.ContainsKey(ReportConstants.ServerKey  + serverInfo.ServerName))
                       {
                           domainNode.Nodes.Add(ReportConstants.ServerKey + serverInfo.ServerName, serverInfo.ServerName, 1, 1);
                       }

                       

                       
                   } 
               }

           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }
           return result;
       }


       DBConnectionInfo dbConnectionInfo = new DBConnectionInfo();


       public  void InitApplication ()
       {
           try
           {

               ShowDBSettings();
               if (!Directory.Exists(ApplicationInfo.ApplicationDocumentPath))
               {
                   Directory.CreateDirectory(ApplicationInfo.ApplicationDocumentPath);

               }
               if (!Directory.Exists(Path.Combine(ApplicationInfo.ApplicationDocumentPath, "Queries")))
               {
                   CopyDirectoryContents(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Queries"), Path.Combine(ApplicationInfo.ApplicationDocumentPath, "Queries"));
               }
               

               new AMT.Manager.InitailizeApp().CreateDatabases(dbConnectionInfo);

             
           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }
       }



       private Boolean   ShowDBSettings ()
       {
           Boolean result = false;

           try
           {

               if (!IsDatabaseConfigured())
               {
                   SettingsManager settingsManager = new SettingsManager();
                   if (settingsManager.ShowDialog() == DialogResult.OK)
                   {
                    dbConnectionInfo =Utility.LoadDbConnectionInfo();

                       result = true;
                   }
               }
               else
               {
                   dbConnectionInfo = Utility.LoadDbConnectionInfo();
               }


           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }




       private Boolean IsDatabaseConfigured ()
       {
           Boolean  result=false ;
           try
           {
               if (File.Exists(ApplicationInfo.DBProfileName))
                   result = true;

           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }

           return result;
       }


       private  void CopyDirectoryContents (string strSource, string strDestination)
       {
           try
           {
               if (!Directory.Exists(strDestination))
               {
                   Directory.CreateDirectory(strDestination);
               }
               DirectoryInfo dirInfo = new DirectoryInfo(strSource);
               FileInfo[] files = dirInfo.GetFiles();
               foreach (FileInfo tempfile in files)
               {
                   tempfile.CopyTo(Path.Combine(strDestination, tempfile.Name));
               }
               DirectoryInfo[] dirctororys = dirInfo.GetDirectories();
               foreach (DirectoryInfo tempdir in dirctororys)
               {
                   CopyDirectoryContents(Path.Combine(strSource, tempdir.Name), Path.Combine(strDestination, tempdir.Name));
               }
           }
           catch (Exception ex)
           {

               AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
           }


       }


   


    }
}
