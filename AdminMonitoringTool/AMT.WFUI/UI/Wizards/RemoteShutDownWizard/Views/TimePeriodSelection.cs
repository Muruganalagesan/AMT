using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AMT.WFUI.UI.Wizards.RemoteShutDownWizard.Views
{
    public partial class TimePeriodSelection : AMT.Wizard.UI.InternalWizardPage
    {
        public TimePeriodSelection()
        {
            InitializeComponent();
        }

        private void TimePeriodSelection_SizeChanged(object sender, EventArgs e)
        {

        }

        private void TimePeriodSelection_SetActive(object sender, CancelEventArgs e)
        {
            SetWizardButtons(Wizard.UI.WizardButtons.Back | Wizard.UI.WizardButtons.Next);

        }
    }
}
