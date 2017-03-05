using CMS.Core.App_Start;
using CMS.Core.DAL;
using CMS.Core.Models;
using CMS.Core.Services.ConfigService;
using CMS.Core.Services.LoggerService;
using Microsoft.Practices.Unity;
using System;
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
        static readonly IDBConfigService config =
            UnityConfig.GetConfiguredContainer().Resolve<IDBConfigService>();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            config.Load(Server.MapPath("/") + "Database.config");

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, 
                 Migrations.Configuration>());
            
            var connectionTestDB = UnityConfig.GetConfiguredContainer().Resolve<IDatabaseContext>();
            if (!connectionTestDB.IsConnected)
                logger.Log(Level.Critical, "Can't connect to database");
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
