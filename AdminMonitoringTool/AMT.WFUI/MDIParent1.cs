using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AMT.WFUI
{
    public partial class AMTMain : Form
    {
        private int childFormNumber = 0;

        public AMTMain ()
        {
            InitializeComponent();
        }

        private void ShowNewForm (object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile (object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click (object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click (object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click (object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click (object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click (object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click (object sender, EventArgs e)
        {
         //   toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click (object sender, EventArgs e)
        {
          //  statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click (object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click (object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click (object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click (object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click (object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void newToolStripMenuItem1_Click (object sender, EventArgs e)
        {
            ReportWindow n = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.Services);
            n.MdiParent = this;
            n.Show();
        }

        private void toolStripButton1_Click (object sender, EventArgs e)
        {
            //GetServiceReport();

           // GetQuickFixReport();
            //GetLogicalDiskReport();
            //GetCompSystemReport();

            //GetBIOSReport();
          //  GetBootReport();
            GetOSReport();
        }


        private void GetCompSystemReport ()
        {
            ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.ComputerSystem);

            serviceReportWindow.MdiParent = this;
            serviceReportWindow.Show();
        }

        private void GetBIOSReport ()
        {
            ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.BIOS);

            serviceReportWindow.MdiParent = this;
            serviceReportWindow.Show();
        }


        private void GetBootReport ()
        {
            ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.BootConfiguration);

            serviceReportWindow.MdiParent = this;
            serviceReportWindow.Show();
        }

        private void GetOSReport ()
        {
            ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.OperatingSystem);

            serviceReportWindow.MdiParent = this;
            serviceReportWindow.Show();
        }

        private void GetServiceReport ()
        {
            ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.Services);

            serviceReportWindow.MdiParent = this;
            serviceReportWindow.Show();
        }

        private void toolStripButton2_Click (object sender, EventArgs e)
        {
           // GetApplicationReport();
        }

        private void GetApplicationReport ()
        {
            ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.Application);

            serviceReportWindow.MdiParent = this;
            serviceReportWindow.Show();
        }

        private void GetQuickFixReport ()
        {
            ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.QuickFix );

            serviceReportWindow.MdiParent = this;
            serviceReportWindow.Show();
        }

        private void GetLogicalDiskReport ()
        {
            ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.LogicalDisk );

            serviceReportWindow.MdiParent = this;
            serviceReportWindow.Show();
        }
    }
}
