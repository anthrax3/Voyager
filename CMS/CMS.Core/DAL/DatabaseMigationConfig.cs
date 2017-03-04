using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace CMS.Core.DAL
{
    public class DatabaseMigationConfig : DbMigrationsConfiguration<DatabaseContext>
    {
        public DatabaseMigationConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;   
        }

        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);
        }
    }
}