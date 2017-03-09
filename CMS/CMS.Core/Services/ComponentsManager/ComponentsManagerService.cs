﻿using CMS.Core.Components;
using CMS.Core.DB;
using CMS.Core.Services.ComponentsLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.ComponentsManager
{
    internal class ComponentsManagerService : IComponentsManagerService
    {
        IDatabaseContext db = null;
        IComponentsLoaderService componentsLoader = null;

        public ComponentsManagerService(IDatabaseContext db, IComponentsLoaderService componentsLoader)
        {
            this.db = db;
            this.componentsLoader = componentsLoader;
        }
    }
}
