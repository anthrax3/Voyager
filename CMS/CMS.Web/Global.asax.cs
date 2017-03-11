using CMS.Core;
using CMS.Core.Services.ComponentsLoader;
using CMS.Core.Services.Log;
using CMS.Core.Services.Templates;
using CMS.Web;
using CMS.Web.App_Start;
using CMS.Web.Services.ViewEngine;
using Microsoft.Practices.Unity;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: PreApplicationStartMethod(typeof(Initializer), "Initialize")]

namespace CMS.Web
{

    public class MvcApplication : System.Web.HttpApplication
    {
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

            var zxc = AppDomain.CurrentDomain.GetAssemblies();

            //Web bootstrap
            var webBootstrap = UnityConfig.GetConfiguredContainer().Resolve<WebBootstrap>();
            webBootstrap.Init();
        }
    }

    public class Initializer
    {
        public static void Initialize()
        {
            //var asm = Assembly.LoadFrom("C:\\Users\\Pawel\\Desktop\\CMS\\CMS\\CMS.Web\\bin/ComArticles.dll");
            //BuildManager.AddReferencedAssembly(asm);
        }
    }
}
