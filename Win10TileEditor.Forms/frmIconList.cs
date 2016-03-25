using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TAFactory.IconPack;
using System.IO;

namespace Win10TileEditor
{
    public partial class frmIconList : Form
    {
        #region Variables
        private Icon folderIcon = null;
        #endregion

        #region Constructor
        public frmIconList()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void frmIconList_Load(object sender, EventArgs e)
        {
            folderIcon = IconHelper.ExtractBestFitIcon(@"%SystemRoot%\system32\shell32.dll", 4, SystemInformation.SmallIconSize);
            AddMergeNode();
            iconList.TileSize = new Size(64, 64);
            AdjustView(64);
            UpdateTreeStatus();
            UpdateListStatus();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (diagSelectLibrary.ShowDialog(this) == DialogResult.OK)
            {
                this.Refresh();
                this.Cursor = Cursors.WaitCursor;
                //if(LoadIconFromLibrary(diagSelectLibrary.FileName))
                //    txtFileName.Text = diagSelectLibrary.FileName;
                this.Cursor = Cursors.Arrow;
            }
        }
        private void treeIcons_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Icon icon = (Icon)e.Node.Tag;
            FillBestFitIcons(icon);
            FillIconListView(icon);
            UpdateTreeStatus();
        }
        private void treeIcons_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeIcons.SelectedNode != e.Node)
                treeIcons.SelectedNode = e.Node;
        }
        private void iconList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListStatus();
        }
        private void tlbarMainOpen_Click(object sender, EventArgs e)
        {
            if (diagSelectLibrary.ShowDialog(this) == DialogResult.OK)
            {
                this.Refresh();
                this.Cursor = Cursors.WaitCursor;
                LoadIconFromLibrary(diagSelectLibrary.FileName);
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion

        #region Methods
        private TreeNode mergeNode = null;
        private void AddMergeNode()
        {
            ilTree.Images.Clear();
            ilTree.Images.Add(folderIcon);

            treeIcons.Nodes.Clear();

            mergeNode = treeIcons.Nodes.Add("MergedIcons", "Merged Icons", 0, 0);
            mergeNode.Tag = null;
        }
        private TreeNode AddFileNode(string fileName, bool addNode)
        {
            FileInfo info = new FileInfo(fileName);
            if (treeIcons.Nodes.ContainsKey(info.FullName.ToLower()))
                return treeIcons.Nodes[info.FullName.ToLower()];

            if (addNode)
            {
                TreeNode node = treeIcons.Nodes.Add(info.FullName.ToLower(), info.Name, 0, 0);
                node.Tag = null;
                return node;
            }
            return null;
        }
        private bool LoadIconFromLibrary(string fileName)
        {
            TreeNode fileNode = AddFileNode(fileName, false);
            if (fileNode != null)
            {
                treeIcons.SelectedNode = fileNode;
                fileNode.ExpandAll();
                treeIcons.Focus();
                return true;
            }

            List<Icon> extractedIcons;
            try { extractedIcons = IconHelper.ExtractAllIcons(fileName); }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message, "Icon Extractor");
                return false;
            }
            this.Refresh();
            fileNode = AddFileNode(fileName, true);
            for (int i = 0; i < extractedIcons.Count; i++)
            {
                int iconIndex = ilTree.Images.Count;
                ilTree.Images.Add(i.ToString(), IconHelper.GetBestFitIcon(extractedIcons[i], SystemInformation.SmallIconSize));
                TreeNode node = fileNode.Nodes.Add(i.ToString(), "Icon #" + i.ToString(), iconIndex, iconIndex);
                node.Tag = extractedIcons[i];
            }
            fileNode.ExpandAll();
            treeIcons.Focus();
            treeIcons.SelectedNode = fileNode;
            return true;
        }
        private void FillIconListView(Icon icon)
        {
            iconList.Items.Clear();
            if (icon == null)
                return;
            List<Icon> l = IconHelper.SplitGroupIcon(icon);
            foreach (Icon icn in l)
            {
                IconListViewItem item = new IconListViewItem();
                item.Name = iconList.Items.Count.ToString().PadLeft(5, '0');
                item.Icon = icn;
                iconList.Items.Add(item);
            }
        }
        private void FillBestFitIcons(Icon icon)
        {
            if (icon == null)
            {
                pic32.Image = null;
                pic64.Image = null;
                pic96.Image = null;
                pic128.Image = null;
                pic256.Image = null;
            }
            else
            {
                string sizeFormat = "{0} x {1}";
                Icon icn = IconHelper.GetBestFitIcon(icon, new Size(256, 256));
                pic256.Image = icn.ToBitmap();
                lbl64.Text = string.Format(sizeFormat, icn.Width, icn.Height);

                icn = IconHelper.GetBestFitIcon(icon, new Size(128, 128));
                pic128.Image = icn.ToBitmap();
                lbl48.Text = string.Format(sizeFormat, icn.Width, icn.Height);

                icn = IconHelper.GetBestFitIcon(icon, new Size(96, 96));
                pic96.Image = icn.ToBitmap();
                lbl32.Text = string.Format(sizeFormat, icn.Width, icn.Height);

                icn = IconHelper.GetBestFitIcon(icon, new Size(64, 64));
                pic64.Image = icn.ToBitmap();
                lbl24.Text = string.Format(sizeFormat, icn.Width, icn.Height);

                icn = IconHelper.GetBestFitIcon(icon, new Size(32, 32));
                pic32.Image = icn.ToBitmap();
                lbl16.Text = string.Format(sizeFormat, icn.Width, icn.Height);
            }
        }
        private TreeNode AddMergedIcon(Icon icon)
        {
            int iconIndex = ilTree.Images.Count;
            string key = Guid.NewGuid().ToString();
            ilTree.Images.Add(key, IconHelper.GetBestFitIcon(icon, SystemInformation.SmallIconSize));
            TreeNode node = mergeNode.Nodes.Add("Merged Icon #" + mergeNode.Nodes.Count.ToString());
            node.ImageKey = key;
            node.SelectedImageKey = key;
            node.Tag = icon;
            return node;
        }
        private void MergeIcons(params Icon[] iconList)
        {
            if (iconList.Length == 0)
                return;
            
            Icon icon = IconHelper.Merge(iconList);
            
            TreeNode node = AddMergedIcon(icon);
            treeIcons.SelectedNode = node;
            treeIcons.Focus();
        }
        private void SaveIcon(Icon icon)
        {
            if (diagSaveIcon.ShowDialog(this) == DialogResult.OK)
            {
                FileStream fs = File.Create(diagSaveIcon.FileName);
                icon.Save(fs);
                fs.Close();
            }
        }
        private void AdjustView(int width)
        {

            mnuIconListView16.Checked = (width == 16);
            mnuIconListView24.Checked = (width == 24);
            mnuIconListView32.Checked = (width == 32);
            mnuIconListView48.Checked = (width == 48);
            mnuIconListView64.Checked = (width == 64);
            mnuIconListView96.Checked = (width == 96);

            tlbarMainView16.Checked = (width == 16);
            tlbarMainView24.Checked = (width == 24);
            tlbarMainView32.Checked = (width == 32);
            tlbarMainView48.Checked = (width == 48);
            tlbarMainView64.Checked = (width == 64);
            tlbarMainView96.Checked = (width == 96);
        }
        private void ShowIconProperties(Icon icon)
        {
            IconInfo info = new IconInfo(icon);
            string format = "Width: {0}\nHeight: {1}\nBit Count: {2}\nColor Depth: {3}\nColor Count: {4}\n# Of Images: {5}\n";
            string message = string.Format(format, info.Width, info.Height, info.BitCount, info.ColorDepth, info.ColorCount, info.Images.Count);
            MessageBox.Show(this, message, "Icon Properties");
        }
        private void UpdateTreeStatus()
        {
            TreeNode selected = treeIcons.SelectedNode;
            if (selected == null)
            {
                lblTreeStatus.Text = "No files was selected.";
                UpdateListStatus();
                return;
            }

            if (selected.Level == 0)
                lblTreeStatus.Text = string.Format("{0} Icon(s) In {1}.", selected.Nodes.Count, selected.Text);
            else
                lblTreeStatus.Text = string.Format("{0} Contais {1} icon(s).", selected.Text, iconList.Items.Count);
            UpdateListStatus();
        }
        private void UpdateListStatus()
        {
            if (iconList.SelectedIndices.Count == 0)
            {
                if (treeIcons.SelectedNode != null && treeIcons.SelectedNode.Level > 0)
                    lblListStatus.Text = string.Format("{0} icon(s) found.", iconList.Items.Count);
                else
                    lblListStatus.Text = "";
            }
            else
            {
                if (iconList.SelectedIndices.Count > 1)
                {
                    lblListStatus.Text = "More than one icon selected.";
                }
                else
                {
                    IconListViewItem item = iconList.SelectedItems[0] as IconListViewItem;
                    if (item == null)
                        lblListStatus.Text = "No information about selected item.";
                    else
                    {
                        IconInfo info = new IconInfo(item.Icon);
                        lblListStatus.Text = string.Format("({0}): {1} x {2}, {3}bpp.", item.Index, info.Width, info.Height, info.ColorDepth);
                    }
                }
            }
        }
        #endregion

        #region Tree Menu Events
        private void cntxtTree_Opening(object sender, CancelEventArgs e)
        {
            Icon icon = (Icon)treeIcons.SelectedNode.Tag;
            e.Cancel = (icon == null);
        }
        private void mnuTreeSaveAs_Click(object sender, EventArgs e)
        {
            Icon icon = (Icon)treeIcons.SelectedNode.Tag;
            if (icon != null)
                SaveIcon(icon);
        }
        private void mnuTreeProperties_Click(object sender, EventArgs e)
        {
            Icon icon = (Icon)treeIcons.SelectedNode.Tag;
            if (icon != null)
                ShowIconProperties(icon);
        }
        #endregion

        #region Icon List Menu Events
        private void cntxtIconList_Opening(object sender, CancelEventArgs e)
        {
            IconListViewItem item = null;
            if (iconList.SelectedIndices.Count == 1)
                item = iconList.SelectedItems[0] as IconListViewItem;
            mnuIconListSaveAs.Enabled = (item != null);
            mnuIconListProperties.Enabled = (item != null);
            mnuIconListMerge.Enabled = (iconList.SelectedIndices.Count > 1);
        }
        private void mnuIconListSaveAs_Click(object sender, EventArgs e)
        {
            IconListViewItem item = iconList.SelectedItems[0] as IconListViewItem;
            if (item != null)
                SaveIcon(item.Icon);
        }
        private void mnuIconListView16_Click(object sender, EventArgs e)
        {
            iconList.TileSize = new Size(16, 16);
            AdjustView(16);
        }
        private void mnuIconListView24_Click(object sender, EventArgs e)
        {
            iconList.TileSize = new Size(24, 24);
            AdjustView(24);
        }
        private void mnuIconListView32_Click(object sender, EventArgs e)
        {
            iconList.TileSize = new Size(32, 32);
            AdjustView(32);
        }
        private void mnuIconListView48_Click(object sender, EventArgs e)
        {
            iconList.TileSize = new Size(48, 48);
            AdjustView(48);
        }
        private void mnuIconListView64_Click(object sender, EventArgs e)
        {
            iconList.TileSize = new Size(64, 64);
            AdjustView(64);
        }
        private void mnuIconListView96_Click(object sender, EventArgs e)
        {
            iconList.TileSize = new Size(96, 96);
            AdjustView(96);
        }
        private void mnuIconListProperties_Click(object sender, EventArgs e)
        {
            IconListViewItem item = iconList.SelectedItems[0] as IconListViewItem;
            if (item != null)
                ShowIconProperties(item.Icon);
        }
        private void mnuIconListMerge_Click(object sender, EventArgs e)
        {
            if (iconList.SelectedIndices.Count < 2)
                return;
            List<Icon> list = new List<Icon>();
            foreach (IconListViewItem item in iconList.SelectedItems)
            {
                if (item.Icon != null)
                    list.Add(item.Icon);
            }
            if (list.Count < 2)
                return;
            MergeIcons(list.ToArray());
        }
        #endregion
    }
}