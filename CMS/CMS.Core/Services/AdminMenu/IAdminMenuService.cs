using CMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.AdminMenu
{
    public interface IAdminMenuService
    {
        List<AdminMenuItem> GetMenuItems();
    }
}
