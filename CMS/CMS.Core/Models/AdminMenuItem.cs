using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Models
{
    public class AdminMenuItem
    {
        public int ID { get; set; }
        public int ComponentID { get; set; }
        public ComponentModel Component { get; set; }

        public String Name { get; set; }
        public String Controller { get; set; }
        public String Action { get; set; }
        public String OptionalData { get; set; }
    }
}
