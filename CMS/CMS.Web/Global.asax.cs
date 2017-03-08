using CMS.Core;
using CMS.Core.Services.ComponentsLoader;
using CMS.Core.Services.Log;
using CMS.Core.Services.Templates;
using CMS.Web.App_Start;
using CMS.Web.Services.ViewEngine;
using Microsoft.Practices.Unity;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        static readonly ILoggerService logger = 
            UnityConfig.GetConfiguredContainer().Resolve<ILoggerService>();
        static readonly IComponentsLoaderService componentsLoaderService =
            UnityConfig.GetConfiguredContainer().Resolve<IComponentsLoaderService>();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ExtendedRazorViewEngine());

            componentsLoaderService.LoadComponents();

            //Web bootstrap
            var webBootstrap = UnityConfig.GetConfiguredContainer().Resolve<WebBootstrap>();
            webBootstrap.Init();
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
