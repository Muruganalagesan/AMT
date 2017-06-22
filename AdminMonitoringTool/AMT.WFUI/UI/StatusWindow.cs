using AMT.Common;
using AMT.Logger;
using AMT.Manager.ReportManagers;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.WMI;
using AMT.WFStatusUpdater;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace AMT.WFUI.UI
{
		public partial class StatusWindow: Form {
			public StatusWindow(RemoteActionInfo remoteactionInfo) {
				InitializeComponent();

				this.remoteactionInfo = remoteactionInfo;
			}
			public ProgressDialog progressDialog = new ProgressDialog();
			InitializeWMICollection ReportObject = null;

			public void ShowProgressDialog(RemoteActionInfo remoteActionInfo) {
				progressDialog = new ProgressDialog();



				progressDialog.Argument = remoteActionInfo;

				progressDialog.DoWork += Report_DoWork;

				progressDialog.worker.RunWorkerCompleted += ReportWorker_RunWorkerCompleted;

				progressDialog.worker.ProgressChanged += worker_ProgressChanged;

				progressDialog.TopMost = false;
				// progressDialog.Parent  = this;

				progressDialog.ProgressBar.Visible = true;
				progressDialog.ProgressBar.Style = ProgressBarStyle.Marquee;

				progressDialog.SetCaption("Remote Action");

				progressDialog.Show(this);
			}

			private List<MachineInfo> RemoteMachineCredentials(RemoteActionInfo remoteAction) {
				List<MachineInfo> machinesWithConnectionDetails = new List<MachineInfo>();
				try
				{
						foreach (MachineInfo machineItems in remoteAction.Machines )
						{
								if (!ConnectionManagerUtil.IsProfileConnected(machineItems.DomainName, machineItems.ServerName))
								{

										ConnectionManager connectionManger = new ConnectionManager(machineItems.DomainName, machineItems.ServerName);

										if (connectionManger.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
										{

												machinesWithConnectionDetails.Add(ConnectionManagerUtil.GetConnectionDetails(machineItems.DomainName, machineItems.ServerName));
												// StartReportCollection(machine.DomainName, machine.ServerName);


										}

										else
												AMTLogger.WriteToLog("Connection cancelled for " + machineItems.DomainName +"/" +  machineItems.ServerName);

								}
								else
								{
										machinesWithConnectionDetails.Add(ConnectionManagerUtil.GetConnectionDetails(machineItems.DomainName, machineItems.ServerName));
								}

						}
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}

				return machinesWithConnectionDetails;
			}

			void ReportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
				try
				{


				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			void Report_DoWork(ProgressDialog sender, DoWorkEventArgs e) {
				try
				{
						RemoteActionInfo  remoteAction = (RemoteActionInfo)e.Argument;


						remoteAction.Machines = RemoteMachineCredentials(remoteAction);


						StartRemoteAction(remoteAction);


				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void StartRemoteAction(RemoteActionInfo remoteActionInfo) {
				try
				{
						WMIMachineInfo machineInfo = new WMIMachineInfo();

						machineInfo.ServersList = remoteActionInfo.Machines;

						machineInfo.CommandMode = EnumHelper.Mode.Action;
						machineInfo.backgroundWorker = progressDialog.worker;

						machineInfo.MachineConnectionInfo = new WMIConnectionInfo()
								{

										ReportMode = EnumHelper.OperationMode.Interactive,


										DatabaseConnectionInfo = Utility.LoadDbConnectionInfo(),



								};

						if (remoteActionInfo.RemoteAction == EnumHelper.RemoteAction.RemoteInstall)
						{
								machineInfo.MachineConnectionInfo.ReportCategory = EnumHelper.WMIReportCategory.Application;
								machineInfo.ActionName = "Install";

						}
						else if (remoteActionInfo.RemoteAction == EnumHelper.RemoteAction.RemoteReboot)
						{
								machineInfo.MachineConnectionInfo.ReportCategory = EnumHelper.WMIReportCategory.OperatingSystem;
								machineInfo.ActionName = "Reboot";
						}

						else if (remoteActionInfo.RemoteAction == EnumHelper.RemoteAction.RemoteShutDown)
						{
								machineInfo.MachineConnectionInfo.ReportCategory = EnumHelper.WMIReportCategory.OperatingSystem;
								machineInfo.ActionName = "Shutdown";
						}

						machineInfo.RemoteActionInfo = remoteActionInfo;


						ReportObject = new AMT.Manager.ReportManagers.InitializeWMICollection();

						Boolean result = ReportObject.CollectReport(machineInfo);
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void StatusWindow_Load(object sender, EventArgs e) {
					//var t = new RemoteActionInfo() { RemoteAction = EnumHelper.RemoteAction.RemoteReboot, Machines = new List<MachineInfo>() { new MachineInfo() { DomainName = "Workgroup", ServerName = "10.70.70.48", UserName = "administrator", Password = "corent123$$" } }, ActionName = "Reboot" };


				ShowProgressDialog(remoteactionInfo);
				//  StartRemoteAction(t);
			}

			private void btnClose_Click(object sender, EventArgs e) {
				this.Close();
			}

			void worker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
				lstStatus.Items.Add(e.UserState.ToString());

				//lblStatus.Text = e.UserState.ToString();
					//lblStatus.Refresh();
			}

			RemoteActionInfo remoteactionInfo { get; set; }
		}
}
