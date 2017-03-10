using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Core.Models
{
    public class ComponentActionsModel
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Action { get; set; }

        public int ComponentID { get; set; }
        public virtual ComponentModel Component { get; set; }
    }
}