using System;
using System.Collections.Generic;

using Aga.Controls.Tree;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using TAFactory.IconPack;

namespace Win10TileEditor
{
    public class LinkBrowserModel : TreeModelBase, IDisposable
    {
        private BackgroundWorker _worker;
        private Stack<LinkViewItem> _linksToReadStack;
        private Dictionary<string, List<BaseViewItem>> cache = new Dictionary<string, List<BaseViewItem>>();
        private FolderBrowser Master;

        public IntPtr Handle { get; private set; }

        public LinkBrowserModel(FolderBrowser master)
        {
            Master = master;
            Handle = master.Handle;
            _linksToReadStack = new Stack<LinkViewItem>();

            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += new DoWorkEventHandler(ReadFilesProperties);
            //_worker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);


            //update();


            //var rootDirectory = new DirectoryInfo(path);
            //var node = ((TreeModel)(this.treeViewAdv1.Model)).Root;
            //node.Tag = rootDirectory;
            //_itemsToReadStack.Push(node);
        }

        void ReadFilesProperties(object sender, DoWorkEventArgs e)
        {
            dynamic shell = ShellHelp.createWshShell();
            //WshShell shell = new WshShell();

            try
            {
                while (_linksToReadStack.Count > 0)
                {
                    LinkViewItem item = _linksToReadStack.Pop();// LinkViewItem
                    WshShortcut lnk = new WshShortcut(shell.CreateShortcut(item.File.FullName));
                    try
                    {

                        item.IconLocation = lnk.IconLocation;
                        item.Description = lnk.Description;
                        item.TargetPath = lnk.TargetPath;

                        Console.WriteLine("Icon: {0}", lnk.IconLocation);



                        if (item.TargetPath != null && item.TargetPath.Length > 3)
                        {
                            //icon
                            IconExtractor ex = new IconExtractor(item.TargetPath);

                            //Console.WriteLine("Icon Extract: cout={0} FIleName={1} toString={2}",ex.Count,ex.FileName, ex.ToString());
                            item.Icon = new Icon(ex.GetIconAt(0), 16, 16).ToBitmap();

                            ex.Dispose();
                            //int index = 0;
                            //StringBuilder strB = new StringBuilder(item.TargetPath);
                            //IntPtr handle = SafeNativeMethods.ExtractAssociatedIcon((IntPtr)e.Argument, strB, ref index);
                            //Icon ico = Icon.FromHandle(handle);
                            //item.Icon = ico.ToBitmap();// new Bitmap(ico.ToBitmap(), new Size(16, 16));

                            //Master.imageList1.Images.Add(ico);
                            //Master.debugPictureBox.Image = Master.imageList1.Images[0];

                            //Shell32.Shell shell = new Shell32.Shell();
                            //shell.MinimizeAll();

                            //icon

                            var file = new FileInfo(item.TargetPath.Substring(0, item.TargetPath.Length - 3) + "VisualElementsManifest.xml");
                            item.ManifestData = new VisualManifest(file);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("And error has occured: '{0}'", ex);
                    }
                    finally
                    {
                        Marshal.FinalReleaseComObject(lnk);
                    }
                    _worker.ReportProgress(0, item);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }

        }
        [DllImport("shell32.dll")]
        [Obsolete]
        static extern IntPtr ExtractAssociatedIcon(IntPtr hInst, StringBuilder lpIconPath, out ushort lpiIcon);

        [DllImport("shell32.dll")]
        [Obsolete]
        static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        [Obsolete]
        public static extern int ExtractIconEx(string lpszFile, int nIconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, uint nIcons);

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        [Obsolete]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);


        /// <summary>
        /// This class suppresses stack walks for unmanaged code permission. 
        /// (System.Security.SuppressUnmanagedCodeSecurityAttribute is applied to this class.) 
        /// This class is for methods that are safe for anyone to call. 
        /// Callers of these methods are not required to perform a full security review to make sure that the 
        /// usage is secure because the methods are harmless for any caller.
        /// </summary>
        [System.Security.SuppressUnmanagedCodeSecurity]
        internal static class SafeNativeMethods
        {
            [DllImport("shell32.dll", EntryPoint = "ExtractAssociatedIcon", CharSet = CharSet.Auto)]
            internal static extern IntPtr ExtractAssociatedIcon(IntPtr hInst, StringBuilder iconPath, ref int index);

            [DllImport("shell32.dll")]
            static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);
        }

