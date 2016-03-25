using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Xml;

namespace Win10TileEditor
{
    public interface IShortcut
    {
        string Description { get; set; }
        string IconLocation { get; set; }
        bool IsValid { get; }
        string LinkPath { get; set; }
        string TargetPath { get; set; }
        string DisplayName { get; }
    }

    public class ShellShortcut : IShortcut
    {
        public string Description { get; set; }

        public string DisplayName
        {
            get
            {
                FileInfo i = new FileInfo(LinkPath);
                return i.Name.Substring(0, i.Name.Length - i.Extension.Length);
            }
        }

        public string IconLocation { get; set; }

        public bool IsValid
        {
            get
            {
                return true;
            }
        }

        public string LinkPath { get; set; }

        public string TargetPath { get; set; }
    }

    public class BindableShortcutData : BindableBase, IShortcut
    {
        protected string targetPath;
        protected string linkPath;
        protected string iconLocation;
        protected string discription;

        public string TargetPath
        {
            get { return targetPath; }
            set { SetProperty(ref targetPath, value, "TargetPath"); }
        }

        public string IconLocation
        {
            get { return iconLocation; }
            set { SetProperty(ref iconLocation, value, "IconLocation"); }
        }

        public string Description
        {
            get { return discription; }
            set { SetProperty(ref discription, value, "Description"); }
        }

        public bool IsValid
        {
            get
            {
                return true;
            }
        }
        public string DisplayName
        {
            get
            {
                FileInfo i = new FileInfo(LinkPath);
                return i.Name.Substring(0, i.Name.Length - i.Extension.Length);
            }
        }

        public string LinkPath
        {
            get { return linkPath; }
            set {
                SetProperty(ref linkPath, value, "LinkPath");
                this.OnPropertyChanged("DisplayName");
            }
        }

        public BindableShortcutData()
        {
        }

        internal void loadFromShortcut(ShellShortcut other)
        {
            this.Description = other.Description;
            this.IconLocation = other.IconLocation;
            this.TargetPath = other.TargetPath;
            this.LinkPath = other.LinkPath;
        }
    }

    /// <summary>
    /// Used to store the valus needed to create a VisualManifest.xml file
    /// </summary>
    public interface IVisualManifest
    {
        bool ShowNameOnSquare { get; set; }
        bool UseDarkText { get; set; }
        bool UseLightText { get; set; }
        ManagedColor BackgroundColor { get; set; }
        string Square150x150Logo { get; set; }
        string Square70x70Logo { get; set; }

        bool IsValid { get; }
        bool HasImageData { get; }

    }
    /// <summary>
    /// Simple implementation of <see cref="IVisualManifest"/> using auto-implemented  properties.
    /// </summary>
    public class FileVisualManifest : IVisualManifest
    {
        public bool ShowNameOnSquare { get; set; }
        public bool UseDarkText { get; set; }
        public bool UseLightText
        {
            get { return !UseDarkText; }
            set { UseDarkText = !value; }
        }
        public ManagedColor BackgroundColor { get; set; }
        public string Square150x150Logo { get; set; }
        public string Square70x70Logo { get; set; }

        public bool IsValid
        {
            get
            {
                return true;
            }
        }
        public bool HasImageData
        {
            get
            {
                return !String.IsNullOrEmpty(Square150x150Logo) && !String.IsNullOrEmpty(Square70x70Logo);
            }
        }
        public bool loadTargetPath(string targetPath)
        {
            return loadFromFile(targetPath.Substring(0, targetPath.Length - 3) + "VisualElementsManifest.xml");
        }

        /// <summary>
        /// Loads data for this SimpleVisualManifest from the given file.
        /// </summary>
        /// <param name="file">File must exist</param>
        /// <returns>True if Properties have been loaded.</returns>
        public bool loadFromFile(string file)
        {
            if (!File.Exists(file))
                return false;
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(file);

                var node = xml.DocumentElement.SelectSingleNode("/Application/VisualElements");
                this.BackgroundColor = ManagedColor.fromName(node.Attributes["BackgroundColor"].Value);
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
                Console.WriteLine("Exception: {0}", ex);
                return false;
            }
        }
    }
    /// <summary>
    /// Another implementation of <see cref="IVisualManifest"/> using a <see cref="BindableBase"/>. For use with the UI
    /// </summary>
    public class BindableVisualManifest : BindableBase, IVisualManifest
    {
        private bool showNameOnSquare;
        private bool useDarkText;
        private bool useLightText;
        private ManagedColor backgroundColor;
        private string square150x150Logo;
        private string square70x70Logo;

        public bool ShowNameOnSquare
        {
            get { return showNameOnSquare; }
            set { SetProperty(ref showNameOnSquare, value, "ShowNameOnSquare"); }
        }
        public bool UseDarkText
        {
            get { return useDarkText; }
            set
            {
                SetProperty(ref useDarkText, value, "UseDarkText");
                SetProperty(ref useLightText, !value, "UseLightText");
                OnPropertyChanged("ForegroundColor");
            }
        }
        public bool UseLightText {
            get { return useLightText; }
            set
            {
                SetProperty(ref useLightText, value, "UseLightText");
                SetProperty(ref useDarkText, !value, "UseDarkText");
                OnPropertyChanged("ForegroundColor");
            }
        }
        public ManagedColor ForegroundColor
        {
            get
            {
                if(UseDarkText)
                    return ManagedColor.fromName("black");
                return ManagedColor.fromName("white");

            }
        }

        public ManagedColor BackgroundColor
        {
            get { return backgroundColor; }
            set { SetProperty(ref backgroundColor, value, "BackgroundColor"); }
        }
        public string Square150x150Logo
        {
            get { return square150x150Logo; }
            set { SetProperty(ref square150x150Logo, value, "Square150x150Logo"); }
        }
        public string Square70x70Logo
        {
            get { return square70x70Logo; }
            set { SetProperty(ref square70x70Logo, value, "Square70x70Logo"); }
        }

        public bool IsValid
        {
            get
            {
                return true;
            }
        }
        public bool HasImageData
        {
            get
            {
                return !String.IsNullOrEmpty(Square150x150Logo) && !String.IsNullOrEmpty(Square70x70Logo);
            }
        }

        public IVisualManifest Source { get; private set; }

        public BindableVisualManifest()
        {
        }
        private void saveToManifest()
        {
            Source.BackgroundColor = this.BackgroundColor;
            Source.ShowNameOnSquare = this.ShowNameOnSquare;
            Source.Square150x150Logo = this.Square150x150Logo;
            Source.Square70x70Logo = this.Square70x70Logo;
            Source.UseDarkText = this.UseDarkText;
        }
        public void loadFromManifest(IVisualManifest m)
        {
            this.Source = m;
            this.BackgroundColor = m.BackgroundColor;
            this.ShowNameOnSquare = m.ShowNameOnSquare;
            this.Square150x150Logo = m.Square150x150Logo;
            this.Square70x70Logo = m.Square70x70Logo;
            this.UseDarkText = m.UseDarkText;
        }
        /// <summary>
        /// Saves this manifest to the disk creating a new file if one does not exist.
        /// </summary>
        /// <returns></returns>
        public bool saveToFile(string file)
        {
            if (file == null)
                return false;
            try
            {
                XmlDocument xml = new XmlDocument();
                var app = xml.CreateElement("Application");
                app.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                var element = xml.CreateElement("VisualElements");
                app.AppendChild(element);
                xml.AppendChild(app);

                element.SetAttribute("BackgroundColor", this.BackgroundColor.Name);
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
                xml.Save(file);
                saveToManifest();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex);
                return false;
            }
        }
    }
}
