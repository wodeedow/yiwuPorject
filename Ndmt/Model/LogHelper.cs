using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using log4net.Core;
using log4net.Appender;
using log4net.Filter;
using log4net.Repository.Hierarchy;

namespace Ndmt.Model
{
    public class LogHelper
    {
        private static readonly log4net.ILog mLogger ;
        private static MemoryAppender consoleAppender;
        private static MemoryAppender logAppender;

        public static MemoryAppender RegisteredConsoleAppender
        {
            get { return consoleAppender; }
        }

        public static MemoryAppender RegisteredLogAppender
        {
            get { return logAppender; }
        }

        static LogHelper()
        {
            RegisterMemoryLogAppender();
            mLogger = log4net.LogManager.GetLogger("WUPLogger");
            CreateLogPatternIndex();
        }

        private static void CreateLogPatternIndex()
        {
            mLogMessageIndex = new Dictionary<string, string>();
            mLogLevelIndex = new Dictionary<string, Level>();

            try
            {
                XElement logInfo = XElement.Parse(global::Ndmt.Properties.Resources.LogInfo);

                var debugLog = from debug in logInfo.Element("Debug").Descendants() select debug;
                foreach (var debug in debugLog)
                {
                    string debugLocation = debug.FirstAttribute.Value;
                    mLogMessageIndex.Add(debugLocation, debug.Value.ToString());
                    mLogLevelIndex.Add(debugLocation, Level.Debug);
                }

                var infoLog = from info in logInfo.Element("Info").Descendants() select info;
                foreach (var info in infoLog)
                {
                    string infoLocation = info.FirstAttribute.Value;
                    mLogMessageIndex.Add(infoLocation, info.Value.ToString());
                    mLogLevelIndex.Add(infoLocation, Level.Info);
                }

                var warnLog = from warn in logInfo.Element("Warn").Descendants() select warn;
                foreach (var warn in warnLog)
                {
                    string warnLocation = warn.FirstAttribute.Value;
                    mLogMessageIndex.Add(warnLocation, warn.Value.ToString());
                    mLogLevelIndex.Add(warnLocation, Level.Warn);
                }

                var errorLog = from error in logInfo.Element("Error").Descendants() select error;
                foreach (var error in errorLog)
                {
                    string errorLocation = error.FirstAttribute.Value;
                    mLogMessageIndex.Add(errorLocation, error.Value.ToString());
                    mLogLevelIndex.Add(errorLocation, Level.Error);
                }

                var fatalLog = from fatal in logInfo.Element("Fatal").Descendants() select fatal;
                foreach (var fatal in fatalLog)
                {
                    string fatalLocation = fatal.FirstAttribute.Value;
                    mLogMessageIndex.Add(fatalLocation, fatal.Value.ToString());
                    mLogLevelIndex.Add(fatalLocation, Level.Fatal);
                }
            }

            catch (Exception e)
            {
                LogHere("LogHelperInitException", e.Message);
            }
        }

        private static void RegisterMemoryLogAppender()
        {
            // 初始化MemoryAppender，用以绑定界面的Console
            consoleAppender = new MemoryAppender
            {
                Name = "ConsoleAppender",
#if DEBUG
                Threshold = log4net.Core.Level.Debug
#else  
                Threshold = log4net.Core.Level.Info
#endif
            };
            consoleAppender.ClearFilters();

            // 初始化MemoryAppender，用以绑定界面的Log
            logAppender = new MemoryAppender
            {
                Name = "LogAppender",
                Threshold = log4net.Core.Level.Info
            };
            logAppender.ClearFilters();
            LevelMatchFilter filter = new LevelMatchFilter();
            filter.LevelToMatch = Level.Info;
            logAppender.AddFilter(filter);

            // 将Appender加入日志系统
            Hierarchy repository = log4net.LogManager.GetRepository() as Hierarchy;
            repository.Root.AddAppender(consoleAppender);
            repository.Root.AddAppender(logAppender);
        }

        // Timestamp [ThreadName] Level - RenderedMessage
        public const string MAConversionPattern = " {0} [{1}] {2} - {3}";

        public static void Init()
        {

        }

        /// <summary>
        /// DEBUG  INFO  WARN  ERROR  FATAL
        /// </summary>
        public static void LogHere(string location, params object[] values)
        {
            string logMessage = String.Format(mLogMessageIndex[location], values);//获取name后的一串汉字 0？
            switch (mLogLevelIndex[location].ToString())//获取name的父标签
            {
                case "DEBUG":
                    mLogger.Debug(logMessage);
                    break;
                case "INFO":
                    mLogger.Info(logMessage);
                    break;
                case "WARN":
                    mLogger.Warn(logMessage);
                    break;
                case "ERROR":
                    mLogger.Error(logMessage);
                    break;
                case "FATAL":
                    mLogger.Fatal(logMessage);
                    break;
                default:
                    break; 
            }
            
        }

        private static Dictionary<string, string> mLogMessageIndex;
        private static Dictionary<string, Level> mLogLevelIndex;
    }
}
