using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web.Models
{
    public class ComponentModel
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Namespace { get; set; }
        public String MainClassName { get; set; }
        public String Author { get; set; }
        public String Description { get; set; }
        public String Version { get; set; }
        public String Website { get; set; }
    }
}