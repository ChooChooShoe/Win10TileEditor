using System;
using System.Collections.ObjectModel;
using System.Drawing;
using TsudaKageyu;

namespace Win10TileEditor.Dialog
{
    public class PickIconModel : BindableBase
    {
        private int index;
        private string path;

        private Icon selectedIcon;
        private Icon selectedSize;

        public int IconIndex
        {
            get { return index; }
            set { SetProperty(ref index, value, "IconIndex"); }
        }
        public string IconPath
        {
            get { return path; }
            set { SetProperty(ref path, value, "IconPath"); }
        }
        public Icon SelectedIconInFile
        {
            get { return selectedIcon; }
            set { SetProperty(ref selectedIcon, value, "SelectedIconInFile"); }
        }
        public Icon SelectedIconSize
        {
            get { return selectedSize; }
            set { SetProperty(ref selectedSize, value, "SelectedIconSize"); }
        }
        /// <summary>
        /// Gets the Icon that was last selected, if a size was also selected that would be returned instead.
        /// </summary>
        public Icon SelectedIcon
        {
            get
            {
                if (SelectedIconSize != null)
                    return SelectedIconSize;
                return SelectedIconInFile;
            }
        }
        
        public ObservableCollection<Icon> allIcons = new ObservableCollection<Icon>();
        public ObservableCollection<Icon> slelectedSizes = new ObservableCollection<Icon>();

        public ObservableCollection<Icon> IconsInFile
        {
            get { return allIcons; }
            set { SetProperty(ref allIcons, value, "IconsInFile"); }
        }
        public ObservableCollection<Icon> IconSizes
        {
            get { return slelectedSizes; }
            set { SetProperty(ref slelectedSizes, value, "IconSizes"); }
        }

        public PickIconModel()
        {

        }

        internal void updatePath()
        {
            if (String.IsNullOrEmpty(IconPath))
                return;
            try
            {
                Icon icon = null;
                //Try to load the file as icon file.
                try
                {
                    icon = new Icon(Environment.ExpandEnvironmentVariables(IconPath));
                }
                catch { }

                if (icon != null) //The file was an icon file.
                {
                    IconsInFile.Clear();
                    IconsInFile.Add(icon);
                }
                else
                {
                    //Load the file as an executable module.
                    IconExtractor extractor = new IconExtractor(IconPath);
                    {
                        IconsInFile.Clear();
                        for (int i = 0; i < extractor.Count; i++)
                        {
                            IconsInFile.Add(extractor.GetIcon(i));
                        }
                    }
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
