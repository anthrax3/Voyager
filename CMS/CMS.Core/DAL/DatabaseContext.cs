using CMS.Core.DAL.Models;
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
        static String connectionStringCache = String.Empty;

        public DbSet<ConfigModel> configModel { get; set; }

        /// <summary>
        /// If connection with DB is open, returns true. Otherwise, returns false.
        /// </summary>
        public bool IsConnected
        {
            get { return Database.Connection.State == System.Data.ConnectionState.Open ? true : false; }
        }

        public DatabaseContext()
        {

        }

        /*[InjectionConstructor]
        public DatabaseContext(IConfigService config, ILoggerService logger)
        {
            if(connectionStringCache == String.Empty)
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

            Database.Connection.ConnectionString = connectionStringCache;

            try
            {
                Database.Connection.Open();
            }
            catch(Exception ex)
            {
                logger.Log(Level.Error, "Can't connect to database. Check your configuration and try again");
                logger.Log(Level.Critical, ex);
            }
            
            try
            {
                Database.Initialize(false);
            }
            catch(Exception ex)
            {
                logger.Log(Level.Error, "Database schema is incorrect");
                logger.Log(Level.Critical, ex);

                Database.Connection.Close();
            }
        }*/

        /// <summary>
        /// Save changes in DB. Returns -1 if there is no connection with DB, 
        /// otherwise returns number of changed objects.
        /// </summary>
        public int Save()
        {
            if (!IsConnected)
                return -1;
            return base.SaveChanges();
        }

        /// <summary>
        /// Get entity with specific TEntity type. Returns null if there is no connection with DB.
        /// </summary>
        public DbSet<TEntity> Get<TEntity>() where TEntity : class
        {
            if (!IsConnected)
                return null;
            return base.Set<TEntity>();
        }
    }
}