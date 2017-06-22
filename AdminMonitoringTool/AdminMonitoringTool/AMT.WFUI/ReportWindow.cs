using AMT.Common;
using AMT.Common.Constants;
using AMT.Manager.ReportManagers;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.Export;
using AMT.ReportingInterfaces.WMI;
using AMT.WFUI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AMT.WFUI
{
    public partial class ReportWindow : Form
    {
         List<ReportUIInit> ServerItems = new List<ReportUIInit>();

         WMIMachineInfo wmimachineInfo = new WMIMachineInfo();

       public  EnumHelper.WMIReportCategory ReportCategory { get; set; }


       InitializeWMICollection ReportObject = null;

       public Boolean IsRefresh { get; set; }

        //public ReportWindow ()
        //{
        //    InitializeComponent();
           

        //}

        public ReportWindow (EnumHelper.WMIReportCategory inputCategory)
        {
            InitializeComponent();

            this.ReportCategory = inputCategory;

            this.Text = inputCategory.ToString() +  " Reports";
        }

        

        private void ReportWindow_Load (object sender, EventArgs e)
        {

          
            try
            {

                LoadDomains();

                DoAction();
                

              
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void LoadDomains ()
        {

            DomainTreeView.Nodes.Clear();
            //ServerItems = new AMT.Manager.InitailizeApp().InitReportWindow(new DBConnectionInfo()
            //{
            //    AuthenticationType = EnumHelper.Authentication.SQLAuthentication,
            //    DatabaseName = "AMTTest3",
            //    DatabaseType = EnumHelper.Databases.SQLServer,
            //    ServerName = "192.168.0.35",
            //    UserName = "sa",
            //    Password = "MSSQL35$"
            //});
            ServerItems = new AMT.Manager.InitailizeApp().InitReportWindow(new DBConnectionInfo()
            {
               // AuthenticationType = EnumHelper.Authentication.,
                DatabaseName = "AMTTest",
                DatabaseType = EnumHelper.Databases.SQLServerCE,

               

                DBPath = AppDomain.CurrentDomain.BaseDirectory 
               // ServerName = "192.168.0.35",
               // UserName = "sa",
               // Password = "MSSQL35$"
            });

            //  new AMT.Manager.InitailizeApp().InitReportWindow ()
            new Common.CommonUIInfo().LoadDomains(ServerItems, DomainTreeView, RWImgList);

          
        }

     
        private void DomainTreeView_AfterExpand (object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name.Contains(ReportConstants.DomainKey))
            {
                if (e.Node.Nodes.ContainsKey("Loading servers"))
                    e.Node.Nodes["Loading servers"].Remove();

                new Common.CommonUIInfo().EnumerateDomain(ServerItems, e.Node.Text, e.Node, e.Node.Name);
            }
        }

        private void tsServers_ItemClicked (object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                if (e.ClickedItem.Tag == "addserver")
                {
                }
                else if(e.ClickedItem.Tag =="removeserver")
                {
                }
                else if (e.ClickedItem.Tag == "refreshserver")
                {

                    ServerItems.Clear();
                    LoadDomains();
                }

            }
        }

        private void DomainTreeView_NodeMouseClick (object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {

                CollectReports(e.Node);


          }

            
            catch (Exception)
            {

                throw;
            }
        }

        private void CollectReports (TreeNode e)
        {

            try
            {
                if (e.Name.Contains(ReportConstants.ServerKey))
                {

                    ReportObject = DoReportCollection(IsRefresh);

                    reportGrid.DataSource = null;


                //    reportGrid.DataSource =ReportObject.GetReportsInfo<T>();



                    //reportGrid.DataSource = AMT.Common.WMI.WMIQueryBuilder.FlipDataTable(ReportObject.GetReportData());

                    reportGrid.DataSource = ReportObject.GetReportData();

                }
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }


        private InitializeWMICollection DoAction ()
        {
            WMIMachineInfo machineInfo = InitParamCollection(IsRefresh);

            machineInfo.CommandMode = EnumHelper.Mode.Action;


            ReportObject = new AMT.Manager.ReportManagers.InitializeWMICollection();

            Boolean result = ReportObject.CollectReport(machineInfo);
            return ReportObject;
        }

        private InitializeWMICollection DoReportCollection (Boolean IsRefresh=false )
        {
          
            try
            {
                WMIMachineInfo machineInfo = InitParamCollection(IsRefresh);


                ReportObject = new AMT.Manager.ReportManagers.InitializeWMICollection();

                Boolean result = ReportObject.CollectReport(machineInfo);
            }
            catch (Exception)
            {
                
                throw;
            }

         
            return ReportObject;
        }

        private WMIMachineInfo InitParamCollection (Boolean IsRefresh=false )
        {
             //objWMIConnectionInfo = new WMIConnectionInfo()
             //   {
             //       ReportCategory = this.ReportCategory,
             //       ReportMode = EnumHelper.OperationMode.Interactive,

             //       TimeStamp = this.ReportCategory.ToString() + Utility.GetReportGuid(),
             //       dbConnectionInfo = new DBConnectionInfo
             //       {
             //           AuthenticationType = EnumHelper.Authentication.SQLAuthentication,
             //           DatabaseName = "AMTTest3",
             //           DatabaseType = EnumHelper.Databases.SQLServer,
             //           ServerName = "192.168.0.35",
             //           UserName = "sa",
             //           Password = "MSSQL35$"
             //       }

             //   }


     wmimachineInfo = new WMIMachineInfo()
            {

                ServersList = new List<MachineInfo>(){
                         

                         //Orginal code
                         new MachineInfo{
                             DomainName="workgroup" ,ServerName="10.70.70.48",Password="corent123$$"  ,UserName="administrator"
                         },

                        new MachineInfo { ServerName = "192.168.1.47", UserName = "optra", Password = "!optra!", DomainName = "workgroup" } 
                     
                     },


                MachineConnectionInfo = new WMIConnectionInfo()
                {
                    ReportCategory = this.ReportCategory,
                    ReportMode = EnumHelper.OperationMode.Interactive,

                    TimeStamp = this.ReportCategory.ToString() + Utility.GetReportGuid(),
                    DatabaseConnectionInfo = new DBConnectionInfo
                    {
                        //AuthenticationType = EnumHelper.Authentication.SQLAuthentication,
                        DatabaseName = "AMTTest",
                        DatabaseType = EnumHelper.Databases.SQLServerCE,

                        DBPath =AppDomain.CurrentDomain.BaseDirectory 
                      //  ServerName = "192.168.0.35",
                     //   UserName = "sa",
                      //  Password = "MSSQL35$"
                    }

                },
                IsRefersh =IsRefresh 

            };
            return wmimachineInfo;
        }

        private void toolStripButton3_Click (object sender, EventArgs e)
        {

            try
            {
                IsRefresh = true;

                CollectReports(DomainTreeView.SelectedNode);


            }
            catch (Exception ex )
            {
                
                throw ex;
            }

        }

        private void Export_Click (object sender, EventArgs e)
        {
            ExportInfo item = new ExportInfo() { 
                
                //ReportDetails= new ReportInfo(){ ExportFormat=  EnumHelper.ExportFormat.HTML  ,ReportName = "TestReport",GeneratorName="Adminstrator",ProductName="AMT",ReportDate=DateTime.Now .ToString ()},
                ReportDetails = new ReportInfo() { ExportFormat = EnumHelper.ExportFormat.CSV , ReportName = "TestReport", GeneratorName = "Adminstrator", ProductName = "AMT", ReportDate = DateTime.Now.ToString() },
                
                MachineInfo = wmimachineInfo };
            try
            {
                ReportObject.ExportReportData (item);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       
    }
}
