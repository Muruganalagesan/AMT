using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AMT.WFUI.UI
{
		public partial class RealTimeMonitoring: Form {
			public RealTimeMonitoring() {
				InitializeComponent();
			}

			private void RealTimeMonitoring_Load(object sender, EventArgs e) {
				try
				{


						chart1.Series["Data"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;




						int[] yval = { 5, 6, 4, 6, 3 };

						List<long> values = new List<long>();

						 List<String> NameValue = new List<String>();



						foreach (DriveInfo item in   DriveInfo.GetDrives ())
						{

								NameValue.Add(item.Name);

								values.Add(item.TotalFreeSpace);

						}

						// initialize an array of strings for X values
						string[] xval = Environment.GetLogicalDrives();

						// bind the arrays to the X and Y values of data points in the "ByArray" series
						chart1.Series["Data"].Points.DataBindXY(NameValue, values);


				}
				catch (Exception ex)
				{

						throw ex;
				}
			}
		}
}
