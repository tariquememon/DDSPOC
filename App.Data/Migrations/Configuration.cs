using App.Model;

namespace App.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<App.Data.PersonManagerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(App.Data.PersonManagerDbContext context)
        {
            context.People.AddOrUpdate(f => f.Name, new Person { Name = "Tarique" });
            context.People.AddOrUpdate(f => f.Name, new Person { Name = "Nik" });
            context.People.AddOrUpdate(f => f.Name, new Person { Name = "Zuhur" });
        }
    }
}
