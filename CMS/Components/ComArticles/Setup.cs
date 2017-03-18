using CMS.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Core.DB;
using System.Data.Entity;
using ComArticles.Models;
using CMS.Core.Services.ComponentsManager;
using Microsoft.Practices.Unity;
using ComArticles.Services;
using CMS.Core.Services.Messages;

namespace ComArticles
{
    public class Setup : IComponent
    {
        public string Name { get; set; } = "ComArticles";

        public bool SetupDatabase(DbModelBuilder builder)
        {
            builder.Entity<ArticleModel>().ToTable("Articles");

            return true;
        }

        public void SetupUnity(IUnityContainer container)
        {
            container.RegisterType<IArticlesService, ArticlesService>();
        }

        public void ReceiveMessage(Message message)
        {

        }
    }
}
