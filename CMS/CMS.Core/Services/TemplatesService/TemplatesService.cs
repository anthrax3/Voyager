using CMS.Core.App_Start;
using CMS.Core.DAL;
using CMS.Core.Models;
using CMS.Core.Services.LoggerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Core.Services.TemplatesService
{
    public class TemplatesService : ITemplatesService
    {
        IDatabaseContext db = null;
        ILoggerService logger = null;

        public TemplatesService(IDatabaseContext db, ILoggerService logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public bool SetActiveTemplateInViewEngine()
        {
            var activeTemplate = GetActiveTemplate();
            if (activeTemplate == null)
                return false;
            
            var viewEngine = ViewEngines.Engines.First() as ExtendedRazorViewEngine;
            var viewLocations = new List<String>() {
                "~/Templates/" + activeTemplate.DirName + "/{1}/{0}.cshtml",
                "~/Templates/" + activeTemplate.DirName + "/Shared/{0}.cshtml"
            };
            viewEngine.SetLocations(viewLocations);

            return true;
        }

        public TemplateModel GetActiveTemplate()
        {
            return db.Set<TemplateModel>().FirstOrDefault(p => p.Active);
        }

        public bool SetTemplateAsActive(String templateName)
        {
            var entity = db.Set<TemplateModel>().FirstOrDefault(p => p.Name == templateName);
            if (entity == null)
                return false;

            db.Set<TemplateModel>().Where(p => p.Active).ToList().ForEach(p => p.Active = false);
            entity.Active = true;

            return true;
        }
    }
}