using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMT.CredentialManagement;
namespace AMT.Common.Profiles
{
   public class WindowsPromptInfo :XPPrompt
    {


       public void test ()
       {
           XPPrompt xp = new XPPrompt();
           xp.AlwaysShowUI = true;
           xp.CompleteUsername = true;
           xp.DoNotPersist = false;
           xp.ExpectConfirmation = true;
           xp.GenericCredentials = true;
           xp.Message = "Enter the credentials for AMT";
           xp.RequestAdministrator = true;
           xp.ShowSaveCheckBox = true;
           xp.Target = "Sample";
           xp.ValidateUsername = true;
       }
       



      
    }
}
