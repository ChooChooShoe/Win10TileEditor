using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Win10TileEditor
{
    [Obsolete]
    public abstract class BaseItem
    {
        public DirectoryInfo DirectoryInfo { get; set; }
        public string ItemPath { get; set; }
		public Image Icon { get; set; }
		public long Size { get; set; }
		public DateTime Date { get; set; }
        public BaseItem Parent { get; set; }
        public LinkBrowserModel Owner { get; set; }
        public string TargetPath { get; set; }

        public abstract string Name { get; set; }

        private bool isChecked;
        public bool IsChecked
		{
			get { return isChecked; }
			set 
			{
                isChecked = value;
				//if (Owner != null)
					//Owner.OnNodesChanged(this);
			}
		}

        public override bool Equals(object obj)
		{
			if (obj is BaseItem)
				return ItemPath.Equals((obj as BaseItem).ItemPath);
			else
				return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return ItemPath.GetHashCode();
		}

        public override string ToString()
        {
            return ItemPath;
        }
	}

    [Obsolete]
    public class RootItem : BaseItem
    {
        
        public RootItem(string name, DirectoryInfo directoryInfo, LinkBrowserModel owner)
        {
            ItemPath = name;
            DirectoryInfo = directoryInfo;
            Owner = owner;
        }

        public override string Name
		{
			get
			{
				return ItemPath;
			}
			set
			{
			}
		}
	}

    [Obsolete]
    public class FolderItem : BaseItem
    {
        public override string Name
        {
            get
            {
                return Path.GetFileName(ItemPath);
            }
            set
            {
                string dir = Path.GetDirectoryName(ItemPath);
                string destination = Path.Combine(dir, value);
                Directory.Move(ItemPath, destination);
                ItemPath = destination;
            }
        }

        public FolderItem(string name, BaseItem parent, DirectoryInfo directoryInfo, LinkBrowserModel owner)
		{
			ItemPath = name;
            Parent = parent;
            DirectoryInfo = directoryInfo;
            Owner = owner;
		}
	}

    [Obsolete]
    public class FileItem : BaseItem
	{
		public override string Name
		{
			get
			{
				return Path.GetFileName(ItemPath);
			}
			set
			{
				string dir = Path.GetDirectoryName(ItemPath);
				string destination = Path.Combine(dir, value);
				File.Move(ItemPath, destination);
				ItemPath = destination;
			}
		}

        public string Description { get; set; }
        public VisualManifest ManifestData { get; internal set; }

        public FileItem(string name, BaseItem parent, LinkBrowserModel owner)
		{
			ItemPath = name;
			Parent = parent;
			Owner = owner;
		}
        /*
        public void LoadShortcut(IWshRuntimeLibrary.WshShell shell)
        {
            Console.WriteLine("OPEN SHORTCUT "+ ItemPath);
            IWshRuntimeLibrary.IWshShortcut shortcut = shell.CreateShortcut(ItemPath);
            Description = shortcut.Description;
            TargetPath = shortcut.TargetPath;
            if(TargetPath != null && TargetPath.Length > 3)
            {
                var file = new FileInfo(TargetPath.Substring(0, TargetPath.Length - 3) + "VisualElementsManifest.xml");
                ManifestData = new VisualManifest(file);
            }
        }*/
	}
}
