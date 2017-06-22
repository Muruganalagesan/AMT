using AMT.Common;
using AMT.Common.Constants;
using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.WMI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard
{
    public partial class RemoteSettings : Form
    {
        List<RemoteActionInfo> remoteActionInfo = new List<RemoteActionInfo>();

        public RemoteSettings()
        {
            InitializeComponent();
        }


        public void LoadProfiles()
        {
            try
            {
                lvRemoteSettings.Items .Clear();
                remoteActionInfo.Clear();

                remoteActionInfo = Utility.LoadRemoteActions();

                foreach (var item in remoteActionInfo)
                {
                    ListViewItem lvItem = new ListViewItem(item.ActionName);

                    lvItem.SubItems.Add(item.ActionDescription);

                    lvRemoteSettings.Items.Add(lvItem);
                    
                }

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProfiles();
        }

        private void RemoteSettings_Load(object sender, EventArgs e)
        {
            LoadProfiles();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvRemoteSettings.SelectedItems.Count > 0)
                {
                    if (Utility.RemoveRemoteAction(lvRemoteSettings.SelectedItems[0].Text))
                    {
                        MessageBox.Show("Action deleted sucessfully.",ApplicationConstants.ApplicationName );
                    }
                }
                else
                    MessageBox.Show("Select a action.", ApplicationConstants.ApplicationName);

                LoadProfiles();
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
          
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (lvRemoteSettings.SelectedItems.Count > 0)
            {
                RemoteActionInfo remoteaction = Utility.GetRemoteAction(lvRemoteSettings.SelectedItems[0].Text);

                new StatusWindow(remoteaction).ShowDialog(this);
            }
            else
                MessageBox.Show("Select a action.", ApplicationConstants.ApplicationName);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void PrepareSummary(RemoteActionInfo remoteaction)
        {
            StringBuilder summary = new StringBuilder();

            try
            {
                summary.AppendLine("Summary:");
                summary.AppendLine("======");
                summary.AppendLine("Action:" + remoteaction.RemoteActionCaption);
                summary.AppendLine("Servers:");
                summary.AppendLine("======");
                foreach (MachineInfo item in remoteaction.Machines)
                {
                    summary.AppendLine(item.DomainName + @"\" + item.ServerName);

                }
                if (!String.IsNullOrWhiteSpace(remoteaction.RemoteShareLocation))
                    summary.AppendLine("Share Path:" + remoteaction.RemoteShareLocation);


                rtbSummary.Text = summary.ToString();


            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

        }

        private void lvRemoteSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 if (lvRemoteSettings.SelectedItems.Count > 0)
            {
              PrepareSummary ( Utility.GetRemoteAction(lvRemoteSettings.SelectedItems[0].Text));

              
            }
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

        }

    }
}
