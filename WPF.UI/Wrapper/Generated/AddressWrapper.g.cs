

using App.Model;
using System.Linq;
using System;

namespace WPF.UI.Wrapper
{
	public class AddressWrapper : ModelWrapper<Address>
	{			
		public AddressWrapper(Address model) : base(model)
		{
		}
		
		public System.Int32 Id
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}

		public System.Int32 IdOriginalValue => GetOriginalValue<System.Int32>(nameof(Id));
		public bool IdIsChanged => GetIsChanged(nameof(Id));


		public System.Int32 StreetNo
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}

		public System.Int32 StreetNoOriginalValue => GetOriginalValue<System.Int32>(nameof(StreetNo));
		public bool StreetNoIsChanged => GetIsChanged(nameof(StreetNo));


		public System.String StreetName
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}

		public System.String StreetNameOriginalValue => GetOriginalValue<System.String>(nameof(StreetName));
		public bool StreetNameIsChanged => GetIsChanged(nameof(StreetName));


		public System.String State
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}

		public System.String StateOriginalValue => GetOriginalValue<System.String>(nameof(State));
		public bool StateIsChanged => GetIsChanged(nameof(State));


		public System.Int32 PostCode
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}

		public System.Int32 PostCodeOriginalValue => GetOriginalValue<System.Int32>(nameof(PostCode));
		public bool PostCodeIsChanged => GetIsChanged(nameof(PostCode));

	}
}

