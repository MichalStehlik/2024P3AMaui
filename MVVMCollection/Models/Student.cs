using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCollection.Models
{
    internal class Student: INotifyPropertyChanged
    {
        private int _age;
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public int Age {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public override string ToString()
        {
            return Firstname + " " + Lastname + "(" + Age + ")";
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
