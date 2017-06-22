using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AMT.Logger;
using AMT.Common;
using AMT.ReportingInterfaces;
using AMT.Common.Constants;
using AMT.WFUI.UI;
using AMT.WFUI.Common;
using AMT.Manager.ReportManagers;
using AMT.ReportingInterfaces.WMI;
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
            ReportWindow n = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.Services,EnumHelper.Mode.Collection );
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


//        BIOS
//BOOTConfig
//COMPSYS
//LogicalDisk
//OS
//Products
//Quick Fix
//Services

        private void GetCompSystemReport ()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.ComputerSystem, EnumHelper.Mode.Collection);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
         
        }

        private void GetBIOSReport ()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.BIOS, EnumHelper.Mode.Collection);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
          
        }


        private void GetBootReport ()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.BootConfiguration, EnumHelper.Mode.Collection);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
           
        }

        private void GetOSReport ()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.OperatingSystem, EnumHelper.Mode.Collection);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            
        }

        private void GetServiceReport ()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.Services);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
          
        }

        private void GetENVReport()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.EnvironmentVaraiable);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

        }


        private void GetUsersReport()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.Users, EnumHelper.Mode.Collection);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

        }


        private void GetGroupsReport()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.Groups, EnumHelper.Mode.Collection);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

        }

        private void GetNetworkAdapterReport()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.NetworkAdapter);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show( );

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

        }


        private void GetNetworkLoginProfileReport()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.NetworkLoginProfile);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

        }

        private void toolStripButton2_Click (object sender, EventArgs e)
        {
           // GetApplicationReport();
        }

        private void GetApplicationReport ()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.Application);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
           
        }

        private void GetQuickFixReport ()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.QuickFix);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
           
        }

        private void GetLogicalDiskReport ()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.LogicalDisk);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
          
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetApplicationReport();
        }

        private void hotFixesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetQuickFixReport();

        }

        private void servicesReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetServiceReport();
        }

        private void systemReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetCompSystemReport();

        }

        private void oSReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetOSReport();
        }

        private void diskReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetLogicalDiskReport();
        }

        private void bIOSReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBIOSReport();
        }

        private void bootConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBootReport();
        }

        private void eNVReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetENVReport();
        }

        private void networkAdapterReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetNetworkAdapterReport();
        }

        private void networkLoginProfileReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetNetworkLoginProfileReport();

        }

        private void usersReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetUsersReport();
        }

        private void groupReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetGroupsReport();
        }



        private void GetSharesReport ()
        {
            try
            {
                ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.Shares);

                serviceReportWindow.MdiParent = this;
                serviceReportWindow.Show();

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
        }

        private void AMTMain_FormClosing (object sender, FormClosingEventArgs e)
        {
            try
            {
                AMT.Common.XMLSerializer<ProfileConnectionInfo>.SerializeInputs<List<ProfileConnectionInfo>>(ApplicationInfo .ProfileFileName, ConnectionManagerUtil.GetProfileConnectionInfo());
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            

        }

        private void AMTMain_Load (object sender, EventArgs e)
        {
            try
            {
                new CommonUIInfo().InitApplication();


                List<ProfileConnectionInfo> items = new List<ProfileConnectionInfo>();

                AMT.Common.XMLSerializer<ProfileConnectionInfo>.DeSerializeInputs<List<ProfileConnectionInfo>>(ApplicationInfo .ProfileFileName, ref items);

                ConnectionManagerUtil.SetProfileConnectionInfo(items);
                ConnectionManagerUtil.LoadProfileTableWithValues();

                

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

        }

        private void settingsManagerToolStripMenuItem_Click (object sender, EventArgs e)
        {
            SettingsManager settingsManager = new SettingsManager();
            settingsManager.ShowDialog(this);
        }

        private void toolStripButton2_Click_1 (object sender, EventArgs e)
        {
            RemoteMachineReebot();
        }

        private static void RemoteMachineReebot ()
        {
            // ReportWindow serviceReportWindow = new ReportWindow(ReportingInterfaces.EnumHelper.WMIReportCategory.OperatingSystem,EnumHelper.Mode.Action );
            InitializeWMICollection ReportObject = null;
            ReportObject = new AMT.Manager.ReportManagers.InitializeWMICollection();

            WMIMachineInfo wmimachineInfo = new WMIMachineInfo()
            {

                ServersList = new List<MachineInfo>() { new MachineInfo() { DomainName = "Workgroup", ServerName = "10.70.70.48", UserName = "administrator", Password = "corent123$$" } },


                MachineConnectionInfo = new WMIConnectionInfo()
                {
                    ReportCategory = ReportingInterfaces.EnumHelper.WMIReportCategory.OperatingSystem,
                    ReportMode = EnumHelper.OperationMode.Interactive,

                    TimeStamp = ReportingInterfaces.EnumHelper.WMIReportCategory.OperatingSystem.ToString() + Utility.GetReportGuid(),
                    DatabaseConnectionInfo = Utility.LoadDbConnectionInfo()

                },
                IsRefersh = true,
                // CommandMode= EnumHelper.Mode.Action  
                CommandMode = EnumHelper.Mode.Action,
                ActionName = WMIConstants.MachineReboot

            };

            ReportObject.CollectReport(wmimachineInfo);
            //serviceReportWindow.MdiParent = this;
            //serviceReportWindow.Show();
        }

        private void serviceStopToolStripMenuItem_Click (object sender, EventArgs e)
        {

        }
    }
}
