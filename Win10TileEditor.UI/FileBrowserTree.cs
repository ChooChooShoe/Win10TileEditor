using Hardcodet.Wpf.GenericTreeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10TileEditor
{
    public class FileBrowserTree : TreeViewBase<Item>
    {
        public override string GetItemKey(Item item)
        {
            return item.FullName;
        }
        
        public override ICollection<Item> GetChildItems(Item parent)
        {
            if (parent is FolderItem)
                return ((FolderItem)parent).Children;
            return new List<Item>();
        }
        

        protected override bool HasChildItems(Item parent)
        {
            if (parent is FolderItem)
            {
                FolderItem i = parent as FolderItem;

                return i.Children != null && i.Children.Count > 0;
            }
            return false;
        }

        public override Item GetParentItem(Item item)
        {
            return item.Parent;
        }
    }
}
