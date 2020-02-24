using App.Model;
using System;
using WPF.UI.ViewModel;

namespace WPF.UI.Wrapper
{
    public class PersonWrapper : ModelWrapper<Person>
    {
        public PersonWrapper(Person model) : base(model)
        {
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
    }
}
