using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AMT.Logger;
using AMT.ReportingInterfaces;

namespace AMT.WFStatusUpdater
{
  public class ProgressUpdaterInfo
    {
     public  ProgressDialog progressDialog = new ProgressDialog();

      //public delegate void DoWorker(object sender, DoWorkEventArgs e);

      //public event DoWorker objDoworker = null;


     public IWin32Window Owner { get; set; }

     long ProgressMaxValue{

         get; set;
     }

     long ProgressMinValue
     {

         get;
         set;
     }


      public Boolean ShowDialog(IntPtr handle)
      {

          Boolean result = false;
          try
          {
             // IntPtr myWindowHandle = new IntPtr(handle);
              IWin32Window w = Control.FromHandle(handle);

              progressDialog.Show(w );
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return result;
      }

      public Boolean ShowDialog()
      {

          Boolean result = false;
          try
          {
             

              progressDialog.ShowDialog();
          }
          catch (Exception ex)
          {

              AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
          }

          return result;
      }

      public void WindowText(String input)
      {
         this. progressDialog.Text = input +"...";
      }


      public void SetProgressMaxValue(long value)
      {
          this.ProgressMaxValue = value;
      }

      public void SetProgressMinValue(long value)
      {
          this.ProgressMinValue = value;
      }

      public void SetProgressStyle(ProgressBarStyle style)
      {


          
          this.progressDialog.ProgressBar.Style = style;
         
      }


      public void SetDoWork()
      {
         // this.progressDialog.BackgroundWorker.DoWork += objDoworker;
      }

    

     

    }
}
