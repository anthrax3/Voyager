using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CMS.Core.Models;
using CMS.Core.Database;

namespace CMS.Core.Services.ComponentsService
{
    public class ComponentsService : IComponentsService
    {
        IDatabaseContext db = null;

        List<IComponent> components = new List<IComponent>();

        public ComponentsService(IDatabaseContext db)
        {
            this.db = db;
        }

        public List<Type> GetInternalComponentsList()
        {
            var components = new List<Type>();
            var listOfComponents = db.Set<ComponentModel>().
                                        Select(p => new { p.Namespace, p.MainClassName }).
                                        ToList();

            for(int i=0; i<listOfComponents.Count; i++)
            {
                var ns = listOfComponents[i].Namespace;
                var name = listOfComponents[i].MainClassName;

                Type t = Assembly.GetExecutingAssembly().GetTypes()
                                 .FirstOrDefault(p => p.Namespace == ns && p.Name == name);
                components.Add(t);
            }

            return components;
        }

        public void LoadInternalComponents()
        {
            /*var componentsList = GetInternalComponentsList();
            var container = UnityConfig.GetConfiguredContainer();
            var containerType = container.GetType();
            for (int i = 0; i < componentsList.Count; i++)
            {
                var com = (IComponent)container.Resolve(componentsList[i], "");
                components.Add(com);
            }*/
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

        public List<IComponent> GetLoadedComponents()
        {
            return null;
        }
    }
}