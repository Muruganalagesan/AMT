using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AMT.ReportingInterfaces;

namespace AMT.WFUI.UI.Wizards.ScheduleWizard.Views
{
    public partial class ExportSettings : AMT.Wizard.UI.InternalWizardPage
    {
        private ScheduleTaskInfo scheduleTaskInfo = null;
        public ExportSettings(ScheduleTaskInfo scheduleTaskInfo)
        {
            InitializeComponent();
            this.scheduleTaskInfo = scheduleTaskInfo;
        }
    }
}
