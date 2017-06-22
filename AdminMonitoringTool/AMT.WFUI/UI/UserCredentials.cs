using AMT.ReportingInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AMT.Manager.WMIManagers;
using AMT.Logger;
using AMT.Common;
using System.Reflection;
namespace AMT.WFUI
{
		public partial class UserCredentials: Form {
			public UserCredentials() {
				InitializeComponent();
			}

			public UserCredentials(String DomainName,String ServerName) {
				InitializeComponent();

				LoadProfileValues(DomainName, ServerName);

				if (objMachineInfo != null)
				{
						objMachineInfo.DomainName = DomainName;

						objMachineInfo.ServerName = ServerName;

						txtDomainName.Text = objMachineInfo.DomainName;

						txtServerName.Text = objMachineInfo.ServerName;

						txtUserName.Text = objMachineInfo.UserName;

						txtPassword.Text = objMachineInfo.Password;
						chkLocalConnection.Checked = objMachineInfo.IsLocalConnection;



				}
			}
			public MachineInfo objMachineInfo = new MachineInfo();
			WMIConnectivityManager connectivityManager = new WMIConnectivityManager();

			private void EnableControls(Boolean IsEnable) {
				try
				{

						txtUserName.Enabled = IsEnable;
						txtPassword.Enabled = IsEnable;

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void LoadProfileValues(String DomainName, String ServerName) {
				try
				{
				 objMachineInfo=   ConnectionManagerUtil.GetConnectionDetails(DomainName, ServerName);
				}
				catch (Exception ex)
				{

						throw ex;
				}
			}

			private Boolean ValidateForm() {
				Boolean result = false;
				try
				{

						if (Validation.ValidateEmptyValue(txtDomainName))
						{
								if (Validation.ValidateEmptyValue(txtServerName))
								{

										if (chkLocalConnection.Checked)
										{
												if (Validation.ValidateEmptyValue(txtUserName))
												{

														if (Validation.ValidateEmptyValue(txtPassword))
														{

																result = true;
														}
														else
														{
																CredentialToolTip.Show("Enter Password", txtPassword);
														}

												}
												else
												{
														CredentialToolTip.Show("Enter UserName", txtUserName);
												}
										}
										else
										{
												result = true;
										}
								}
								else
								{
										CredentialToolTip.Show("Enter Server Name", txtServerName);
								}
						}
						else
						{
								CredentialToolTip.Show("Enter Domain Name", txtDomainName);
						}

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}

				return result;
			}

			private void btnCancel_Click(object sender, EventArgs e) {
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.Close();
			}

			private void btnConnect_Click(object sender, EventArgs e) {
				try
				{
						if (ValidateForm())
						{
								objMachineInfo = new MachineInfo() { DomainName = txtDomainName.Text, ServerName = txtServerName.Text, UserName = txtUserName.Text, Password = txtPassword.Text,IsLocalConnection =!chkLocalConnection.Checked  };


								if (connectivityManager.CheckConnectivity(objMachineInfo))
								{
										this.DialogResult = System.Windows.Forms.DialogResult.OK;
								}

								else
								{
										MessageBox.Show(this,"Failed to connect...", "AMT", MessageBoxButtons.OK);
										// CredentialToolTip.Show("Failed to connect...", groupBox1);
								}

						}
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void btnTest_Click(object sender, EventArgs e) {
				try
				{
						if (ValidateForm())
						{
								objMachineInfo = new MachineInfo() { DomainName = txtDomainName.Text, ServerName = txtServerName.Text, UserName = txtUserName.Text, Password = txtPassword.Text };

								if (connectivityManager.CheckConnectivity(objMachineInfo))
								{
										MessageBox.Show("Connected Successfully!","AMT",MessageBoxButtons.OK);
								}
								else
								{
										MessageBox.Show(this, "Failed to connect...", "AMT", MessageBoxButtons.OK);
									 // CredentialToolTip.Show("Failed to connect...", groupBox1);
								}



						}
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void chkLocalConnection_CheckedChanged(object sender, EventArgs e) {
				try
				{
						EnableControls(chkLocalConnection.Checked);
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}
		}
}
