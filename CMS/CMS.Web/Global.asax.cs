using CMS.Web.App_Start;
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
        /*static readonly ILoggerService logger = 
            UnityConfig.GetConfiguredContainer().Resolve<ILoggerService>();
        static readonly ITemplatesService templates =
            UnityConfig.GetConfiguredContainer().Resolve<ITemplatesService>();
        static readonly IComponentsService components =
            UnityConfig.GetConfiguredContainer().Resolve<IComponentsService>();*/

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ExtendedRazorViewEngine());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CMS.Core.Database.DatabaseContext,
                 CMS.Core.Migrations.Configuration>());

            //components.LoadInternalComponents();
            //templates.SetActiveTemplateInViewEngine();
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (exception != null)
            {
                //logger.Log(Level.Critical, exception);
            }
        }
    }
}
