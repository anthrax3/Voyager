using CMS.Core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComArticles.Services
{
    internal class ArticlesService : IArticlesService
    {
        IDatabaseContext db = null;
        public ArticlesService(IDatabaseContext db)
        {
            this.db = db;
        }
    }
}
