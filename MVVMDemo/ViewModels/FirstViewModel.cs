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
        private int _size = 12;
        private ColorSet _color = ColorSet.Black;

        public FirstViewModel()
        {
            IncreaseCommand = new Command(
                () => Size++,
                () => Size < 72
            );
            DecreaseCommand = new Command(
                () => Size--,
                () => Size > 6
            );
            IncreaseByValueCommand = new Command<string>(
                (value) => {
                    int x = Int32.Parse(value);
                    Size += x;
                },
                (value) =>
                {
                    int x = Int32.Parse(value);
                    return (Size + x) < 72 && (Size - x) > 6;
                }
            );
            ChangeColorCommand = new Command<string>(
                (value) =>
                {
                    Color = (ColorSet)Enum.Parse(typeof(ColorSet), value);
                }
            );
        }

        public Command IncreaseCommand {  get; set; }
        public Command DecreaseCommand { get; set; }
        public Command<string> IncreaseByValueCommand { get; set; }
        public Command<string> ChangeColorCommand { get; set; }
        public string Text { 
            get { return _text; } 
            set { 
                _text = value;
                OnPropertyChanged();
            } 
        }

        public int Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged();
                IncreaseCommand.ChangeCanExecute();
                DecreaseCommand.ChangeCanExecute();
                IncreaseByValueCommand.ChangeCanExecute();
            }
        }

        public ColorSet Color
        {
            get { return _color; }
            set
            {
                _color = value;
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

    enum ColorSet
    {
        Black,
        Red,
        Green,
        Blue
    }
}
