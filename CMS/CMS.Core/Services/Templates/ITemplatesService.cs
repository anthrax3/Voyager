using CMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.Templates
{
    public interface ITemplatesService
    {
        bool SetActiveTemplateInViewEngine();
        TemplateModel GetActiveTemplate();
        bool SetTemplateAsActive(String templateName);
    }
}
