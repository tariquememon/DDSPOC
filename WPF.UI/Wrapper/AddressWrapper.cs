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

        public string StreetName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public int PostCode
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public string State
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
