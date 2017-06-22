namespace AMT.WFUI
{
    partial class ReportWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportWindow));
            this.grpRoot = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DomainTreeView = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsServers = new System.Windows.Forms.ToolStrip();
            this.tsbAddServer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRemoveServer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.reportGrid = new System.Windows.Forms.DataGridView();
            this.tcReports = new System.Windows.Forms.TabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ReportStrip = new System.Windows.Forms.ToolStrip();
            this.RefreshReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.PreviewReport = new System.Windows.Forms.ToolStripButton();
            this.RWImgList = new System.Windows.Forms.ImageList(this.components);
            this.grpRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsServers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.ReportStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRoot
            // 
            this.grpRoot.Controls.Add(this.splitContainer1);
            this.grpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRoot.Location = new System.Drawing.Point(0, 0);
            this.grpRoot.Name = "grpRoot";
            this.grpRoot.Size = new System.Drawing.Size(723, 329);
            this.grpRoot.TabIndex = 0;
            this.grpRoot.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DomainTreeView);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportGrid);
            this.splitContainer1.Panel2.Controls.Add(this.tcReports);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(717, 310);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 0;
            // 
            // DomainTreeView
            // 
            this.DomainTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DomainTreeView.HideSelection = false;
            this.DomainTreeView.HotTracking = true;
            this.DomainTreeView.Location = new System.Drawing.Point(0, 32);
            this.DomainTreeView.Name = "DomainTreeView";
            this.DomainTreeView.Size = new System.Drawing.Size(177, 278);
            this.DomainTreeView.TabIndex = 3;
            this.DomainTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.DomainTreeView_AfterExpand);
            this.DomainTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.DomainTreeView_NodeMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 10);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tsServers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 22);
            this.panel1.TabIndex = 0;
            // 
            // tsServers
            // 
            this.tsServers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.tsServers.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsServers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddServer,
            this.toolStripSeparator1,
            this.tsbRemoveServer,
            this.toolStripSeparator2,
            this.tsbRefresh});
            this.tsServers.Location = new System.Drawing.Point(0, 0);
            this.tsServers.Name = "tsServers";
            this.tsServers.Size = new System.Drawing.Size(177, 25);
            this.tsServers.TabIndex = 0;
            this.tsServers.Text = "toolStrip1";
            this.tsServers.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsServers_ItemClicked);
            // 
            // tsbAddServer
            // 
            this.tsbAddServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddServer.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddServer.Image")));
            this.tsbAddServer.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsbAddServer.Name = "tsbAddServer";
            this.tsbAddServer.Size = new System.Drawing.Size(23, 22);
            this.tsbAddServer.Tag = "addserver";
            this.tsbAddServer.Text = "Add";
            this.tsbAddServer.ToolTipText = "Add Server";
            this.tsbAddServer.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
            // 
            // tsbRemoveServer
            // 
            this.tsbRemoveServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveServer.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveServer.Image")));
            this.tsbRemoveServer.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsbRemoveServer.Name = "tsbRemoveServer";
            this.tsbRemoveServer.Size = new System.Drawing.Size(23, 22);
            this.tsbRemoveServer.Tag = "removeserver";
            this.tsbRemoveServer.Text = "Remove";
            this.tsbRemoveServer.ToolTipText = "Remove Server";
            this.tsbRemoveServer.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(66, 22);
            this.tsbRefresh.Tag = "refreshserver";
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.ToolTipText = "Refresh";
            // 
            // reportGrid
            // 
            this.reportGrid.AllowUserToAddRows = false;
            this.reportGrid.AllowUserToDeleteRows = false;
            this.reportGrid.AllowUserToOrderColumns = true;
            this.reportGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.reportGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.reportGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.reportGrid.Location = new System.Drawing.Point(0, 48);
            this.reportGrid.MultiSelect = false;
            this.reportGrid.Name = "reportGrid";
            this.reportGrid.ReadOnly = true;
            this.reportGrid.RowHeadersVisible = false;
            this.reportGrid.Size = new System.Drawing.Size(536, 262);
            this.reportGrid.TabIndex = 3;
            // 
            // tcReports
            // 
            this.tcReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcReports.Location = new System.Drawing.Point(0, 25);
            this.tcReports.Name = "tcReports";
            this.tcReports.SelectedIndex = 0;
            this.tcReports.Size = new System.Drawing.Size(536, 23);
            this.tcReports.TabIndex = 2;
            this.tcReports.SelectedIndexChanged += new System.EventHandler(this.tcReports_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ReportStrip);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 25);
            this.panel2.TabIndex = 0;
            // 
            // ReportStrip
            // 
            this.ReportStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.ReportStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ReportStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshReport,
            this.toolStripSeparator3,
            this.ExportReport,
            this.toolStripSeparator4,
            this.PreviewReport});
            this.ReportStrip.Location = new System.Drawing.Point(0, 0);
            this.ReportStrip.Name = "ReportStrip";
            this.ReportStrip.Size = new System.Drawing.Size(536, 25);
            this.ReportStrip.TabIndex = 0;
            // 
            // RefreshReport
            // 
            this.RefreshReport.ForeColor = System.Drawing.Color.Blue;
            this.RefreshReport.Image = ((System.Drawing.Image)(resources.GetObject("RefreshReport.Image")));
            this.RefreshReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshReport.Name = "RefreshReport";
            this.RefreshReport.Size = new System.Drawing.Size(66, 22);
            this.RefreshReport.Text = "Refresh";
            this.RefreshReport.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ExportReport
            // 
            this.ExportReport.ForeColor = System.Drawing.Color.Blue;
            this.ExportReport.Image = ((System.Drawing.Image)(resources.GetObject("ExportReport.Image")));
            this.ExportReport.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ExportReport.Name = "ExportReport";
            this.ExportReport.Size = new System.Drawing.Size(60, 22);
            this.ExportReport.Text = "Export";
            this.ExportReport.Click += new System.EventHandler(this.Export_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // PreviewReport
            // 
            this.PreviewReport.ForeColor = System.Drawing.Color.Blue;
            this.PreviewReport.Image = ((System.Drawing.Image)(resources.GetObject("PreviewReport.Image")));
            this.PreviewReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PreviewReport.Name = "PreviewReport";
            this.PreviewReport.Size = new System.Drawing.Size(98, 22);
            this.PreviewReport.Text = "Print/Preview";
            this.PreviewReport.Click += new System.EventHandler(this.PreviewReport_Click);
            // 
            // RWImgList
            // 
            this.RWImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("RWImgList.ImageStream")));
            this.RWImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.RWImgList.Images.SetKeyName(0, "domain");
            this.RWImgList.Images.SetKeyName(1, "server");
            this.RWImgList.Images.SetKeyName(2, "root.jpg");
            this.RWImgList.Images.SetKeyName(3, "searchserver.ico");
            // 
            // ReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 329);
            this.Controls.Add(this.grpRoot);
            this.Name = "ReportWindow";
            this.ShowInTaskbar = false;
            this.Text = "Report Window";
            this.Load += new System.EventHandler(this.ReportWindow_Load);
            this.grpRoot.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsServers.ResumeLayout(false);
            this.tsServers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ReportStrip.ResumeLayout(false);
            this.ReportStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRoot;
        private System.Windows.Forms.ImageList RWImgList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView DomainTreeView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip tsServers;
        private System.Windows.Forms.ToolStripButton tsbAddServer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbRemoveServer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        public System.Windows.Forms.DataGridView reportGrid;
        private System.Windows.Forms.TabControl tcReports;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip ReportStrip;
        private System.Windows.Forms.ToolStripButton RefreshReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ExportReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton PreviewReport;
    }
}

