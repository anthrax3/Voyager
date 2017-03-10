using CMS.Core.Components;
using CMS.Core.Models;
using CMS.Core.Services.ComponentsLoader;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.Practices.Unity;

namespace CMS.Core.DB
{
    internal class DatabaseContext : DbContext, IDatabaseContext
    {
        public virtual DbSet<ConfigModel> Config { get; set; }
        public virtual DbSet<TemplateModel> Templates { get; set; }
        public virtual DbSet<ComponentModel> Components { get; set; }
        public virtual DbSet<ComponentActionsModel> ComponentActions { get; set; }
        
        static String connectionStringCache = String.Empty;
        IComponentsLoaderService componentsLoader = null;

        /// <summary>
        /// If connection with DB is open, returns true. Otherwise, returns false.
        /// </summary>
        public bool IsConnected
        {
            get { return Database.Exists(); }
        }

        public DatabaseContext() : base("MainConnection")
        {

        }

        [InjectionConstructor]
        public DatabaseContext(IComponentsLoaderService componentsLoader) : base("MainConnection")
        {
            this.componentsLoader = componentsLoader;
        }

        /// <summary>
        /// Saves changes in DB. Returns -1 if there is no connection with DB, 
        /// otherwise returns number of changed objects.
        /// </summary>
        public int Save()
        {
            if (!IsConnected)
                return -1;
            return base.SaveChanges();
        }

        /// <summary>
        /// Gets entity with specific TEntity type. Returns null if there is no connection with DB.
        /// </summary>
        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            if (!IsConnected)
                return null;
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            
            var componentsList = componentsLoader.GetLoadedComponents();
            foreach(IComponent com in componentsList)
            {
                com.SetupDatabase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}