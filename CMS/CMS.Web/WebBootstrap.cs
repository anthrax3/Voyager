using CMS.Core;
using CMS.Core.Services.Templates;
using CMS.Web.Services.ViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web
{
    public class WebBootstrap
    {
        ITemplatesService templates = null;
        IViewEngineService viewEngineService = null;
        CoreBootloader coreBootloader = null;

        public WebBootstrap(ITemplatesService templates, IViewEngineService viewEngineService)
        {
            coreBootloader = new CoreBootloader();

            this.templates = templates;
            this.viewEngineService = viewEngineService;
        }

        public void Init()
        {
            coreBootloader.Init();

            var localisations = templates.GetListOfTemplateLocalisations();
            viewEngineService.UpdateViewLocalisations(localisations);
        }
    }
}