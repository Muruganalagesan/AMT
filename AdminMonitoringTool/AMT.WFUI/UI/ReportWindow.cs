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
using System.Reflection;
using AMT.Logger;
using AMT.WFUI.UI;
using AMT.WFStatusUpdater;
using System.IO;

namespace AMT.WFUI
{
		public partial class ReportWindow: Form {
			public ReportWindow(EnumHelper.WMIReportCategory inputCategory,EnumHelper.Mode Mode=EnumHelper.Mode.Collection) {
				InitializeComponent();

				this.ReportCategory = inputCategory;

				this.ReportMode = Mode;

				this.Text = inputCategory.ToString() +  " Reports";
			}
			public ProgressDialog progressDialog = new ProgressDialog();
			InitializeWMICollection ReportObject = null;
			List<ReportUIInit> ServerItems = new List<ReportUIInit>();
			DBConnectionInfo dbConnectionInfo = new DBConnectionInfo();
			WMIMachineInfo wmimachineInfo = new WMIMachineInfo();

			public EnumHelper.WMIReportCategory GetReportCategoryFromName(String Name) {
				EnumHelper.WMIReportCategory reportCategroy=0;
				try
				{

						string[] names = Enum.GetNames(typeof(EnumHelper.WMIReportCategory));
						EnumHelper.WMIReportCategory[] values = (EnumHelper.WMIReportCategory[])Enum.GetValues(typeof(EnumHelper.WMIReportCategory));

						for (int i = 0; i < names.Length; i++)
						{

								if (names[i].ToString() == Name)
								{
										reportCategroy = values[i];
								}
							 // print(names[i], values[i]);
						}

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}

				return reportCategroy;
			}

