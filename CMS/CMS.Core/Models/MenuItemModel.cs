using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Core.Models
{
    public class MenuItemModel
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Parameters { get; set; }

        public int MenuID { get; set; }
        public virtual MenuModel Menu { get; set; }

        public int ComponentID { get; set; }
        public virtual ComponentModel Component { get; set; }
    }
}