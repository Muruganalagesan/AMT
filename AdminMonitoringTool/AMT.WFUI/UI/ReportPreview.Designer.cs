namespace AMT.WFUI.UI
{
		partial class ReportPreview: System.Object {
			private System.Windows.Forms.ToolStripButton PageSetupTSButton;
			private System.Windows.Forms.WebBrowser PreviewBrowser;
			private System.Windows.Forms.ToolStripButton PreviewTSButton;
			private System.Windows.Forms.ToolStripButton PrintTSButton;
			private System.Windows.Forms.ToolStripButton PropertiesTSButton;
			private System.Windows.Forms.ToolStripButton SaveTSButton;

			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.IContainer components = null;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.GroupBox groupBox2;
			private System.Windows.Forms.ToolStrip toolStrip1;
			private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
			private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
			private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
			private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
			protected override void Dispose(bool disposing) {
				if (disposing && (components != null))
				{
						components.Dispose();
				}
				base.Dispose(disposing);
			}

			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent() {
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportPreview));
				this.groupBox1 = new System.Windows.Forms.GroupBox();
				this.PreviewBrowser = new System.Windows.Forms.WebBrowser();
				this.groupBox2 = new System.Windows.Forms.GroupBox();
				this.toolStrip1 = new System.Windows.Forms.ToolStrip();
				this.PrintTSButton = new System.Windows.Forms.ToolStripButton();
				this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
				this.PageSetupTSButton = new System.Windows.Forms.ToolStripButton();
				this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
				this.PreviewTSButton = new System.Windows.Forms.ToolStripButton();
				this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
				this.PropertiesTSButton = new System.Windows.Forms.ToolStripButton();
				this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
				this.SaveTSButton = new System.Windows.Forms.ToolStripButton();
				this.groupBox1.SuspendLayout();
				this.toolStrip1.SuspendLayout();
				this.SuspendLayout();
				//
				// groupBox1
				//
				this.groupBox1.Controls.Add(this.PreviewBrowser);
				this.groupBox1.Controls.Add(this.groupBox2);
				this.groupBox1.Controls.Add(this.toolStrip1);
				this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.groupBox1.Location = new System.Drawing.Point(0, 0);
				this.groupBox1.Name = "groupBox1";
				this.groupBox1.Size = new System.Drawing.Size(890, 443);
				this.groupBox1.TabIndex = 1;
				this.groupBox1.TabStop = false;
				this.groupBox1.Text = "Print/Preview";
				//
				// PreviewBrowser
				//
				this.PreviewBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
				this.PreviewBrowser.Location = new System.Drawing.Point(3, 51);
				this.PreviewBrowser.MinimumSize = new System.Drawing.Size(20, 20);
				this.PreviewBrowser.Name = "PreviewBrowser";
				this.PreviewBrowser.Size = new System.Drawing.Size(884, 389);
				this.PreviewBrowser.TabIndex = 2;
				this.PreviewBrowser.Url = new System.Uri("C:\\Users\\Public\\Documents\\AMT\\Preview\\Application.HTML", System.UriKind.Absolute);
				//
				// groupBox2
				//
				this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
				this.groupBox2.Location = new System.Drawing.Point(3, 41);
				this.groupBox2.Name = "groupBox2";
				this.groupBox2.Size = new System.Drawing.Size(884, 10);
				this.groupBox2.TabIndex = 1;
				this.groupBox2.TabStop = false;
				//
				// toolStrip1
				//
				this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
				this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.PrintTSButton,
				this.toolStripSeparator1,
				this.PageSetupTSButton,
				this.toolStripSeparator2,
				this.PreviewTSButton,
				this.toolStripSeparator3,
				this.PropertiesTSButton,
				this.toolStripSeparator4,
				this.SaveTSButton});
				this.toolStrip1.Location = new System.Drawing.Point(3, 16);
				this.toolStrip1.Name = "toolStrip1";
				this.toolStrip1.Size = new System.Drawing.Size(884, 25);
				this.toolStrip1.TabIndex = 0;
				this.toolStrip1.Text = "toolStrip1";
				//
				// PrintTSButton
				//
				this.PrintTSButton.Image = ((System.Drawing.Image)(resources.GetObject("PrintTSButton.Image")));
				this.PrintTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.PrintTSButton.Name = "PrintTSButton";
				this.PrintTSButton.Size = new System.Drawing.Size(52, 22);
				this.PrintTSButton.Text = "Print";
				this.PrintTSButton.Click += new System.EventHandler(this.PrintTSButton_Click);
				//
				// toolStripSeparator1
				//
				this.toolStripSeparator1.Name = "toolStripSeparator1";
				this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
				//
				// PageSetupTSButton
				//
				this.PageSetupTSButton.Image = ((System.Drawing.Image)(resources.GetObject("PageSetupTSButton.Image")));
				this.PageSetupTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.PageSetupTSButton.Name = "PageSetupTSButton";
				this.PageSetupTSButton.Size = new System.Drawing.Size(83, 22);
				this.PageSetupTSButton.Text = "PageSetup";
				this.PageSetupTSButton.Click += new System.EventHandler(this.PageSetupTSButton_Click);
				//
				// toolStripSeparator2
				//
				this.toolStripSeparator2.Name = "toolStripSeparator2";
				this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
				//
				// PreviewTSButton
				//
				this.PreviewTSButton.Image = ((System.Drawing.Image)(resources.GetObject("PreviewTSButton.Image")));
				this.PreviewTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.PreviewTSButton.Name = "PreviewTSButton";
				this.PreviewTSButton.Size = new System.Drawing.Size(98, 22);
				this.PreviewTSButton.Text = "Print/Preview";
				this.PreviewTSButton.Click += new System.EventHandler(this.PreviewTSButton_Click);
				//
				// toolStripSeparator3
				//
				this.toolStripSeparator3.Name = "toolStripSeparator3";
				this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
				//
				// PropertiesTSButton
				//
				this.PropertiesTSButton.Image = ((System.Drawing.Image)(resources.GetObject("PropertiesTSButton.Image")));
				this.PropertiesTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.PropertiesTSButton.Name = "PropertiesTSButton";
				this.PropertiesTSButton.Size = new System.Drawing.Size(108, 22);
				this.PropertiesTSButton.Text = "Print Properties";
				this.PropertiesTSButton.Click += new System.EventHandler(this.PropertiesTSButton_Click);
				//
				// toolStripSeparator4
				//
				this.toolStripSeparator4.Name = "toolStripSeparator4";
				this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
				//
				// SaveTSButton
				//
				this.SaveTSButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveTSButton.Image")));
				this.SaveTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.SaveTSButton.Name = "SaveTSButton";
				this.SaveTSButton.Size = new System.Drawing.Size(64, 22);
				this.SaveTSButton.Text = "SaveAs";
				this.SaveTSButton.Click += new System.EventHandler(this.SaveTSButton_Click);
				//
				// ReportPreview
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(890, 443);
				this.Controls.Add(this.groupBox1);
				this.Name = "ReportPreview";
				this.ShowInTaskbar = false;
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "Report Preview";
				this.Load += new System.EventHandler(this.ReportPreview_Load);
				this.groupBox1.ResumeLayout(false);
				this.groupBox1.PerformLayout();
				this.toolStrip1.ResumeLayout(false);
				this.toolStrip1.PerformLayout();
				this.ResumeLayout(false);
			}
		}
}
