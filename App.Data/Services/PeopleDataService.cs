using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model;
using WPF.UI.Data;

namespace App.Data.Services
{
    public class PeopleDataService : IPeopleDataService
    {
        Func<PersonManagerDbContext> _contextCreator;

        public PeopleDataService(Func<PersonManagerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            using(var ctx = _contextCreator())
            {
                return await ctx.People
                    .Include(p => p.Address)
                    .Include(p => p.Emails)
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task SaveAsync(Person person)
        {
            using(var ctx = _contextCreator())
            {
                ctx.People.Attach(person);
                ctx.Entry(person).State = EntityState.Modified;
                ctx.Entry(person.Address).State = EntityState.Modified;

                foreach (var email in person.Emails)
                {
                    ctx.Entry(email).State = (email.Id == 0 ? EntityState.Added : EntityState.Modified);
                }


                //TODO: replace with Linq expression
                var missingEmails = ctx.Emails.Where(e => e.PersonId == person.Id)
                    .AsNoTracking()
                    .ToList();
                    
                foreach(var missingEmail in missingEmails)
                {
                    if(!person.Emails.Any(e => e.Id == missingEmail.Id))
                    {
                        ctx.Emails.Attach(missingEmail);
                        ctx.Entry(missingEmail).State = EntityState.Deleted;
                    }
                }

                await ctx.SaveChangesAsync();
            }
        }
    }
}
