namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views
{
    partial class TimePeriodSelection
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Subtitle = "Select a time period for perfroming specific action.";
            this.Banner.Title = "Time Period Selection";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(31, 83);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // TimePeriodSelection
            // 
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "TimePeriodSelection";
            this.Size = new System.Drawing.Size(432, 228);
            this.SetActive += new System.ComponentModel.CancelEventHandler(this.TimePeriodSelection_SetActive);
            this.SizeChanged += new System.EventHandler(this.TimePeriodSelection_SizeChanged);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
