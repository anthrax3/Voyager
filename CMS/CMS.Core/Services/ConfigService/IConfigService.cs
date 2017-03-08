using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.ConfigService
{
    public interface IConfigService
    {
        bool AddKey(String key, String value);
        bool SetValue(String key, String value);
        bool RemoveKey(String key);
        String GetValue(String key);
        bool Exist(String key);
    }
}
