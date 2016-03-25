using System;
using Aga.Controls.Tree;
using System.IO;
using System.Drawing;
using System.Windows;
using System.Xml;
using Win10TileEditor.Properties;

namespace Win10TileEditor
{
    public abstract class BaseViewItem
    {
        public FileSystemInfo Info { get; set; }

        //These 3 objects are required for the node controls
        public String Name { get { return Info.Name; } }
        public String TargetPath { get; set; }
        public DateTime Date { get { return Info.LastAccessTime; } }

        /// <summary>
        /// The Unique name for this Item. Used by LinkBrowserModel.
        /// </summary>
        public String FullName { get { return Info.FullName; } }

    }

    public class FolderViewItem : BaseViewItem
    {
        public DirectoryInfo Directory { get { return Info as DirectoryInfo; } set { Info = value; } }
        
        public FolderViewItem(DirectoryInfo directory)
        {
            Info = directory;
            TargetPath = String.Empty;
        }
    }

    //Used with WshShortcut (.url) or (.lnk)
    public class LinkViewItem : BaseViewItem
    {
        public FileInfo File { get { return Info as FileInfo; } set { Info = value; } }

        protected dynamic shortcut;

        public object Icon { get; set; }
        public VisualManifest ManifestData { get; set; }

        public String Description { get; internal set; }

        public String IconLocation { get; set; }

        public LinkViewItem(FileInfo file)
        {
            Info = file;
        }
    }

    public class VisualManifest
    {
        internal string Path
        {
            get
            {
                if (File == null)
                    return null;
                return this.File.DirectoryName;
            }
        }

        public bool HasImageData
        {
            get
            {
                return Square150x150Logo != null && Square70x70Logo != null;
            }
        }

        /// <summary>
        /// True if this has an associated file and it exits on the disk.
        /// </summary>
        public bool Exists
        {
            get
            {
                return File != null && File.Exists;
            }
        }
        public FileInfo File { get; set; }

        public bool ShowNameOnSquare { get; set; }
        public bool UseDarkText { get; set; }
        public string BackgroundColor { get; set; }
        public string Square150x150Logo { get; set; }
        public string Square70x70Logo { get; set; }

        /// <summary>
        /// Creates a new VisualManifest in memory.
        /// </summary>
        /// <param name="file">Optional file to load data from</param>
        public VisualManifest(FileInfo file)
        {
            this.File = file;
            loadFromFile();
        }

        public bool loadFromFile()
        {
            if (!Exists)
                return false;
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(File.FullName);

                var node = xml.DocumentElement.SelectSingleNode("/Application/VisualElements");
                this.BackgroundColor = node.Attributes["BackgroundColor"].Value;
                this.ShowNameOnSquare = node.Attributes["ShowNameOnSquare150x150Logo"].InnerText == "on";
                this.UseDarkText = node.Attributes["ForegroundText"].InnerText == "dark";
                if (node.Attributes["Square150x150Logo"] != null)
                {
                    this.Square150x150Logo = node.Attributes["Square150x150Logo"].InnerText;
                    this.Square70x70Logo = node.Attributes["Square70x70Logo"].InnerText;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can't load file as Visual Manifest XML");
                if (ex.Source != null)
                    Console.WriteLine("Exception: {0}", ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Saves this manifest to the disk creating a new file if one does not exist.
        /// </summary>
        /// <returns></returns>
        public bool saveToFile()
        {

            if (File == null)
                return false;
            try
            {
                XmlDocument xml = new XmlDocument();
                var app = xml.CreateElement("Application");
                app.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                var element = xml.CreateElement("VisualElements");
                app.AppendChild(element);
                xml.AppendChild(app);

                element.SetAttribute("BackgroundColor", this.BackgroundColor);
                element.SetAttribute("ShowNameOnSquare150x150Logo", this.ShowNameOnSquare ? "on" : "off");
                element.SetAttribute("ForegroundText", this.UseDarkText ? "dark" : "light");

                // if only one image is set we use it as both 150 and 70.

                if (Square150x150Logo != null)
                {
                    element.SetAttribute("Square150x150Logo", Square150x150Logo);
                    element.SetAttribute("Square70x70Logo", Square70x70Logo != null ? Square70x70Logo : Square150x150Logo);
                }
                else if (this.Square70x70Logo != null)
                {
                    element.SetAttribute("Square150x150Logo", Square70x70Logo);
                    element.SetAttribute("Square70x70Logo", Square150x150Logo);
                }
                xml.Save(this.File.FullName);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can't save file as XML");
                if (ex.Source != null)
                    Console.WriteLine("Exception: {0}", ex.ToString());
                return false;
            }
        }
    }
    public class TreeItemNodeIcon : Aga.Controls.Tree.NodeControls.NodeIcon
    {
        private Image _leaf;
        private Image _opened;
        private Image _closed;

        public TreeItemNodeIcon()
        {
            _leaf = MakeTransparent(Resources.document_a4_blank);
            _opened = MakeTransparent(Resources.folder_classic_opened);
            _closed = MakeTransparent(Resources.folder_classic);
        }

        private static Image MakeTransparent(Bitmap bitmap)
        {
            bitmap = new Bitmap(bitmap, 16, 16);
            bitmap.MakeTransparent(bitmap.GetPixel(0, 0));
            return bitmap;
        }

        protected override Image GetIcon(TreeNodeAdv node)
        {
            Image icon = base.GetIcon(node);
            if (icon != null)
                return MakeTransparent((Bitmap)icon);
            else if (node.IsLeaf)
                return _leaf;
            else if (node.CanExpand && node.IsExpanded)
                return _opened;
            else
                return _closed;
        }
    }
}