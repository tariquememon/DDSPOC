using App.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WPF.UI.Data;

namespace WPF.UI.ViewModel
{
    public class MainViewModel : Observable
    {
        private IPeopleDataService _peopleDataService;
        private Person _selectedPerson;

        public MainViewModel(IPeopleDataService peopleDataService)
        {
            People = new ObservableCollection<Person>();
            _peopleDataService = peopleDataService;
        }

        public async Task LoadAsync()
        {
            var people = await _peopleDataService.GetAllAsync();
            People.Clear();

            foreach (var person in people)
            {
                People.Add(person);
            }
        }

        public ObservableCollection<Person> People { get; set; }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {   
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }

    }
}
