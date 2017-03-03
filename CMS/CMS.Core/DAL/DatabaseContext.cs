using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMS.Core.DAL
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext()
        {
            
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