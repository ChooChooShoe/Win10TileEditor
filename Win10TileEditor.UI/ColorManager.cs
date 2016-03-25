using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Win10TileEditor
{
    public class ColorManager
    {
        internal static ObservableCollection<ManagedColor> allColors = build();
        static ObservableCollection<ManagedColor> build()
        {
            var allColors = new ObservableCollection<ManagedColor>();
            allColors.Add(new ManagedColor("aqua", Brushes.Aqua, Brushes.Black));
            allColors.Add(new ManagedColor("black", Brushes.Black, Brushes.White));
            allColors.Add(new ManagedColor("blue", Brushes.Blue, Brushes.White));
            allColors.Add(new ManagedColor("fuchsia", Brushes.Fuchsia, Brushes.White));
            allColors.Add(new ManagedColor("gray", Brushes.Gray, Brushes.White));
            allColors.Add(new ManagedColor("green", Brushes.Green, Brushes.White));
            allColors.Add(new ManagedColor("lime", Brushes.Lime, Brushes.Black));
            allColors.Add(new ManagedColor("maroon", Brushes.Maroon, Brushes.White));
            allColors.Add(new ManagedColor("navy", Brushes.Navy, Brushes.White));
            allColors.Add(new ManagedColor("olive", Brushes.Olive, Brushes.White));
            allColors.Add(new ManagedColor("purple", Brushes.Purple, Brushes.White));
            allColors.Add(new ManagedColor("red", Brushes.Red, Brushes.White));
            allColors.Add(new ManagedColor("silver", Brushes.Silver, Brushes.Black));
            allColors.Add(new ManagedColor("teal", Brushes.Teal, Brushes.White));
            allColors.Add(new ManagedColor("white", Brushes.White, Brushes.Black));
            allColors.Add(new ManagedColor("yellow", Brushes.Yellow, Brushes.Black));
            return allColors;
        }
        public ObservableCollection<ManagedColor> AllColors { get { return allColors; } }

        public ColorManager()
        {
        }
    }

    public class ManagedColor : BindableBase
    {

        protected Brush colorValue;
        protected string name;
        protected Brush highlight;

        public Brush Value
        {
            get { return colorValue; }
            set { SetProperty(ref colorValue, value, "Value"); }
        }

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value, "Name"); }
        }

        public Brush Highlight
        {
            get { return highlight; }
            set { SetProperty(ref highlight, value, "Highlight"); }
        }

        public ManagedColor(string name, Brush value, Brush highlight)
        {
            Value = value;
            Name = name;
            Highlight = highlight;
        }

        public override string ToString()
        {
            return Name;
        }

        internal static ManagedColor fromName(string value)
        {
            foreach(ManagedColor c in ColorManager.allColors)
            {
                if (c.name.Equals(value))
                    return c;
            }
            return new ManagedColor(value,Brushes.SpringGreen,Brushes.SkyBlue);
        }
    }
}
