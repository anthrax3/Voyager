using CMS.Core.App_Start;
using CMS.Core.DAL;
using CMS.Core.Models;
using CMS.Core.Services.ConfigService;
using CMS.Core.Services.LoggerService;
using CMS.Core.Services.TemplatesService;
using Microsoft.Practices.Unity;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CMS.Core
{
    public class MvcApplication : System.Web.HttpApplication
    {
        static readonly ILoggerService logger = 
            UnityConfig.GetConfiguredContainer().Resolve<ILoggerService>();
        static readonly ITemplatesService templates =
            UnityConfig.GetConfiguredContainer().Resolve<ITemplatesService>();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ExtendedRazorViewEngine());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, 
                 Migrations.Configuration>());
            
            templates.SetActiveTemplateInViewEngine();
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
