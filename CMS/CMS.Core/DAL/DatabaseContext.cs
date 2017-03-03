using CMS.Core.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMS.Core.DAL
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public bool IsConnected { get; set; } = false;

        public DatabaseContext(IConfigService config, ILoggerService logger)
        {
            var cs = new SqlConnectionStringBuilder();
            cs.DataSource = config.GetValue("DB-Address");
            cs.InitialCatalog = config.GetValue("DB-InitialCatalog");
            cs.IntegratedSecurity = bool.Parse(config.GetValue("DB-IntegratedSecurity"));

            if (!cs.IntegratedSecurity)
            {
                cs.UserID = config.GetValue("DB-UserName");
                cs.Password = config.GetValue("DB-Password");
            }

            Database.Connection.ConnectionString = cs.ConnectionString;

            try
            {
                Database.Connection.Open();
                IsConnected = true;
            }
            catch(Exception ex)
            {
                logger.Log(Level.Critical, ex);
            }
        }

        public int Save()
        {
            return base.SaveChanges();
        }

        public DbSet<TEntity> Get<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}