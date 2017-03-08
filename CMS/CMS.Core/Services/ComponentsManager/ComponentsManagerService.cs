using CMS.Core.DB;
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

        public ComponentsManagerService(IDatabaseContext db)
        {
            this.db = db;
        }
    }
}
