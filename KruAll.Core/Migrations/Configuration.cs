namespace KruAll.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KruAll.Core.Models.PZE_Entities>
    {
        public Configuration()
        {
            //allow migration
            AutomaticMigrationsEnabled = false;
            //no data loss when migrating
            AutomaticMigrationDataLossAllowed = false; 
        }

        protected override void Seed(KruAll.Core.Models.PZE_Entities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }

    //internal sealed class Configuration : DbMigrationsConfiguration<KruAll.Core.Models.KrutecPZE>
    //{
    //    public Configuration()
    //    {
    //        //allow migration
    //        AutomaticMigrationsEnabled = false;
    //        //no data loss when migrating
    //        AutomaticMigrationDataLossAllowed = false;
    //    }

    //    protected override void Seed(KruAll.Core.Models.KrutecPZE context)
    //    {
    //        //  This method will be called after migrating to the latest version.

    //        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
    //        //  to avoid creating duplicate seed data. E.g.
    //        //
    //        //    context.People.AddOrUpdate(
    //        //      p => p.FullName,
    //        //      new Person { FullName = "Andrew Peters" },
    //        //      new Person { FullName = "Brice Lambson" },
    //        //      new Person { FullName = "Rowan Miller" }
    //        //    );
    //        //
    //    }
    //}

}
