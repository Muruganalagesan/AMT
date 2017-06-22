namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard
{
    partial class RemoteShutdownWizard
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
            this.SuspendLayout();
            // 
            // RemoteShutdownWizard
            // 
            this.ClientSize = new System.Drawing.Size(384, 141);
            this.Name = "RemoteShutdownWizard";
            this.Text = "Remote Action Wizard";
            this.Load += new System.EventHandler(this.RemoteShutdownWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
