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

namespace ComArticles
{
    public class Main : IComponent
    {
        public string Name { get; set; } = "ComArticles";

        public CallResult DoAction(CallParameters parameters, CoreState state)
        {
            state.Database.Set<ArticleModel>().Add(new ArticleModel() { Title = "Test",
            CreateTime = DateTime.Now, ModifyTime = DateTime.Now});
            state.Database.Save();

            return new CallResult()
            {
                View = "~/Components/ComArticles/Views/Index.cshtml",
                Model = new TestModel() { Name = "X", Age = 12 }
            };
        }

        public bool SetupDatabase(DbModelBuilder builder)
        {
            builder.Entity<ArticleModel>().ToTable("Articles");

            return true;
        }
    }
}
