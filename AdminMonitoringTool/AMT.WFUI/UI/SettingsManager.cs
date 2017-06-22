using AMT.Logger;
using AMT.ReportingInterfaces;
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
using AMT.Common;
using AMT.Common.Constants;
namespace AMT.WFUI.UI
{
		public partial class SettingsManager: Form {
			public SettingsManager() {
				InitializeComponent();
			}
			public ProgressDialog progressDialog = new ProgressDialog();

			public void SetSQLControlStatus(Boolean enabled) {
				grpSQLDetails.Enabled = enabled;
			}

			public void SetSQLUserControlStatus(Boolean enabled) {
				txtUserName.Enabled = enabled;
				txtPassword.Enabled = enabled;
			}

			private void LoadSettingsManager() {
				try
				{
					DBProfileInfo profileInfo=  Utility.GetDBProfileInfo();

					if (profileInfo != null)
					{
							rdbSQLCE.Checked = profileInfo.DatabaseType == EnumHelper.Databases.SQLServerCE ? true : false;
							rdbSQL.Checked = profileInfo.DatabaseType == EnumHelper.Databases.SQLServer ? true : false;

							rdbSQLAuthentication .Checked =profileInfo.AuthenticationType ==EnumHelper.Authentication.SQLAuthentication ?true :false ;
							rdbWinAuthentication .Checked =profileInfo.AuthenticationType ==EnumHelper.Authentication.Windows? true :false ;

							txtUserName.Text = profileInfo.UserName;
							txtPassword.Text = Utility.Decrypt(profileInfo.Password, profileInfo.HashSalt);
							txtServerName.Text = profileInfo.ServerName;
					}

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void SetStatus() {
				SetSQLControlStatus(rdbSQL.Checked);

				SetSQLUserControlStatus(rdbSQLAuthentication.Checked);
			}

			private void SettingsManager_Load(object sender, EventArgs e) {
				trwSettings.ExpandAll();
				trwSettings.SelectedNode = trwSettings.Nodes[0].Nodes[0];

				rdbSQLCE.Checked = true;
				LoadSettingsManager();



				SetStatus();
			}

			private void ShowProgressDialog() {
				progressDialog = new ProgressDialog();

					// inputMachineInfo.backgroundWorker = progressUpdater.progressDialog.worker;
				//  progressDialog.Argument = e;

				progressDialog.DoWork += form_DoWork;

				progressDialog.worker.RunWorkerCompleted += worker_RunWorkerCompleted;

				progressDialog.TopMost = false;
					// progressDialog.Parent  = this;


				progressDialog.Show(this);
			}

			private Boolean ValidateSQLServerSettings() {
				Boolean result=false ;
				try
				{
						if (rdbSQL.Checked)
						{
								if (Validation.ValidateEmptyValue (txtServerName))
								{
										if (rdbSQLAuthentication.Checked)
										{
												if (Validation.ValidateEmptyValue(txtUserName))
												{
														if (Validation.ValidateEmptyValue(txtPassword))
																result = true;
														else
																ServerToolTip.Show("Enter password", txtPassword);
												}
												else
														ServerToolTip.Show("Enter User Name", txtUserName);
										}
										else
												result = true;
								}
								else
								{
										ServerToolTip.Show("Enter SQL Server Name", txtServerName);
								}

						}

						else if (rdbSQLCE.Checked)
						{
								result = true;
						}


				}
				 catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
				return  result ;
			}

			private void btnOK_Click(object sender, EventArgs e) {
				try
				{

						if (ValidateSQLServerSettings())
						{
								DBProfileInfo dbprofileInfo = new DBProfileInfo();

								dbprofileInfo.AuthenticationType = rdbSQLAuthentication.Checked ? EnumHelper.Authentication.SQLAuthentication : EnumHelper.Authentication.Windows;
								dbprofileInfo.DatabaseType = rdbSQLCE.Checked ? EnumHelper.Databases.SQLServerCE : EnumHelper.Databases.SQLServer;
								dbprofileInfo.ServerName = txtServerName.Text;
								dbprofileInfo.UserName = txtUserName.Text;

								dbprofileInfo.HashSalt = Utility.HashPassword(txtPassword.Text);

								dbprofileInfo.Password = Utility.Encrypt(txtPassword.Text, dbprofileInfo.HashSalt);

								XMLSerializer<DBProfileInfo>.SerializeInputs<DBProfileInfo>(ApplicationInfo.DBProfileName, dbprofileInfo);



								new AMT.Manager.InitailizeApp().CreateDatabases(Utility.LoadDbConnectionInfo ());
								//new Common.CommonUIInfo().InitApplication();

								this.DialogResult = System.Windows.Forms.DialogResult.OK;
								this.Close();
						}
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void btnTestConnection_Click(object sender, EventArgs e) {
				try
				{

						AMTLogger.WriteToLog("Inside test connection");
						if (ValidateSQLServerSettings())
						{
								DBProfileInfo dbprofileInfo = new DBProfileInfo();

								dbprofileInfo.AuthenticationType = rdbSQLAuthentication.Checked ? EnumHelper.Authentication.SQLAuthentication : EnumHelper.Authentication.Windows;
								dbprofileInfo.DatabaseType = rdbSQLCE.Checked ? EnumHelper.Databases.SQLServerCE : EnumHelper.Databases.SQLServer;
								dbprofileInfo.ServerName = txtServerName.Text;
								dbprofileInfo.UserName = txtUserName.Text;

									dbprofileInfo.HashSalt = Utility.HashPassword(txtPassword.Text);
									dbprofileInfo.Password = Utility.Encrypt(txtPassword.Text, dbprofileInfo.HashSalt);


								if (new AMT.Manager.InitailizeApp().CheckDatabaseConnection(Utility.GetConnectionInfoFromProfile(dbprofileInfo)))
								{
										MessageBox.Show("Connected Sucessfully.");
								}
								else{
										MessageBox.Show ("Unable to connect");
								}
						}
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			void form_DoWork(ProgressDialog sender, DoWorkEventArgs e) {
				try
				{




				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void rdbSQLCE_CheckedChanged(object sender, EventArgs e) {
				// grpSQLDetails.Enabled = !rdbSQLCE.Checked;
				SetStatus();
			}

			private void rdbWinAuthentication_CheckedChanged(object sender, EventArgs e) {
				SetStatus();
			}

			private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {
			}

			void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
				try
				{
						this.Close();
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}
		}
}
