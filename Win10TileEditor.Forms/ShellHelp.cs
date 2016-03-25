using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Win10TileEditor
{
    public static class ShellHelp
    {
        const UInt32 BCM_SETSHIELD = 0x160C;

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, IntPtr lParam);

        public static void addElevateToControl(IntPtr handle)
        {

            SendMessage(handle, BCM_SETSHIELD, 0, (IntPtr)1);
        }


        [DllImport("shell32.dll")]
        [Obsolete]
        static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

        [DllImport("shell32.dll")]
        [Obsolete]
        static extern IntPtr ExtractAssociatedIcon(IntPtr hInst, StringBuilder lpIconPath, out ushort lpiIcon);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        [Obsolete]
        static extern uint ExtractIconEx(string szFileName, int nIconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, uint nIcons);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [Obsolete]
        static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);


        [DllImport("shell32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool SHObjectProperties(IntPtr hwnd, uint shopObjectType, string pszObjectName, string pszPropertyPage);

        public static bool ShowPropertiesDialog(IntPtr handle, string filename)
        {
            try
            {
                return SHObjectProperties(handle, SHOP_FILEPATH, filename, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        
        [DllImport("shell32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        static extern IntPtr ExtractIcon(IntPtr hInstance, string strFileName, uint uiIconIndex);

        public static Icon extractIcon(string strPath, int nIndex)
        {
            return extractIcon(IntPtr.Zero, strPath, nIndex);
        }

        public static Icon extractIcon(IntPtr handle, string strPath, int nIndex)
        {
            Icon icon = null;
            IntPtr hIcon = ExtractIcon(handle, strPath, (uint)nIndex);
            if (IntPtr.Zero != hIcon)
            {
                icon = Icon.FromHandle(hIcon);
            }
            return icon;
        }



        [DllImport("shell32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        static extern int PickIconDlg(IntPtr hwndOwner, System.Text.StringBuilder lpstrFile, int nMaxFile, ref int lpdwIconIndex);


        public static bool ShowPickIconDialog(IntPtr handle, StringBuilder filename, ref int iconindex)
        {
            try
            {
                return PickIconDlg(handle, filename, filename.Capacity, ref iconindex) == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public static bool ShowPickIconDialog(IntPtr handle, ref string filename, ref int iconindex)
        {
            StringBuilder sb = new StringBuilder(filename, MAX_PATH);
            bool res = ShowPickIconDialog(handle, sb, ref iconindex);
            filename = sb.ToString();
            return res;
        }

        /// <summary>
        /// The maximum length of a filename
        /// </summary>
        public const int MAX_PATH = 260;

        [Obsolete]
        public static bool ShowPickIconDialog(IntPtr handle, string filename)
        {
            string iconfile;
            int iconindex = 2;
            System.Text.StringBuilder sb;

            iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System);
            iconfile = iconfile + @"\shell32.dll";
            sb = new System.Text.StringBuilder(iconfile, MAX_PATH);
            try
            {
                Console.WriteLine("PickIconDlg started: '{0}' at '{1}' with index '{2}'", sb.ToString(), iconfile, iconindex);
                int i = PickIconDlg(handle, sb, MAX_PATH, ref iconindex);
                Console.WriteLine("PickIconDlg ended: '{0}' at '{1}' with index '{2}'",sb.ToString(), iconfile, iconindex);
                return i == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        [DllImport("shell32.dll", EntryPoint = "#62", CharSet = CharSet.Unicode, SetLastError = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool SHPickIconDialog(IntPtr hWnd, StringBuilder pszFilename, int cchFilenameMax, out int pnIconIndex);

        

        public static uint SHOP_PRINTERNAME = 0x1;  // lpObject points to a printer friendly name
        public static uint SHOP_FILEPATH = 0x2;  // lpObject points to a fully qualified path+file name
        public static uint SHOP_VOLUMEGUID = 0x4;  // lpObject points to a Volume GUID
        
            public static void tezt()
        {


            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object

            //IWshRuntimeLibrary.WshShell c = new IWshRuntimeLibrary.WshShell();

            dynamic shell = Activator.CreateInstance(t);

            var sf = shell.SpecialFolders("Programs");
            Console.WriteLine(sf);
            sf = shell.SpecialFolders("AllUsersPrograms");
            Console.WriteLine(sf);
            

            var shortcut = shell.CreateShortcut(@"C:\Games\templnk.lnk");


            var urlshortcut = shell.CreateShortcut(@"C:\Games\tempurl.url");

            urlshortcut.TargetPath = "http://www.microsoft.com";
            //urlshortcut.Hotkey = "Shift+N";
            //shortcut.IconLocation = ",2";
            urlshortcut.save();


            shortcut.Arguments = "args";
            shortcut.Description = "ME DISC";
           // shortcut.FullName = "FULLNAME";
            shortcut.Hotkey = "Shift+N";
            shortcut.IconLocation = ",0";
            shortcut.RelativePath = "c:\\";
            shortcut.TargetPath = "Games";
            shortcut.WindowStyle = 3;
            shortcut.WorkingDirectory = "c:\\Deverloper\\";

            shortcut.save();


        }

        public static dynamic createWshShell()
        {
            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
            return Activator.CreateInstance(t);
        }

    }
    public class WshShortcut
    {
        public static int NORMAL_WINDOW = 1;
        public static int MIN_WINDOW = 7;
        public static int MAX_WINDOW = 3;

        public enum WindowStyles { NORMAL_WINDOW = 1, MAX_WINDOW = 3, MIN_WINDOW = 7, UNKNOWN = 0 }
        private dynamic shortcut;

        [Obsolete]
        public bool IsURL { get; private set; }
        public string Arguments
        {
            set
            {
                shortcut.Arguments = value;
            }
            get
            {
                return shortcut.Arguments;
            }
        }
        public string Description { get { return shortcut.Description; } }
        public string FullName { get { return shortcut.FullName; } }
        public string Hotkey { get { return shortcut.Hotkey; } }
        public string IconLocation { get { return shortcut.IconLocation; } }
        public string RelativePath { get { return shortcut.RelativePath; } }
        public string TargetPath { get { return shortcut.TargetPath; } }
        public WindowStyles WindowStyle
        {
            get
            {
                switch ((int)shortcut.WindowStyle)
                {
                    case 1:
                        return WindowStyles.NORMAL_WINDOW;
                    case 3:
                        return WindowStyles.MAX_WINDOW;
                    case 7:
                        return WindowStyles.MIN_WINDOW;
                    default:
                        return WindowStyles.UNKNOWN;
                }

            }
        }
        public string WorkingDirectory { get { return shortcut.WorkingDirectory; } }

        public WshShortcut(dynamic data)
        {
            this.shortcut = data;
            //IsURL = false;
        }
    }
}
