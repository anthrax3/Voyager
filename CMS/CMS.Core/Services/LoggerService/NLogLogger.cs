using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;

namespace CMS.Core.Services.Implementations
{
    public class NLogLogger : ILoggerService
    {
        Logger logger = null;

        public NLogLogger()
        {
            this.logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public void Log(Level level, Exception ex)
        {
            LogLevel convertedLogLevel = ConvertToNLogFormatFromLevel(level);
            logger.Log(convertedLogLevel, ex);
        }

        public void Log(Level level, string message)
        {
            LogLevel convertedLogLevel = ConvertToNLogFormatFromLevel(level);
            logger.Log(convertedLogLevel, message);
        }

        LogLevel ConvertToNLogFormatFromLevel(Level level)
        {
            switch(level)
            {
                case (Level.Error): return LogLevel.Error;
                case (Level.Warn): return LogLevel.Warn;
                case (Level.Info): return LogLevel.Info;
                case (Level.Critical): return LogLevel.Fatal;
            }

            return LogLevel.Debug;
        }
    }
}