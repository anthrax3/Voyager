using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Core.Models
{
    public class ComponentModel
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Author { get; set; }
        public String Description { get; set; }
        public String Version { get; set; }
        public String Website { get; set; }
    }
}