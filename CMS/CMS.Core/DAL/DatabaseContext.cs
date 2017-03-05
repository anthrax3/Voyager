using CMS.Core.Models;
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

        static String connectionStringCache = String.Empty;

        /// <summary>
        /// If connection with DB is open, returns true. Otherwise, returns false.
        /// </summary>
        public bool IsConnected
        {
            get { return Database.Exists(); }
        }

        //Shouldn't be called manually because default connectionStringCache is empty.
        //It's only for IDbContextFactory
        public DatabaseContext() : base(connectionStringCache)
        {

        }

        [InjectionConstructor]
        public DatabaseContext(IDBConfigService config) : base(GetConnectionString(config))
        {

        }

        static String GetConnectionString(IDBConfigService config)
        {
            if (connectionStringCache == String.Empty)
            {
                var cs = new SqlConnectionStringBuilder();
                cs.DataSource = config.GetValue("DB-Address");
                cs.InitialCatalog = config.GetValue("DB-InitialCatalog");

                var integratedSecurity = false;
                var result = bool.TryParse(config.GetValue("DB-IntegratedSecurity"), out integratedSecurity);
                if (!result)
                    throw new FormatException("DB-IntegratedSecurity");
                cs.IntegratedSecurity = integratedSecurity;

                if (!cs.IntegratedSecurity)
                {
                    cs.UserID = config.GetValue("DB-UserName");
                    cs.Password = config.GetValue("DB-Password");
                }

                connectionStringCache = cs.ConnectionString;
            }

            return connectionStringCache;
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
    }
}