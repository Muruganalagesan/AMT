using AMT.Logger;
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
		public partial class ReportPreview: Form {
			public ReportPreview() {
				InitializeComponent();
			}

			private void PageSetupTSButton_Click(object sender, EventArgs e) {
				PreviewBrowser.ShowPageSetupDialog();
			}

			private void PreviewTSButton_Click(object sender, EventArgs e) {
				PreviewBrowser.ShowPrintPreviewDialog();
			}

			private void PrintTSButton_Click(object sender, EventArgs e) {
				PreviewBrowser.ShowPrintDialog();
			}

			private void PropertiesTSButton_Click(object sender, EventArgs e) {
				PreviewBrowser.ShowPropertiesDialog();
			}

			private void ReportPreview_Load(object sender, EventArgs e) {
				try
				{
						PreviewBrowser.WebBrowserShortcutsEnabled = true;
						PreviewBrowser.ScrollBarsEnabled = true;
						PreviewBrowser.IsWebBrowserContextMenuEnabled = true;
						PreviewBrowser.Url =  new Uri("file:///"+ FileLocation); ;
				}
				catch (Exception ex)
				{

						AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
				}
			}

			private void SaveTSButton_Click(object sender, EventArgs e) {
				PreviewBrowser.ShowSaveAsDialog();
			}

			public String FileLocation { get; set; }
		}
}
