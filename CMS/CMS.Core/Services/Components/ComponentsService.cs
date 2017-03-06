using CMS.Core.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Microsoft.Practices.Unity;

namespace CMS.Core.Services.Components
{
    public class ComponentsService : IComponentsService
    {
        List<IComponent> components = new List<IComponent>();

        public List<Type> GetInternalComponentsList()
        {
            String componentsNamespace = "CMS.Core.InternalComponents";

            var components = Assembly.GetExecutingAssembly().GetTypes()
                .Where(p => p.IsClass && 
                       p.Namespace == componentsNamespace && 
                       p.GetInterfaces().Contains(typeof(IComponent)))
                .ToList();

            return components;
        }

        public void LoadInternalComponents()
        {
            var componentsList = GetInternalComponentsList();
            var container = UnityConfig.GetConfiguredContainer();
            var containerType = container.GetType();
            for (int i = 0; i < componentsList.Count; i++)
            {
                var com = (IComponent)container.Resolve(componentsList[i], "");
                components.Add(com);
            }
        }

        public T GetComponent<T>()
        {
            return (T)components.FirstOrDefault(p => p.GetType().GetInterfaces().
                                                              Contains(typeof(T)));
        }

        public IComponent GetComponent(ComponentType type)
        {
            return components.FirstOrDefault(p => p.Type == type);
        }

        public IComponent GetComponent(String name)
        {
            return components.FirstOrDefault(p => p.Name == name);
        }
    }
}