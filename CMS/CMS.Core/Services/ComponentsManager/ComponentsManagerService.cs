using CMS.Core.Components;
using CMS.Core.DB;
using CMS.Core.Models;
using CMS.Core.Services.ComponentsLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.ComponentsManager
{
    internal class ComponentsManagerService : IComponentsManagerService
    {
        IDatabaseContext db = null;
        IComponentsLoaderService componentsLoader = null;

        public ComponentsManagerService(IDatabaseContext db, IComponentsLoaderService componentsLoader)
        {
            this.db = db;
            this.componentsLoader = componentsLoader;
        }

        /// <summary>
        /// Returns false if any of the loaded component is not present in database.
        /// </summary>
        public bool ValidateLoadedComponents()
        {
            var loadedComponets = componentsLoader.GetLoadedComponents();
            foreach(IComponent com in loadedComponets)
            {
                if (!db.Set<ComponentModel>().Any(p => p.Name == com.Name))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Call component action. Returns null if passed component name not exist.
        /// </summary>
        public CallResult CallComponent(CallParameters parameters)
        {
            var component = componentsLoader.GetComponent(parameters.ComponentName);
            if (component == null)
                return null;

            var coreState = new CoreState()
            {
                Database = db
            };

            var result = component.DoAction(parameters, coreState);
            return result;
        }
    }
}
