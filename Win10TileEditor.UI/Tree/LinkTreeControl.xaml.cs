using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using Win10TileEditor.Core;
using Win10TileEditor.Tree.ViewModels;

namespace Win10TileEditor.Tree
{
    /// <summary>
    /// Interaction logic for LinkTreeControl.xaml
    /// </summary>
    public partial class LinkTreeControl : UserControl
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
            worker.RunWorkerAsync(this.Resources["SearchViewModel"]);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //SearchViewModel m = this.Resources["SearchViewModel"] as SearchViewModel;

            //m.Roots = new ObservableCollection<SearchTreeItem>(m.Roots.OrderBy(a => a.Name));
            
            // foreach (SearchTreeItem x in e.Result as ICollection<SearchTreeItem>)
            //    m.Roots.Add(x);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 98:
                    dynamic[] data = e.UserState as object[];
                    AddSorted(data[0], data[1]);
                    break;
                case 99:
                    break;
            }
        }

        public  void AddSorted<ListViewItem>(IList<ListViewItem> list, ListViewItem item, IComparer<ListViewItem> comparer = null)
        {
            if (comparer == null)
                comparer = Comparer<ListViewItem>.Default;

            int i = 0;

            while (i < list.Count && comparer.Compare(list[i], item) < 0)
                i++;

            list.Insert(i, item);
        }

        /// <summary>
        /// Builds file and folder structure for the Browser control.
        /// </summary>
        /// <param name="sender">BackgroundWorker</param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            SearchViewModel model = e.Argument as SearchViewModel;

            var dirQueue = new Queue<FolderItem>();
            var linkQueue = new Queue<LinkItem>();
            var childCache = new Dictionary<string, FolderItem>();

            dirQueue.Enqueue(new FolderItem(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms)), null, "ROOT"));
            dirQueue.Enqueue(new FolderItem(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Programs)), null, "ROOT"));

            double done = 0, todo = 2;
            //IconFlags flags = IconFlags.SmallIcon | IconFlags.Icon;

            // Worker part 1 - folders and file structure
            while (dirQueue.Count > 0)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                //System.Threading.Thread.Sleep(10);
                FolderItem folder = dirQueue.Dequeue();

                if (done < 10)
                    Console.WriteLine(string.Format("i={0} - {1} - {2}",done,folder.Name,folder.FullName));

                done++;
                worker.ReportProgress(97, new object[] { done / todo * 100.0, "\\" + folder.Name });
                
                ICollection<SearchTreeItem> folderChildren;
                if (folder.Parent == null)//is root
                    folderChildren = model.Roots;
                else
                    folderChildren = folder.Children;

                foreach(var rootDir in folder.Directories)
                {

                    todo += rootDir.GetFileSystemInfos().Length;

                    foreach (var subDir in rootDir.GetDirectories())
                    {
                        FolderItem child;
                        var key = folder.TreePath + "\\" + subDir.Name;

                        if (childCache.ContainsKey(key))
                        {
                            child = childCache[key];
                            child.Directories.Add(subDir);
                        }
                        else
                        {
                            child = new FolderItem(subDir, folder, key);
                            childCache[key] = child;
                            worker.ReportProgress(98, new object[] { folderChildren, child });
                            dirQueue.Enqueue(child);
                        }

                        //folderChildren.Add(child);
                        //ObservableCollection<SearchTreeItem> childItems = new ObservableCollection<SearchTreeItem>();

                        //buildFiles(childItems, childItem.Directory, childItem);

                        //childItem.children = childItems;//.OrderBy(c => c.Name).ToArray();
                    }
                    foreach (var file in rootDir.GetFiles("*.lnk"))
                    {
                        var child = new LinkItem(file, folder);
                        worker.ReportProgress(98, new object[] { folderChildren, child });
                        //folderChildren.Add(child);
                        linkQueue.Enqueue(child);
                    }
                    foreach (var file in rootDir.GetFiles("*.url"))
                    {
                        var child = new UrlLinkItem(file, folder);
                        worker.ReportProgress(98, new object[] { folderChildren, child });
                        //folderChildren.Add(child);
                        linkQueue.Enqueue(child);
                    }
                }
            }
            // Worker part 2 - read links and WshShortcut data
            dynamic shell = ShellHelper.createWshShell();
            try
            {
                done = 0;
                todo = linkQueue.Count;
                while (linkQueue.Count > 0)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        return;
                    }
                    LinkItem item = linkQueue.Dequeue();
                    done++;
                    worker.ReportProgress(97, new object[] { done / todo * 100.0, "Link: "+ item.Name, item.FullName });
                    
                    if (item.ShortcutData == null)
                    {
                        dynamic lnk = shell.CreateShortcut(item.Info.FullName);
                        try
                        {
                            item.ShortcutData = new ShellShortcut(item.Info.FullName, lnk);

                            if (!String.IsNullOrEmpty(item.ShortcutData.TargetPath) && !(item is UrlLinkItem))
                            {

                                //SHFILEINFO fileInfo = new SHFILEINFO();
                                //IntPtr result = NativeMethods.SHGetFileInfo(s.TargetPath, 0, ref fileInfo, (uint)Marshal.SizeOf(fileInfo), (SHGetFileInfoFlags)flags);

                                //if (fileInfo.hIcon != IntPtr.Zero)
                                //{
                                //   link.Icon = new ResourceName(fileInfo.hIcon);
                                //}

                                item.ManifestData = new FileVisualManifest();
                                item.ManifestData.loadTargetPath(item.ShortcutData.TargetPath);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("And error has occured when reading link data for '{0}': {1}", item.Info.FullName, ex);
                        }
                        finally
                        {
                            Marshal.FinalReleaseComObject(lnk);
                        }
                        //_worker.ReportProgress(0, item);
                    }
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }
        }
    }
}
