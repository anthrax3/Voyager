using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web.Areas.Administrator.ViewModels
{
    public class MenuItemViewModel
    {
        public String Name { get; set; }
        public String ComponentAlias { get; set; }
        public String Controller { get; set; }
        public String Action { get; set; }
    }
}