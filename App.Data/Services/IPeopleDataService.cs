using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.UI.Data
{
    public interface IPeopleDataService
    {
        Task<IEnumerable<Person>> GetAllAsync();
    }
}
