using CMS.Core.DB;
using CMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.AdminMenu
{
    internal class AdminMenuService : IAdminMenuService
    {
        IDatabaseContext db = null;
        public AdminMenuService(IDatabaseContext db)
        {
            this.db = db;
        }

        public List<AdminMenuItem> GetMenuItems()
        {
            return db.Set<AdminMenuItem>().ToList();
        }
    }
}
