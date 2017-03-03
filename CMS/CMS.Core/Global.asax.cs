using CMS.Core.App_Start;
using CMS.Core.Services;
using CMS.Core.Services.Implementations;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CMS.Core
{
    public class MvcApplication : System.Web.HttpApplication
    {
        static readonly ILoggerService logger = 
            UnityConfig.GetConfiguredContainer().Resolve<ILoggerService>();
        static readonly IConfigService config =
            UnityConfig.GetConfiguredContainer().Resolve<IConfigService>();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            config.Load(Server.MapPath("/") + "CMS.config");
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (exception != null)
            {
                logger.Log(Level.Critical, exception);
            }
        }
    }
}
