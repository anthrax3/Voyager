using CMS.Web.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Web.Services.ComponentsService
{
    public interface IComponent
    {
        String Name { get; set; }
        ComponentType Type { get; set; }

        void SetupDatabase(IDatabaseContext context, DbModelBuilder builder);
    }
}
