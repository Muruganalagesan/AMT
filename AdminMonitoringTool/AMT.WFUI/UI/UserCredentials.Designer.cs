namespace AMT.WFUI
{
		partial class UserCredentials: System.Object {
			private System.Windows.Forms.ToolTip CredentialToolTip;
			private System.Windows.Forms.Button btnCancel;
			private System.Windows.Forms.Button btnConnect;
			private System.Windows.Forms.Button btnTest;
			private System.Windows.Forms.CheckBox chkLocalConnection;
			private System.Windows.Forms.CheckBox chkSavePassword;

			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.IContainer components = null;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.GroupBox groupBox2;
			private System.Windows.Forms.Label lblDescription;
			private System.Windows.Forms.Label lblDomainName;
			private System.Windows.Forms.Label lblPassword;
			private System.Windows.Forms.Label lblServerName;
			private System.Windows.Forms.Label lblUserName;
			private System.Windows.Forms.Panel panel1;
			private System.Windows.Forms.Panel panel2;
			private System.Windows.Forms.TextBox txtDomainName;
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
				this.panel1 = new System.Windows.Forms.Panel();
				this.chkSavePassword = new System.Windows.Forms.CheckBox();
				this.chkLocalConnection = new System.Windows.Forms.CheckBox();
				this.btnTest = new System.Windows.Forms.Button();
				this.groupBox2 = new System.Windows.Forms.GroupBox();
				this.groupBox1 = new System.Windows.Forms.GroupBox();
				this.txtPassword = new System.Windows.Forms.TextBox();
				this.lblPassword = new System.Windows.Forms.Label();
				this.txtUserName = new System.Windows.Forms.TextBox();
				this.lblUserName = new System.Windows.Forms.Label();
				this.txtServerName = new System.Windows.Forms.TextBox();
				this.txtDomainName = new System.Windows.Forms.TextBox();
				this.lblServerName = new System.Windows.Forms.Label();
				this.lblDomainName = new System.Windows.Forms.Label();
				this.btnCancel = new System.Windows.Forms.Button();
				this.btnConnect = new System.Windows.Forms.Button();
				this.panel2 = new System.Windows.Forms.Panel();
				this.lblDescription = new System.Windows.Forms.Label();
				this.CredentialToolTip = new System.Windows.Forms.ToolTip(this.components);
				this.panel1.SuspendLayout();
				this.panel2.SuspendLayout();
				this.SuspendLayout();
				//
				// panel1
				//
				this.panel1.Controls.Add(this.chkSavePassword);
				this.panel1.Controls.Add(this.chkLocalConnection);
				this.panel1.Controls.Add(this.btnTest);
				this.panel1.Controls.Add(this.groupBox2);
				this.panel1.Controls.Add(this.groupBox1);
				this.panel1.Controls.Add(this.txtPassword);
				this.panel1.Controls.Add(this.lblPassword);
				this.panel1.Controls.Add(this.txtUserName);
				this.panel1.Controls.Add(this.lblUserName);
				this.panel1.Controls.Add(this.txtServerName);
				this.panel1.Controls.Add(this.txtDomainName);
				this.panel1.Controls.Add(this.lblServerName);
				this.panel1.Controls.Add(this.lblDomainName);
				this.panel1.Controls.Add(this.btnCancel);
				this.panel1.Controls.Add(this.btnConnect);
				this.panel1.Controls.Add(this.panel2);
				this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.panel1.Location = new System.Drawing.Point(0, 0);
				this.panel1.Name = "panel1";
				this.panel1.Size = new System.Drawing.Size(283, 266);
				this.panel1.TabIndex = 0;
				//
				// chkSavePassword
				//
				this.chkSavePassword.Location = new System.Drawing.Point(29, 194);
				this.chkSavePassword.Name = "chkSavePassword";
				this.chkSavePassword.Size = new System.Drawing.Size(253, 31);
				this.chkSavePassword.TabIndex = 15;
				this.chkSavePassword.Text = "Save password in Windows Stored User Names and Passwords applet ";
				this.chkSavePassword.UseVisualStyleBackColor = true;
				//
				// chkLocalConnection
				//
				this.chkLocalConnection.AutoSize = true;
				this.chkLocalConnection.Location = new System.Drawing.Point(16, 105);
				this.chkLocalConnection.Name = "chkLocalConnection";
				this.chkLocalConnection.Size = new System.Drawing.Size(134, 17);
				this.chkLocalConnection.TabIndex = 14;
				this.chkLocalConnection.Text = "Login using credentials";
				this.chkLocalConnection.UseVisualStyleBackColor = true;
				this.chkLocalConnection.CheckedChanged += new System.EventHandler(this.chkLocalConnection_CheckedChanged);
				//
				// btnTest
				//
				this.btnTest.Location = new System.Drawing.Point(14, 238);
				this.btnTest.Name = "btnTest";
				this.btnTest.Size = new System.Drawing.Size(75, 23);
				this.btnTest.TabIndex = 13;
				this.btnTest.Text = "&Test";
				this.btnTest.UseVisualStyleBackColor = true;
				this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
				//
				// groupBox2
				//
				this.groupBox2.Location = new System.Drawing.Point(-1, 224);
				this.groupBox2.Name = "groupBox2";
				this.groupBox2.Size = new System.Drawing.Size(289, 10);
				this.groupBox2.TabIndex = 12;
				this.groupBox2.TabStop = false;
				//
				// groupBox1
				//
				this.groupBox1.Location = new System.Drawing.Point(1, 17);
				this.groupBox1.Name = "groupBox1";
				this.groupBox1.Size = new System.Drawing.Size(316, 10);
				this.groupBox1.TabIndex = 11;
				this.groupBox1.TabStop = false;
				//
				// txtPassword
				//
				this.txtPassword.Location = new System.Drawing.Point(96, 167);
				this.txtPassword.Name = "txtPassword";
				this.txtPassword.Size = new System.Drawing.Size(184, 20);
				this.txtPassword.TabIndex = 10;
				this.txtPassword.UseSystemPasswordChar = true;
				//
				// lblPassword
				//
				this.lblPassword.AutoSize = true;
				this.lblPassword.Location = new System.Drawing.Point(13, 167);
				this.lblPassword.Name = "lblPassword";
				this.lblPassword.Size = new System.Drawing.Size(56, 13);
				this.lblPassword.TabIndex = 9;
				this.lblPassword.Text = "Password:";
				//
				// txtUserName
				//
				this.txtUserName.Location = new System.Drawing.Point(96, 131);
				this.txtUserName.Name = "txtUserName";
				this.txtUserName.Size = new System.Drawing.Size(184, 20);
				this.txtUserName.TabIndex = 8;
				//
				// lblUserName
				//
				this.lblUserName.AutoSize = true;
				this.lblUserName.Location = new System.Drawing.Point(13, 134);
				this.lblUserName.Name = "lblUserName";
				this.lblUserName.Size = new System.Drawing.Size(63, 13);
				this.lblUserName.TabIndex = 7;
				this.lblUserName.Text = "User Name:";
				//
				// txtServerName
				//
				this.txtServerName.Location = new System.Drawing.Point(96, 72);
				this.txtServerName.Name = "txtServerName";
				this.txtServerName.Size = new System.Drawing.Size(184, 20);
				this.txtServerName.TabIndex = 6;
				//
				// txtDomainName
				//
				this.txtDomainName.Location = new System.Drawing.Point(96, 37);
				this.txtDomainName.Name = "txtDomainName";
				this.txtDomainName.Size = new System.Drawing.Size(184, 20);
				this.txtDomainName.TabIndex = 5;
				//
				// lblServerName
				//
				this.lblServerName.AutoSize = true;
				this.lblServerName.Location = new System.Drawing.Point(13, 79);
				this.lblServerName.Name = "lblServerName";
				this.lblServerName.Size = new System.Drawing.Size(72, 13);
				this.lblServerName.TabIndex = 4;
				this.lblServerName.Text = "Server Name:";
				//
				// lblDomainName
				//
				this.lblDomainName.AutoSize = true;
				this.lblDomainName.Location = new System.Drawing.Point(13, 40);
				this.lblDomainName.Name = "lblDomainName";
				this.lblDomainName.Size = new System.Drawing.Size(77, 13);
				this.lblDomainName.TabIndex = 3;
				this.lblDomainName.Text = "Domain Name:";
				//
				// btnCancel
				//
				this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.btnCancel.Location = new System.Drawing.Point(203, 238);
				this.btnCancel.Name = "btnCancel";
				this.btnCancel.Size = new System.Drawing.Size(75, 23);
				this.btnCancel.TabIndex = 2;
				this.btnCancel.Text = "&Cancel";
				this.btnCancel.UseVisualStyleBackColor = true;
				this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
				//
				// btnConnect
				//
				this.btnConnect.Location = new System.Drawing.Point(122, 238);
				this.btnConnect.Name = "btnConnect";
				this.btnConnect.Size = new System.Drawing.Size(75, 23);
				this.btnConnect.TabIndex = 1;
				this.btnConnect.Text = "&Connect";
				this.btnConnect.UseVisualStyleBackColor = true;
				this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
				//
				// panel2
				//
				this.panel2.Controls.Add(this.lblDescription);
				this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
				this.panel2.Location = new System.Drawing.Point(0, 0);
				this.panel2.Name = "panel2";
				this.panel2.Size = new System.Drawing.Size(283, 22);
				this.panel2.TabIndex = 0;
				//
				// lblDescription
				//
				this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
				this.lblDescription.Location = new System.Drawing.Point(0, 0);
				this.lblDescription.Name = "lblDescription";
				this.lblDescription.Size = new System.Drawing.Size(283, 22);
				this.lblDescription.TabIndex = 0;
				this.lblDescription.Text = "Enter the credentials for connecting to server/workstation";
				//
				// UserCredentials
				//
				this.AcceptButton = this.btnConnect;
				this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.CancelButton = this.btnCancel;
				this.ClientSize = new System.Drawing.Size(283, 266);
				this.ControlBox = false;
				this.Controls.Add(this.panel1);
				this.MaximizeBox = false;
				this.Name = "UserCredentials";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
				this.Text = "User Credentials";
				this.panel1.ResumeLayout(false);
				this.panel1.PerformLayout();
				this.panel2.ResumeLayout(false);
				this.ResumeLayout(false);
			}
		}
}
