using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Win10TileEditor.Core
{
    static class IconHelper
    {
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
                return Imaging.CreateBitmapSourceFromHIcon(shfi.hIcon, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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

        /// <summary>  get icon </summary>
        private const uint SHGFI_ICON = 0x000000100;

        /// <summary> get display name </summary>
        private const uint SHGFI_DISPLAYNAME = 0x000000200;

        /// <summary> get type name </summary>
        private const uint SHGFI_TYPENAME = 0x000000400;

        /// <summary>  get attributes </summary>
        private const uint SHGFI_ATTRIBUTES = 0x000000800;

        /// <summary> get icon location </summary>
        private const uint SHGFI_ICONLOCATION = 0x000001000;

        /// <summary> return exe type </summary>
        private const uint SHGFI_EXETYPE = 0x000002000;

        /// <summary> get system icon index </summary>
        private const uint SHGFI_SYSICONINDEX = 0x000004000;

        /// <summary> put a link overlay on icon </summary>
        private const uint SHGFI_LINKOVERLAY = 0x000008000;

        /// <summary> show icon in selected state </summary>
        private const uint SHGFI_SELECTED = 0x000010000;

        /// <summary> get only specified attributes </summary>
        private const uint SHGFI_ATTR_SPECIFIED = 0x000020000;

        /// <summary> get large icon </summary>
        private const uint SHGFI_LARGEICON = 0x000000000;

        /// <summary> get small icon </summary>
        private const uint SHGFI_SMALLICON = 0x000000001;

        /// <summary> get open icon </summary>
        private const uint SHGFI_OPENICON = 0x000000002;

        /// <summary> get shell size icon </summary>
        private const uint SHGFI_SHELLICONSIZE = 0x000000004;

        /// <summary> pszPath is a pidl </summary>
        private const uint SHGFI_PIDL = 0x000000008;

        /// <summary> use passed dwFileAttribute </summary>
        private const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
    }
}
