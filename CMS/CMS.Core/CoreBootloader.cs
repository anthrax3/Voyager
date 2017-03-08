using CMS.Core.DB;
using CMS.Core.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core
{
    public class CoreBootloader
    {
        public void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext,
                 Configuration>());
        }
    }
}
