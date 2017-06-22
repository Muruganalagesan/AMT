using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AMT.Common;
using AMT.Common.Constants;
using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.WMI;
using System.Linq;
namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views
{
    public partial class MachineSelection : AMT.Wizard.UI.InternalWizardPage
    {
        List<ReportUIInit> ServerItems = new List<ReportUIInit>();

        List<MachineInfo> Machines = new List<MachineInfo>();

        private readonly RemoteActionInfo remoteActionInfo;

        public MachineSelection(RemoteActionInfo remoteActionInfo)
        {
            InitializeComponent();
            this.remoteActionInfo = remoteActionInfo;
        }

        private void MachineSelection_SetActive(object sender, CancelEventArgs e)
        {
            SetWizardButtons(Wizard.UI.WizardButtons.Back | Wizard.UI.WizardButtons.Next);

        }

        private void MachineSelection_WizardNext(object sender, Wizard.UI.WizardPageEventArgs e)
        {
            this.remoteActionInfo.Machines = Machines;

            if (this.remoteActionInfo.RemoteAction == EnumHelper.RemoteAction.RemoteInstall)
                e.NewPage = "LocationSelection";
            else
                e.NewPage = "Summary";
        }

        private void MachineSelection_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDomains();

                
                foreach (TreeNode node in ServerTreeView.Nodes)
                {

                     SelectServers(node, remoteActionInfo.Machines.Select(t => t.ServerName).ToList());
                }
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
           

        }
        private void LoadDomains()
        {
            try
            {
                ServerTreeView.Nodes.Clear();

                ServerItems.Clear();
                ServerItems = new AMT.Manager.InitailizeApp().InitReportWindow(Utility.LoadDbConnectionInfo());

                new Common.CommonUIInfo().LoadDomains(ServerItems, ServerTreeView, RWImgList);
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }




        }

        private void ServerTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Name.Contains(ReportConstants.DomainKey))
                {
                    if (e.Node.Nodes.ContainsKey(ApplicationConstants.LoadingServers))
                        e.Node.Nodes[ApplicationConstants.LoadingServers].Remove();

                    new Common.CommonUIInfo().EnumerateDomain(ServerItems, e.Node.Text, e.Node, e.Node.Name,false );
                }
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
          
        }


        public Boolean IsServersSelected()
        {
            Machines.Clear();

            Boolean result = false;
            try
            {

                foreach (TreeNode node in ServerTreeView.Nodes)
                {

                    result = CheckServerSelection(node);
                }

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        private bool CheckServerSelection(TreeNode node)
        {
            Boolean result = false;
            if (node.Checked)
            {
                if (node.Name.Contains(ReportConstants.ServerKey))
                {
                    Machines.Add(new MachineInfo() { DomainName = node.Parent.Text, ServerName = node.Text });
                    result = true;
                  
                }
            }

            if (node.Nodes.Count > 0)
            {
                result = CheckSubNodes(node, result);
            }
            
            return result;
        }

        private  bool CheckSubNodes(TreeNode node, Boolean result)
        {
            foreach (TreeNode serverNode in node.Nodes)
            {
                if (serverNode.Checked)
                {
                    if (serverNode.Name.Contains(ReportConstants.ServerKey))
                    {
                        Machines.Add(new MachineInfo() { DomainName = serverNode.Parent.Text, ServerName = serverNode.Text });
                        result = true;
                       // break;
                    }
                }

                if (serverNode.Nodes.Count > 0)
                {
                    result = CheckSubNodes(serverNode, result);
                }

            }
            return result;
        }

        private bool SelectServers(TreeNode node,List<String> ServerNames)
        {
            Boolean result = false;
           
                if (node.Name.Contains(ReportConstants.ServerKey))
                {
                    if (ServerNames.Contains(node.Text))
                        node.Checked = true;
                    result = true;

                }
            

            if (node.Nodes.Count > 0)
            {
                result = SelectSubNodes(node, ServerNames);
            }

            return result;
        }

        private bool SelectSubNodes(TreeNode node,List<String> ServerNames)
        {
            Boolean result = false;
            foreach (TreeNode item in node.Nodes)
            {
               
                    if (item.Name.Contains(ReportConstants.ServerKey))
                    {
                        if (ServerNames.Contains(node.Text))
                            node.Checked = true;
                        
                       
                    }
                

                if (item.Nodes.Count > 0)
                {
                    result = SelectSubNodes(item, ServerNames );
                }

            }
            return result;
        }




        private bool MachineSelection_ValidatePageAction()
        {
            Boolean result = false;
            try
            {

                if (!IsServersSelected())
                    MessageBox.Show("Select a machine/workstation to proceed", ApplicationConstants.ApplicationName);
                else
                    result = true;
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }
       
    }
}
