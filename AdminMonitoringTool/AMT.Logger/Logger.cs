using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AMT.Logger
{
    public class Logger
        {

        public const String ApplicationName = "AMT";

        public static String ApplicationDocumentPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), ApplicationName);
        #region "Properties"

        public log4net.ILog ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string LOG_PATTERN = "%d %-5p %m%n";

        private const string LogFolder = "Logs";

        private PatternLayout _layout = new PatternLayout();

        public string DefaultPattern
            {
            get { return LOG_PATTERN; }
            }

        #endregion

        public static String LogFilePath
            {
            get;
            set;
            }
        public PatternLayout DefaultLayout
            {
            get { return _layout; }
            }
        public void AddAppender (IAppender appender)
            {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Root.AddAppender(appender);
            }
        public Logger ()
            {
            _layout.ConversionPattern = DefaultPattern;
            _layout.ActivateOptions();
            }

        public void Initialize (String Logpath, String Logname)
            {

            if (String.IsNullOrEmpty(Logpath))
                LogFilePath = Path.Combine(Path.Combine(ApplicationDocumentPath, LogFolder));
            else
                LogFilePath = Path.Combine(Logpath, LogFolder);

            ILoggerRepository repository = LogManager.GetRepository();

            if (repository.Configured == true)
                {

                IAppender[] appenders = repository.GetAppenders();

                foreach (IAppender appender in (from iAppender in appenders
                                                where iAppender is FileAppender
                                                select iAppender))
                    {
                    FileAppender provisionfileAppender = appender as FileAppender;

                    provisionfileAppender.File = Path.Combine(LogFilePath, Logname);
                    provisionfileAppender.AppendToFile = true;
                    provisionfileAppender.ActivateOptions();

                    }
                }
            else
                {
                LogFilePath = Path.Combine(LogFilePath, Logname);
                Hierarchy provisionhierarchy = (Hierarchy)LogManager.GetRepository();
                TraceAppender provisiontracer = new TraceAppender();
                PatternLayout patternLayout = new PatternLayout();

                patternLayout.ConversionPattern = LOG_PATTERN;
                patternLayout.ActivateOptions();

                provisiontracer.Layout = patternLayout;
                provisiontracer.ActivateOptions();
                provisionhierarchy.Root.AddAppender(provisiontracer);

                RollingFileAppender provisionroller = new RollingFileAppender();
                provisionroller.Layout = patternLayout;
                provisionroller.AppendToFile = true;
                provisionroller.RollingStyle = RollingFileAppender.RollingMode.Size;
                provisionroller.MaxSizeRollBackups = -1;
                provisionroller.MaximumFileSize = "4MB";
                provisionroller.StaticLogFileName = true;
                provisionroller.File = LogFilePath;
                //provisionroller.PreserveLogFileNameExtension = true;
                provisionroller.ActivateOptions();
                provisionhierarchy.Root.AddAppender(provisionroller);

                provisionhierarchy.Root.Level = Level.All;
                provisionhierarchy.Configured = true;
                }

            }

        public void InfoWriter (String message)
            {

            ILog.Info(message);
            }

        public void ErrorWriter (String message)
            {
            ILog.Error(message);
            }
        }
}
