using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AMT.Logger;
using AMT.ReportingInterfaces;

namespace AMT.WFUI.UI
{
		public partial class ExportDialog: Form {
			public ExportDialog(ReportExportInfo reportExportInfo) {
				InitializeComponent();

				this.reportExportInfo = reportExportInfo;

				txtReportName.Text = reportExportInfo.ReportName;
				//  cmbExportFormat.SelectedText=reportExportInfo.ReportFormat;

				if (cmbExportFormat.Items.Count > 0)
						cmbExportFormat.SelectedIndex = 0;
				 txtLocation.Text=reportExportInfo.FileLocation ;
			}
			public ReportExportInfo reportExportInfo = new ReportingInterfaces.ReportExportInfo();

			private Boolean ValidateForm() {
				Boolean result = false;
				try
				{

						if (Validation.ValidateEmptyValue(txtReportName))
						{
								if (Validation.ValidateComboBox(cmbExportFormat))
								{
										if (Validation.ValidateEmptyValue(txtLocation))
												result = true;
										else
										{


												ExportToolTip.Show("Specify location for export.", txtLocation);
										}
								}
								else
								{


										ExportToolTip.Show("Select a export format.", cmbExportFormat );
								}
						}
						else
						{


								ExportToolTip.Show("Specify report name for export.", txtReportName);
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
			}

			private void btnOk_Click(object sender, EventArgs e) {
				try
				{
						if(ValidateForm ())
						{
								reportExportInfo.ReportName = txtReportName.Text;
								reportExportInfo.ReportFormat = cmbExportFormat.Text ;
								reportExportInfo.FileLocation = txtLocation .Text;

								this.DialogResult = System.Windows.Forms.DialogResult.OK;
						}
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void button1_Click(object sender, EventArgs e) {
				try
				{

						FolderBrowserDialog saveFileDailog = new FolderBrowserDialog();

						saveFileDailog.ShowNewFolderButton = true;
						saveFileDailog.Description = "Select folder path for saving file";

						if (saveFileDailog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
						{
								txtLocation.Text = saveFileDailog.SelectedPath;
						}

				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}
		}
}

