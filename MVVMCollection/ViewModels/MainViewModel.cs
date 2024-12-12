using MVVMCollection.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMCollection.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            AddStudentCommand = new Command(
                () => Students.Add(new Student { Firstname = "Jana", Lastname = "Pokorná", Email = "jana.pokorna@pslib.cz", Age=16, Phone="+420111111111"}),
                () => true
            );
            AddYearToAllStudentsCommand = new Command(
                () =>
                {
                    foreach (var student in Students)
                    {
                        student.Age++;
                    }
                },
                () => true
            );
        }

        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>
        {
            new Student { Firstname = "Jan", Lastname = "Novák", Age = 20, Email = "jan.novak@pslib.cz", Phone = "123456789" },
            new Student { Firstname = "Petr", Lastname = "Svoboda", Age = 25, Email = "petr.svoboda@pslib.cz", Phone = "987654321" }
        };

        public ICommand AddStudentCommand { get; set; }
        public ICommand AddYearToAllStudentsCommand { get; set; }

        #region MVVM
        protected void OnPropertyChanged([CallerMemberName] string propName = null) // název bindu se doplní automaticky
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion
    }
}
