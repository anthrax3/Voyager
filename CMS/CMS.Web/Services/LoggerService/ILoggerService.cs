using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Web.Services.LoggerService
{
    public enum Level
    {
        Info,
        Warn,
        Error,
        Critical
    }

    public interface ILoggerService
    {
        void Log(Level level, String message);
        void Log(Level level, Exception ex);
    }
}
