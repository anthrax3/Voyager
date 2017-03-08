using CMS.Web.App_Start;
using CMS.Web.DAL;
using CMS.Web.Models;
using CMS.Web.Services.LoggerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Services.TemplatesService
{
    public class TemplatesService : ITemplatesService
    {
        IDatabaseContext db = null;

        public TemplatesService(IDatabaseContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Finds active template in database and update locatinos in view engine. Returns false
        /// if there is no active template.
        /// </summary>
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

        /// <summary>
        /// Returns active template. If there is no active template, returns null.
        /// </summary>
        public TemplateModel GetActiveTemplate()
        {
            return db.Set<TemplateModel>().FirstOrDefault(p => p.Active);
        }

        /// <summary>
        /// Disables all templates and sets template with specific name as active.
        /// </summary>
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