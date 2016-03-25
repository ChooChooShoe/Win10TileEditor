using Aga.Controls.Tree;

namespace Win10TileEditor
{
    partial class FolderBrowser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView = new Aga.Controls.Tree.TreeViewAdv();
            this.tcName = new Aga.Controls.Tree.TreeColumn();
            this.tcTarget = new Aga.Controls.Tree.TreeColumn();
            this.tcDate = new Aga.Controls.Tree.TreeColumn();
            this.contextMenuStripTreeItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TargetPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeControlIcon = new Win10TileEditor.TreeItemNodeIcon();
            this.nodeControlName = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.nodeControlTarget = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.nodeControlDate = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.debugPictureBox = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripTreeItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debugPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.AllowColumnReorder = true;
            this.treeView.BackColor = System.Drawing.SystemColors.Window;
            this.treeView.Columns.Add(this.tcName);
            this.treeView.Columns.Add(this.tcTarget);
            this.treeView.Columns.Add(this.tcDate);
            this.treeView.ContextMenuStrip = this.contextMenuStripTreeItem;
            this.treeView.DefaultToolTipProvider = null;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.DragDropMarkColor = System.Drawing.Color.Black;
            this.treeView.FullRowSelect = true;
            this.treeView.FullRowSelectActiveColor = System.Drawing.SystemColors.Highlight;
            this.treeView.FullRowSelectInactiveColor = System.Drawing.SystemColors.InactiveCaption;
            this.treeView.GridLineStyle = Aga.Controls.Tree.GridLineStyle.Horizontal;
            this.treeView.LineColor = System.Drawing.SystemColors.ControlDark;
            this.treeView.LoadOnDemand = true;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Model = null;
            this.treeView.Name = "treeView";
            this.treeView.NodeControls.Add(this.nodeControlIcon);
            this.treeView.NodeControls.Add(this.nodeControlName);
            this.treeView.NodeControls.Add(this.nodeControlTarget);
            this.treeView.NodeControls.Add(this.nodeControlDate);
            this.treeView.NodeFilter = null;
            this.treeView.SelectedNode = null;
            this.treeView.Size = new System.Drawing.Size(760, 327);
            this.treeView.TabIndex = 0;
            this.treeView.UseColumns = true;
            this.treeView.NodeMouseClick += new System.EventHandler<Aga.Controls.Tree.TreeNodeAdvMouseEventArgs>(this._treeView_NodeMouseClick);
            this.treeView.NodeMouseDoubleClick += new System.EventHandler<Aga.Controls.Tree.TreeNodeAdvMouseEventArgs>(this.treeView_NodeMouseDoubleClick);
            this.treeView.ColumnClicked += new System.EventHandler<Aga.Controls.Tree.TreeColumnEventArgs>(this._treeView_ColumnClicked);
            this.treeView.SelectionChanged += new System.EventHandler(this._treeView_SelectionChanged);
            this.treeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this._treeView_MouseClick);
            // 
            // tcName
            // 
            this.tcName.Header = "Name";
            this.tcName.MinColumnWidth = 20;
            this.tcName.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tcName.TooltipText = "File name";
            this.tcName.Width = 250;
            // 
            // tcTarget
            // 
            this.tcTarget.Header = "Target";
            this.tcTarget.MinColumnWidth = 20;
            this.tcTarget.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tcTarget.TooltipText = "Link\'s Targeted File";
            this.tcTarget.Width = 410;
            // 
            // tcDate
            // 
            this.tcDate.Header = "Date";
            this.tcDate.MinColumnWidth = 20;
            this.tcDate.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tcDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tcDate.TooltipText = "File date";
            this.tcDate.Width = 70;
            // 
            // contextMenuStripTreeItem
            // 
            this.contextMenuStripTreeItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editIconToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.toolStripSeparator1,
            this.openPropertiesToolStripMenuItem,
            this.TargetPropertiesToolStripMenuItem});
            this.contextMenuStripTreeItem.Name = "contextMenuStrip1";
            this.contextMenuStripTreeItem.Size = new System.Drawing.Size(164, 148);
            // 
            // editIconToolStripMenuItem
            // 
            this.editIconToolStripMenuItem.Name = "editIconToolStripMenuItem";
            this.editIconToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.editIconToolStripMenuItem.Text = "Edit Icon";
            this.editIconToolStripMenuItem.Click += new System.EventHandler(this.editIconToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // openPropertiesToolStripMenuItem
            // 
            this.openPropertiesToolStripMenuItem.Name = "openPropertiesToolStripMenuItem";
            this.openPropertiesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openPropertiesToolStripMenuItem.Text = "Properties";
            this.openPropertiesToolStripMenuItem.Click += new System.EventHandler(this.openPropertiesToolStripMenuItem_Click);
            // 
            // TargetPropertiesToolStripMenuItem
            // 
            this.TargetPropertiesToolStripMenuItem.Name = "TargetPropertiesToolStripMenuItem";
            this.TargetPropertiesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.TargetPropertiesToolStripMenuItem.Text = "Target Properties";
            this.TargetPropertiesToolStripMenuItem.Click += new System.EventHandler(this.TargetPropertiesToolStripMenuItem_Click);
            // 
            // nodeControlIcon
            // 
            this.nodeControlIcon.DataPropertyName = "Icon";
            this.nodeControlIcon.LeftMargin = 1;
            this.nodeControlIcon.ParentColumn = this.tcName;
            this.nodeControlIcon.ScaleMode = Aga.Controls.Tree.ImageScaleMode.Clip;
            // 
            // nodeControlName
            // 
            this.nodeControlName.DataPropertyName = "Name";
            this.nodeControlName.IncrementalSearchEnabled = true;
            this.nodeControlName.LeftMargin = 3;
            this.nodeControlName.ParentColumn = this.tcName;
            this.nodeControlName.Trimming = System.Drawing.StringTrimming.Character;
            this.nodeControlName.UseCompatibleTextRendering = true;
            // 
            // nodeControlTarget
            // 
            this.nodeControlTarget.DataPropertyName = "TargetPath";
            this.nodeControlTarget.IncrementalSearchEnabled = true;
            this.nodeControlTarget.LeftMargin = 3;
            this.nodeControlTarget.ParentColumn = this.tcTarget;
            // 
            // nodeControlDate
            // 
            this.nodeControlDate.DataPropertyName = "Date";
            this.nodeControlDate.IncrementalSearchEnabled = true;
            this.nodeControlDate.LeftMargin = 3;
            this.nodeControlDate.ParentColumn = this.tcDate;
            this.nodeControlDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // debugPictureBox
            // 
            this.debugPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debugPictureBox.Image = global::Win10TileEditor.Properties.Resources.folder_classic;
            this.debugPictureBox.Location = new System.Drawing.Point(528, 99);
            this.debugPictureBox.Name = "debugPictureBox";
            this.debugPictureBox.Size = new System.Drawing.Size(216, 199);
            this.debugPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.debugPictureBox.TabIndex = 1;
            this.debugPictureBox.TabStop = false;
            this.debugPictureBox.Click += new System.EventHandler(this.debugPictureBox_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FolderBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.debugPictureBox);
            this.Controls.Add(this.treeView);
            this.Name = "FolderBrowser";
            this.Size = new System.Drawing.Size(760, 327);
            this.contextMenuStripTreeItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.debugPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TreeItemNodeIcon nodeControlIcon;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeControlName;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeControlTarget;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeControlDate;
        private TreeColumn tcName;
        private TreeColumn tcTarget;
        private TreeColumn tcDate;
        private TreeViewAdv treeView;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.PictureBox debugPictureBox;
        private System.Windows.Forms.ToolStripMenuItem editIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTreeItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem openPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TargetPropertiesToolStripMenuItem;
    }
}
