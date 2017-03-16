using CMS.Core.DB;
using CMS.Core.Services.ComponentsManager;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CMS.Core.Components
{
    public interface IComponent
    {
        String Name { get; set; }
        bool SetupDatabase(DbModelBuilder builder);
        void SetupUnity(IUnityContainer container);
    }
}
