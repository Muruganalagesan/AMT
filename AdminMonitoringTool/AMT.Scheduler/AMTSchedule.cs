using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMT.Scheduler
{
    public partial class AMTSchedule : Form
    {
        public String TaskName { get; set; }

        //public AMTSchedule ()
        //{
        //    InitializeComponent();
        //}


        public AMTSchedule (String TaskName)
        {
            InitializeComponent();

            this.TaskName = TaskName;
        }

        private void AMTSchedule_Load (object sender, EventArgs e)
        {
       //     ExecuteTask2();
            
                Parallel.Invoke(() => ExecuteTasks(), () => ExecuteTask1(), () => ExecuteTask2());
           
           

            //for (int i = 0; i < 10; i++)
            //{
            //    ExecuteTasks();
                
            //}


           

        }

        public  void ExecuteTasks ()
        {
            TaskInitiator taskInitiator = new TaskInitiator(this.TaskName);
            taskInitiator.InitManager(ReportingInterfaces.EnumHelper.WMIReportCategory.Services);

           // ExecuteTask1();


            //ExecuteTask2();
        }

        public void ExecuteTask2 ()
        {
            TaskInitiator taskInitiator2 = new TaskInitiator(this.TaskName);
            taskInitiator2.InitManager(ReportingInterfaces.EnumHelper.WMIReportCategory.Groups);
        }

        private void ExecuteTask1 ()
        {
            TaskInitiator taskInitiator1 = new TaskInitiator(this.TaskName);
            taskInitiator1.InitManager(ReportingInterfaces.EnumHelper.WMIReportCategory.Application);
        }


        
    }
}
//ReportCategory
