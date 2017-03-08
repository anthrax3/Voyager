using CMS.Core.DB;
using CMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Core.Services.Templates
{
    internal class TemplatesService : ITemplatesService
    {
        IDatabaseContext db = null;

        public TemplatesService(IDatabaseContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Finds active template in database and returns localisations. Returns null
        /// if there is no active template.
        /// </summary>
        public List<String> GetListOfTemplateLocalisations()
        {
            var activeTemplate = GetActiveTemplate();
            if (activeTemplate == null)
                return null;
            
            var viewLocations = new List<String>() {
                "~/Templates/" + activeTemplate.DirName + "/{1}/{0}.cshtml",
                "~/Templates/" + activeTemplate.DirName + "/Shared/{0}.cshtml"
            };

            return viewLocations;
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