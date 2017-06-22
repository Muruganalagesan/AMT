using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AMT.Logger;
using System.Reflection;
using AMT.ReportingInterfaces.WMI;
using System.IO;
using AMT.Common.Constants;
using AMT.Common;
using AMT.ReportingInterfaces;

namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views
{
    public partial class SaveAction : AMT.Wizard.UI.InternalWizardPage
    {

        private readonly RemoteActionInfo remoteActionInfo;

       
        public SaveAction(RemoteActionInfo remoteActionInfo)
        {
            InitializeComponent();
            this.remoteActionInfo = remoteActionInfo;
        }

        private bool SaveAction_ValidatePageAction()
        {
            Boolean result = false;
            try
            {
                

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }

            return result;
        }

        private void SaveAction_SetActive(object sender, CancelEventArgs e)
        {

            SetWizardButtons(Wizard.UI.WizardButtons.Back | Wizard.UI.WizardButtons.Finish);

            txtActionName.Text=remoteActionInfo.ActionName ;
            txtDescription.Text = remoteActionInfo.ActionDescription;
        }

        private void SaveAction_WizardNext(object sender, Wizard.UI.WizardPageEventArgs e)
        {
            //SetWizardButtons(Wizard.UI.WizardButtons.Back | Wizard.UI.WizardButtons.Next);
        }

        private void SaveAction_WizardFinish(object sender, CancelEventArgs e)
        {

            remoteActionInfo.ActionName = txtActionName.Text;
            remoteActionInfo.ActionDescription = txtDescription.Text;
                
            List<RemoteActionInfo > remoteactionListInfo= new List<RemoteActionInfo> ();
            try
            {
                if(! Directory.Exists (ApplicationInfo.RemoteActionPath))
                    Directory.CreateDirectory (ApplicationInfo.RemoteActionPath);

                if(File.Exists (ApplicationInfo.RemoteActionFile))
                    XMLSerializer<List<RemoteActionInfo>>.DeSerializeInputs (ApplicationInfo.RemoteActionFile,ref remoteactionListInfo );



               if( DoSerializationCheck(e, remoteactionListInfo))
                XMLSerializer<List<RemoteActionInfo>>.SerializeInputs<List<RemoteActionInfo>>(ApplicationInfo.RemoteActionFile, remoteactionListInfo);

               

              // remoteActionInfo = t;



            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
        }

        private Boolean DoSerializationCheck(CancelEventArgs e, List<RemoteActionInfo> remoteactionListInfo)
        {
            Boolean result = false;
            try
            {
                if (!String.IsNullOrWhiteSpace(remoteActionInfo.ActionName))
                {

                    var test = remoteactionListInfo.Where(t => t.ActionName == remoteActionInfo.ActionName).Count();
                    if (test > 0)
                    {
                        MessageBox.Show("Profile name already exists.");
                        e.Cancel = true;

                    }
                    else
                    {
                        remoteactionListInfo.Add(remoteActionInfo);
                        result = true;
                    }

                }

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            return result;
        }

        private void SaveAction_WizardBack(object sender, Wizard.UI.WizardPageEventArgs e)
        {
            remoteActionInfo.ActionName = txtActionName.Text;
            remoteActionInfo.ActionDescription = txtDescription.Text;
        }
    }
}
