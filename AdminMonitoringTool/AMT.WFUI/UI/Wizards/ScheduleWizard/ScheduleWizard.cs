using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AMT.ReportingInterfaces;
using AMT.WFUI.UI.Wizards.ScheduleWizard.Views;

namespace AMT.WFUI.UI.Wizards.ScheduleWizard
{
    public partial class ScheduleWizard : AMT.Wizard.UI.WizardSheet
    {
        ScheduleTaskInfo scheduleTaskInfo = new ScheduleTaskInfo();
        public ScheduleWizard()
        {
            InitializeComponent();

            Pages.Add( new ReportsSelection(scheduleTaskInfo ));
            Pages.Add(new MachineSelection(scheduleTaskInfo));
            Pages.Add(new ExportSettings(scheduleTaskInfo));
            Pages.Add(new TaskSettings(scheduleTaskInfo));
            Pages.Add(new Summary(scheduleTaskInfo));
        }
    }
}
