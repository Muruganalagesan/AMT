using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AMT.Logger;
using AMT.ReportingInterfaces;
using AMT.ReportingInterfaces.WMI;

namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views
{
    public partial class Summary : AMT.Wizard.UI.InternalWizardPage
    {

        private readonly RemoteActionInfo remoteActionInfo;

       
       
        public Summary(RemoteActionInfo remoteActionInfo)
        {
            InitializeComponent();
             this.remoteActionInfo = remoteActionInfo;
        }

        private void Summary_SetActive(object sender, CancelEventArgs e)
        {
            SetWizardButtons(Wizard.UI.WizardButtons.Back | Wizard.UI.WizardButtons.Next);
            PrepareSummary();
        }

        private void Summary_WizardNext(object sender, Wizard.UI.WizardPageEventArgs e)
        {

        }

        private void Summary_WizardBack(object sender, Wizard.UI.WizardPageEventArgs e)
        {
            if (remoteActionInfo.RemoteAction != ReportingInterfaces.EnumHelper.RemoteAction.RemoteInstall)
                e.NewPage = "MachineSelection";
        }

        private void PrepareSummary()
        {
            StringBuilder summary = new StringBuilder();

            try
            {
                summary.AppendLine("Summary:");
                summary.AppendLine("======");
                summary.AppendLine("Action:" + remoteActionInfo.RemoteActionCaption);
                summary.AppendLine("Servers:");
                summary.AppendLine("======");
                foreach (MachineInfo item in remoteActionInfo.Machines )
                {
                    summary.AppendLine(item.DomainName + @"\" + item.ServerName  );
                    
                }
                if(!String.IsNullOrWhiteSpace ( remoteActionInfo.RemoteShareLocation ))
                    summary.AppendLine("Share Path:" + remoteActionInfo.RemoteShareLocation);


                rtbSummary.Text = summary.ToString();
              
                
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

        }
    }
}
