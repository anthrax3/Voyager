using CMS.Core.Services.ComponentsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Core.DAL;
using System.Data.Entity;

namespace CMS.Core.InternalComponents
{
    public class ArticlesCom : IComponent, IArticlesCom
    {
        public string Name { get; set; } = "ArticlesCom";
        public ComponentType Type { get; set; } = ComponentType.Artiles;

        public ArticlesCom()
        {

        }

        public String DisplayArticle(int id)
        {
            return "Text from " + Name;
        }

        public void SetupDatabase(IDatabaseContext context, DbModelBuilder builder)
        {

        }
    }
}