namespace AMT.WFUI.UI
{
		partial class StatusWindow: System.Object {
			private System.Windows.Forms.Button btnClose;
			private System.Windows.Forms.Button btnLogs;

			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.IContainer components = null;
			private Wizard.UI.EtchedLine etchedLine1;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.ListBox lstStatus;

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
				this.btnLogs = new System.Windows.Forms.Button();
				this.btnClose = new System.Windows.Forms.Button();
				this.etchedLine1 = new AMT.Wizard.UI.EtchedLine();
				this.groupBox1 = new System.Windows.Forms.GroupBox();
				this.lstStatus = new System.Windows.Forms.ListBox();
				this.groupBox1.SuspendLayout();
				this.SuspendLayout();
				//
				// btnLogs
				//
				this.btnLogs.Location = new System.Drawing.Point(126, 235);
				this.btnLogs.Name = "btnLogs";
				this.btnLogs.Size = new System.Drawing.Size(75, 23);
				this.btnLogs.TabIndex = 1;
				this.btnLogs.Text = "Logs";
				this.btnLogs.UseVisualStyleBackColor = true;
				this.btnLogs.Visible = false;
				//
				// btnClose
				//
				this.btnClose.Location = new System.Drawing.Point(207, 235);
				this.btnClose.Name = "btnClose";
				this.btnClose.Size = new System.Drawing.Size(75, 23);
				this.btnClose.TabIndex = 2;
				this.btnClose.Text = "Close";
				this.btnClose.UseVisualStyleBackColor = true;
				this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
				//
				// etchedLine1
				//
				this.etchedLine1.Edge = AMT.Wizard.UI.EtchEdge.Top;
				this.etchedLine1.Location = new System.Drawing.Point(-4, 228);
				this.etchedLine1.Name = "etchedLine1";
				this.etchedLine1.Size = new System.Drawing.Size(289, 1);
				this.etchedLine1.TabIndex = 0;
				//
				// groupBox1
				//
				this.groupBox1.Controls.Add(this.lstStatus);
				this.groupBox1.Controls.Add(this.btnLogs);
				this.groupBox1.Controls.Add(this.btnClose);
				this.groupBox1.Controls.Add(this.etchedLine1);
				this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.groupBox1.Location = new System.Drawing.Point(0, 0);
				this.groupBox1.Name = "groupBox1";
				this.groupBox1.Size = new System.Drawing.Size(284, 261);
				this.groupBox1.TabIndex = 3;
				this.groupBox1.TabStop = false;
				//
				// lstStatus
				//
				this.lstStatus.FormattingEnabled = true;
				this.lstStatus.Location = new System.Drawing.Point(6, 12);
				this.lstStatus.Name = "lstStatus";
				this.lstStatus.Size = new System.Drawing.Size(276, 212);
				this.lstStatus.TabIndex = 3;
				//
				// StatusWindow
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(284, 261);
				this.ControlBox = false;
				this.Controls.Add(this.groupBox1);
				this.MaximizeBox = false;
				this.Name = "StatusWindow";
				this.Text = "Remote Action Status";
				this.Load += new System.EventHandler(this.StatusWindow_Load);
				this.groupBox1.ResumeLayout(false);
				this.ResumeLayout(false);
			}
		}
}