        [Obsolete]
        void update()
        {

            int m_nIcons = ExtractIconEx("‪C:\\Program Files\\Rainmeter\\Rainmeter.exe", -1, null, null, 0);

            if (m_nIcons == -1)
            {
                MessageBox.Show("Couldn't retreive icons.");
                return;
            }

            IntPtr[] m_pIconsLarge = new IntPtr[m_nIcons];
            IntPtr[] m_pIconsSmall = new IntPtr[m_nIcons];

            ExtractIconEx("‪C:\\Program Files\\Rainmeter\\Rainmeter.exe", 0, m_pIconsLarge, m_pIconsSmall, (uint)m_nIcons);

            for (int i = 0; i < m_nIcons; i++)
            {
                System.Drawing.Icon myIcon = Icon.FromHandle(m_pIconsSmall[i]);
                Master.imageList1.Images.Add(myIcon);
                Master.debugPictureBox.Image = Master.imageList1.Images[i];
            }


            //IntPtr[] phiconLarge = null;
            //IntPtr[] phiconSmall = null;
            //Console.WriteLine("Number of icons: " + ExtractIconEx("Shell32.dll",-1, phiconLarge, phiconSmall, 1));
            //Console.WriteLine("Icons extracted: " + ExtractIconEx("Shell32.dll", 0, phiconLarge, phiconSmall, 10));
            //System.Drawing.Icon myIcon = Icon.FromHandle(phiconLarge[0]);
            //Console.WriteLine(myIcon.Size.ToString());


            //Master.imageList1.Images.Add(myIcon);
            //Master.debugPictureBox.Image = Master.imageList1.Images[0];

        }

        public override IEnumerable GetChildren(TreePath treePath)
        {
            List<BaseViewItem> items = null;
            if (treePath.IsEmpty())
            {
                if (cache.ContainsKey("__ROOT__"))
                    items = cache["__ROOT__"];
                else
                {
                    items = new List<BaseViewItem>();
                    cache.Add("__ROOT__", items);

                    //Root has poth Progarms and CommonPrograms
                    buildFiles(items, new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms)));
                    buildFiles(items, new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Programs)));

                    if (!_worker.IsBusy)
                        _worker.RunWorkerAsync(Handle);
                }
            }
            else if (treePath.LastNode is FolderViewItem)
            {
                FolderViewItem parent = treePath.LastNode as FolderViewItem;

                if (Win10TileEditor.Properties.Settings.Default.MergeFolderItems)
                {
                    if(cache.ContainsKey(parent.FullName)) // If FullName found return shared name
                        items = cache[parent.Name];
                    else // else build full name and save as shared name
                    {
                        if (cache.ContainsKey(parent.Name)) // add to sahred
                            items = cache[parent.Name];
                        else
                        {
                            items = new List<BaseViewItem>(); // or make new shared
                            cache.Add(parent.Name, items);
                        }
                        
                        buildFiles(items, parent.Directory);

                        if (!_worker.IsBusy)
                            _worker.RunWorkerAsync(Handle);
                    }
                }
                else
                {
                    if (cache.ContainsKey(parent.FullName))
                        return cache[parent.FullName];

                    items = new List<BaseViewItem>();
                    buildFiles(items, parent.Directory);
                    cache.Add(parent.FullName, items);

                    if (!_worker.IsBusy)
                        _worker.RunWorkerAsync(Handle);
                    
                }
            }
            //Thread.Sleep(2000); //emulate time consuming operation
            return items;
        }

        /// <summary>
        /// Fills items with children (dirs and files) of the parent, one level deep
        /// </summary>
        /// <param name="items">The list to add items</param>
        /// <param name="parent"></param>
        private void buildFiles(List<BaseViewItem> items, DirectoryInfo parent)
        {
            Console.WriteLine(parent.FullName);
            foreach (var dir in parent.GetDirectories())
            {
                items.Add(new FolderViewItem(dir));
            }
            foreach (var file in parent.GetFiles("*.lnk"))
            {
                LinkViewItem item = new LinkViewItem(file);
                items.Add(item);
                _linksToReadStack.Push(item);
            }
            foreach (var file in parent.GetFiles("*.url"))
            {
                LinkViewItem item = new LinkViewItem(file);
                items.Add(item);
                _linksToReadStack.Push(item);
            }
        }

        public override bool IsLeaf(TreePath treePath)
        {
            return treePath.LastNode is LinkViewItem;
        }

        public void Dispose()
        {
            this._worker.Dispose();
        }
    }
}
