namespace AMT.WFUI.UI
{
    partial class DomainScanner
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbEntireScan = new System.Windows.Forms.RadioButton();
            this.rdbCustomScan = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstServers = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstServers);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.rdbCustomScan);
            this.groupBox1.Controls.Add(this.rdbEntireScan);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rdbEntireScan
            // 
            this.rdbEntireScan.AutoSize = true;
            this.rdbEntireScan.Location = new System.Drawing.Point(12, 19);
            this.rdbEntireScan.Name = "rdbEntireScan";
            this.rdbEntireScan.Size = new System.Drawing.Size(119, 17);
            this.rdbEntireScan.TabIndex = 0;
            this.rdbEntireScan.TabStop = true;
            this.rdbEntireScan.Text = "Scan entire domain.";
            this.rdbEntireScan.UseVisualStyleBackColor = true;
            this.rdbEntireScan.CheckedChanged += new System.EventHandler(this.rdbCustomScan_CheckedChanged);
            // 
            // rdbCustomScan
            // 
            this.rdbCustomScan.AutoSize = true;
            this.rdbCustomScan.Location = new System.Drawing.Point(13, 50);
            this.rdbCustomScan.Name = "rdbCustomScan";
            this.rdbCustomScan.Size = new System.Drawing.Size(144, 17);
            this.rdbCustomScan.TabIndex = 1;
            this.rdbCustomScan.TabStop = true;
            this.rdbCustomScan.Text = "Scan specific computers.";
            this.rdbCustomScan.UseVisualStyleBackColor = true;
            this.rdbCustomScan.CheckedChanged += new System.EventHandler(this.rdbCustomScan_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(96, 279);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(178, 279);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 10);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // lstServers
            // 
            this.lstServers.CheckOnClick = true;
            this.lstServers.FormattingEnabled = true;
            this.lstServers.Location = new System.Drawing.Point(33, 73);
            this.lstServers.Name = "lstServers";
            this.lstServers.ScrollAlwaysVisible = true;
            this.lstServers.Size = new System.Drawing.Size(214, 184);
            this.lstServers.TabIndex = 6;
            // 
            // DomainScanner
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(257, 308);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DomainScanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Domain Scanner";
            this.Load += new System.EventHandler(this.DomainScanner_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbCustomScan;
        private System.Windows.Forms.RadioButton rdbEntireScan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.CheckedListBox lstServers;
    }
}