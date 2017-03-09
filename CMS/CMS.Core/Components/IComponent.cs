using CMS.Core.DB;
using System;
using System.Data.Entity;

namespace CMS.Core.Components
{
    public interface IComponent
    {
        String Name { get; set; }
        bool SetupDatabase(DbModelBuilder builder);
    }
}
