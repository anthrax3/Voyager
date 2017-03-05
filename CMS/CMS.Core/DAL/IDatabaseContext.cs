using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.DAL
{
    public interface IDatabaseContext
    {
        bool IsConnected { get; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int Save();
    }
}
