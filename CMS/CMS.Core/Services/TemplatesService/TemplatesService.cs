using CMS.Core.DAL;
using CMS.Core.Services.LoggerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}