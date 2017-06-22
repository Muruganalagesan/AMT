namespace AMT.WFUI.UI
{
    partial class ConnectionManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionManager));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ConnectionGrid = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConnectionManagerStrip = new System.Windows.Forms.ToolStrip();
            this.AddTSButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EditTSButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteTSButton = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionGrid)).BeginInit();
            this.ConnectionManagerStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 407);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.ConnectionManagerStrip);
            this.splitContainer1.Size = new System.Drawing.Size(685, 407);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 322);
            this.panel2.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ConnectionGrid);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer2.Panel2.Controls.Add(this.btnConnect);
            this.splitContainer2.Size = new System.Drawing.Size(685, 322);
            this.splitContainer2.SplitterDistance = 272;
            this.splitContainer2.TabIndex = 0;
            // 
            // ConnectionGrid
            // 
            this.ConnectionGrid.AllowUserToAddRows = false;
            this.ConnectionGrid.AllowUserToDeleteRows = false;
            this.ConnectionGrid.AllowUserToOrderColumns = true;
            this.ConnectionGrid.AllowUserToResizeColumns = false;
            this.ConnectionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ConnectionGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ConnectionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConnectionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConnectionGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ConnectionGrid.Location = new System.Drawing.Point(0, 0);
            this.ConnectionGrid.MultiSelect = false;
            this.ConnectionGrid.Name = "ConnectionGrid";
            this.ConnectionGrid.ReadOnly = true;
            this.ConnectionGrid.RowHeadersVisible = false;
            this.ConnectionGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConnectionGrid.Size = new System.Drawing.Size(685, 272);
            this.ConnectionGrid.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(601, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(520, 11);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 10);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // ConnectionManagerStrip
            // 
            this.ConnectionManagerStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ConnectionManagerStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTSButton,
            this.toolStripSeparator1,
            this.EditTSButton,
            this.toolStripSeparator2,
            this.DeleteTSButton});
            this.ConnectionManagerStrip.Location = new System.Drawing.Point(0, 0);
            this.ConnectionManagerStrip.Name = "ConnectionManagerStrip";
            this.ConnectionManagerStrip.Size = new System.Drawing.Size(685, 25);
            this.ConnectionManagerStrip.TabIndex = 0;
            this.ConnectionManagerStrip.Text = "toolStrip1";
            // 
            // AddTSButton
            // 
            this.AddTSButton.Image = ((System.Drawing.Image)(resources.GetObject("AddTSButton.Image")));
            this.AddTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddTSButton.Name = "AddTSButton";
            this.AddTSButton.Size = new System.Drawing.Size(49, 22);
            this.AddTSButton.Text = "Add";
            this.AddTSButton.Click += new System.EventHandler(this.AddTSButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // EditTSButton
            // 
            this.EditTSButton.Image = ((System.Drawing.Image)(resources.GetObject("EditTSButton.Image")));
            this.EditTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditTSButton.Name = "EditTSButton";
            this.EditTSButton.Size = new System.Drawing.Size(47, 22);
            this.EditTSButton.Text = "Edit";
            this.EditTSButton.Click += new System.EventHandler(this.EditTSButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // DeleteTSButton
            // 
            this.DeleteTSButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteTSButton.Image")));
            this.DeleteTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteTSButton.Name = "DeleteTSButton";
            this.DeleteTSButton.Size = new System.Drawing.Size(60, 22);
            this.DeleteTSButton.Text = "Delete";
            this.DeleteTSButton.Click += new System.EventHandler(this.DeleteTSButton_Click);
            // 
            // ConnectionManager
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(685, 407);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConnectionManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectionManager";
            this.Load += new System.EventHandler(this.ConnectionManager_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionGrid)).EndInit();
            this.ConnectionManagerStrip.ResumeLayout(false);
            this.ConnectionManagerStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip ConnectionManagerStrip;
        private System.Windows.Forms.ToolStripButton AddTSButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton EditTSButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton DeleteTSButton;
        public System.Windows.Forms.DataGridView ConnectionGrid;
    }
}