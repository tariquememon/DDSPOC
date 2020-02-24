using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model;

namespace WPF.UI.Data
{
    public class PeopleDataService : IPeopleDataService
    {
        public IEnumerable<Person> GetAll()
        {
            yield return new Person { Id = 1, Name = "Tarique" };
            yield return new Person { Id = 1, Name = "Nik" };
            yield return new Person { Id = 1, Name = "Zuhur" };
        }
    }
}
