﻿using CMS.Core.Database;
using System;
using System.Data.Entity;

namespace CMS.Core.Services.Components
{
    public interface IComponent
    {
        String Name { get; set; }
        ComponentType Type { get; set; }

        void SetupDatabase(IDatabaseContext context, DbModelBuilder builder);
    }
}