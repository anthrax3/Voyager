using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.ComponentsService
{
    public interface IComponent
    {
        String Name { get; set; }
        ComponentType Type { get; set; }
    }
}
