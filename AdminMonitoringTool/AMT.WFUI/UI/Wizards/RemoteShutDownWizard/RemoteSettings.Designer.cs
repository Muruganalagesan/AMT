namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard
{
    partial class RemoteSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvRemoteSettings = new System.Windows.Forms.ListView();
            this.NameItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.rtbSummary = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 287);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbSummary);
            this.splitContainer1.Panel1.Controls.Add(this.lvRemoteSettings);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnRun);
            this.splitContainer1.Size = new System.Drawing.Size(489, 268);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvRemoteSettings
            // 
            this.lvRemoteSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameItem,
            this.Description});
            this.lvRemoteSettings.FullRowSelect = true;
            this.lvRemoteSettings.Location = new System.Drawing.Point(0, 0);
            this.lvRemoteSettings.MultiSelect = false;
            this.lvRemoteSettings.Name = "lvRemoteSettings";
            this.lvRemoteSettings.Size = new System.Drawing.Size(262, 233);
            this.lvRemoteSettings.TabIndex = 0;
            this.lvRemoteSettings.UseCompatibleStateImageBehavior = false;
            this.lvRemoteSettings.View = System.Windows.Forms.View.Details;
            this.lvRemoteSettings.SelectedIndexChanged += new System.EventHandler(this.lvRemoteSettings_SelectedIndexChanged);
            // 
            // NameItem
            // 
            this.NameItem.Text = "Name";
            this.NameItem.Width = 162;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 326;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(411, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(249, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(330, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(168, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // rtbSummary
            // 
            this.rtbSummary.Location = new System.Drawing.Point(266, 3);
            this.rtbSummary.Name = "rtbSummary";
            this.rtbSummary.Size = new System.Drawing.Size(220, 233);
            this.rtbSummary.TabIndex = 1;
            this.rtbSummary.Text = "";
            // 
            // RemoteSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 287);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "RemoteSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoteSettings";
            this.Load += new System.EventHandler(this.RemoteSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ListView lvRemoteSettings;
        private System.Windows.Forms.ColumnHeader NameItem;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtbSummary;

    }
}