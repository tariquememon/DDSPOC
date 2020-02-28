using App.Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
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
            ResetCommand = new DelegateCommand(OnResetExecute, OnResetCanExecute);
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
            if (SelectedPerson == null) return false;

            return SelectedPerson.IsChanged;
        }

        async void OnSaveExecute()
        {
            await _peopleDataService.SaveAsync(SelectedPerson.Model);
            SelectedPerson.AcceptChanges();
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
        public ICommand ResetCommand { get; set; }

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
                OnPropertyChanged(nameof(ShowDetail));

                _selectedPerson.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(_selectedPerson.IsChanged))
                    {
                        InvalidateCommands();
                    }
                };
            }
        }

        private void InvalidateCommands()
        {
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)ResetCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)AddEmailCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)RemoveEmailCommand).RaiseCanExecuteChanged();
        }
        
        void OnResetExecute()
        {
            SelectedPerson.RejectChanges();
        }

        bool OnResetCanExecute()
        {
            if (SelectedPerson == null) return false;

            return SelectedPerson.IsChanged;
        }

        public bool ShowDetail => SelectedPerson != null;
        
        public ObservableCollection<PersonWrapper> People { get; set; }
        public ObservableCollection<EmailWrapper> Emails { get; set; }
    }
}
