using AMT.Logger;
using AMT.ReportingInterfaces;
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
		public partial class DomainScanner: Form {
			public DomainScanner(String DomainName, List<ReportingInterfaces.ReportUIInit> DomainItems) {
				InitializeComponent();

				this.DomainName = DomainName;
				this.DomainItems = DomainItems;
			}
			public List<MachineInfo> ChoosenMachines = new List<MachineInfo>();

			private void CollectSelectedServers() {
					ChoosenMachines.Clear ();
				try
				{
						if (rdbEntireScan.Checked)
						{


								foreach (var item in DomainItems )
									{


												ChoosenMachines.Add(new MachineInfo() { DomainName = item.DomainName,ServerName =item.ServerName  });
									}

						}
						else if (rdbCustomScan.Checked)
						{
								foreach (String  serverItem in lstServers.CheckedItems )
									{
												ChoosenMachines.Add(new MachineInfo() { DomainName = DomainName, ServerName = serverItem });
									}

						}

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void DomainScanner_Load(object sender, EventArgs e) {
				try
				{
						LoadDomains();
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void EnableControls() {
				try
				{
						lstServers.Enabled = rdbCustomScan.Checked;

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void LoadDomains() {
				try
				{
						lstServers.Items.Clear();
						foreach (var domainItem in DomainItems.Where (t=>t.DomainName ==DomainName ))
						{
								lstServers.Items.Add(domainItem.ServerName);

						}
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private Boolean ValidateUI() {
				Boolean result = false;
				try
				{

						if (rdbCustomScan.Checked)
						{
								if (lstServers.CheckedItems.Count > 0)
										result = true;

						}
						else
								result = true;

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}

				return result;
			}

			private void btnCancel_Click(object sender, EventArgs e) {
				try
				{
						this.DialogResult = DialogResult.Cancel;
						this.Close();
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void btnOK_Click(object sender, EventArgs e) {
				try
				{

						if (ValidateUI())
						{
								CollectSelectedServers();
								this.DialogResult = DialogResult.OK;
								this.Close();
						}
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void rdbCustomScan_CheckedChanged(object sender, EventArgs e) {
				try
				{
						EnableControls();


				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			List<ReportingInterfaces.ReportUIInit> DomainItems { get; set; }

			String DomainName { get; set; }
		}
}
