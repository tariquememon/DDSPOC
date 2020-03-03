
using App.Model;
using System.Linq;
using System;

namespace WPF.UI.Wrapper
{
	public class EmailWrapper : ModelWrapper<Email>
	{			
		public EmailWrapper(Email model) : base(model)
		{
		}
		
		public System.Int32 Id
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}

		public System.Int32 IdOriginalValue => GetOriginalValue<System.Int32>(nameof(Id));
		public bool IdIsChanged => GetIsChanged(nameof(Id));


		public System.String EmailAddress
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}

		public System.String EmailAddressOriginalValue => GetOriginalValue<System.String>(nameof(EmailAddress));
		public bool EmailAddressIsChanged => GetIsChanged(nameof(EmailAddress));

	}
}

