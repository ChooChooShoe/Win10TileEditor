using System;
using System.Drawing;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Win10TileEditor.Tree.ViewModels;

namespace Win10TileEditor.Dialog
{

    [ValueConversion(typeof(SearchTreeItem), typeof(ImageSource))]
    public class IconToIamgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            /*if(value is IntPtr)
                return Imaging.CreateBitmapSourceFromHIcon((IntPtr)value, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());


            if (value is ResourceName)
            {
                ResourceName res = value as ResourceName;
                try
                {
                    if (res == null)
                        return Binding.DoNothing;

                    return Imaging.CreateBitmapSourceFromHIcon(res.Value, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return Binding.DoNothing;
                }

            }*/
            Icon icon = value as Icon;
            try
            {
                if (icon == null)
                    return Binding.DoNothing;

                return Imaging.CreateBitmapSourceFromHIcon(icon.Handle,Int32Rect.Empty,BitmapSizeOptions.FromEmptyOptions());
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
