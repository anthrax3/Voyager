using CMS.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CMS.Tests
{
    public class FakeDbContext : IDatabaseContext
    {
        public bool IsConnected { get { return true; } }

        public virtual IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return null;
        }

        public int Save()
        {
            return 0;
        }
    }
}
