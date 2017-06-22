using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AMT.Common;
using AMT.ReportingInterfaces;
using AMT.Common.Constants;
using AMT.Logger;
using System.Reflection;
using AMT.Manager.WMIManagers;

namespace AMT.WFUI.UI
{
		public partial class ConnectionManager: Form {
			public ConnectionManager() {
				InitializeComponent();

				usercredentials = new UserCredentials();

				// SetGridSource();
			}

			public ConnectionManager(String DomainName, String ServerName) {
				InitializeComponent();

				usercredentials = new UserCredentials(DomainName ,ServerName );

				SetGridSource();
			}
			WMIConnectivityManager connectivityManager = new WMIConnectivityManager();
			UserCredentials usercredentials = null;

			public void SetCMCaptions(String ServerName) {
				try
				{
						this.Text = "Connect to " + ServerName;

				}
				catch (Exception ex)
				{


						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			public Boolean ValidateServerSelection() {
				Boolean result = false;
				try
				{

						if( ConnectionGrid.SelectedRows.Count >0)
						{
								var t = ConnectionGrid.SelectedRows[0];

								if(t.Cells ["ServerName"].Value.ToString () ==usercredentials.objMachineInfo.ServerName )
								{

										result = true;

								}

						}


				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}


				return result;
			}

			private void AddTSButton_Click(object sender, EventArgs e) {
				try
				{
						if (usercredentials.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
						ProfileConnectionInfo pinfo = new ProfileConnectionInfo();

						pinfo.ConnectionStatus = ApplicationConstants.Connected;

						pinfo.DomainName = usercredentials.objMachineInfo.DomainName;
						pinfo.ServerName = usercredentials.objMachineInfo.ServerName;
						pinfo.UserName = usercredentials.objMachineInfo.UserName;


						pinfo.Password = usercredentials.objMachineInfo.Password;

						pinfo.LastConnectTime = DateTime.Now;

						pinfo.IsLocalConnection = usercredentials.objMachineInfo.IsLocalConnection;


					 ConnectionManagerUtil.AddProfile(pinfo);

					//  this.DialogResult = System.Windows.Forms.DialogResult.OK;

				}
						else
								this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

						SetGridSource();
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void ConnectionManager_Load(object sender, EventArgs e) {
				try
				{
						SetGridSource();

						SetCMCaptions(usercredentials.objMachineInfo.ServerName);

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void DeleteTSButton_Click(object sender, EventArgs e) {
				try
				{

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void EditTSButton_Click(object sender, EventArgs e) {
				try
				{
						if (ConnectionGrid.SelectedRows.Count > 0)
						{
								var connectionItem = ConnectionGrid.SelectedRows[0];

								usercredentials = new UserCredentials(connectionItem.Cells["DomainName"].Value.ToString(), connectionItem.Cells["ServerName"].Value.ToString());

									if (usercredentials.ShowDialog() == System.Windows.Forms.DialogResult.OK)
										 {

												 UpdateConnectionProfile();

										 }
									SetGridSource();

						}

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void SetColor() {
				try
				{
						for (int i = 0; i < ConnectionGrid.Rows.Count ; i++)
						{
								foreach (DataGridViewColumn  columns in ConnectionGrid.Columns)
								{
										if (ConnectionGrid.Rows[i].Cells[columns.Name].Value.ToString()==(ApplicationConstants.DisConnected))
										{

										ConnectionGrid.Rows[i].Cells[columns.Name].Style.ForeColor = Color.Red;

										}

										if (ConnectionGrid.Rows[i].Cells[columns.Name].Value.ToString()==(ApplicationConstants.Connected))
										{
												ConnectionGrid.Rows[i].Cells[columns.Name].Style.ForeColor = Color.Green;

										}

								}
						}

				}
				catch (Exception ex)
				{


						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void SetGridSource() {
				try
				{
						ConnectionGrid.DataSource = null;

						ConnectionGrid.DataSource = ConnectionManagerUtil.GetConnections();

						SetColor();
				}
				catch (Exception ex)
				{


						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void UpdateConnectionProfile() {
				ConnectionManagerUtil.ChangeProfileConnectionStatus(new ProfileConnectionInfo()
				{
						ConnectionStatus = ApplicationConstants.Connected,
						DomainName = usercredentials.objMachineInfo.DomainName,
						ServerName = usercredentials.objMachineInfo.ServerName,
						UserName = usercredentials.objMachineInfo.UserName,
						Hash= Utility.HashPassword(usercredentials.objMachineInfo.Password) ,
						Password =usercredentials.objMachineInfo.Password,
						LastConnectTime = DateTime.Now,
						IsLocalConnection = usercredentials.objMachineInfo.IsLocalConnection,
						IsConnected =true



				});
			}

			private void btnCancel_Click(object sender, EventArgs e) {
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			}

			private void btnConnect_Click(object sender, EventArgs e) {
				if (ValidateServerSelection())
				{

						if (connectivityManager.CheckConnectivity(ConnectionManagerUtil.GetConnectionDetails(usercredentials.objMachineInfo.DomainName, usercredentials.objMachineInfo.ServerName)))
						{
								UpdateConnectionProfile();


								this.DialogResult = System.Windows.Forms.DialogResult.OK;
								this.Close();
						}

						else
						{
								MessageBox.Show(this,"Connection to server " + usercredentials.objMachineInfo.ServerName + " failed.", ApplicationConstants.ApplicationLongName);
						}
				}
				else
				{
						MessageBox.Show(this, "Select connection option for server " + usercredentials.objMachineInfo.ServerName + " to connect.", ApplicationConstants.ApplicationLongName);
				}
			}
		}
}
