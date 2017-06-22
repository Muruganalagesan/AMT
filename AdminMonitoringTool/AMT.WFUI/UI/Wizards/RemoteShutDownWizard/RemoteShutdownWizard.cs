using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AMT.ReportingInterfaces.WMI;
using AMT.WFUI.UI.Wizards;
using AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views;
namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard
{
    public partial class RemoteShutdownWizard : AMT.Wizard.UI.WizardSheet
    {

      public   RemoteActionInfo remoteactionInfo = new RemoteActionInfo();
        public RemoteShutdownWizard()
        {
            InitializeComponent();
            Pages.Add(new ActionSelection(remoteactionInfo));
            Pages.Add(new MachineSelection(remoteactionInfo));
            Pages.Add(new LocationSelection(remoteactionInfo));
            Pages.Add(new Summary(remoteactionInfo));
            Pages.Add(new SaveAction(remoteactionInfo));
        }

        private void RemoteShutdownWizard_Load(object sender, EventArgs e)
        {
          
        }

        
    }
}
