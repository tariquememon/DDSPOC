using System;
using System.Linq;
using System.Runtime.CompilerServices;
using WPF.UI.ViewModel;

namespace WPF.UI.Wrapper
{
    public class ModelWrapper<T> : Observable
    {
        public ModelWrapper(T model)
        {
            if(model == null)
            {
                throw new ArgumentNullException("model");
            }

            Model = model;
        }

        public T Model { get; private set; }

        protected void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            var currentValue = propertyInfo.GetValue(Model);
            if(!Equals(currentValue, value))
            {
                propertyInfo.SetValue(Model, value);
                OnPropertyChanged(propertyName);
            }
        }

        protected TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            return (TValue) propertyInfo.GetValue(Model);
        }
    }
}
