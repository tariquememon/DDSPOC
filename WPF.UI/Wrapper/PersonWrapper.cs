using App.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace WPF.UI.Wrapper
{
    public class PersonWrapper : ModelWrapper<Person>
    {
        public PersonWrapper(Person model) : base(model)
        {
            InitializeComplexProperties(model);
            InitializeCollectionProperties(model);
        }
        void InitializeComplexProperties(Person model)
        {
            if(model.Address == null)
            {
                throw new ArgumentException("Address cannot be null");
            }
            Address = new AddressWrapper(model.Address);
            RegisterComplex(Address);
        }
        void InitializeCollectionProperties(Person model)
        {
            if(model.Emails == null)
            {
                throw new ArgumentException("Emails cannot be null");
            }
            Emails = new ChangeTrackingCollection<EmailWrapper>(model.Emails.Select(e => new EmailWrapper(e)));
            RegisterCollection(Emails, model.Emails);
        }

        public int Id
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public string Name
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string NameOriginalValue => GetOriginalValue<string>(nameof(Name));            
        public bool NameIsChanged => GetIsChanged(nameof(Name));
            
        public AddressWrapper Address { get; private set; }
        public ChangeTrackingCollection<EmailWrapper> Emails { get; private set; }
    }
}
