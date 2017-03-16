using CMS.Core.DB;
using CMS.Core.Services.AdminMenu;
using CMS.Core.Services.ComponentsLoader;
using CMS.Core.Services.ComponentsManager;
using CMS.Core.Services.Log;
using CMS.Core.Services.Positions;
using CMS.Core.Services.Templates;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services
{
    public class UnityManager
    {
        public UnityManager()
        {

        }

        public void RegisterCoreDependencies(IUnityContainer container, String rootPath)
        {
            container.RegisterType<ILoggerService, NLogLogger>();
            container.RegisterType<IDatabaseContext, DatabaseContext>();
            container.RegisterType<ITemplatesService, TemplatesService>();
            container.RegisterType<IComponentsLoaderService, ComponentsLoaderService>(
                new ContainerControlledLifetimeManager(), new InjectionConstructor(rootPath));
            container.RegisterType<IPositionsService, PositionsService>();
            container.RegisterType<IComponentsManagerService, ComponentsManagerService>();
            container.RegisterType<IAdminMenuService, AdminMenuService>();
        }
    }
}
