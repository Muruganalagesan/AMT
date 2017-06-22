using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMT.Logger;
using AMT.CredentialManagement;
using System.Reflection;
using AMT.ReportingInterfaces;
namespace AMT.Common
    {
   public class ProfileManagment
        {

           public Boolean AddCredentials (String UserName,String Password, String Description="")
           {

           Boolean result = false;
           try
               {



               Credential addCredential = new Credential(UserName ,Password ,UserName ,CredentialType.Generic  );
               addCredential.Description = Description;

               if (!addCredential.Exists())
                   {
                   addCredential.Save();

                   }

           
               result =true ;
               addCredential.Dispose();

               }
           catch (Exception ex)
               {
               
              AMTLogger.WriteToLog(ex.Message , MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
               }

           return result;

           }

           public CredentialInfo GetCredentials (String ProfileName)
               {

               CredentialInfo resultCredInfo = null;
               try
                   {



                   Credential credential = new Credential();
                   credential.Target = ProfileName;

                   if (credential.Load())
                       {

                       resultCredInfo = new CredentialInfo(credential.Username,credential.Password ,credential.Description  ,credential.Target ,credential.LastWriteTimeUtc );
                        

                       }

                   credential.Dispose();


                   }
               catch (Exception ex)
                   {

                   AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
                   }

               return resultCredInfo;
               }

           public Boolean CheckProfileExists (String ProfileName)
           {

               Boolean result = false;
               try
               {

                   Credential credential = new Credential();
                   credential.Target = ProfileName;

                   result = credential.Exists();

                   credential.Dispose();
               }
               catch (Exception ex)
               {

                   AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
               }
               finally
               {
                  
               }
               return result;
           }

           public Boolean DeleteProfile (String ProfileName)
           {
               Boolean result = false;

               try
               {
                   Credential credential = new Credential();
                   credential.Target = ProfileName;


                   if (credential.Exists())
                   {
                       result = credential.Delete();
                   }
                   credential.Dispose();
               }
               catch (Exception ex)
               {

                   AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
               }

               return result;
           }


           public List<CredentialInfo> GetCredentialList ()
           {
               List<CredentialInfo> credentialInfoItems = new List<CredentialInfo>();

               try
               {
                   CredentialSet credentialSet = new CredentialSet().Load();

                   foreach (Credential credentialItem in credentialSet)
                   {

                       credentialInfoItems.Add(new CredentialInfo
                       {
                           UserName = credentialItem.Username,
                           Password = credentialItem.Password,
                           Target = credentialItem.Target,
                           Description =credentialItem.Description ,
                           ModifiedDate =credentialItem .LastWriteTimeUtc 
                      
                       });
                       
                   }


                   credentialSet.Dispose();



               }
               catch (Exception ex)
               {

                   AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
               }

               return credentialInfoItems;
           }


           public Boolean UpdateProfile (String UserName, String Password, String Description = "")
           {

               Boolean result = false;
               try
               {
                   Credential addCredential = new Credential(UserName, Password, UserName, CredentialType.Generic);
                   addCredential.Description = Description;


                   if (addCredential.Exists())
                   {
                       addCredential.Delete();

                   }

                   if (!addCredential.Exists())
                   {
                       addCredential.Save();

                   }


                   result = true;
                   addCredential.Dispose();
               }
               catch (Exception ex)
               {

                   AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
               }
               return result;

           }


           private void  ShowWindowsCredentialDialog()
           {
               try
               {

                   //if (Environment.OSVersion.Version.Major >= 6)
                   //{
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

                       xp.ShowDialog();
                  


               }
               catch (Exception ex)
               {

                   AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
               }




           }

           


        }
    }
