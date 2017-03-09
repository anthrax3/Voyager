using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CMS.Core.Models;
using CMS.Core.DB;
using CMS.Core.Components;
using System.IO;

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

        public void LoadComponents()
        {
            var folders = Directory.GetDirectories(rootPath + "Components");
            foreach(String componentDir in folders)
            {
                var files = Directory.GetFiles(componentDir);
                foreach(String f in files)
                {
                    var fileName = f.Split('\\').Last();
                    if (!fileName.StartsWith("Com"))
                        continue;

                    var dll = Assembly.LoadFile(f);
                    var main = dll.GetTypes().FirstOrDefault(p => p.IsClass &&
                                p.GetInterfaces().Contains(typeof(IComponent)));
                    var instance = (IComponent)Activator.CreateInstance(main);

                    components.Add(instance);
                    break;
                }
            }
        }

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
            return components;
        }
    }
}