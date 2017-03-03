using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services
{
    public interface IConfigService
    {
        void Load(String file);
        bool Exist(String key);
        String GetValue(String key);
    }
}
