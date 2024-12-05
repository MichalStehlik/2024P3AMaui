using MVVMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Convertors
{
    class EnumToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            if (value is ColorSet)
            {
                switch (value)
                {
                    case ColorSet.Black:
                        return Colors.Black;
                    case ColorSet.Blue:
                        return Colors.Blue;
                    case ColorSet.Green:
                        return Colors.Green;
                    case ColorSet.Red:
                        return Colors.Red;
                    default:
                        return Colors.Black;

                }
            }
            return Colors.Black;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
