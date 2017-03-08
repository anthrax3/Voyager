using System;
using System.Collections.Generic;

namespace CMS.Core.Services.Components
{
    public interface IComponentsService
    {
        List<Type> GetInternalComponentsList();
        void LoadInternalComponents();

        T GetComponent<T>();
        IComponent GetComponent(ComponentType type);
        IComponent GetComponent(String name);

        List<IComponent> GetLoadedComponents();
    }
}
