namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views
{
    partial class ActionSelection
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
            this.rdbRemoteReboot = new System.Windows.Forms.RadioButton();
            this.rdbRemoteShutdown = new System.Windows.Forms.RadioButton();
            this.rdbRemoteInstallation = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Subtitle = "Select a remote action.";
            this.Banner.Title = "Action Selection";
            // 
            // rdbRemoteReboot
            // 
            this.rdbRemoteReboot.AutoSize = true;
            this.rdbRemoteReboot.Checked = true;
            this.rdbRemoteReboot.Location = new System.Drawing.Point(12, 70);
            this.rdbRemoteReboot.Name = "rdbRemoteReboot";
            this.rdbRemoteReboot.Size = new System.Drawing.Size(108, 17);
            this.rdbRemoteReboot.TabIndex = 1;
            this.rdbRemoteReboot.TabStop = true;
            this.rdbRemoteReboot.Text = "Reboot machines";
            this.rdbRemoteReboot.UseVisualStyleBackColor = true;
            this.rdbRemoteReboot.CheckedChanged += new System.EventHandler(this.rdbRemoteInstallation_CheckedChanged);
            // 
            // rdbRemoteShutdown
            // 
            this.rdbRemoteShutdown.AutoSize = true;
            this.rdbRemoteShutdown.Location = new System.Drawing.Point(12, 105);
            this.rdbRemoteShutdown.Name = "rdbRemoteShutdown";
            this.rdbRemoteShutdown.Size = new System.Drawing.Size(121, 17);
            this.rdbRemoteShutdown.TabIndex = 2;
            this.rdbRemoteShutdown.TabStop = true;
            this.rdbRemoteShutdown.Text = "Shutdown machines";
            this.rdbRemoteShutdown.UseVisualStyleBackColor = true;
            this.rdbRemoteShutdown.CheckedChanged += new System.EventHandler(this.rdbRemoteInstallation_CheckedChanged);
            // 
            // rdbRemoteInstallation
            // 
            this.rdbRemoteInstallation.AutoSize = true;
            this.rdbRemoteInstallation.Location = new System.Drawing.Point(12, 137);
            this.rdbRemoteInstallation.Name = "rdbRemoteInstallation";
            this.rdbRemoteInstallation.Size = new System.Drawing.Size(275, 17);
            this.rdbRemoteInstallation.TabIndex = 3;
            this.rdbRemoteInstallation.TabStop = true;
            this.rdbRemoteInstallation.Text = "Install softwares in remote machine(s)/workstations(s)";
            this.rdbRemoteInstallation.UseVisualStyleBackColor = true;
            this.rdbRemoteInstallation.CheckedChanged += new System.EventHandler(this.rdbRemoteInstallation_CheckedChanged);
            // 
            // ActionSelection
            // 
            this.Controls.Add(this.rdbRemoteInstallation);
            this.Controls.Add(this.rdbRemoteShutdown);
            this.Controls.Add(this.rdbRemoteReboot);
            this.Name = "ActionSelection";
            this.Size = new System.Drawing.Size(432, 170);
            this.SetActive += new System.ComponentModel.CancelEventHandler(this.ActionSelection_SetActive);
            this.ValidatePageAction += new AMT.Wizard.UI.WizardPage.Validation(this.ActionSelection_ValidatePageAction);
            this.WizardNext += new AMT.Wizard.UI.WizardPageEventHandler(this.ActionSelection_WizardNext);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.rdbRemoteReboot, 0);
            this.Controls.SetChildIndex(this.rdbRemoteShutdown, 0);
            this.Controls.SetChildIndex(this.rdbRemoteInstallation, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbRemoteReboot;
        private System.Windows.Forms.RadioButton rdbRemoteShutdown;
        private System.Windows.Forms.RadioButton rdbRemoteInstallation;
    }
}
