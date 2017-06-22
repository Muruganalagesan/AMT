namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views
{
    partial class SaveAction
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtActionName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Size = new System.Drawing.Size(437, 64);
            this.Banner.Subtitle = "Save action for future use.";
            this.Banner.Title = "Save";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // txtActionName
            // 
            this.txtActionName.Location = new System.Drawing.Point(76, 71);
            this.txtActionName.Name = "txtActionName";
            this.txtActionName.Size = new System.Drawing.Size(342, 20);
            this.txtActionName.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(76, 102);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(342, 89);
            this.txtDescription.TabIndex = 4;
            // 
            // SaveAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtActionName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SaveAction";
            this.Size = new System.Drawing.Size(437, 209);
            this.SetActive += new System.ComponentModel.CancelEventHandler(this.SaveAction_SetActive);
            this.ValidatePageAction += new AMT.Wizard.UI.WizardPage.Validation(this.SaveAction_ValidatePageAction);
            this.WizardNext += new AMT.Wizard.UI.WizardPageEventHandler(this.SaveAction_WizardNext);
            this.WizardBack += new AMT.Wizard.UI.WizardPageEventHandler(this.SaveAction_WizardBack);
            this.WizardFinish += new System.ComponentModel.CancelEventHandler(this.SaveAction_WizardFinish);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDescription, 0);
            this.Controls.SetChildIndex(this.txtActionName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtActionName;
        private System.Windows.Forms.TextBox txtDescription;
    }
}
