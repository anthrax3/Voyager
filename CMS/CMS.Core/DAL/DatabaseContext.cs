﻿using CMS.Core.Models;
using CMS.Core.Services.ConfigService;
using CMS.Core.Services.LoggerService;
using Microsoft.Practices.Unity;
using System;
using System.Data.Entity;
using System.Data.SqlClient;

namespace CMS.Core.DAL
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public virtual DbSet<ConfigModel> Config { get; set; }
        public virtual DbSet<TemplateModel> Templates { get; set; }
        public virtual DbSet<MenuModel> Menus { get; set; }
        public virtual DbSet<MenuItemModel> MenuItems { get; set; }
        public virtual DbSet<ComponentModel> Components { get; set; }
        public virtual DbSet<ComponentsData> ComponentsData { get; set; }
        public virtual DbSet<ComponentInstances> ComponentInstances { get; set; }
        public virtual DbSet<PositionModel> Positions { get; set; }

        static String connectionStringCache = String.Empty;

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
            modelBuilder.Entity<MenuItemModel>().HasRequired(p => p.Menu)
                .WithMany().HasForeignKey(t => t.MenuID);
            modelBuilder.Entity<MenuItemModel>().HasRequired(p => p.Component)
                .WithMany().HasForeignKey(t => t.ComponentID);

            base.OnModelCreating(modelBuilder);
        }
    }
}