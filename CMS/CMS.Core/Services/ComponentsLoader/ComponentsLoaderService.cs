using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CMS.Core.Models;
using CMS.Core.DB;
using CMS.Core.Components;
using System.IO;
using System.Web.Compilation;
using Microsoft.Practices.Unity;
using CMS.Core.Services.Messages;

namespace CMS.Core.Services.ComponentsLoader
{
    internal class ComponentsLoaderService : IComponentsLoaderService
    {
        List<IComponent> components = new List<IComponent>();
        String rootPath = String.Empty;

        public ComponentsLoaderService(String rootPath)
        {
            this.rootPath = rootPath;
        }

        /// <summary>
        /// Loads components from specified directory (rootPath). Returns false if 
        /// any of the loaded components hasn't implemented IComponent interface.
        /// </summary>
        public bool LoadComponents()
        {
            var assembliesList = AppDomain.CurrentDomain.GetAssemblies();
            foreach(Assembly assembly in assembliesList)
            {
                var types = assembly.GetTypes();
                var main = types.FirstOrDefault(p => p.IsClass &&
                           p.GetInterfaces().Contains(typeof(IComponent)));
                if (main == null)
                    continue;
                var instance = (IComponent)Activator.CreateInstance(main);
                components.Add(instance);
            }

            return true;
        }

        /// <summary>
        /// Returns component instance by type. Returns null if specified type is not loaded.
        /// </summary>
        public T GetComponent<T>()
        {
            return (T)components.FirstOrDefault(p => p.GetType().GetInterfaces().
                                                              Contains(typeof(T)));
        }

        /// <summary>
        /// Returns component instance by name. Returns null if specified type is not loaded.
        /// </summary>
        public IComponent GetComponent(String name)
        {
            return components.FirstOrDefault(p => p.Name == name);
        }

        /// <summary>
        /// Returns all loaded components.
        /// </summary>
        public List<IComponent> GetLoadedComponents()
        {
            return components;
        }

        public void InitComponents(IUnityContainer container, IMessagesService messagesService)
        {
            for(int i=0; i<components.Count; i++)
            {
                components[i].SetupUnity(container);
            }
        }
    }
}