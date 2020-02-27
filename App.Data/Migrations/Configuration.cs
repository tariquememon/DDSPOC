using App.Model;

namespace App.Data.Migrations
{
    using System;
    using System.Collections.Generic;
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
            context.People.AddOrUpdate(f => f.Name, 
                new Person
                {
                    Name = "Tarique",
                    Address = new Address { PostCode = 1000, State = "WA", StreetName = "Street A", StreetNo = 10 },
                    Emails = new List<Email> {
                        new Email {EmailAddress = "Tarique1@gmail.com" },
                        new Email {EmailAddress = "Tarique2@gmail.com" }
                    }
                });
            context.People.AddOrUpdate(f => f.Name,
                new Person
                {
                    Name = "Nik",
                    Address = new Address { PostCode = 2000, State = "WA", StreetName = "Street B", StreetNo = 20 },
                    Emails = new List<Email> {
                        new Email {EmailAddress = "Nik1@gmail.com" },
                        new Email {EmailAddress = "Nik2@gmail.com" }
                    }
                });
            context.People.AddOrUpdate(f => f.Name,
                new Person
                {
                    Name = "Zuhur",
                    Address = new Address { PostCode = 3000, State = "WA", StreetName = "Street C", StreetNo = 30 },
                    Emails = new List<Email> {
                        new Email {EmailAddress = "Zuhur1@gmail.com" },
                        new Email {EmailAddress = "Zuhur2@gmail.com" }
                    }
                });
        }
    }
}
