using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AMT.Logger;
using AMT.ReportingInterfaces.WMI;

namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views
{
    public partial class ActionSelection : AMT.Wizard.UI.InternalWizardPage
    {
        private readonly RemoteActionInfo remoteActionInfo;


        public ActionSelection(RemoteActionInfo remoteActionInfo)
        {
            InitializeComponent();

            this.remoteActionInfo = remoteActionInfo;
        }
     
        public ActionSelection()
        {
          
        }

        private void ActionSelection_SetActive(object sender, CancelEventArgs e)
        {
            SetWizardButtons(Wizard.UI.WizardButtons.Next);
            LoadActionDetails();
        }


        private void LoadActionDetails()
        {
            if (remoteActionInfo.RemoteAction == ReportingInterfaces.EnumHelper.RemoteAction.RemoteInstall)
            {
                rdbRemoteInstallation.Checked=true ;
            }
            else if(remoteActionInfo.RemoteAction == ReportingInterfaces.EnumHelper.RemoteAction.RemoteReboot )
            {
                rdbRemoteReboot.Checked=true ; 
            }
            else if (remoteActionInfo.RemoteAction == ReportingInterfaces.EnumHelper.RemoteAction.RemoteShutDown)
            {
                rdbRemoteShutdown.Checked = true;
            }
            
        }
        

        private void ActionSelection_WizardNext(object sender, Wizard.UI.WizardPageEventArgs e)
        {
            try
            {
               
                
                    if (rdbRemoteInstallation.Checked)
                    {
                        remoteActionInfo.RemoteAction = ReportingInterfaces.EnumHelper.RemoteAction.RemoteInstall;

                        remoteActionInfo.RemoteActionCaption = rdbRemoteInstallation.Text;
                    }
                    else if (rdbRemoteReboot.Checked)
                    {
                        remoteActionInfo.RemoteAction = ReportingInterfaces.EnumHelper.RemoteAction.RemoteReboot;
                        remoteActionInfo.RemoteActionName = "Reboot";
                        remoteActionInfo.RemoteActionCaption=rdbRemoteReboot.Text ;
                    }
                    else if (rdbRemoteShutdown.Checked)
                    {
                        remoteActionInfo.RemoteAction = ReportingInterfaces.EnumHelper.RemoteAction.RemoteShutDown;
                        remoteActionInfo.RemoteActionName = "Shutdown";
                        remoteActionInfo.RemoteActionCaption=rdbRemoteShutdown.Text ;
                    }

                
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
             
        }

      

        private bool ActionSelection_ValidatePageAction()
        {
            return true;
        }

        private void rdbRemoteInstallation_CheckedChanged(object sender, EventArgs e)
        {
            remoteActionInfo.RemoteActionCaption = ((RadioButton)sender).Text;
        }

      
    }
}
