using System;
using System.Globalization;
using System.Windows.Data;

namespace HMI.Converters
{
    public class BoolToTextConverter : IValueConverter
    {
        // ConverterParameter format: "FalseText|TrueText"
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null) return value?.ToString() ?? string.Empty;

            var parts = parameter.ToString().Split('|');
            if (parts.Length != 2) return value?.ToString() ?? string.Empty;

            return (bool)value ? parts[1] : parts[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}