using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.ViewModels
{
    internal class FirstViewModel : INotifyPropertyChanged
    {
        private string _text = "Ukázkový text";
        public string Text { 
            get { return _text; } 
            set { 
                _text = value;
                OnPropertyChanged();
            } 
        }

        #region MVVM
        protected void OnPropertyChanged([CallerMemberName] string propName = null) // název bindu se doplní automaticky
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion
    }
}
