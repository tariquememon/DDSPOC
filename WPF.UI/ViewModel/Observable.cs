using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WPF.UI.ViewModel
{
    public class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Observable()
        {
            PropertyChanged += (s, e) => { };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;

            if(propertyName != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
