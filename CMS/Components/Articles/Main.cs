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

        public CallResult DoAction(string actionName, Dictionary<string, object> parameters)
        {
            return new CallResult()
            {
                View = "~/Components/ComArticles/Views/Index.cshtml",
                Model = "Hello world, this is " + Name + " :) Action: " + actionName
            };
        }

        public bool SetupDatabase(DbModelBuilder builder)
        {
            builder.Entity<ArticleModel>().ToTable("Articles");

            return true;
        }
    }
}
