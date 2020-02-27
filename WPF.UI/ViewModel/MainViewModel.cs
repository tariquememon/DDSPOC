using App.Model;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.UI.Data;
using WPF.UI.Wrapper;

namespace WPF.UI.ViewModel
{
    public class MainViewModel : Observable
    {
        private IPeopleDataService _peopleDataService;
        private EmailWrapper _selectedEmail;
        private PersonWrapper _selectedPerson;

        public MainViewModel(IPeopleDataService peopleDataService)
        {   
            _peopleDataService = peopleDataService;

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            AddEmailCommand = new DelegateCommand(OnAddEmailExecute);
            RemoveEmailCommand = new DelegateCommand(OnRemoveEmailExecute, OnRemoveEmailCanExecute);

            People = new ObservableCollection<PersonWrapper>();
            Emails = new ObservableCollection<EmailWrapper>();
        }

        void OnAddEmailExecute()
        {
            var newEmail = new EmailWrapper(new Email());
            SelectedPerson.Emails.Add(newEmail);
            newEmail.EmailAddress = "";
        }

        bool OnRemoveEmailCanExecute()
        {
            return SelectedEmail != null;
        }

        void OnRemoveEmailExecute()
        {
            SelectedPerson.Emails.Remove(SelectedEmail);
        }

        bool OnSaveCanExecute()
        {
            return true;
        }

        async void OnSaveExecute()
        {
            await _peopleDataService.SaveAsync(SelectedPerson.Model);
        }

        public async Task LoadAsync()
        {
            var people = await _peopleDataService.GetAllAsync();
            People.Clear();

            foreach (var person in people)
            {
                People.Add(new PersonWrapper(person));
            }
        }

        public ICommand AddEmailCommand { get; set; }
        public ICommand RemoveEmailCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public EmailWrapper SelectedEmail
        {
            get { return _selectedEmail; }
            set
            {
                _selectedEmail = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveEmailCommand).RaiseCanExecuteChanged();
            }
        }

        public PersonWrapper SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();                
            }
        }

        public ObservableCollection<PersonWrapper> People { get; set; }
        public ObservableCollection<EmailWrapper> Emails { get; set; }
    }
}
