using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.UI.Wrapper
{
    public class AddressWrapper : ModelWrapper<Address>
    {
        public AddressWrapper(Address model) : base(model)
        {

        }

        public int Id
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int StreetNo
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public int StreetNoOriginalValue => GetOriginalValue<int>(nameof(StreetNo));
        public bool StreetNoIsChanged => GetIsChanged(nameof(StreetNo));

        public string StreetName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string StreetNameOriginalValue => GetOriginalValue<string>(nameof(StreetName));
        public bool StreetNameIsChanged => GetIsChanged(nameof(StreetName));

        public int PostCode
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public int PostCodeOriginalValue => GetOriginalValue<int>(nameof(PostCode));
        public bool PostCodeIsChanged => GetIsChanged(nameof(PostCode));

        public string State
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string StateOriginalValue => GetOriginalValue<string>(nameof(State));
        public bool StateIsChanged => GetIsChanged(nameof(State));
    }
}
