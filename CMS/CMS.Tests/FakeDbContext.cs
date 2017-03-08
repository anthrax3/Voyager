using CMS.Web.DAL;
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
