using CMS.Core.Exceptions;
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
        static String connectionStringCache = String.Empty;

        public bool IsConnected
        {
            get { return Database.Connection.State == System.Data.ConnectionState.Open ? true : false; }
        }

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
                logger.Log(Level.Critical, ex);
            }
        }

        public int Save()
        {
            if (!IsConnected)
                throw new NoDatabaseConnectionException();
            return base.SaveChanges();
        }

        public DbSet<TEntity> Get<TEntity>() where TEntity : class
        {
            if (!IsConnected)
                throw new NoDatabaseConnectionException();
            return base.Set<TEntity>();
        }
    }
}