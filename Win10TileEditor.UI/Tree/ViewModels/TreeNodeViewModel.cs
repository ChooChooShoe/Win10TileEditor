using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Win10TileEditor.Tree.ViewModels
{

    public abstract class SearchTreeItem : BindableBase
    {
        private bool expanded;
        private bool match;
        private bool visable;
        private dynamic icon;
        
        public SearchTreeItem Parent { get; internal set; }

        public abstract string Name { get; }
        
        public dynamic Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value, "Icon"); }
        }

        public bool IsLeaf { get; set; }
       
        public bool IsExpanded
        {
            get { return expanded; }
            set
            {
                //if (value == expanded)
                //    return;

                expanded = value;
                if (expanded)
                {
                    foreach (var child in Children)
                    {
                        child.IsMatch = true;
                    }
                    if(Parent != null)
                        Parent.IsExpanded = true;
                }
                OnPropertyChanged("IsExpanded");
            }
        }

        public bool IsVisable
        {
            get { return visable; }
            set { SetProperty(ref visable, value, "IsVisable"); }
        }

        public bool IsMatch
        {
            get { return match; }
            set { SetProperty(ref match, value, "IsMatch"); }
        }

        public void RemoveCriteria(Stack<SearchTreeItem> stack)
        {
            ApplyCriteria("", stack);
        }

        public void ApplyCriteria(string criteria, Stack<SearchTreeItem> ancestors)
        {
            if (Name.ToLower().Contains(criteria))
            {
                IsMatch = true;
                IsExpanded = !String.IsNullOrEmpty(criteria);
                //foreach (var ancestor in ancestors)
                //{
                //    ancestor.IsMatch = true;
                //    ancestor.IsExpanded = !String.IsNullOrEmpty(criteria);
                //}
            }
            else
            {
                IsMatch = false;
            }
            foreach (var child in Children)
                child.ApplyCriteria(criteria, ancestors);

            //ancestors.Push(this);

            //ancestors.Pop();
        }

        public abstract ICollection<SearchTreeItem> Children { get; }
        
    }

    public abstract class Item : SearchTreeItem
    {
        public FileSystemInfo Info { get; set; }
        
        public override String Name { get { return Info.Name; } }
        [Obsolete]
        public String TargetPath { get; set; }
        [Obsolete]
        public DateTime Date { get { return Info.LastAccessTime; } }

        /// <summary>
        /// The Unique name for this Item. Used by LinkBrowserModel.
        /// </summary>
        public String FullName { get { return Info.FullName; } }

        public string ShortName
        {
            get
            {
                int i = Info.FullName.IndexOf("Start Menu\\Programs"+10);
                return Info.FullName.Remove(0, i);
            }
        }

    }

    public class FolderItem : Item
    {
        internal Collection<SearchTreeItem> children = new ObservableCollection<SearchTreeItem>();

        public override ICollection<SearchTreeItem> Children { get { return children; } }

        public DirectoryInfo Directory { get { return Info as DirectoryInfo; } set { Info = value; } }

        public FolderItem(DirectoryInfo directory, Item parent)
        {
            Info = directory;
            Parent = parent;
            IsMatch = true;
            IsLeaf = true;

        }
    }

    //Used with WshShortcut (.url) or (.lnk)
    public class LinkItem : Item
    {
        public FileInfo File { get { return Info as FileInfo; } set { Info = value; } }
        
        public ShellShortcut ShortcutData { get; set; }
        public FileVisualManifest ManifestData { get; set; }

        [Obsolete]
        public String Description { get; internal set; }
        [Obsolete]
        public String IconLocation { get; set; }
        
        public override ICollection<SearchTreeItem> Children
        {
            get
            {
                return new Collection<SearchTreeItem>();
            }
        }
        
        public LinkItem(FileInfo file, Item parent)
        {
            Info = file;
            Parent = parent;
            IsMatch = true;
            IsLeaf = true;
        }
    }
    public class UrlLinkItem : LinkItem
    {
        //TODO make links and urls diffrent
        public UrlLinkItem(FileInfo file, Item parent) : base(file, parent) { }
    }
}
