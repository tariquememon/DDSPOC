
using App.Model;
using System.Linq;
using System;

namespace WPF.UI.Wrapper
{
	public class PersonWrapper : ModelWrapper<Person>
	{			
		public PersonWrapper(Person model) : base(model)
		{
			InitializeComplexProperties(model);
			InitializeCollectionProperties(model);
		}
		
		public System.Int32 Id
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}

		public System.Int32 IdOriginalValue => GetOriginalValue<System.Int32>(nameof(Id));
		public bool IdIsChanged => GetIsChanged(nameof(Id));


		public System.String Name
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}

		public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
		public bool NameIsChanged => GetIsChanged(nameof(Name));


		public System.Int32 AddressId
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}

		public System.Int32 AddressIdOriginalValue => GetOriginalValue<System.Int32>(nameof(AddressId));
		public bool AddressIdIsChanged => GetIsChanged(nameof(AddressId));

			
		public AddressWrapper Address {get; private set;}

		public ChangeTrackingCollection<EmailWrapper> Emails {get; private set;}

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
            Emails = new ChangeTrackingCollection<EmailWrapper>(
				model.Emails.Select(e => new EmailWrapper(e)));
            RegisterCollection( Emails, model.Emails);
        }
	}
}

