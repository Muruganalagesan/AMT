namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views
{
    partial class MachineSelection
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineSelection));
            this.ServerTreeView = new System.Windows.Forms.TreeView();
            this.RWImgList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Size = new System.Drawing.Size(448, 64);
            this.Banner.Subtitle = "Select machine(s)/workstation(s) for performing remote action.";
            this.Banner.Title = "Machines/Workstations Selection";
            // 
            // ServerTreeView
            // 
            this.ServerTreeView.CheckBoxes = true;
            this.ServerTreeView.Location = new System.Drawing.Point(3, 70);
            this.ServerTreeView.Name = "ServerTreeView";
            this.ServerTreeView.Size = new System.Drawing.Size(442, 265);
            this.ServerTreeView.TabIndex = 1;
            this.ServerTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.ServerTreeView_AfterExpand);
            // 
            // RWImgList
            // 
            this.RWImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("RWImgList.ImageStream")));
            this.RWImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.RWImgList.Images.SetKeyName(0, "domain");
            this.RWImgList.Images.SetKeyName(1, "server");
            this.RWImgList.Images.SetKeyName(2, "root.jpg");
            this.RWImgList.Images.SetKeyName(3, "searchserver.ico");
            // 
            // MachineSelection
            // 
            this.Controls.Add(this.ServerTreeView);
            this.Name = "MachineSelection";
            this.Size = new System.Drawing.Size(448, 351);
            this.SetActive += new System.ComponentModel.CancelEventHandler(this.MachineSelection_SetActive);
            this.ValidatePageAction += new AMT.Wizard.UI.WizardPage.Validation(this.MachineSelection_ValidatePageAction);
            this.WizardNext += new AMT.Wizard.UI.WizardPageEventHandler(this.MachineSelection_WizardNext);
            this.Load += new System.EventHandler(this.MachineSelection_Load);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.ServerTreeView, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView ServerTreeView;
        private System.Windows.Forms.ImageList RWImgList;
    }
}
