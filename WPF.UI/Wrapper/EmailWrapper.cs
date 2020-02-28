using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.UI.Wrapper
{
    public class EmailWrapper : ModelWrapper<Email>
    {
        public EmailWrapper(Email model): base(model)
        {
        }

        public int Id
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public string EmailAddress
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string EmailAddressOriginalValue => GetOriginalValue<string>(nameof(EmailAddress));
        public bool EmailAddressIsChanged => GetIsChanged(nameof(EmailAddress));
    }
}
