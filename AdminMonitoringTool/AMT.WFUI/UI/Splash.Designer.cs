namespace AMT.WFUI
{
		partial class Splash: System.Object {
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.IContainer components = null;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.Label lblCopyRight;
			private System.Windows.Forms.Label lblStatus;
			private System.Windows.Forms.PictureBox pictureBox1;

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
				this.groupBox1 = new System.Windows.Forms.GroupBox();
				this.lblStatus = new System.Windows.Forms.Label();
				this.lblCopyRight = new System.Windows.Forms.Label();
				this.pictureBox1 = new System.Windows.Forms.PictureBox();
				this.groupBox1.SuspendLayout();
				((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
				this.SuspendLayout();
				//
				// groupBox1
				//
				this.groupBox1.Controls.Add(this.lblStatus);
				this.groupBox1.Controls.Add(this.lblCopyRight);
				this.groupBox1.Controls.Add(this.pictureBox1);
				this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.groupBox1.Location = new System.Drawing.Point(0, 0);
				this.groupBox1.Name = "groupBox1";
				this.groupBox1.Size = new System.Drawing.Size(513, 287);
				this.groupBox1.TabIndex = 0;
				this.groupBox1.TabStop = false;
				//
				// lblStatus
				//
				this.lblStatus.Location = new System.Drawing.Point(16, 205);
				this.lblStatus.Name = "lblStatus";
				this.lblStatus.Size = new System.Drawing.Size(402, 23);
				this.lblStatus.TabIndex = 2;
				this.lblStatus.Text = "status";
				//
				// lblCopyRight
				//
				this.lblCopyRight.AutoSize = true;
				this.lblCopyRight.Location = new System.Drawing.Point(13, 236);
				this.lblCopyRight.Name = "lblCopyRight";
				this.lblCopyRight.Size = new System.Drawing.Size(133, 13);
				this.lblCopyRight.TabIndex = 1;
				this.lblCopyRight.Text = "Copyright reserved @2014";
				//
				// pictureBox1
				//
				this.pictureBox1.Location = new System.Drawing.Point(12, 38);
				this.pictureBox1.Name = "pictureBox1";
				this.pictureBox1.Size = new System.Drawing.Size(144, 149);
				this.pictureBox1.TabIndex = 0;
				this.pictureBox1.TabStop = false;
				//
				// Splash
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(513, 287);
				this.ControlBox = false;
				this.Controls.Add(this.groupBox1);
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
				this.MaximizeBox = false;
				this.Name = "Splash";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "Splash";
				this.Load += new System.EventHandler(this.Splash_Load);
				this.groupBox1.ResumeLayout(false);
				this.groupBox1.PerformLayout();
				((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
				this.ResumeLayout(false);
			}
		}
}
