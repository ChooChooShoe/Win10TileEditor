namespace Win10TileEditor
{
    partial class frmIconList
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIconList));
            this.label2 = new System.Windows.Forms.Label();
            this.treeIcons = new System.Windows.Forms.TreeView();
            this.cntxtTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuTreeSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTreeProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.ilTree = new System.Windows.Forms.ImageList(this.components);
            this.diagSelectLibrary = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl16 = new System.Windows.Forms.Label();
            this.lbl24 = new System.Windows.Forms.Label();
            this.lbl32 = new System.Windows.Forms.Label();
            this.lbl48 = new System.Windows.Forms.Label();
            this.lbl64 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pic32 = new System.Windows.Forms.PictureBox();
            this.pic64 = new System.Windows.Forms.PictureBox();
            this.pic96 = new System.Windows.Forms.PictureBox();
            this.pic128 = new System.Windows.Forms.PictureBox();
            this.pic256 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cntxtIconList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuIconListSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIconListMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mmnuIconListView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIconListView16 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIconListView24 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIconListView32 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIconListView48 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIconListView64 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIconListView96 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuIconListProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.diagSaveIcon = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTreeStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblListStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbarMain = new System.Windows.Forms.ToolStrip();
            this.tlbarMainOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbarMainView = new System.Windows.Forms.ToolStripDropDownButton();
            this.tlbarMainView16 = new System.Windows.Forms.ToolStripMenuItem();
            this.tlbarMainView24 = new System.Windows.Forms.ToolStripMenuItem();
            this.tlbarMainView32 = new System.Windows.Forms.ToolStripMenuItem();
            this.tlbarMainView48 = new System.Windows.Forms.ToolStripMenuItem();
            this.tlbarMainView64 = new System.Windows.Forms.ToolStripMenuItem();
            this.tlbarMainView96 = new System.Windows.Forms.ToolStripMenuItem();
            this.iconList = new TAFactory.IconPack.IconListView();
            this.cntxtTree.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic96)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic256)).BeginInit();
            this.cntxtIconList.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tlbarMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Icons List:";
            // 
            // treeIcons
            // 
            this.treeIcons.AllowDrop = true;
            this.treeIcons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeIcons.ContextMenuStrip = this.cntxtTree;
            this.treeIcons.HideSelection = false;
            this.treeIcons.HotTracking = true;
            this.treeIcons.ImageIndex = 0;
            this.treeIcons.ImageList = this.ilTree;
            this.treeIcons.Location = new System.Drawing.Point(12, 41);
            this.treeIcons.Name = "treeIcons";
            this.treeIcons.SelectedImageIndex = 0;
            this.treeIcons.Size = new System.Drawing.Size(203, 420);
            this.treeIcons.TabIndex = 3;
            this.treeIcons.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeIcons_AfterSelect);
            this.treeIcons.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeIcons_NodeMouseClick);
            // 
            // cntxtTree
            // 
            this.cntxtTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTreeSaveAs,
            this.toolStripMenuItem2,
            this.mnuTreeProperties});
            this.cntxtTree.Name = "cntxtTree";
            this.cntxtTree.Size = new System.Drawing.Size(128, 54);
            this.cntxtTree.Opening += new System.ComponentModel.CancelEventHandler(this.cntxtTree_Opening);
            // 
            // mnuTreeSaveAs
            // 
            this.mnuTreeSaveAs.Name = "mnuTreeSaveAs";
            this.mnuTreeSaveAs.Size = new System.Drawing.Size(127, 22);
            this.mnuTreeSaveAs.Text = "&Save As...";
            this.mnuTreeSaveAs.Click += new System.EventHandler(this.mnuTreeSaveAs_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 6);
            // 
            // mnuTreeProperties
            // 
            this.mnuTreeProperties.Name = "mnuTreeProperties";
            this.mnuTreeProperties.Size = new System.Drawing.Size(127, 22);
            this.mnuTreeProperties.Text = "P&roperties";
            this.mnuTreeProperties.Click += new System.EventHandler(this.mnuTreeProperties_Click);
            // 
            // ilTree
            // 
            this.ilTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilTree.ImageSize = new System.Drawing.Size(16, 16);
            this.ilTree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // diagSelectLibrary
            // 
            this.diagSelectLibrary.FileName = "shell32.dll";
            this.diagSelectLibrary.Filter = "All Supported Files (*.exe, *.dll, *.ico)|*.exe;*.dll;*.ico|Executable Modules (*" +
    ".exe, *.dll)|*.exe;*.dll|Icon Files (*.ico)|*.ico|All Files (*.*)|*.*";
            this.diagSelectLibrary.InitialDirectory = "%SystemRoot%\\system32\\";
            this.diagSelectLibrary.Title = "Select File";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl16);
            this.panel1.Controls.Add(this.lbl24);
            this.panel1.Controls.Add(this.lbl32);
            this.panel1.Controls.Add(this.lbl48);
            this.panel1.Controls.Add(this.lbl64);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pic32);
            this.panel1.Controls.Add(this.pic64);
            this.panel1.Controls.Add(this.pic96);
            this.panel1.Controls.Add(this.pic128);
            this.panel1.Controls.Add(this.pic256);
            this.panel1.Location = new System.Drawing.Point(221, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 105);
            this.panel1.TabIndex = 4;
            // 
            // lbl16
            // 
            this.lbl16.Location = new System.Drawing.Point(290, 84);
            this.lbl16.Name = "lbl16";
            this.lbl16.Size = new System.Drawing.Size(64, 13);
            this.lbl16.TabIndex = 1;
            this.lbl16.Text = "New Size";
            this.lbl16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl24
            // 
            this.lbl24.Location = new System.Drawing.Point(220, 84);
            this.lbl24.Name = "lbl24";
            this.lbl24.Size = new System.Drawing.Size(64, 13);
            this.lbl24.TabIndex = 1;
            this.lbl24.Text = "New Size";
            this.lbl24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl32
            // 
            this.lbl32.Location = new System.Drawing.Point(150, 84);
            this.lbl32.Name = "lbl32";
            this.lbl32.Size = new System.Drawing.Size(64, 13);
            this.lbl32.TabIndex = 1;
            this.lbl32.Text = "New Size";
            this.lbl32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl48
            // 
            this.lbl48.Location = new System.Drawing.Point(80, 84);
            this.lbl48.Name = "lbl48";
            this.lbl48.Size = new System.Drawing.Size(64, 13);
            this.lbl48.TabIndex = 1;
            this.lbl48.Text = "New Size";
            this.lbl48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl64
            // 
            this.lbl64.Location = new System.Drawing.Point(10, 84);
            this.lbl64.Name = "lbl64";
            this.lbl64.Size = new System.Drawing.Size(64, 13);
            this.lbl64.TabIndex = 1;
            this.lbl64.Text = "New Size";
            this.lbl64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(293, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "32 x 32:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(223, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "64 x 64:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "96 x 96:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "128 x 128:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "256 x 256:";
            // 
            // pic32
            // 
            this.pic32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic32.Location = new System.Drawing.Point(293, 17);
            this.pic32.Name = "pic32";
            this.pic32.Size = new System.Drawing.Size(64, 64);
            this.pic32.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic32.TabIndex = 0;
            this.pic32.TabStop = false;
            // 
            // pic64
            // 
            this.pic64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic64.Location = new System.Drawing.Point(223, 17);
            this.pic64.Name = "pic64";
            this.pic64.Size = new System.Drawing.Size(64, 64);
            this.pic64.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic64.TabIndex = 0;
            this.pic64.TabStop = false;
            // 
            // pic96
            // 
            this.pic96.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic96.Location = new System.Drawing.Point(153, 17);
            this.pic96.Name = "pic96";
            this.pic96.Size = new System.Drawing.Size(64, 64);
            this.pic96.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic96.TabIndex = 0;
            this.pic96.TabStop = false;
            // 
            // pic128
            // 
            this.pic128.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic128.Location = new System.Drawing.Point(83, 17);
            this.pic128.Name = "pic128";
            this.pic128.Size = new System.Drawing.Size(64, 64);
            this.pic128.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic128.TabIndex = 0;
            this.pic128.TabStop = false;
            // 
            // pic256
            // 
            this.pic256.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic256.Location = new System.Drawing.Point(13, 17);
            this.pic256.Name = "pic256";
            this.pic256.Size = new System.Drawing.Size(64, 64);
            this.pic256.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic256.TabIndex = 0;
            this.pic256.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Best Fit Icons:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Icon Set:";
            // 
            // cntxtIconList
            // 
            this.cntxtIconList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIconListSaveAs,
            this.mnuIconListMerge,
            this.toolStripMenuItem3,
            this.mmnuIconListView,
            this.toolStripMenuItem1,
            this.mnuIconListProperties});
            this.cntxtIconList.Name = "cntxtIconList";
            this.cntxtIconList.Size = new System.Drawing.Size(128, 104);
            this.cntxtIconList.Opening += new System.ComponentModel.CancelEventHandler(this.cntxtIconList_Opening);
            // 
            // mnuIconListSaveAs
            // 
            this.mnuIconListSaveAs.Name = "mnuIconListSaveAs";
            this.mnuIconListSaveAs.Size = new System.Drawing.Size(127, 22);
            this.mnuIconListSaveAs.Text = "&Save As...";
            this.mnuIconListSaveAs.Click += new System.EventHandler(this.mnuIconListSaveAs_Click);
            // 
            // mnuIconListMerge
            // 
            this.mnuIconListMerge.Name = "mnuIconListMerge";
            this.mnuIconListMerge.Size = new System.Drawing.Size(127, 22);
            this.mnuIconListMerge.Text = "Merge";
            this.mnuIconListMerge.Click += new System.EventHandler(this.mnuIconListMerge_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(124, 6);
            // 
            // mmnuIconListView
            // 
            this.mmnuIconListView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIconListView16,
            this.mnuIconListView24,
            this.mnuIconListView32,
            this.mnuIconListView48,
            this.mnuIconListView64,
            this.mnuIconListView96});
            this.mmnuIconListView.Name = "mmnuIconListView";
            this.mmnuIconListView.Size = new System.Drawing.Size(127, 22);
            this.mmnuIconListView.Text = "&View";
            // 
            // mnuIconListView16
            // 
            this.mnuIconListView16.Name = "mnuIconListView16";
            this.mnuIconListView16.Size = new System.Drawing.Size(109, 22);
            this.mnuIconListView16.Text = "16 x 16";
            this.mnuIconListView16.Click += new System.EventHandler(this.mnuIconListView16_Click);
            // 
            // mnuIconListView24
            // 
            this.mnuIconListView24.Name = "mnuIconListView24";
            this.mnuIconListView24.Size = new System.Drawing.Size(109, 22);
            this.mnuIconListView24.Text = "24 x 24";
            this.mnuIconListView24.Click += new System.EventHandler(this.mnuIconListView24_Click);
            // 
            // mnuIconListView32
            // 
            this.mnuIconListView32.Name = "mnuIconListView32";
            this.mnuIconListView32.Size = new System.Drawing.Size(109, 22);
            this.mnuIconListView32.Text = "32 x 32";
            this.mnuIconListView32.Click += new System.EventHandler(this.mnuIconListView32_Click);
            // 
            // mnuIconListView48
            // 
            this.mnuIconListView48.Name = "mnuIconListView48";
            this.mnuIconListView48.Size = new System.Drawing.Size(109, 22);
            this.mnuIconListView48.Text = "48 x 48";
            this.mnuIconListView48.Click += new System.EventHandler(this.mnuIconListView48_Click);
            // 
            // mnuIconListView64
            // 
            this.mnuIconListView64.Name = "mnuIconListView64";
            this.mnuIconListView64.Size = new System.Drawing.Size(109, 22);
            this.mnuIconListView64.Text = "64 x 64";
            this.mnuIconListView64.Click += new System.EventHandler(this.mnuIconListView64_Click);
            // 
            // mnuIconListView96
            // 
            this.mnuIconListView96.Name = "mnuIconListView96";
            this.mnuIconListView96.Size = new System.Drawing.Size(109, 22);
            this.mnuIconListView96.Text = "96 x 96";
            this.mnuIconListView96.Click += new System.EventHandler(this.mnuIconListView96_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 6);
            // 
            // mnuIconListProperties
            // 
            this.mnuIconListProperties.Name = "mnuIconListProperties";
            this.mnuIconListProperties.Size = new System.Drawing.Size(127, 22);
            this.mnuIconListProperties.Text = "P&roperties";
            this.mnuIconListProperties.Click += new System.EventHandler(this.mnuIconListProperties_Click);
            // 
            // diagSaveIcon
            // 
            this.diagSaveIcon.DefaultExt = "*.ico";
            this.diagSaveIcon.Filter = "Icon Files|*.ico";
            this.diagSaveIcon.Title = "Save Icon";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTreeStatus,
            this.lblListStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(609, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTreeStatus
            // 
            this.lblTreeStatus.AutoSize = false;
            this.lblTreeStatus.Name = "lblTreeStatus";
            this.lblTreeStatus.Size = new System.Drawing.Size(220, 17);
            this.lblTreeStatus.Text = "toolStripStatusLabel1";
            this.lblTreeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblListStatus
            // 
            this.lblListStatus.Name = "lblListStatus";
            this.lblListStatus.Size = new System.Drawing.Size(118, 17);
            this.lblListStatus.Text = "toolStripStatusLabel2";
            // 
            // tlbarMain
            // 
            this.tlbarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbarMainOpen,
            this.toolStripSeparator1,
            this.tlbarMainView});
            this.tlbarMain.Location = new System.Drawing.Point(0, 0);
            this.tlbarMain.Name = "tlbarMain";
            this.tlbarMain.Size = new System.Drawing.Size(609, 25);
            this.tlbarMain.TabIndex = 8;
            this.tlbarMain.Text = "toolStrip1";
            // 
            // tlbarMainOpen
            // 
            this.tlbarMainOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbarMainOpen.Image = ((System.Drawing.Image)(resources.GetObject("tlbarMainOpen.Image")));
            this.tlbarMainOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbarMainOpen.Name = "tlbarMainOpen";
            this.tlbarMainOpen.Size = new System.Drawing.Size(23, 22);
            this.tlbarMainOpen.Text = "&Open";
            this.tlbarMainOpen.Click += new System.EventHandler(this.tlbarMainOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlbarMainView
            // 
            this.tlbarMainView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlbarMainView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbarMainView16,
            this.tlbarMainView24,
            this.tlbarMainView32,
            this.tlbarMainView48,
            this.tlbarMainView64,
            this.tlbarMainView96});
            this.tlbarMainView.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tlbarMainView.Name = "tlbarMainView";
            this.tlbarMainView.Size = new System.Drawing.Size(45, 22);
            this.tlbarMainView.Text = "&View";
            // 
            // tlbarMainView16
            // 
            this.tlbarMainView16.Name = "tlbarMainView16";
            this.tlbarMainView16.Size = new System.Drawing.Size(109, 22);
            this.tlbarMainView16.Text = "16 x 16";
            this.tlbarMainView16.Click += new System.EventHandler(this.mnuIconListView16_Click);
            // 
            // tlbarMainView24
            // 
            this.tlbarMainView24.Name = "tlbarMainView24";
            this.tlbarMainView24.Size = new System.Drawing.Size(109, 22);
            this.tlbarMainView24.Text = "24 x 24";
            this.tlbarMainView24.Click += new System.EventHandler(this.mnuIconListView24_Click);
            // 
            // tlbarMainView32
            // 
            this.tlbarMainView32.Name = "tlbarMainView32";
            this.tlbarMainView32.Size = new System.Drawing.Size(109, 22);
            this.tlbarMainView32.Text = "32 x 32";
            this.tlbarMainView32.Click += new System.EventHandler(this.mnuIconListView32_Click);
            // 
            // tlbarMainView48
            // 
            this.tlbarMainView48.Name = "tlbarMainView48";
            this.tlbarMainView48.Size = new System.Drawing.Size(109, 22);
            this.tlbarMainView48.Text = "48 x 48";
            this.tlbarMainView48.Click += new System.EventHandler(this.mnuIconListView48_Click);
            // 
            // tlbarMainView64
            // 
            this.tlbarMainView64.Name = "tlbarMainView64";
            this.tlbarMainView64.Size = new System.Drawing.Size(109, 22);
            this.tlbarMainView64.Text = "64 x 64";
            this.tlbarMainView64.Click += new System.EventHandler(this.mnuIconListView64_Click);
            // 
            // tlbarMainView96
            // 
            this.tlbarMainView96.Name = "tlbarMainView96";
            this.tlbarMainView96.Size = new System.Drawing.Size(109, 22);
            this.tlbarMainView96.Text = "96 x 96";
            this.tlbarMainView96.Click += new System.EventHandler(this.mnuIconListView96_Click);
            // 
            // iconList
            // 
            this.iconList.AllowDrop = true;
            this.iconList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconList.ContextMenuStrip = this.cntxtIconList;
            this.iconList.Location = new System.Drawing.Point(221, 165);
            this.iconList.Name = "iconList";
            this.iconList.OwnerDraw = true;
            this.iconList.Size = new System.Drawing.Size(376, 296);
            this.iconList.TabIndex = 5;
            this.iconList.TileSize = new System.Drawing.Size(0, 0);
            this.iconList.UseCompatibleStateImageBehavior = false;
            this.iconList.View = System.Windows.Forms.View.Tile;
            this.iconList.SelectedIndexChanged += new System.EventHandler(this.iconList_SelectedIndexChanged);
            // 
            // frmIconList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 486);
            this.Controls.Add(this.iconList);
            this.Controls.Add(this.treeIcons);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tlbarMain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmIconList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Icon Lister";
            this.Load += new System.EventHandler(this.frmIconList_Load);
            this.cntxtTree.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic96)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic256)).EndInit();
            this.cntxtIconList.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tlbarMain.ResumeLayout(false);
            this.tlbarMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeIcons;
        private System.Windows.Forms.ImageList ilTree;
        private System.Windows.Forms.OpenFileDialog diagSelectLibrary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pic256;
        private System.Windows.Forms.Label lbl64;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl16;
        private System.Windows.Forms.Label lbl24;
        private System.Windows.Forms.Label lbl32;
        private System.Windows.Forms.Label lbl48;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pic32;
        private System.Windows.Forms.PictureBox pic64;
        private System.Windows.Forms.PictureBox pic96;
        private System.Windows.Forms.PictureBox pic128;
        private System.Windows.Forms.Label label5;
        private TAFactory.IconPack.IconListView iconList;
        private System.Windows.Forms.ContextMenuStrip cntxtIconList;
        private System.Windows.Forms.ToolStripMenuItem mnuIconListSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mmnuIconListView;
        private System.Windows.Forms.ToolStripMenuItem mnuIconListView16;
        private System.Windows.Forms.ToolStripMenuItem mnuIconListView24;
        private System.Windows.Forms.ToolStripMenuItem mnuIconListView32;
        private System.Windows.Forms.ToolStripMenuItem mnuIconListView48;
        private System.Windows.Forms.ToolStripMenuItem mnuIconListView64;
        private System.Windows.Forms.ToolStripMenuItem mnuIconListView96;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuIconListProperties;
        private System.Windows.Forms.ContextMenuStrip cntxtTree;
        private System.Windows.Forms.ToolStripMenuItem mnuTreeSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuTreeProperties;
        private System.Windows.Forms.SaveFileDialog diagSaveIcon;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTreeStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblListStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuIconListMerge;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStrip tlbarMain;
        private System.Windows.Forms.ToolStripButton tlbarMainOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton tlbarMainView;
        private System.Windows.Forms.ToolStripMenuItem tlbarMainView16;
        private System.Windows.Forms.ToolStripMenuItem tlbarMainView24;
        private System.Windows.Forms.ToolStripMenuItem tlbarMainView32;
        private System.Windows.Forms.ToolStripMenuItem tlbarMainView48;
        private System.Windows.Forms.ToolStripMenuItem tlbarMainView64;
        private System.Windows.Forms.ToolStripMenuItem tlbarMainView96;
    }
}