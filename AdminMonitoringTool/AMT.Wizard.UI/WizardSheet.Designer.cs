using System;
using System.Collections.Generic;
using System.Text;

namespace AMT.Wizard.UI
{
   partial class WizardSheet
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;


      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
            {
               components.Dispose();
            }
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
            this.backButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.finishButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.etchedLine1 = new AMT.Wizard.UI.EtchedLine();
            this.pagePanel = new System.Windows.Forms.Panel();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backButton.Location = new System.Drawing.Point(134, 8);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "< &Back";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.nextButton.Location = new System.Drawing.Point(208, 8);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "&Next >";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // finishButton
            // 
            this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.finishButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.finishButton.Location = new System.Drawing.Point(208, 8);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 2;
            this.finishButton.Text = "&Finish";
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(296, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.etchedLine1);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.backButton);
            this.buttonPanel.Controls.Add(this.finishButton);
            this.buttonPanel.Controls.Add(this.nextButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 101);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(384, 40);
            this.buttonPanel.TabIndex = 4;
            // 
            // etchedLine1
            // 
            this.etchedLine1.Dock = System.Windows.Forms.DockStyle.Top;
            this.etchedLine1.Edge = AMT.Wizard.UI.EtchEdge.Top;
            this.etchedLine1.Location = new System.Drawing.Point(0, 0);
            this.etchedLine1.Name = "etchedLine1";
            this.etchedLine1.Size = new System.Drawing.Size(384, 8);
            this.etchedLine1.TabIndex = 4;
            // 
            // pagePanel
            // 
            this.pagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePanel.Location = new System.Drawing.Point(0, 0);
            this.pagePanel.Name = "pagePanel";
            this.pagePanel.Size = new System.Drawing.Size(384, 101);
            this.pagePanel.TabIndex = 5;
            // 
            // WizardSheet
            // 
            this.AcceptButton = this.nextButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(384, 141);
            this.ControlBox = false;
            this.Controls.Add(this.pagePanel);
            this.Controls.Add(this.buttonPanel);
            this.MaximizeBox = false;
            this.Name = "WizardSheet";
            this.Text = "WizardSheet";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.WizardSheet_Closing);
            this.Load += new System.EventHandler(this.WizardSheet_Load);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

      }
      #endregion

      private System.Windows.Forms.Button backButton;
       protected System.Windows.Forms.Button nextButton;
      private System.Windows.Forms.Button finishButton;
      private System.Windows.Forms.Button cancelButton;
      private System.Windows.Forms.Panel buttonPanel;
      private AMT.Wizard.UI.EtchedLine etchedLine1;
      private System.Windows.Forms.Panel pagePanel;
   }
}
