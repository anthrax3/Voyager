using CMS.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Core.DB;
using System.Data.Entity;
using ComArticles.Models;

namespace ComArticles
{
    public class Main : IComponent
    {
        public string Name { get; set; } = "ComArticles";

        public bool SetupDatabase(DbModelBuilder builder)
        {
            builder.Entity<ArticleModel>().ToTable("Articles");

            return true;
        }
    }
}
