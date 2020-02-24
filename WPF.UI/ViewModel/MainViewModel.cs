using App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.UI.Data;

namespace WPF.UI.ViewModel
{
    public class MainViewModel
    {
        IPeopleDataService _peopleDataService;
        public MainViewModel(IPeopleDataService peopleDataService)
        {
            _peopleDataService = peopleDataService;
        }

        public void Load()
        {
            var people = _peopleDataService.GetAll();
        }

        public ObservableCollection<Person> People { get; set; }
    }
}
