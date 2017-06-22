using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMT.Logger
    {
   
    public  static class AMTLogger
        {
        private static Logger log = new Logger();

        private static string FullLogFilePath = String.Empty;

        static AMTLogger ()
            {
            log.Initialize(String.Empty, "AMTErrorLog.log");
            }

        public static String LogFilePath
            {
            get;
            set;
            }

        public static bool ResetLog
            {
            get;
            set;
            }

        public enum LogInfo
            {
            Info = 1,
            Error

            }

        public static void WriteToLog (String message, String methodName = "", int errorNumber = 0, LogInfo messageType = LogInfo.Info)
            {
            try
                {
                if (messageType == LogInfo.Info)
                    {
                    log.InfoWriter(String.Format("{0} \t {1}", methodName, message));
                    }
                else
                    {
                    log.ErrorWriter(String.Format("{0} \t {1}", methodName, message));
                    }


                }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            }

        }


    }
