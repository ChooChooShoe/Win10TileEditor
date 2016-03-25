using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using Win10TileEditor.Core;
using Win10TileEditor.Tree.ViewModels;

namespace Win10TileEditor.Tree
{
    /// <summary>
    /// Interaction logic for LinkTreeControl.xaml
    /// </summary>
    public partial class LinkTreeControl : UserControl,IDisposable
    {
        public BackgroundWorker Worker { get { return worker; } }
        private BackgroundWorker worker;

        public LinkTreeControl()
        {
            InitializeComponent();

            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.ProgressChanged += worker_ProgressChanged;

            //this.Resources["SearchViewModel"];
            //this.DataContext = new SearchViewModel(Item.buildElements());
        }

        private void MainTree_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView view = sender as TreeView;
            MainWindow main = ((Grid)Parent).Parent as MainWindow;
            main.openItem(e.OldValue as SearchTreeItem, e.NewValue as SearchTreeItem);
        }
        
        public void StartWorker()
        {
            worker.RunWorkerAsync(((SearchViewModel)this.Resources["SearchViewModel"]).Roots);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //SearchViewModel m = this.Resources["SearchViewModel"] as SearchViewModel;
           // foreach (SearchTreeItem x in e.Result as ICollection<SearchTreeItem>)
            //    m.Roots.Add(x);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 98:
                    dynamic[] data = e.UserState as object[];
                    data[0].Add(data[1]);
                    break;
                case 99:
                    break;
            }
        }
        /// <summary>
        /// Builds file and folder structure for the Browser control.
        /// </summary>
        /// <param name="sender">BackgroundWorker</param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Stack<SearchTreeItem> stack = new Stack<SearchTreeItem>();
            //SearchViewModel model = e.Argument as SearchViewModel;

            Collection<SearchTreeItem> root = e.Argument as Collection<SearchTreeItem>;//new Collection<SearchTreeItem>();// 

            stack.Push(new FolderItem(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms)), null));
            stack.Push(new FolderItem(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Programs)), null));

            int done = 0, todo = 2;
            dynamic shell = ShellHelper.createWshShell();
            //IconFlags flags = IconFlags.SmallIcon | IconFlags.Icon;
            try
            {
                while (stack.Count > 0)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        return;
                    }
                    SearchTreeItem value = stack.Pop();
                    done++;
                    worker.ReportProgress(97, new object[] { (double)done / (double)todo * 100.0, value.Name });

                    if (value is FolderItem)
                    {
                        FolderItem folder = value as FolderItem;
                        Item child;
                        ICollection<SearchTreeItem> folderChildren;
                        if (folder.Parent == null)//is root
                            folderChildren = root;
                        else
                            folderChildren = folder.Children;

                        foreach (var dir in folder.Directory.GetDirectories())
                        {
                            child = new FolderItem(dir, folder);
                            worker.ReportProgress(98, new object[] { folderChildren, child });
                            //folderChildren.Add(child);
                            stack.Push(child);
                            todo++;
                            //ObservableCollection<SearchTreeItem> childItems = new ObservableCollection<SearchTreeItem>();

                            //buildFiles(childItems, childItem.Directory, childItem);

                            //childItem.children = childItems;//.OrderBy(c => c.Name).ToArray();
                        }
                        foreach (var file in folder.Directory.GetFiles("*.lnk"))
                        {
                            child = new LinkItem(file, folder);
                            worker.ReportProgress(98, new object[] { folderChildren, child });
                            //folderChildren.Add(child);
                            stack.Push(child);
                            todo++;
                        }
                        foreach (var file in folder.Directory.GetFiles("*.url"))
                        {
                            child = new UrlLinkItem(file, folder);
                            worker.ReportProgress(98, new object[] { folderChildren, child });
                            //folderChildren.Add(child);
                            stack.Push(child);
                            todo++;
                        }

                    }
                    else if (value is LinkItem)
                    {
                        LinkItem link = value as LinkItem;
                        if (link.ShortcutData == null)
                        {

                            dynamic lnk = shell.CreateShortcut(link.Info.FullName);
                            try
                            {
                                ShellShortcut s = new ShellShortcut();
                                s.IconLocation = lnk.IconLocation;
                                s.Description = lnk.Description;
                                s.TargetPath = lnk.TargetPath;
                                s.LinkPath = link.Info.FullName;
                                link.ShortcutData = s;

                                if (!String.IsNullOrEmpty(s.TargetPath))
                                {

                                    //SHFILEINFO fileInfo = new SHFILEINFO();
                                    //IntPtr result = NativeMethods.SHGetFileInfo(s.TargetPath, 0, ref fileInfo, (uint)Marshal.SizeOf(fileInfo), (SHGetFileInfoFlags)flags);

                                    //if (fileInfo.hIcon != IntPtr.Zero)
                                    //{
                                     //   link.Icon = new ResourceName(fileInfo.hIcon);
                                    //}
                                    
                                    link.ManifestData = new FileVisualManifest();
                                    link.ManifestData.loadTargetPath(s.TargetPath);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("And error has occured: {0}", ex);
                            }
                            finally
                            {
                                Marshal.FinalReleaseComObject(lnk);
                            }
                            //_worker.ReportProgress(0, item);
                        }
                    }
                }

            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }
            e.Result = root;
        }

        public void Dispose()
        {
            ((IDisposable)Worker).Dispose();
        }
    }
}
