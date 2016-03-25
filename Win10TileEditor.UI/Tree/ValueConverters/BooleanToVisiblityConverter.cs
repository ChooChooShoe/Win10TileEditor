using System;
using System.Windows;
using System.Windows.Data;

namespace Win10TileEditor.Tree.ValueConverters {
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToVisiblityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return (Visibility)value == Visibility.Visible;
        }
    }
}
