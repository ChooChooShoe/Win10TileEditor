using System;
using System.Windows.Forms;

namespace Win10TileEditor
{
    static class Program
    {
        public static string[] TileColorOptions { get; } = "black silver gray white maroon red purple fuchsia green lime olive yellow navy blue teal aqua".Split(' ');

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ShellHelp.tezt();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmIconList());

            TileMaker m = new TileMaker();
            Application.Run(new MainForm(m));
            m.onClose();
        }
    }

    public class TileMaker
    {
        public static string[] ProgramLinkFolders = new string[] {
            Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms),
            Environment.GetFolderPath(Environment.SpecialFolder.Programs)
        };

        //public WshShell shell { get; private set; }

        public TileMaker()
        {
            //this.shell = new WshShell();
        }
        
        public void CreateShortcut()
        {
            //object shDesktop = (object)"Desktop";
           // string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Notepad.lnk";
            //IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
           // shortcut.Description = "New shortcut for a Notepad";
            //shortcut.Hotkey = "Ctrl+Shift+N";
            //shortcut.TargetPath = Environment.GetFolderPath(Environment.SpecialFolders.System) + @"\notepad.exe";
          //  shortcut.Save();
        }
        public void updateLink()
        {

            //(ls "C:\Users\Tim\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Heaven's Feel.lnk").lastwritetime = get-date

        }

        [System.Diagnostics.Conditional("DEBUG")]
        internal void onClose()
        {
           Console.Write(Aga.Controls.PerformanceAnalyzer.GenerateReport());
        }
    }
}
