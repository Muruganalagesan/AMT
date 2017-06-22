using AMT.Logger;
using AMT.ReportingInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMT.Common.Constants
{
   public  class ApplicationConstants
    {

       public const String ApplicationName = "AMT";

       public const String ApplicationLongName = "Admin Monitoring Tool";

      public const String ProfileName = "AMTProfile.xml";

      public const String DBProfileName = "AMTDBProfile.xml";

       public const String Connected = "Connected";

       public const String DisConnected = "DisConnected";

       public const String LoadingServers = "Loading servers";

     

    }


   public static class ApplicationInfo
   {
       public static String ApplicationDocumentPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), ApplicationConstants.ApplicationName);

       public static String ApplicationPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), ApplicationConstants.ApplicationName);

       public static String ProfileFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), ApplicationConstants.ApplicationName, ApplicationConstants.ProfileName );

       public static String DatabaseName = "AMTDB" + "-" + Environment.MachineName;

       public static String DBProfileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), ApplicationConstants.ApplicationName, ApplicationConstants.DBProfileName);

       public static String QueryFilePath = Path.Combine(ApplicationInfo.ApplicationDocumentPath, "Queries");

       public static String RemoteActionPath = Path.Combine(ApplicationInfo.ApplicationDocumentPath, "Remote");

       public static String RemoteActionFile = Path.Combine(RemoteActionPath, "RemoteAction.xml");

   

   }

}
