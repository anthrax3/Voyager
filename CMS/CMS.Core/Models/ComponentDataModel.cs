using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Core.Models
{
    public class ComponentDataModel
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Data { get; set; }

        public int ComponentInstanceID { get; set; }
        public virtual ComponentInstanceModel ComponentInstance { get; set; }
    }
}