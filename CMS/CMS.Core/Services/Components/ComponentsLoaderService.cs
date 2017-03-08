using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CMS.Core.Models;
using CMS.Core.DB;
using CMS.Core.Components;
using System.IO;

namespace CMS.Core.Services.Components
{
    internal class ComponentsLoaderService : IComponentsLoaderService
    {
        List<IComponent> components = new List<IComponent>();
        String rootPath = String.Empty;

        public ComponentsLoaderService(String rootPath)
        {
            this.rootPath = rootPath;
        }

        public void LoadComponents()
        {
            var folders = Directory.GetDirectories(rootPath + "Components");
            foreach(String componentDir in folders)
            {

            }
        }

        /*public List<Type> GetComponentsList()
        {
            var components = new List<Type>();
            //var folders = Directory.GetDirectories("~")

            /*for(int i=0; i<listOfComponents.Count; i++)
            {
                var ns = listOfComponents[i].Namespace;
                var name = listOfComponents[i].MainClassName;

                Type t = Assembly.GetExecutingAssembly().GetTypes()
                                 .FirstOrDefault(p => p.Namespace == ns && p.Name == name);
                components.Add(t);
            }

            return null;
        }*/

        public T GetComponent<T>()
        {
            return (T)components.FirstOrDefault(p => p.GetType().GetInterfaces().
                                                              Contains(typeof(T)));
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