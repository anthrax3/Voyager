﻿using System.Data.Entity;

namespace CMS.Core.Database
{
    public interface IDatabaseContext
    {
        bool IsConnected { get; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int Save();
    }
}
