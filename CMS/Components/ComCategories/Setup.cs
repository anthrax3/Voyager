using CMS.Core.Components;
using CMS.Core.Services.Messages;
using ComCategories.Models;
using ComCategories.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCategories
{
    public class Setup : IComponent
    {
        public string Name { get; set; } = "ComCategories";

        public bool SetupDatabase(DbModelBuilder builder)
        {
            builder.Entity<CategoryModel>().ToTable("Categories");

            return true;
        }

        public void SetupUnity(IUnityContainer container)
        {
            container.RegisterType<ICategoriesService, CategoriesService>();
        }

        public void RegisterMessagesHandler(IMessagesService messagesService)
        {

        }
    }
}
