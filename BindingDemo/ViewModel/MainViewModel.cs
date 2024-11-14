using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BindingDemo.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private int _value = 75;
        private int _result = 0;
        public int Value 
        {
            get { return _value; }
            set { 
                _value = value; 
                _result = _value * 2;  
                OnPropertyChanged();
                OnPropertyChanged("Result");
            } 
        }

        public int Result
        {
            get { return _result; }
        }

        #region MVVM
        protected void OnPropertyChanged([CallerMemberName] string propName = null) // název bindou se doplní automaticky
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion
    }
}
