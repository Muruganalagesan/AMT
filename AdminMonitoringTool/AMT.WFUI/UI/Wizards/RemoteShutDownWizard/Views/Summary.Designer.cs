namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views
{
    partial class Summary
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
            this.rtbSummary = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Subtitle = "Shows summary about selected action and machine(s) / workstation(s).";
            this.Banner.Title = "Summary";
            // 
            // rtbSummary
            // 
            this.rtbSummary.Location = new System.Drawing.Point(3, 73);
            this.rtbSummary.Name = "rtbSummary";
            this.rtbSummary.Size = new System.Drawing.Size(426, 209);
            this.rtbSummary.TabIndex = 1;
            this.rtbSummary.Text = "";
            // 
            // Summary
            // 
            this.Controls.Add(this.rtbSummary);
            this.Name = "Summary";
            this.Size = new System.Drawing.Size(432, 291);
            this.SetActive += new System.ComponentModel.CancelEventHandler(this.Summary_SetActive);
            this.WizardNext += new AMT.Wizard.UI.WizardPageEventHandler(this.Summary_WizardNext);
            this.WizardBack += new AMT.Wizard.UI.WizardPageEventHandler(this.Summary_WizardBack);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.rtbSummary, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbSummary;
    }
}
