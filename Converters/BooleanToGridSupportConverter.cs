using System;
using System.Windows.Data;

namespace SolarAutomation.Converters
{
    public class BooleanToGridSupportConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? nullableBool = value as bool?;
            if (nullableBool.HasValue)
            {
                return nullableBool.Value ? "Şebeke Destekli" : "Şebeke Desteksiz";
            }
            return "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}