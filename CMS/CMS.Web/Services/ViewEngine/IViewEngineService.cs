using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Web.Services.ViewEngine
{
    public interface IViewEngineService
    {
        void UpdateViewLocalisations(List<String> localisations);
    }
}
