using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AMT.ReportingInterfaces.WMI;
using AMT.Logger;
using System.Reflection;
using System.IO;

namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views
{
    public partial class LocationSelection : AMT.Wizard.UI.InternalWizardPage
    {
         private readonly RemoteActionInfo remoteActionInfo;

        
        public LocationSelection(RemoteActionInfo remoteActionInfo)
        {
            InitializeComponent();
            this.remoteActionInfo = remoteActionInfo;
        }

        private void LocationSelection_WizardNext(object sender, Wizard.UI.WizardPageEventArgs e)
        {
            remoteActionInfo.RemoteShareLocation = txtSharePath.Text;
        }

        private bool LocationSelection_ValidatePageAction()
        {
            Boolean  result=false ;
            try
            {
                String input = txtSharePath.Text;

                if (String.IsNullOrWhiteSpace(input))
                    MessageBox.Show("Enter a share path.", AMT.Common.Constants.ApplicationConstants.ApplicationName);
                else
                {

                    if (AMT.Common.Win32Api.NetAPICommon.PathIsUNC(input))
                    {

                        if (String.Compare(Path.GetExtension(input), ".msi", true) == 0)
                        {
                            result = true;
                        }
                        else
                            MessageBox.Show("Select a msi file.", AMT.Common.Constants.ApplicationConstants.ApplicationName);
                        
                    }
                    else
                        MessageBox.Show("Given share path is not valid.", AMT.Common.Constants.ApplicationConstants.ApplicationName);
                }
            }
           catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            return result;
          
        }

        private void LocationSelection_SetActive(object sender, CancelEventArgs e)
        {
            SetWizardButtons(Wizard.UI.WizardButtons.Back | Wizard.UI.WizardButtons.Next);
            txtSharePath.Text = remoteActionInfo.RemoteShareLocation;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog openfileDialog = new OpenFileDialog();
                openfileDialog.CheckFileExists = true;
                openfileDialog.CheckPathExists = true;
                openfileDialog.Filter = "Msi Files (.msi)|*.msi|All Files (*.*)|*.*";
                if (openfileDialog.ShowDialog() == DialogResult.OK)
                {

                    remoteActionInfo.RemoteShareLocation = openfileDialog.FileName;
                    txtSharePath.Text = remoteActionInfo.RemoteShareLocation;
                }

            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
        }
    }
}
