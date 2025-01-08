using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Compass.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private double _north;
        public MainViewModel()
        {
            ToggleCompassCommand = new Command(ToggleCompass);
        }

        public Command ToggleCompassCommand { get; set; }
        public double MagneticNorth { get { return _north; } set { _north = value; OnPropertyChanged(); } }
        private void ToggleCompass()
        {
            if (Microsoft.Maui.Devices.Sensors.Compass.Default.IsSupported)
            {
                if (!Microsoft.Maui.Devices.Sensors.Compass.Default.IsMonitoring)
                {
                    // Turn on compass
                    Microsoft.Maui.Devices.Sensors.Compass.Default.ReadingChanged += Compass_ReadingChanged;
                    Microsoft.Maui.Devices.Sensors.Compass.Default.Start(SensorSpeed.UI);
                }
                else
                {
                    // Turn off compass
                    Microsoft.Maui.Devices.Sensors.Compass.Default.Stop();
                    Microsoft.Maui.Devices.Sensors.Compass.Default.ReadingChanged -= Compass_ReadingChanged;
                }
            }
        }

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            MagneticNorth = (Math.Round(e.Reading.HeadingMagneticNorth * 100)) / 100;
            //OnPropertyChanged(nameof(MagneticNorth));
            Console.WriteLine(e.Reading.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
