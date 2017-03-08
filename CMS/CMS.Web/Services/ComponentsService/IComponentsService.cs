﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Web.Services.ComponentsService
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
