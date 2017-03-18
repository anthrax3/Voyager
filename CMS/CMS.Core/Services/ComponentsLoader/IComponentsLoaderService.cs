using CMS.Core.Components;
using CMS.Core.Services.Messages;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;

namespace CMS.Core.Services.ComponentsLoader
{
    public interface IComponentsLoaderService
    {
        bool LoadComponents();

        T GetComponent<T>();
        IComponent GetComponent(String name);
        List<IComponent> GetLoadedComponents();
        void InitComponents(IUnityContainer container, IMessagesService messagesService);
    }
}
