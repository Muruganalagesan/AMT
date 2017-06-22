using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AMT.Logger;

namespace AMT.WFUI
{
    public static class Validation
    {
        public static bool ValidateEmptyValue (TextBox ts)
        {
            Boolean result = false;
            try
            {
                if (!String.IsNullOrEmpty(ts.Text))
                    result = true;
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            return result;
        }


        public static bool ValidateComboBox (ComboBox combo)
        {
            Boolean result = false;
            try
            {
                if ((combo.Items.Count > 0) && (combo.SelectedIndex >= 0) && (combo.Text != "---Select---"))
                    result = true;


            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            return result;
        }

    }
}
