using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using Aga.Controls.Tree;

namespace Win10TileEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonImage70 = new System.Windows.Forms.Button();
            this.buttonImage150 = new System.Windows.Forms.Button();
            this.text150ImagePath = new System.Windows.Forms.TextBox();
            this.text70ImagePath = new System.Windows.Forms.TextBox();
            this.buttonOpenColorPicker = new System.Windows.Forms.Button();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textExePath = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupRequired = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txt_Hex = new Aga.Controls.NumericTextBox();
            this.buttonBrowseExe = new System.Windows.Forms.Button();
            this.checkBoxShowName = new System.Windows.Forms.CheckBox();
            this.radioButtonDarkText = new System.Windows.Forms.RadioButton();
            this.radioButtonLightText = new System.Windows.Forms.RadioButton();
            this.groupBoxOption1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSaveTile = new System.Windows.Forms.Button();
            this.buttonDeleteTile = new System.Windows.Forms.Button();
            this.buttonLoadTile = new System.Windows.Forms.Button();
            this.buttonRestoreBackup = new System.Windows.Forms.Button();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.treeColumn1 = new Aga.Controls.Tree.TreeColumn();
            this.treeColumn2 = new Aga.Controls.Tree.TreeColumn();
            this.nodeTextBox1 = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.pictureBox150 = new System.Windows.Forms.PictureBox();
            this.pictureBox70 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxOption2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxIconSource = new System.Windows.Forms.TextBox();
            this.buttonPickIcon = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numericTextBoxIconIndex = new Aga.Controls.NumericTextBox();
            this.linkBrowser = new Win10TileEditor.FolderBrowser();
            this.menuStrip1.SuspendLayout();
            this.groupRequired.SuspendLayout();
            this.groupBoxOption1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBoxOption2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonImage70
            // 
            this.buttonImage70.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImage70.Location = new System.Drawing.Point(444, 52);
            this.buttonImage70.Name = "buttonImage70";
            this.buttonImage70.Size = new System.Drawing.Size(145, 23);
            this.buttonImage70.TabIndex = 1;
            this.buttonImage70.Text = "Select a 70px Iamge";
            this.buttonImage70.UseVisualStyleBackColor = true;
            this.buttonImage70.Click += new System.EventHandler(this.buttonImage70_Click);
            // 
            // buttonImage150
            // 
            this.buttonImage150.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImage150.Location = new System.Drawing.Point(444, 26);
            this.buttonImage150.Name = "buttonImage150";
            this.buttonImage150.Size = new System.Drawing.Size(145, 23);
            this.buttonImage150.TabIndex = 0;
            this.buttonImage150.Text = "Select a 150px Image";
            this.buttonImage150.UseVisualStyleBackColor = true;
            this.buttonImage150.Click += new System.EventHandler(this.button1_Click);
            // 
            // text150ImagePath
            // 
            this.text150ImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text150ImagePath.Location = new System.Drawing.Point(112, 28);
            this.text150ImagePath.Name = "text150ImagePath";
            this.text150ImagePath.Size = new System.Drawing.Size(326, 20);
            this.text150ImagePath.TabIndex = 5;
            this.text150ImagePath.TextChanged += new System.EventHandler(this.textExePath_TextChanged);
            // 
            // text70ImagePath
            // 
            this.text70ImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text70ImagePath.Location = new System.Drawing.Point(112, 54);
            this.text70ImagePath.Name = "text70ImagePath";
            this.text70ImagePath.Size = new System.Drawing.Size(326, 20);
            this.text70ImagePath.TabIndex = 6;
            // 
            // buttonOpenColorPicker
            // 
            this.buttonOpenColorPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenColorPicker.Location = new System.Drawing.Point(444, 66);
            this.buttonOpenColorPicker.Name = "buttonOpenColorPicker";
            this.buttonOpenColorPicker.Size = new System.Drawing.Size(145, 23);
            this.buttonOpenColorPicker.TabIndex = 7;
            this.buttonOpenColorPicker.Text = "Color Picker";
            this.buttonOpenColorPicker.UseVisualStyleBackColor = true;
            this.buttonOpenColorPicker.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColor.Items.AddRange(new object[] {
            "[custom]",
            "aqua",
            "black",
            "blue",
            "fuchsia",
            "gray",
            "green",
            "lime",
            "maroon",
            "navy",
            "olive",
            "purple",
            "red",
            "silver",
            "teal",
            "white",
            "yellow"});
            this.comboBoxColor.Location = new System.Drawing.Point(61, 68);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(181, 21);
            this.comboBoxColor.TabIndex = 8;
            this.comboBoxColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            this.comboBoxColor.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "BG Color";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // textExePath
            // 
            this.textExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textExePath.AutoCompleteCustomSource.AddRange(new string[] {
            "AUTO-COMPLETE"});
            this.textExePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textExePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.textExePath.Location = new System.Drawing.Point(6, 19);
            this.textExePath.Name = "textExePath";
            this.textExePath.Size = new System.Drawing.Size(488, 20);
            this.textExePath.TabIndex = 11;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.gif|All Files|*.*";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // groupRequired
            // 
            this.groupRequired.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupRequired.Controls.Add(this.label2);
            this.groupRequired.Controls.Add(this.m_txt_Hex);
            this.groupRequired.Controls.Add(this.buttonBrowseExe);
            this.groupRequired.Controls.Add(this.checkBoxShowName);
            this.groupRequired.Controls.Add(this.radioButtonDarkText);
            this.groupRequired.Controls.Add(this.comboBoxColor);
            this.groupRequired.Controls.Add(this.label1);
            this.groupRequired.Controls.Add(this.buttonOpenColorPicker);
            this.groupRequired.Controls.Add(this.radioButtonLightText);
            this.groupRequired.Controls.Add(this.textExePath);
            this.groupRequired.Location = new System.Drawing.Point(177, 252);
            this.groupRequired.Name = "groupRequired";
            this.groupRequired.Size = new System.Drawing.Size(595, 104);
            this.groupRequired.TabIndex = 12;
            this.groupRequired.TabStop = false;
            this.groupRequired.Text = "Required";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "#";
            // 
            // m_txt_Hex
            // 
            this.m_txt_Hex.AllowDecimalSeparator = false;
            this.m_txt_Hex.AllowNegativeSign = false;
            this.m_txt_Hex.Location = new System.Drawing.Point(328, 68);
            this.m_txt_Hex.Name = "m_txt_Hex";
            this.m_txt_Hex.Size = new System.Drawing.Size(110, 20);
            this.m_txt_Hex.TabIndex = 18;
            this.m_txt_Hex.TextChanged += new System.EventHandler(this.numericTextBox1_TextChanged);
            this.m_txt_Hex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txt_Hex_KeyPress);
            this.m_txt_Hex.Leave += new System.EventHandler(this.m_txt_Hex_Leave);
            // 
            // buttonBrowseExe
            // 
            this.buttonBrowseExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseExe.Location = new System.Drawing.Point(500, 17);
            this.buttonBrowseExe.Name = "buttonBrowseExe";
            this.buttonBrowseExe.Size = new System.Drawing.Size(89, 23);
            this.buttonBrowseExe.TabIndex = 7;
            this.buttonBrowseExe.Text = "Browse...";
            this.buttonBrowseExe.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowName
            // 
            this.checkBoxShowName.AutoSize = true;
            this.checkBoxShowName.Location = new System.Drawing.Point(9, 45);
            this.checkBoxShowName.Name = "checkBoxShowName";
            this.checkBoxShowName.Size = new System.Drawing.Size(119, 17);
            this.checkBoxShowName.TabIndex = 17;
            this.checkBoxShowName.Text = "Show Name on Tile";
            this.checkBoxShowName.UseVisualStyleBackColor = true;
            // 
            // radioButtonDarkText
            // 
            this.radioButtonDarkText.AutoSize = true;
            this.radioButtonDarkText.Location = new System.Drawing.Point(212, 45);
            this.radioButtonDarkText.Name = "radioButtonDarkText";
            this.radioButtonDarkText.Size = new System.Drawing.Size(72, 17);
            this.radioButtonDarkText.TabIndex = 14;
            this.radioButtonDarkText.Text = "Dark Text";
            this.radioButtonDarkText.UseVisualStyleBackColor = true;
            // 
            // radioButtonLightText
            // 
            this.radioButtonLightText.AutoSize = true;
            this.radioButtonLightText.Location = new System.Drawing.Point(134, 45);
            this.radioButtonLightText.Name = "radioButtonLightText";
            this.radioButtonLightText.Size = new System.Drawing.Size(72, 17);
            this.radioButtonLightText.TabIndex = 13;
            this.radioButtonLightText.Text = "Light Text";
            this.radioButtonLightText.UseVisualStyleBackColor = true;
            // 
            // groupBoxOption1
            // 
            this.groupBoxOption1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOption1.Controls.Add(this.label4);
            this.groupBoxOption1.Controls.Add(this.label3);
            this.groupBoxOption1.Controls.Add(this.text150ImagePath);
            this.groupBoxOption1.Controls.Add(this.text70ImagePath);
            this.groupBoxOption1.Controls.Add(this.buttonImage150);
            this.groupBoxOption1.Controls.Add(this.buttonImage70);
            this.groupBoxOption1.Location = new System.Drawing.Point(177, 362);
            this.groupBoxOption1.Name = "groupBoxOption1";
            this.groupBoxOption1.Size = new System.Drawing.Size(595, 92);
            this.groupBoxOption1.TabIndex = 18;
            this.groupBoxOption1.TabStop = false;
            this.groupBoxOption1.Text = "Option 1 - External Image";
            this.groupBoxOption1.Enter += new System.EventHandler(this.groupOptional_Enter);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Image 70 x 70 px";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Image 150 x 150 px";
            // 
            // buttonSaveTile
            // 
            this.buttonSaveTile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveTile.Location = new System.Drawing.Point(273, 578);
            this.buttonSaveTile.Name = "buttonSaveTile";
            this.buttonSaveTile.Size = new System.Drawing.Size(146, 23);
            this.buttonSaveTile.TabIndex = 19;
            this.buttonSaveTile.Text = "Save Tile";
            this.buttonSaveTile.UseVisualStyleBackColor = true;
            this.buttonSaveTile.Click += new System.EventHandler(this.buttonSaveTile_Click);
            // 
            // buttonDeleteTile
            // 
            this.buttonDeleteTile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteTile.Location = new System.Drawing.Point(662, 578);
            this.buttonDeleteTile.Name = "buttonDeleteTile";
            this.buttonDeleteTile.Size = new System.Drawing.Size(110, 23);
            this.buttonDeleteTile.TabIndex = 20;
            this.buttonDeleteTile.Text = "Delete Tile";
            this.buttonDeleteTile.UseVisualStyleBackColor = true;
            // 
            // buttonLoadTile
            // 
            this.buttonLoadTile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadTile.Location = new System.Drawing.Point(425, 578);
            this.buttonLoadTile.Name = "buttonLoadTile";
            this.buttonLoadTile.Size = new System.Drawing.Size(115, 23);
            this.buttonLoadTile.TabIndex = 21;
            this.buttonLoadTile.Text = "Load Existing Tile";
            this.buttonLoadTile.UseVisualStyleBackColor = true;
            this.buttonLoadTile.Click += new System.EventHandler(this.buttonLoadTile_Click);
            // 
            // buttonRestoreBackup
            // 
            this.buttonRestoreBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRestoreBackup.Location = new System.Drawing.Point(546, 578);
            this.buttonRestoreBackup.Name = "buttonRestoreBackup";
            this.buttonRestoreBackup.Size = new System.Drawing.Size(110, 23);
            this.buttonRestoreBackup.TabIndex = 22;
            this.buttonRestoreBackup.Text = "Restore Backup";
            this.buttonRestoreBackup.UseVisualStyleBackColor = true;
            // 
            // imageListIcons
            // 
            this.imageListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcons.ImageStream")));
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcons.Images.SetKeyName(0, "folder_classic.png");
            this.imageListIcons.Images.SetKeyName(1, "folder_classic_opened.png");
            this.imageListIcons.Images.SetKeyName(2, "document_a4_blank.png");
            this.imageListIcons.Images.SetKeyName(3, "document_a4_edit.png");
            // 
            // treeColumn1
            // 
            this.treeColumn1.Header = "Link Name";
            this.treeColumn1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeColumn1.TooltipText = null;
            // 
            // treeColumn2
            // 
            this.treeColumn2.Header = "Path";
            this.treeColumn2.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeColumn2.TooltipText = null;
            // 
            // nodeTextBox1
            // 
            this.nodeTextBox1.IncrementalSearchEnabled = true;
            this.nodeTextBox1.LeftMargin = 3;
            this.nodeTextBox1.ParentColumn = this.treeColumn1;
            // 
            // pictureBox150
            // 
            this.pictureBox150.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox150.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox150.Image = global::Win10TileEditor.Properties.Resources.UknownIcon150;
            this.pictureBox150.Location = new System.Drawing.Point(12, 449);
            this.pictureBox150.Name = "pictureBox150";
            this.pictureBox150.Size = new System.Drawing.Size(152, 152);
            this.pictureBox150.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox150.TabIndex = 2;
            this.pictureBox150.TabStop = false;
            this.pictureBox150.Click += new System.EventHandler(this.pictureBox150_Click);
            // 
            // pictureBox70
            // 
            this.pictureBox70.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox70.Image = global::Win10TileEditor.Properties.Resources.UknownIcon70;
            this.pictureBox70.Location = new System.Drawing.Point(12, 371);
            this.pictureBox70.Name = "pictureBox70";
            this.pictureBox70.Size = new System.Drawing.Size(72, 72);
            this.pictureBox70.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox70.TabIndex = 3;
            this.pictureBox70.TabStop = false;
            // 
            // groupBoxOption2
            // 
            this.groupBoxOption2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOption2.Controls.Add(this.numericTextBoxIconIndex);
            this.groupBoxOption2.Controls.Add(this.label5);
            this.groupBoxOption2.Controls.Add(this.label6);
            this.groupBoxOption2.Controls.Add(this.textBoxIconSource);
            this.groupBoxOption2.Controls.Add(this.buttonPickIcon);
            this.groupBoxOption2.Location = new System.Drawing.Point(177, 460);
            this.groupBoxOption2.Name = "groupBoxOption2";
            this.groupBoxOption2.Size = new System.Drawing.Size(595, 92);
            this.groupBoxOption2.TabIndex = 19;
            this.groupBoxOption2.TabStop = false;
            this.groupBoxOption2.Text = "Option 2 - System Icon";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Icon Source";
            // 
            // textBoxIconSource
            // 
            this.textBoxIconSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIconSource.Location = new System.Drawing.Point(77, 28);
            this.textBoxIconSource.Name = "textBoxIconSource";
            this.textBoxIconSource.Size = new System.Drawing.Size(129, 20);
            this.textBoxIconSource.TabIndex = 5;
            // 
            // buttonPickIcon
            // 
            this.buttonPickIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPickIcon.Location = new System.Drawing.Point(444, 26);
            this.buttonPickIcon.Name = "buttonPickIcon";
            this.buttonPickIcon.Size = new System.Drawing.Size(145, 23);
            this.buttonPickIcon.TabIndex = 0;
            this.buttonPickIcon.Text = "Pick Icon";
            this.buttonPickIcon.UseVisualStyleBackColor = true;
            this.buttonPickIcon.Click += new System.EventHandler(this.buttonPickIcon_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Icon Index";
            // 
            // numericTextBoxIconIndex
            // 
            this.numericTextBoxIconIndex.AllowDecimalSeparator = false;
            this.numericTextBoxIconIndex.AllowNegativeSign = false;
            this.numericTextBoxIconIndex.Location = new System.Drawing.Point(290, 28);
            this.numericTextBoxIconIndex.Name = "numericTextBoxIconIndex";
            this.numericTextBoxIconIndex.Size = new System.Drawing.Size(54, 20);
            this.numericTextBoxIconIndex.TabIndex = 9;
            // 
            // linkBrowser
            // 
            this.linkBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkBrowser.Location = new System.Drawing.Point(12, 27);
            this.linkBrowser.Name = "linkBrowser";
            this.linkBrowser.Size = new System.Drawing.Size(760, 219);
            this.linkBrowser.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 613);
            this.Controls.Add(this.groupBoxOption2);
            this.Controls.Add(this.buttonRestoreBackup);
            this.Controls.Add(this.buttonLoadTile);
            this.Controls.Add(this.buttonDeleteTile);
            this.Controls.Add(this.buttonSaveTile);
            this.Controls.Add(this.groupBoxOption1);
            this.Controls.Add(this.groupRequired);
            this.Controls.Add(this.pictureBox150);
            this.Controls.Add(this.pictureBox70);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.linkBrowser);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "Win10TileEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupRequired.ResumeLayout(false);
            this.groupRequired.PerformLayout();
            this.groupBoxOption1.ResumeLayout(false);
            this.groupBoxOption1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBoxOption2.ResumeLayout(false);
            this.groupBoxOption2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox pictureBox150;
        private PictureBox pictureBox70;
        private Button buttonImage70;
        private Button buttonImage150;
        private TextBox text150ImagePath;
        private TextBox text70ImagePath;
        private Button buttonOpenColorPicker;
        private ComboBox comboBoxColor;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private TextBox textExePath;
        private OpenFileDialog openFileDialog;
        private GroupBox groupRequired;
        private CheckBox checkBoxShowName;
        private RadioButton radioButtonDarkText;
        private RadioButton radioButtonLightText;
        private GroupBox groupBoxOption1;
        private Button buttonBrowseExe;
        private Button buttonSaveTile;
        private Button buttonDeleteTile;
        private Button buttonLoadTile;
        private Button buttonRestoreBackup;
        private BindingSource bindingSource1;
        private ImageList imageListIcons;
        private TreeColumn treeColumn1;
        private TreeColumn treeColumn2;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBox1;
        private FolderBrowser linkBrowser;
        private Aga.Controls.NumericTextBox m_txt_Hex;
        private Label label2;
        private Label label4;
        private Label label3;
        private GroupBox groupBoxOption2;
        private Label label6;
        private TextBox textBoxIconSource;
        private Button buttonPickIcon;
        private Aga.Controls.NumericTextBox numericTextBoxIconIndex;
        private Label label5;

        public OpenPainter.ColorPicker.ColorPickerForm colorPicker { get; private set; }
        public Color userSelectedColor { get; set; }
    }
}

