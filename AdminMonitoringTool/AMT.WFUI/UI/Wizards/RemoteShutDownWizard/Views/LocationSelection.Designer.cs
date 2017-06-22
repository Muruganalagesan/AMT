namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views
{
    partial class LocationSelection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSharePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Size = new System.Drawing.Size(412, 64);
            this.Banner.Subtitle = "Select location of msi packages";
            this.Banner.Title = "Location Selection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Share Folder Lcoation:";
            // 
            // txtSharePath
            // 
            this.txtSharePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSharePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtSharePath.Location = new System.Drawing.Point(124, 83);
            this.txtSharePath.Name = "txtSharePath";
            this.txtSharePath.Size = new System.Drawing.Size(232, 20);
            this.txtSharePath.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(362, 83);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblNote
            // 
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(39, 109);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(353, 81);
            this.lblNote.TabIndex = 4;
            this.lblNote.Text = "Note: Select only files with .msi extension for installation. \r\n\r\nFormat::\\\\<Mach" +
    "ineName>\\<ShareName>\\<msi file path>.\r\n\r\nExample:\\\\Universe79\\Share\\test.msi";
            // 
            // LocationSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtSharePath);
            this.Controls.Add(this.label1);
            this.Name = "LocationSelection";
            this.Size = new System.Drawing.Size(412, 213);
            this.SetActive += new System.ComponentModel.CancelEventHandler(this.LocationSelection_SetActive);
            this.ValidatePageAction += new AMT.Wizard.UI.WizardPage.Validation(this.LocationSelection_ValidatePageAction);
            this.WizardNext += new AMT.Wizard.UI.WizardPageEventHandler(this.LocationSelection_WizardNext);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtSharePath, 0);
            this.Controls.SetChildIndex(this.btnBrowse, 0);
            this.Controls.SetChildIndex(this.lblNote, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSharePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblNote;
    }
}
