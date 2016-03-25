using System;
using System.ComponentModel;
using System.Windows.Forms;

using Aga.Controls.Tree.NodeControls;
using Aga.Controls.Tree;

namespace Win10TileEditor
{
	public partial class FolderBrowser : UserControl
	{
		private class ToolTipProvider: IToolTipProvider
		{
			public string GetToolTip(TreeNodeAdv node, NodeControl nodeControl)
			{
					return "I need to make tool tips";
			}
		}

        public TreeViewAdv TreeView { get { return treeView; } private set { treeView = value;  } }

        public FolderBrowser()
		{
			InitializeComponent();

            //cboxGrid.DataSource = System.Enum.GetValues(typeof(GridLineStyle));
            //cboxGrid.SelectedItem = GridLineStyle.HorizontalAndVertical;

            //cbLines.Checked = _treeView.ShowLines;

            SortedTreeModel model = new SortedTreeModel(new LinkBrowserModel(this));
            this.treeView.Model = model;

            TreeColumn clicked = this.treeView.Columns[0];
            clicked.SortOrder = SortOrder.Ascending;
            model.Comparer = new FolderItemSorter(clicked.Header, clicked.SortOrder);
            
            //nodeControlName.ToolTipProvider = new ToolTipProvider();


            //nodeControlName.EditorShowing += new CancelEventHandler(_name_EditorShowing);

        }

		void _name_EditorShowing(object sender, CancelEventArgs e)
		{
            //TODO Edior
				e.Cancel = true;
		}

		private void _treeView_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				NodeControlInfo info = treeView.GetNodeControlInfoAt(e.Location);
                
			}
		}

		private void _treeView_ColumnClicked(object sender, TreeColumnEventArgs e)
		{
            TreeColumn clicked = e.Column;
            if (clicked.SortOrder == SortOrder.Ascending)
                clicked.SortOrder = SortOrder.Descending;
            else
                clicked.SortOrder = SortOrder.Ascending;

            (treeView.Model as SortedTreeModel).Comparer = new FolderItemSorter(clicked.Header, clicked.SortOrder);
		}
        
		private void _treeView_NodeMouseClick(object sender, TreeNodeAdvMouseEventArgs e)
        {
            if (e.Node.Tag is LinkViewItem)
            {
                LinkViewItem item = (LinkViewItem)e.Node.Tag;
                ((MainForm)this.ParentForm).loadItemData(item);
            }
            else if (e.Node.Tag is FolderViewItem)
            {
                if(e.Control is NodeTextBox || e.Control is TreeItemNodeIcon)
                {
                    if (e.Node.CanExpand)
                        e.Node.IsExpanded = !e.Node.IsExpanded;
                    e.Handled = true;
                }
            }
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeAdvMouseEventArgs e)
        {
            e.Handled = true;
        }
        private void _treeView_SelectionChanged(object sender, EventArgs e)
        {
            
        }
        private int index = 0;

        private void debugPictureBox_Click(object sender, EventArgs e)
        {
            this.debugPictureBox.Image = this.imageList1.Images[index++];
            debugPictureBox.Size = new System.Drawing.Size(64, 64);
        }

        private void openPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string filename = ((BaseViewItem)this.treeView.SelectedNode.Tag).FullName;
            ShellHelp.ShowPropertiesDialog(Handle,filename);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented");
        }

        private void editIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = ((BaseViewItem)this.treeView.SelectedNode.Tag).TargetPath;
            int index = 0;
            ShellHelp.ShowPickIconDialog(Handle,ref path, ref index);
        }

        private void TargetPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.treeView.SelectedNode != null)
            {
                string filename = ((BaseViewItem)this.treeView.SelectedNode.Tag).TargetPath;
                if (filename != null && filename.Length != 0)
                    ShellHelp.ShowPropertiesDialog(Handle, filename);
                else
                    MessageBox.Show("No Target found.", "Target Properties", MessageBoxButtons.OK);
            }
        }
    }
}
