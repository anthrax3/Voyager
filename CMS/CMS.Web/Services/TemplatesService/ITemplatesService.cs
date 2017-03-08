using CMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Web.Services.TemplatesService
{
    public interface ITemplatesService
    {
        bool SetActiveTemplateInViewEngine();
        TemplateModel GetActiveTemplate();
        bool SetTemplateAsActive(String templateName);
    }
}
