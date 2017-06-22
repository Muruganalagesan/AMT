namespace AMT.WFUI.UI
{
		partial class SettingsManager: System.Object {
			public System.Windows.Forms.ToolTip ServerToolTip;
			private System.Windows.Forms.Button btnCancel;
			private System.Windows.Forms.Button btnOK;
			private System.Windows.Forms.Button btnTestConnection;

			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.IContainer components = null;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.GroupBox grpAuthentication;
			private System.Windows.Forms.GroupBox grpSQLDetails;
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.Label lblPassword;
			private System.Windows.Forms.Label lblUserName;
			private System.Windows.Forms.Panel panel1;
			private System.Windows.Forms.RadioButton rdbSQL;
			private System.Windows.Forms.RadioButton rdbSQLAuthentication;
			private System.Windows.Forms.RadioButton rdbSQLCE;
			private System.Windows.Forms.RadioButton rdbWinAuthentication;
			private System.Windows.Forms.SplitContainer splitContainer1;
			private System.Windows.Forms.SplitContainer splitContainer2;
			private System.Windows.Forms.TreeView trwSettings;
			private System.Windows.Forms.TextBox txtPassword;
			private System.Windows.Forms.TextBox txtServerName;
			private System.Windows.Forms.TextBox txtUserName;

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
				this.components = new System.ComponentModel.Container();
				System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Database Settings");
				System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Settings", new System.Windows.Forms.TreeNode[] {
				treeNode1});
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsManager));
				this.splitContainer1 = new System.Windows.Forms.SplitContainer();
				this.trwSettings = new System.Windows.Forms.TreeView();
				this.splitContainer2 = new System.Windows.Forms.SplitContainer();
				this.panel1 = new System.Windows.Forms.Panel();
				this.groupBox1 = new System.Windows.Forms.GroupBox();
				this.grpSQLDetails = new System.Windows.Forms.GroupBox();
				this.btnTestConnection = new System.Windows.Forms.Button();
				this.grpAuthentication = new System.Windows.Forms.GroupBox();
				this.lblPassword = new System.Windows.Forms.Label();
				this.lblUserName = new System.Windows.Forms.Label();
				this.rdbSQLAuthentication = new System.Windows.Forms.RadioButton();
				this.rdbWinAuthentication = new System.Windows.Forms.RadioButton();
				this.txtUserName = new System.Windows.Forms.TextBox();
				this.txtPassword = new System.Windows.Forms.TextBox();
				this.label1 = new System.Windows.Forms.Label();
				this.txtServerName = new System.Windows.Forms.TextBox();
				this.rdbSQL = new System.Windows.Forms.RadioButton();
				this.rdbSQLCE = new System.Windows.Forms.RadioButton();
				this.btnCancel = new System.Windows.Forms.Button();
				this.btnOK = new System.Windows.Forms.Button();
				this.ServerToolTip = new System.Windows.Forms.ToolTip(this.components);
				((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
				this.splitContainer1.Panel1.SuspendLayout();
				this.splitContainer1.Panel2.SuspendLayout();
				this.splitContainer1.SuspendLayout();
				((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
				this.splitContainer2.Panel1.SuspendLayout();
				this.splitContainer2.Panel2.SuspendLayout();
				this.splitContainer2.SuspendLayout();
				this.panel1.SuspendLayout();
				this.groupBox1.SuspendLayout();
				this.grpSQLDetails.SuspendLayout();
				this.grpAuthentication.SuspendLayout();
				this.SuspendLayout();
				//
				// splitContainer1
				//
				this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.splitContainer1.Location = new System.Drawing.Point(0, 0);
				this.splitContainer1.Name = "splitContainer1";
				//
				// splitContainer1.Panel1
				//
				this.splitContainer1.Panel1.Controls.Add(this.trwSettings);
				//
				// splitContainer1.Panel2
				//
				this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
				this.splitContainer1.Size = new System.Drawing.Size(595, 374);
				this.splitContainer1.SplitterDistance = 198;
				this.splitContainer1.TabIndex = 0;
				//
				// trwSettings
				//
				this.trwSettings.Dock = System.Windows.Forms.DockStyle.Fill;
				this.trwSettings.Location = new System.Drawing.Point(0, 0);
				this.trwSettings.Name = "trwSettings";
				treeNode1.Name = "DatabaseSettings";
				treeNode1.Text = "Database Settings";
				treeNode2.Name = "Settings";
				treeNode2.Text = "Settings";
				this.trwSettings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
				treeNode2});
				this.trwSettings.Size = new System.Drawing.Size(198, 374);
				this.trwSettings.TabIndex = 0;
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
				this.splitContainer2.Panel1.Controls.Add(this.panel1);
				//
				// splitContainer2.Panel2
				//
				this.splitContainer2.Panel2.Controls.Add(this.btnCancel);
				this.splitContainer2.Panel2.Controls.Add(this.btnOK);
				this.splitContainer2.Size = new System.Drawing.Size(393, 374);
				this.splitContainer2.SplitterDistance = 339;
				this.splitContainer2.TabIndex = 2;
				//
				// panel1
				//
				this.panel1.Controls.Add(this.groupBox1);
				this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.panel1.Location = new System.Drawing.Point(0, 0);
				this.panel1.Name = "panel1";
				this.panel1.Size = new System.Drawing.Size(393, 339);
				this.panel1.TabIndex = 0;
				//
				// groupBox1
				//
				this.groupBox1.Controls.Add(this.btnTestConnection);
				this.groupBox1.Controls.Add(this.grpSQLDetails);
				this.groupBox1.Controls.Add(this.rdbSQL);
				this.groupBox1.Controls.Add(this.rdbSQLCE);
				this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.groupBox1.Location = new System.Drawing.Point(0, 0);
				this.groupBox1.Name = "groupBox1";
				this.groupBox1.Size = new System.Drawing.Size(393, 339);
				this.groupBox1.TabIndex = 0;
				this.groupBox1.TabStop = false;
				this.groupBox1.Text = "Database";
				//
				// grpSQLDetails
				//
				this.grpSQLDetails.Controls.Add(this.grpAuthentication);
				this.grpSQLDetails.Controls.Add(this.label1);
				this.grpSQLDetails.Controls.Add(this.txtServerName);
				this.grpSQLDetails.Location = new System.Drawing.Point(22, 86);
				this.grpSQLDetails.Name = "grpSQLDetails";
				this.grpSQLDetails.Size = new System.Drawing.Size(365, 219);
				this.grpSQLDetails.TabIndex = 2;
				this.grpSQLDetails.TabStop = false;
				//
				// btnTestConnection
				//
				this.btnTestConnection.Location = new System.Drawing.Point(22, 311);
				this.btnTestConnection.Name = "btnTestConnection";
				this.btnTestConnection.Size = new System.Drawing.Size(102, 23);
				this.btnTestConnection.TabIndex = 5;
				this.btnTestConnection.Text = "Test Connection";
				this.btnTestConnection.UseVisualStyleBackColor = true;
				this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
				//
				// grpAuthentication
				//
				this.grpAuthentication.Controls.Add(this.lblPassword);
				this.grpAuthentication.Controls.Add(this.lblUserName);
				this.grpAuthentication.Controls.Add(this.rdbSQLAuthentication);
				this.grpAuthentication.Controls.Add(this.rdbWinAuthentication);
				this.grpAuthentication.Controls.Add(this.txtUserName);
				this.grpAuthentication.Controls.Add(this.txtPassword);
				this.grpAuthentication.Location = new System.Drawing.Point(18, 60);
				this.grpAuthentication.Name = "grpAuthentication";
				this.grpAuthentication.Size = new System.Drawing.Size(341, 143);
				this.grpAuthentication.TabIndex = 4;
				this.grpAuthentication.TabStop = false;
				this.grpAuthentication.Text = "Authentication";
				//
				// lblPassword
				//
				this.lblPassword.AutoSize = true;
				this.lblPassword.Location = new System.Drawing.Point(41, 99);
				this.lblPassword.Name = "lblPassword";
				this.lblPassword.Size = new System.Drawing.Size(56, 13);
				this.lblPassword.TabIndex = 6;
				this.lblPassword.Text = "Password:";
				//
				// lblUserName
				//
				this.lblUserName.AutoSize = true;
				this.lblUserName.Location = new System.Drawing.Point(38, 73);
				this.lblUserName.Name = "lblUserName";
				this.lblUserName.Size = new System.Drawing.Size(63, 13);
				this.lblUserName.TabIndex = 5;
				this.lblUserName.Text = "User Name:";
				//
				// rdbSQLAuthentication
				//
				this.rdbSQLAuthentication.AutoSize = true;
				this.rdbSQLAuthentication.Location = new System.Drawing.Point(17, 50);
				this.rdbSQLAuthentication.Name = "rdbSQLAuthentication";
				this.rdbSQLAuthentication.Size = new System.Drawing.Size(139, 17);
				this.rdbSQLAuthentication.TabIndex = 4;
				this.rdbSQLAuthentication.Text = "Use SQL Authentication";
				this.rdbSQLAuthentication.UseVisualStyleBackColor = true;
				//
				// rdbWinAuthentication
				//
				this.rdbWinAuthentication.AutoSize = true;
				this.rdbWinAuthentication.Checked = true;
				this.rdbWinAuthentication.Location = new System.Drawing.Point(17, 20);
				this.rdbWinAuthentication.Name = "rdbWinAuthentication";
				this.rdbWinAuthentication.Size = new System.Drawing.Size(162, 17);
				this.rdbWinAuthentication.TabIndex = 3;
				this.rdbWinAuthentication.TabStop = true;
				this.rdbWinAuthentication.Text = "Use Windows Authentication";
				this.rdbWinAuthentication.UseVisualStyleBackColor = true;
				this.rdbWinAuthentication.CheckedChanged += new System.EventHandler(this.rdbWinAuthentication_CheckedChanged);
				//
				// txtUserName
				//
				this.txtUserName.Location = new System.Drawing.Point(107, 73);
				this.txtUserName.Name = "txtUserName";
				this.txtUserName.Size = new System.Drawing.Size(193, 20);
				this.txtUserName.TabIndex = 1;
				//
				// txtPassword
				//
				this.txtPassword.Location = new System.Drawing.Point(107, 99);
				this.txtPassword.Name = "txtPassword";
				this.txtPassword.Size = new System.Drawing.Size(193, 20);
				this.txtPassword.TabIndex = 2;
				this.txtPassword.UseSystemPasswordChar = true;
				//
				// label1
				//
				this.label1.AutoSize = true;
				this.label1.Location = new System.Drawing.Point(15, 25);
				this.label1.Name = "label1";
				this.label1.Size = new System.Drawing.Size(69, 13);
				this.label1.TabIndex = 3;
				this.label1.Text = "Server Name";
				//
				// txtServerName
				//
				this.txtServerName.Location = new System.Drawing.Point(90, 22);
				this.txtServerName.Name = "txtServerName";
				this.txtServerName.Size = new System.Drawing.Size(269, 20);
				this.txtServerName.TabIndex = 0;
				//
				// rdbSQL
				//
				this.rdbSQL.AutoSize = true;
				this.rdbSQL.Location = new System.Drawing.Point(7, 63);
				this.rdbSQL.Name = "rdbSQL";
				this.rdbSQL.Size = new System.Drawing.Size(102, 17);
				this.rdbSQL.TabIndex = 1;
				this.rdbSQL.Text = "Use SQL Server";
				this.rdbSQL.UseVisualStyleBackColor = true;
				this.rdbSQL.CheckedChanged += new System.EventHandler(this.rdbSQLCE_CheckedChanged);
				//
				// rdbSQLCE
				//
				this.rdbSQLCE.AutoSize = true;
				this.rdbSQLCE.Checked = true;
				this.rdbSQLCE.Location = new System.Drawing.Point(8, 29);
				this.rdbSQLCE.Name = "rdbSQLCE";
				this.rdbSQLCE.Size = new System.Drawing.Size(116, 17);
				this.rdbSQLCE.TabIndex = 0;
				this.rdbSQLCE.TabStop = true;
				this.rdbSQLCE.Text = "Use SQLServer CE";
				this.rdbSQLCE.UseVisualStyleBackColor = true;
				this.rdbSQLCE.CheckedChanged += new System.EventHandler(this.rdbSQLCE_CheckedChanged);
				//
				// btnCancel
				//
				this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.btnCancel.Location = new System.Drawing.Point(315, 5);
				this.btnCancel.Name = "btnCancel";
				this.btnCancel.Size = new System.Drawing.Size(75, 23);
				this.btnCancel.TabIndex = 1;
				this.btnCancel.Text = "Cancel";
				this.btnCancel.UseVisualStyleBackColor = true;
				//
				// btnOK
				//
				this.btnOK.Location = new System.Drawing.Point(234, 5);
				this.btnOK.Name = "btnOK";
				this.btnOK.Size = new System.Drawing.Size(75, 23);
				this.btnOK.TabIndex = 0;
				this.btnOK.Text = "OK";
				this.btnOK.UseVisualStyleBackColor = true;
				this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
				//
				// SettingsManager
				//
				this.AcceptButton = this.btnOK;
				this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.CancelButton = this.btnCancel;
				this.ClientSize = new System.Drawing.Size(595, 374);
				this.Controls.Add(this.splitContainer1);
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
				this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
				this.MaximizeBox = false;
				this.MinimizeBox = false;
				this.Name = "SettingsManager";
				this.ShowInTaskbar = false;
				this.Text = "SettingsManager";
				this.Load += new System.EventHandler(this.SettingsManager_Load);
				this.splitContainer1.Panel1.ResumeLayout(false);
				this.splitContainer1.Panel2.ResumeLayout(false);
				((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
				this.splitContainer1.ResumeLayout(false);
				this.splitContainer2.Panel1.ResumeLayout(false);
				this.splitContainer2.Panel2.ResumeLayout(false);
				((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
				this.splitContainer2.ResumeLayout(false);
				this.panel1.ResumeLayout(false);
				this.groupBox1.ResumeLayout(false);
				this.groupBox1.PerformLayout();
				this.grpSQLDetails.ResumeLayout(false);
				this.grpSQLDetails.PerformLayout();
				this.grpAuthentication.ResumeLayout(false);
				this.grpAuthentication.PerformLayout();
				this.ResumeLayout(false);
			}
		}
}
