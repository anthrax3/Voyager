using CMS.Core.Services.Log;
using CMS.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace CMS.Web.Filters
{
    public class LogErrorFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var logger = UnityConfig.GetConfiguredContainer().Resolve<ILoggerService>();
            logger.Log(Level.Critical, filterContext.Exception);
        }
    }
}