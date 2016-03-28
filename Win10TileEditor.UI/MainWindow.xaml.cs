using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Win10TileEditor.Core;
using Win10TileEditor.Dialog;
using Win10TileEditor.Tree.ViewModels;

namespace Win10TileEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BindableVisualManifest VisManifest { get { return Resources["VisualManifest"] as BindableVisualManifest; } }
        public BindableShortcutData ShortcutData { get { return Resources["ShortcutData"] as BindableShortcutData; } }

        public MainWindow()
        {
            InitializeComponent();
            
            this.Browser.Worker.ProgressChanged += worker_ProgressChanged;
            this.Browser.Worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            //var b = new BitmapImage();

            //this.image0.Source = ShellHelper.GetIcon(@"‪C:\Games\UNDERTALE_v1.1.exe", true, false);
        }

        private void image150Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.png;*.jpeg;*.jpg;*.gif|All files|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
                this.image150Path.Text = openFileDialog.FileName;
        }

        private void image70Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.png;*.jpeg;*.jpg;*.gif|All files|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
                this.image70Path.Text = openFileDialog.FileName;
        }

        private void image150BrowseIcon_Click(object sender, RoutedEventArgs e)
        {
            PickIconDialog pickIconDialog = new PickIconDialog(this.ShortcutData.TargetPath, 0);

            if (pickIconDialog.ShowDialog() == true)
            {
                this.image150Path.Text = pickIconDialog.Model.IconPath;
                this.image150.DataContext = pickIconDialog.Model.SelectedIconSize;
            }
        }

        private void image70BrowseIcon_Click(object sender, RoutedEventArgs e)
        {
            PickIconDialog pickIconDialog = new PickIconDialog(this.ShortcutData.TargetPath, 0);

            if (pickIconDialog.ShowDialog() == true)
            {
                this.image70Path.Text = pickIconDialog.Model.IconPath;
                this.image70.DataContext = pickIconDialog.Model.SelectedIconSize;

            }
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;// !String.IsNullOrWhiteSpace(TargetFile) && File.Exists(TargetFile) && VisManifest.IsValid;
        }

        
        private void Save_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(ShortcutData.TargetPath) && File.Exists(ShortcutData.TargetPath) && VisManifest.IsValid)
            {
                FileInfo exeFile = new FileInfo(ShortcutData.TargetPath);

                if (!exeFile.Exists)
                {
                    MessageBox.Show("No application found at '" + ShortcutData.TargetPath + "'", "Can't save changes");
                    return;
                }
                var baseName = exeFile.Name.Substring(0, exeFile.Name.Length - exeFile.Extension.Length);

                var visualPath = new FileInfo(exeFile.DirectoryName + "\\" + baseName + ".VisualElementsManifest.xml");

                if (!String.IsNullOrEmpty(this.image150Path.Text))//TODO Make this optinal
                {
                    var fileIcon150 = baseName + "Icon150x150.png";
                    var fileIcon70 = baseName + "Icon70x70.png";

                    VisManifest.Square150x150Logo = fileIcon150;
                    VisManifest.Square70x70Logo = fileIcon70;

                    fileIcon150 = exeFile.DirectoryName + "\\" + fileIcon150;
                    fileIcon70 = exeFile.DirectoryName + "\\" + fileIcon70;

                    //TODO save exception
                    using (var fileStream = new FileStream(fileIcon150, FileMode.Create))
                    {
                        BitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(this.image150.Source as BitmapSource));
                        encoder.Save(fileStream);
                    }
                    using (var fileStream = new FileStream(fileIcon70, FileMode.Create))
                    {
                        BitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(this.image70.Source as BitmapSource));
                        encoder.Save(fileStream);
                    }
                    //this._image150FileName.CopyTo(fileIcon150);
                    //this.image70FileName.CopyTo(fileIcon70);
                }
                if (VisManifest.saveToFile(visualPath.FullName))
                {
                    File.SetLastWriteTime(ShortcutData.LinkPath, DateTime.Now);
                    //if (item.ManifestData != null)
                    //    this.VisManifest.loadFromManifest(item.ManifestData);
                }
            }
        }
        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Open_Execute(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.statusProgress.Value = 0;
            this.statusPath.Text = "Loading Link data completed.";
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 97:
                    dynamic[] data = e.UserState as object[];
                    this.statusProgress.Value = data[0];
                    this.statusText.Text = data[1];
                    if (data.Length > 2)
                        this.statusPath.Text = data[2];
                    break;
            }
        }

        internal void openItem(SearchTreeItem oldItem, SearchTreeItem newItem)
        {
            LinkItem item = newItem as LinkItem;
            if (item == null)
            {
                this.VisManifest.Clear();
                this.image150.Source = null;
                this.image70.Source = null;
                this.ShortcutData.Clear();
                return;
            }
            if(item.ManifestData != null)
            {
                this.VisManifest.loadFromManifest(item.ManifestData);
                this.image150.Source = null;
                this.image70.Source = null;
            }
            if (item.ShortcutData != null)
                this.ShortcutData.loadFromShortcut(item.ShortcutData);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.statusProgress.Value = 0;
            this.Browser.StartWorker();
        }

        private void OpenFileProperties_Click(object sender, RoutedEventArgs e)
        {
            ShellHelper.ShowPropertiesDialog(IntPtr.Zero, this.ShortcutData.LinkPath);
        }
    }
}