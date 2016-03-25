using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TsudaKageyu;

namespace Win10TileEditor.Dialog
{
    /// <summary>
    /// Interaction logic for PickIconDialog.xaml
    /// </summary>
    public partial class PickIconDialog : Window
    {
        public PickIconModel Model {
            get
            {
                return Resources["PickIconModel"] as PickIconModel;
            }
        }

        public PickIconDialog(string path, int index)
        {
            InitializeComponent();
            Model.IconPath = path;
            Model.IconIndex = index;
            Model.updatePath();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            PickIconModel m = Model;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Icon files|*.ico;*.icl;*.exe;*.dll|Programs|*.exe|Libraries|*.dll|Icons|*.ico|All files|*.*";

            if (String.IsNullOrEmpty(m.IconPath))
                openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            else
            {
                FileInfo info = new FileInfo(Environment.ExpandEnvironmentVariables(m.IconPath));
                openFileDialog.InitialDirectory = info.DirectoryName;
                openFileDialog.FileName = info.Name;
            }

            if (openFileDialog.ShowDialog() == true)
            {
                m.IconPath = openFileDialog.FileName;
                m.updatePath();
            }
        }

        private void TextIconPath_LostFocus(object sender, RoutedEventArgs e)
        {
            Model.updatePath();
        }

        private void IconInFileView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.IconSizes.Clear();
            if (e.AddedItems.Count == 0)
                return;
            Icon sel = e.AddedItems[0] as Icon;
            if(sel != null)
            {
                this.Cursor = Cursors.Wait;

                foreach (Icon i in sel.Split())
                {
                    Model.IconSizes.Add(i);
                }
                this.Cursor = Cursors.Arrow;
            }
        }

        private void IconSizeView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
