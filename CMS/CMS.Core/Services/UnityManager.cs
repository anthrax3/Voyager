using CMS.Core.Database;
using CMS.Core.Services.Components;
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

        public void RegisterCoreDependencies(IUnityContainer container)
        {
            container.RegisterType<ILoggerService, NLogLogger>();
            container.RegisterType<IDatabaseContext, DatabaseContext>();
            container.RegisterType<ITemplatesService, TemplatesService>();
            container.RegisterType<IComponentsService, ComponentsService>();
            container.RegisterType<IPositionsService, PositionsService>();
        }
    }
}
