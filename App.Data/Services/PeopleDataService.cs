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
                return await ctx.People.AsNoTracking().ToListAsync();
            }
        }
    }
}
