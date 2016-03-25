using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Win10TileEditor.Tree.ViewModels;

namespace Win10TileEditor.Tree.ValueConverters {

    [ValueConversion(typeof(SearchTreeItem), typeof(ImageSource))]
    public class TreeNodeToImageConverter : IValueConverter
    {
        private const string UriFormat = "pack://application:,,,/Tree/Resources/Images/{0}";
        private static readonly IDictionary<string, ImageSource> SuffixToImageMap = new Dictionary<string, ImageSource>();

        private static readonly ImageSource FolderSource = new BitmapImage(new Uri(String.Format(UriFormat, "Folder.png")));

        static TreeNodeToImageConverter()
        {
            SuffixToImageMap[".exe"] = new BitmapImage(new Uri(String.Format(UriFormat, "Executable.png")));
            SuffixToImageMap[".zip"] = new BitmapImage(new Uri(String.Format(UriFormat, "Archive.png")));
            SuffixToImageMap[".png"] = SuffixToImageMap[".jpeg"] = SuffixToImageMap[".jpg"] = new BitmapImage(new Uri(String.Format(UriFormat, "Picture.png")));
            SuffixToImageMap[".txt"] = new BitmapImage(new Uri(String.Format(UriFormat, "Text.png")));
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is IntPtr)
                return Imaging.CreateBitmapSourceFromHIcon((IntPtr)value, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            SearchTreeItem item = value as SearchTreeItem;
            if (item == null)
                return Binding.DoNothing;
            
            if(item.IsLeaf)
            {
                //TODO build icons

                var i = item as LinkItem;
                return Binding.DoNothing;
            }
            else
                return FolderSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
