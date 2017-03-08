using CMS.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Core.Services.Positions
{
    public class PositionsService : IPositionsService
    {
        IDatabaseContext db = null;

        public PositionsService(IDatabaseContext db)
        {
            this.db = db;
        }
    }
}