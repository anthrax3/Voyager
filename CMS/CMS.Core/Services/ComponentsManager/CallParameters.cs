using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.ComponentsManager
{
    public class CallParameters
    {
        public String ComponentName { get; set; }
        public String ActionName { get; set; }
        public Dictionary<String, object> Parameters { get; set; }
    }
}
