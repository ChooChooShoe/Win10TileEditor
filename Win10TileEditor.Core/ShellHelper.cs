using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Win10TileEditor.Core
{
    public static class ShellHelper
    {
        [DllImport("shell32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool SHObjectProperties(IntPtr hwnd, uint shopObjectType, string pszObjectName, string pszPropertyPage);
        
        public static uint SHOP_PRINTERNAME = 0x1;  // lpObject points to a printer friendly name
        public static uint SHOP_FILEPATH = 0x2;  // lpObject points to a fully qualified path+file name
        public static uint SHOP_VOLUMEGUID = 0x4;  // lpObject points to a Volume GUID

        public static bool ShowPropertiesDialog(IntPtr handle, string filename)
        {
            try
            {
                return SHObjectProperties(handle, SHOP_FILEPATH, filename, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static dynamic createWshShell()
        {
            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
            return Activator.CreateInstance(t);
        }

        /*
        public static void ReadFilesProperties(object sender)
        {
            dynamic shell = ShellHelper.createWshShell();
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
                    //_worker.ReportProgress(0, item);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }

        }*/

        public static ImageSource GetIcon(string path, bool smallIcon, bool isDirectory)
        {
            // SHGFI_USEFILEATTRIBUTES takes the file name and attributes into account if it doesn't exist
            uint flags = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES;
            if (smallIcon)
                flags |= SHGFI_SMALLICON;

            uint attributes = FILE_ATTRIBUTE_NORMAL;
            if (isDirectory)
                attributes |= FILE_ATTRIBUTE_DIRECTORY;

            SHFILEINFO shfi;
            if (0 != SHGetFileInfo(path, attributes, out shfi, (uint)Marshal.SizeOf(typeof(SHFILEINFO)), flags))
            {
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(shfi.hIcon, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            return null;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [DllImport("shell32")]
        private static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, uint flags);

        private const uint FILE_ATTRIBUTE_READONLY = 0x00000001;
        private const uint FILE_ATTRIBUTE_HIDDEN = 0x00000002;
        private const uint FILE_ATTRIBUTE_SYSTEM = 0x00000004;
        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        private const uint FILE_ATTRIBUTE_ARCHIVE = 0x00000020;
        private const uint FILE_ATTRIBUTE_DEVICE = 0x00000040;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        private const uint FILE_ATTRIBUTE_TEMPORARY = 0x00000100;
        private const uint FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200;
        private const uint FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400;
        private const uint FILE_ATTRIBUTE_COMPRESSED = 0x00000800;
        private const uint FILE_ATTRIBUTE_OFFLINE = 0x00001000;
        private const uint FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000;
        private const uint FILE_ATTRIBUTE_ENCRYPTED = 0x00004000;
        private const uint FILE_ATTRIBUTE_VIRTUAL = 0x00010000;

        private const uint SHGFI_ICON = 0x000000100;     // get icon
        private const uint SHGFI_DISPLAYNAME = 0x000000200;     // get display name
        private const uint SHGFI_TYPENAME = 0x000000400;     // get type name
        private const uint SHGFI_ATTRIBUTES = 0x000000800;     // get attributes
        private const uint SHGFI_ICONLOCATION = 0x000001000;     // get icon location
        private const uint SHGFI_EXETYPE = 0x000002000;     // return exe type
        private const uint SHGFI_SYSICONINDEX = 0x000004000;     // get system icon index
        private const uint SHGFI_LINKOVERLAY = 0x000008000;     // put a link overlay on icon
        private const uint SHGFI_SELECTED = 0x000010000;     // show icon in selected state
        private const uint SHGFI_ATTR_SPECIFIED = 0x000020000;     // get only specified attributes
        private const uint SHGFI_LARGEICON = 0x000000000;     // get large icon
        private const uint SHGFI_SMALLICON = 0x000000001;     // get small icon
        private const uint SHGFI_OPENICON = 0x000000002;     // get open icon
        private const uint SHGFI_SHELLICONSIZE = 0x000000004;     // get shell size icon
        private const uint SHGFI_PIDL = 0x000000008;     // pszPath is a pidl
        private const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;     // use passed dwFileAttribute
    }
}