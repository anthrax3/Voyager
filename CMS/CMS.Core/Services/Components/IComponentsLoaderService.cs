using CMS.Core.Components;
using System;
using System.Collections.Generic;

namespace CMS.Core.Services.Components
{
    public interface IComponentsLoaderService
    {
        void LoadComponents();
        //List<Type> GetComponentsList();

        T GetComponent<T>();
        IComponent GetComponent(String name);
        List<IComponent> GetLoadedComponents();
    }
}