			private void AddTabs(Dictionary<String, String> TabNames) {
				try
				{
						tcReports.TabPages.Clear();
						foreach (var tabName in TabNames)
						{
								this.tcReports.TabPages.Add(tabName.Key.ToString () , tabName.Value );
						}



				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void Collect(List<MachineInfo> machines) {
				ShowProgressDialog(machines);



				// else
			}

			private void CollectConnectionParamters(List<MachineInfo> machinesWithConnectionDetails, List<MachineInfo> machineItems) {
				foreach (var machine in machineItems)
				{
						if (!ConnectionManagerUtil.IsProfileConnected(machine.DomainName, machine.ServerName))
						{

								ConnectionManager connectionManger = new ConnectionManager(machine.DomainName, machine.ServerName);

								if (connectionManger.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
								{

										machinesWithConnectionDetails.Add(ConnectionManagerUtil.GetConnectionDetails(machine.DomainName, machine.ServerName));
										// StartReportCollection(machine.DomainName, machine.ServerName);


								}
								else
										AMTLogger.WriteToLog("Connection cancelled for " + machine.DomainName + "/" + machine.ServerName);

						}
						else
						{
								machinesWithConnectionDetails.Add(ConnectionManagerUtil.GetConnectionDetails(machine.DomainName, machine.ServerName));
						}
						// StartReportCollection();

				}
			}

			private void CollectReports(TreeNode e) {
				try
				{

						if (e.Name.Contains(ReportConstants.ServerKey))
						{
								reportGrid.DataSource = null;

								if (e.Name.Contains(ReportConstants.ServerKey))
								{
										Collect( new List<MachineInfo >(){ new MachineInfo (){DomainName= e.Parent.Text ,ServerName=e.Text }});
								}


						}

						else if (e.Name.Contains(ReportConstants.CustomScanKey))
						{

								if(ServerItems .Count ==0)
								ServerItems = new AMT.Manager.InitailizeApp().InitReportWindow(Utility.LoadDbConnectionInfo());
								DomainScanner domainScanner = new DomainScanner(e.Parent.Text ,ServerItems );
								if (domainScanner.ShowDialog(this) == DialogResult.OK)
								{
										//foreach (var machineItems in domainScanner.ChoosenMachines )
										//{

										Collect(domainScanner.ChoosenMachines);

											 // StartReportCollection();

										//}
								}
						}

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private InitializeWMICollection DoAction(List<MachineInfo> machineInfoItems,Boolean IsRefresh) {
				try
				{
						WMIMachineInfo machineInfo = InitParamCollection(machineInfoItems, IsRefresh);

						machineInfo.CommandMode = EnumHelper.Mode.Action;
						//machineInfo.OwnerHandle = this.Handle;

						ReportObject = new AMT.Manager.ReportManagers.InitializeWMICollection();

						Boolean result = ReportObject.CollectReport(machineInfo);
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}

				return ReportObject;
			}

			private InitializeWMICollection DoReportCollection(List<MachineInfo > machineItems, Boolean IsRefresh=false) {
				try
				{
						WMIMachineInfo machineInfo = InitParamCollection(machineItems , IsRefresh);

						machineInfo.backgroundWorker = progressDialog.worker ;

						Boolean result = ReportObject.CollectReport(machineInfo);
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}


				return ReportObject;
			}

			private void DomainTreeView_AfterExpand(object sender, TreeViewEventArgs e) {
				try
				{
						if (e.Node.Name.Contains(ReportConstants.DomainKey))
						{
								if (e.Node.Nodes.ContainsKey(ApplicationConstants.LoadingServers))
										e.Node.Nodes[ApplicationConstants.LoadingServers].Remove();

								new Common.CommonUIInfo().EnumerateDomain(ServerItems, e.Node.Text, e.Node, e.Node.Name);
						}
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void DomainTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
					try
					{
							CollectReports(e.Node);

				}


					catch (Exception ex)
					{

							AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
					}
			}

			private String ExportForPreview() {
				String PreviewPath = Path.Combine(ApplicationInfo.ApplicationDocumentPath, "Preview");
				try
				{

						if (!Directory.Exists(PreviewPath))
								Directory.CreateDirectory(PreviewPath);
						ExportInfo item = new ExportInfo()
						{


								ReportDetails = new ReportInfo()
								{
										ExportFormat = EnumHelper.ExportFormat.HTML.ToString(),
										ReportName = this.ReportCategory.ToString(),
										GeneratorName = "Adminstrator",
										ProductName = "AMT",
										ReportDate = DateTime.Now.ToString(),
										ExportPath = PreviewPath

								},
								MachineInfo = wmimachineInfo
						};
						ReportObject.ExportReportData(item);

						PreviewPath = Path.Combine(PreviewPath, this.ReportCategory.ToString() + "." + item.ReportDetails.ExportFormat );
				}
				catch (Exception)
				{

						throw;
				}

				return PreviewPath;
			}

			private void Export_Click(object sender, EventArgs e) {
				try
				{
						String ExportPath = Path.Combine(ApplicationInfo.ApplicationDocumentPath, "Export");
						if (!Directory.Exists(ExportPath))
								Directory.CreateDirectory(ExportPath);
						ExportDialog exportDialog = new ExportDialog(new ReportExportInfo() { ReportName = this.ReportCategory.ToString(), ReportFormat = EnumHelper.ExportFormat.HTML.ToString(), FileLocation = ExportPath });
						if (exportDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
						{

								ExportInfo item = new ExportInfo()
								{


										ReportDetails = new ReportInfo() { ExportFormat = exportDialog.reportExportInfo.ReportFormat, ReportName = exportDialog.reportExportInfo.ReportName, GeneratorName = "Adminstrator", ProductName = "AMT", ReportDate = DateTime.Now.ToString(), ExportPath = exportDialog.txtLocation.Text },
										MachineInfo = wmimachineInfo
								};

								ReportObject.ExportReportData(item);

								MessageBox.Show("Report exported successfully.");
						}

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private WMIMachineInfo InitParamCollection(List<MachineInfo > machineItems ,Boolean IsRefresh = false) {
					//if (userCredential.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					//{
						wmimachineInfo = new WMIMachineInfo()
						{

								ServersList = machineItems,


								MachineConnectionInfo = new WMIConnectionInfo()
								{
										ReportCategory = this.ReportCategory,
										ReportMode = EnumHelper.OperationMode.Interactive,

										TimeStamp = this.ReportCategory.ToString() + Utility.GetReportGuid () ,
										DatabaseConnectionInfo= Utility.LoadDbConnectionInfo ()

								},
								IsRefresh = IsRefresh,
									// CommandMode= EnumHelper.Mode.Action
								CommandMode = EnumHelper.Mode.Collection

						};

				//  }



				return wmimachineInfo;
			}

			private void LoadDomains() {
				try
				{
						DomainTreeView.Nodes.Clear();

						ServerItems.Clear();

						ServerItems = new AMT.Manager.InitailizeApp().InitReportWindow(Utility.LoadDbConnectionInfo());
						new CommonUIInfo().AddDomainsToTree(ServerItems,DomainTreeView,RWImgList);

						//AddDomainsToTree();
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void PreviewReport_Click(object sender, EventArgs e) {
				ReportPreview reportPreview = new ReportPreview();
				try
				{
						reportPreview.FileLocation = ExportForPreview();

						reportPreview.Show(this);
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void PrintDocument(object sender, WebBrowserDocumentCompletedEventArgs e) {
				// Print the document now that it is fully loaded.
				((WebBrowser)sender).Print();

				// Dispose the WebBrowser now that the task is complete.
				((WebBrowser)sender).Dispose();
			}

			private void PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
				try
				{



				}

				catch (Exception exc)
				{
						MessageBox.Show(exc.ToString());
				}
			}

			private void ReportWindow_Load(object sender, EventArgs e) {
				try
				{
						ReportObject = new AMT.Manager.ReportManagers.InitializeWMICollection();

					// AddTabs(ReportObject.GetReportTabs(this.ReportCategory));

						LoadDomains();

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			void ReportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
				try
				{
						reportGrid.DataSource = null;



								reportGrid.DataSource = ReportObject.GetReportData();

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			void Report_DoWork(ProgressDialog sender, DoWorkEventArgs e) {
				List<MachineInfo> machinesWithConnectionDetails = new List<MachineInfo>();


				try
				{
						wmimachineInfo.backgroundWorker = progressDialog.worker;

						List<MachineInfo> machineItems = (List<MachineInfo>)e.Argument;

						//ConnectionManagerUtil.GetConnectionDetails(DomainName ,ServerName )
						CollectConnectionParamters(machinesWithConnectionDetails, machineItems);

						StartReportCollection(machinesWithConnectionDetails);



				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void ShowPreviewDialog() {
				try
				{




				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void ShowProgressDialog(List<MachineInfo > MachineInfoList) {
				progressDialog = new ProgressDialog();


				// inputMachineInfo.backgroundWorker = progressUpdater.progressDialog.worker;
				progressDialog.Argument = MachineInfoList;

				progressDialog.DoWork += Report_DoWork;

				progressDialog.worker.RunWorkerCompleted += ReportWorker_RunWorkerCompleted;

				progressDialog.TopMost = false;
				// progressDialog.Parent  = this;


				progressDialog.Show(this);
			}

			private void StartReportCollection(List<MachineInfo> machineInfoItems) {
				try
				{
						//new List<MachineInfo>() { ConnectionManagerUtil.GetConnectionDetails(DomainName, ServerName) }

						if (ReportMode == EnumHelper.Mode.Collection)
						{

								ReportObject = DoReportCollection(machineInfoItems, IsRefresh);
						}
						else if (ReportMode == EnumHelper.Mode.Action)
								ReportObject = DoAction(machineInfoItems, IsRefresh);
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void tcReports_SelectedIndexChanged(object sender, EventArgs e) {
				try
				{
						TabPage tabpage = tcReports.TabPages[tcReports.SelectedIndex];

						this.ReportCategory = GetReportCategoryFromName(tabpage.Text );

						CollectReports(this.DomainTreeView.SelectedNode);
				}
				catch (Exception)
				{

						throw;
				}



				//Console.WriteLine(tabpage.Name);
			}

			private void toolStripButton3_Click(object sender, EventArgs e) {
				try
				{
						IsRefresh = true;

						CollectReports(DomainTreeView.SelectedNode);


				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void tsServers_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
				try
				{
						if (e.ClickedItem != null)
						{
								//if (e.ClickedItem.Tag.ToString() == "addserver")
								//{
								//}
								//else if (e.ClickedItem.Tag.ToString() == "removeserver")
								//{
								//}
								if (e.ClickedItem.Tag.ToString() == "refreshserver")
								{

										ServerItems.Clear();
										LoadDomains();
								}

						}
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			public Boolean IsRefresh { get; set; }

			public EnumHelper.WMIReportCategory ReportCategory { get; set; }

			public EnumHelper.Mode ReportMode { get; set; }
		}
}
