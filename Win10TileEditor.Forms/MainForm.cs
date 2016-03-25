using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPainter.ColorPicker;
using Aga.Controls.Tree;
using System.Diagnostics;
using System.Security.Permissions;
using TAFactory.IconPack;

namespace Win10TileEditor
{
    public partial class MainForm : Form
    {
        private Color iconBackgroundColor;
        public Color IconBackgroundColor {
            get
            {
                return iconBackgroundColor;
            }
            set
            {
                iconBackgroundColor = value;

                this.pictureBox150.BackColor = iconBackgroundColor;
                this.pictureBox70.BackColor = iconBackgroundColor;
            }
        }

        public TileMaker tileMaker { get; set; }
        
        public FileInfo image70FileName { get; set; }
        [Obsolete]
        public Image image70Image { get; set; }

        public FileInfo _image150FileName;

        public FileInfo Image150FileName
        {
            get
            {
                return _image150FileName;
            }
            set
            {
                _image150FileName = value;
                if(text150ImagePath != null)
                    text150ImagePath.Text = value == null ? "" : value.FullName;
            }
        }


        [Obsolete]
        public Image image150Image { get; set; }

        public MainForm(TileMaker tileMaker)
        {
            this.tileMaker = tileMaker;
            InitializeComponent();
            this.postLoadComponent();

        }

        private void postLoadComponent()
        {
            //ListDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms));
            //ListDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Programs));
            //this.treeViewAdv1.UseColumns = true;
        }
        

        internal void loadItemData(LinkViewItem item)
        {
            this.textExePath.Text = item.TargetPath;
            bool clearImages = true;
            
            if(item.ManifestData != null)
            {
                if(item.ManifestData.UseDarkText)
                    this.radioButtonDarkText.Select();
                else
                    this.radioButtonLightText.Select();
                this.checkBoxShowName.Checked = item.ManifestData.ShowNameOnSquare;

                bool colorMatched = false;
                for(int i = 0; i < comboBoxColor.Items.Count; i++)
                {
                    if (comboBoxColor.Items[i] as string == item.ManifestData.BackgroundColor)
                    {
                        this.comboBoxColor.SelectedIndex = i;
                        colorMatched = true;
                        break;
                    }
                }
                if (!colorMatched)
                {
                    this.comboBoxColor.SelectedIndex = 0;
                    WriteHexData(ParseHexData(item.ManifestData.BackgroundColor));
                    this.IconBackgroundColor = this.ParseHexData(item.ManifestData.BackgroundColor);
                }

                if (item.ManifestData.HasImageData)
                {
                    this.Image150FileName = new FileInfo(item.ManifestData.Path + "\\" + item.ManifestData.Square150x150Logo);
                    this.pictureBox150.Image = LoadImageFile(this.Image150FileName);
                    this.pictureBox150.SizeMode = PictureBoxSizeMode.StretchImage;

                    this.image70FileName = new FileInfo(item.ManifestData.Path + "\\" + item.ManifestData.Square70x70Logo);
                    this.text70ImagePath.Text = this.image70FileName.FullName;
                    this.pictureBox70.Image = LoadImageFile(this.image70FileName);
                    this.pictureBox70.SizeMode = PictureBoxSizeMode.StretchImage;
                    clearImages = false;
                }
                else if(item.Icon != null)
                {
                    this._image150FileName = null;
                    this.text150ImagePath.Text = "";
                    this.pictureBox150.Image = (Image)item.Icon;
                    this.pictureBox150.SizeMode = PictureBoxSizeMode.CenterImage;

                    this.image70FileName = null;
                    this.text70ImagePath.Text = "";
                    this.pictureBox70.Image = (Image)item.Icon;
                    this.pictureBox70.SizeMode = PictureBoxSizeMode.CenterImage;
                    clearImages = false;
                }
            }
            if (clearImages)
            {
                this._image150FileName = null;
                this.text150ImagePath.Text = "";
                this.pictureBox150.Image = global::Win10TileEditor.Properties.Resources.UknownIcon150;
                this.pictureBox150.SizeMode = PictureBoxSizeMode.CenterImage;

                this.image70FileName = null;
                this.text70ImagePath.Text = "";
                this.pictureBox70.Image = global::Win10TileEditor.Properties.Resources.UknownIcon70;
                this.pictureBox70.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
        
        internal void saveData()
        {

            if(this.textExePath.Text == "")
            {
                MessageBox.Show("No application selected", "Can't save changes");
                return;
            }

            FileInfo exeFile = new FileInfo(this.textExePath.Text);
            
            if (!exeFile.Exists)
            {
                MessageBox.Show("No application found at '"+ this.textExePath.Text+"'", "Can't save changes");
                return;
            }
            var baseName = exeFile.Name.Substring(0, exeFile.Name.Length - 3);

            var visualPath = new FileInfo(exeFile.DirectoryName + "\\"+ baseName + "VisualElementsManifest.xml");

            VisualManifest ManifestData = new VisualManifest(visualPath);

            ManifestData.UseDarkText = this.radioButtonDarkText.Checked;
            ManifestData.ShowNameOnSquare = this.checkBoxShowName.Checked;
            ManifestData.BackgroundColor = this.comboBoxColor.Text;
            
            if (_image150FileName != null)//TODO Make this optinal
            {
                var fileIcon150 = baseName +  "Icon150x150" + this._image150FileName.Extension;
                var fileIcon70 = baseName + "Icon70x70" + this.image70FileName.Extension;

                ManifestData.Square150x150Logo = fileIcon150;
                ManifestData.Square70x70Logo = fileIcon70;

                fileIcon150 = exeFile.DirectoryName + "\\" + fileIcon150;
                fileIcon70 = exeFile.DirectoryName + "\\" + fileIcon70;

                if (File.Exists(fileIcon150))
                    File.Delete(fileIcon150);

                if (File.Exists(fileIcon70))
                    File.Delete(fileIcon70);

                this._image150FileName.CopyTo(fileIcon150);
                this.image70FileName.CopyTo(fileIcon70);
            }
            if (ManifestData.saveToFile())
            {
                var tag = this.linkBrowser.TreeView.SelectedNode.Tag;

                if (tag is LinkViewItem)
                {
                    LinkViewItem item = (LinkViewItem)tag;
                    item.File.LastWriteTime = System.DateTime.Now;
                    this.loadItemData(item);
                }
            }
        }

        /*private void ListDirectory(string path)
        {
            var stack = new Stack<Node>();
            var rootDirectory = new DirectoryInfo(path);
            var node = ((TreeModel)(this.treeViewAdv1.Model)).Root;
            node.Tag = rootDirectory;
            stack.Push(node);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = (DirectoryInfo)currentNode.Tag;
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var childDirectoryNode = new Node(directory.Name) { Tag = directory };
                    currentNode.Nodes.Add(childDirectoryNode);
                    stack.Push(childDirectoryNode);
                }
                foreach (var file in directoryInfo.GetFiles("*.lnk"))
                    currentNode.Nodes.Add(new Node(file.Name));
            }
        }*/


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Open 150x150 Image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this._image150FileName = new FileInfo(openFileDialog.FileName);
                this.text150ImagePath.Text = openFileDialog.FileName;
                this.pictureBox150.Image = LoadImageFile(this._image150FileName);
            }
        }

        private void buttonImage70_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Open 70x70 Image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.image70FileName = new FileInfo( openFileDialog.FileName);
                this.text70ImagePath.Text = openFileDialog.FileName;
                this.pictureBox70.Image = LoadImageFile(this.image70FileName);
            }
        }

        private Image LoadImageFile(FileInfo fileName)
        {
            Image image = null;
            try
            {
                image = Image.FromFile(fileName.FullName);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Unable to load The file '" + fileName.Name + "'. Is it a valid image file?", "An Error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
            }
            return image;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox150_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background 
            //e.DrawBackground();

            // Get the item text    
            string text;
            if (e.Index >= 0)
                text = ((ComboBox)sender).Items[e.Index].ToString();
            else
                text = "NONE";

            Color c = Color.FromName(text);

            if (text == "[custom]")
                c = IconBackgroundColor;
            e.Graphics.FillRectangle(new SolidBrush(c), e.Bounds.X + 55, e.Bounds.Y + 2, 100, e.Bounds.Height - 4);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), e.Bounds.X + 55, e.Bounds.Y + 2, 100, e.Bounds.Height - 4);
            e.Graphics.DrawString(text, e.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
            //e.Graphics.DrawRectangle(new Pen(brush), e.Bounds);

            // Draw the focus rectangle if the mouse hovers over an item.
            //e.DrawFocusRectangle();

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (this.colorPicker == null || this.colorPicker.IsDisposed)
            {
                this.colorPicker = new ColorPickerForm(this.userSelectedColor);
                this.colorPicker.Show(this);
                this.colorPicker.ColorChange += new ColorPickerForm.ColorChangeEventHandler(frmColorPicker_ColorChange);

            }
        }

        private void frmColorPicker_ColorChange(ColorPickerForm sender, EventArgs e)
        {
            this.userSelectedColor = sender.PrimaryColor;
            this.pictureBox150.BackColor = userSelectedColor;
            this.pictureBox70.BackColor = userSelectedColor;
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.comboBoxColor.SelectedIndex == 0)
            {
                this.m_txt_Hex.Enabled = true;
                this.buttonOpenColorPicker.Enabled = true;
                this.IconBackgroundColor = ParseHexData(this.m_txt_Hex.Text);
            }
            else
            {
                this.m_txt_Hex.Enabled = false;
                this.buttonOpenColorPicker.Enabled = false;
                if(comboBoxColor.SelectedIndex > 0 && comboBoxColor.SelectedIndex < comboBoxColor.Items.Count)
                    this.IconBackgroundColor = Color.FromName(comboBoxColor.Items[comboBoxColor.SelectedIndex].ToString());
            }
        }

        private void groupOptional_Enter(object sender, EventArgs e)
        {

        }

        private void textExePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void listLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //object item = this.listLinks.SelectedItems[0].Text;
        }

        private void treeViewLinks_Click(object sender, EventArgs e)
        {
        }

        private void buttonSaveTile_Click(object sender, EventArgs e)
        {
            this.saveData();
        }

        private void buttonLoadTile_Click(object sender, EventArgs e)
        {

        }

        private void numericTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void WriteHexData(Color rgb)
        {
            string red = Convert.ToString(rgb.R, 16);
            if (red.Length < 2) red = "0" + red;
            string green = Convert.ToString(rgb.G, 16);
            if (green.Length < 2) green = "0" + green;
            string blue = Convert.ToString(rgb.B, 16);
            if (blue.Length < 2) blue = "0" + blue;

            m_txt_Hex.Text = red.ToUpper() + green.ToUpper() + blue.ToUpper();
            m_txt_Hex.Update();
        }

        private Color ParseHexData(string hex_data)
        {
            hex_data = "000000" + hex_data;
            hex_data = hex_data.Remove(0, hex_data.Length - 6);

            string r_text, g_text, b_text;
            int r, g, b;

            r_text = hex_data.Substring(0, 2);
            g_text = hex_data.Substring(2, 2);
            b_text = hex_data.Substring(4, 2);

            r = int.Parse(r_text, System.Globalization.NumberStyles.HexNumber);
            g = int.Parse(g_text, System.Globalization.NumberStyles.HexNumber);
            b = int.Parse(b_text, System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(r, g, b);
        }

        private void m_txt_Hex_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (e.KeyChar != '\b')
                    e.Handled = !System.Uri.IsHexDigit(e.KeyChar);
            }
        }

        private void m_txt_Hex_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Hex.Text.ToUpper();
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            foreach (char letter in text)
            {
                if (!char.IsNumber(letter))
                {
                    if (letter >= 'A' && letter <= 'F')
                        continue;
                    has_illegal_chars = true;
                    break;
                }
            }

            if (has_illegal_chars)
            {
                MessageBox.Show("Hex must be a hex value between 0x000000 and 0xFFFFFF");
                WriteHexData(IconBackgroundColor);
                return;
            }

            IconBackgroundColor = ParseHexData(text);

            //this.m_txt_Hex.BackColor = rgb;

            //UpdateTextBoxes();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void buttonPickIcon_Click(object sender, EventArgs e)
        {
            string path = this.textBoxIconSource.Text;
            if (string.IsNullOrWhiteSpace(path))
            {
                path = this.textExePath.Text;
                if (string.IsNullOrWhiteSpace(path))
                {
                    MessageBox.Show("No application found at '" + this.textExePath.Text + "'", "Can't pick an icon");
                    return;
                }
            }
            int index = this.numericTextBoxIconIndex.IntValue;

            if(ShellHelp.ShowPickIconDialog(Handle, ref path, ref index))
            {
                this.textBoxIconSource.Text = path;
                this.numericTextBoxIconIndex.Text = index.ToString();

                IconExtractor ex = new IconExtractor(path);
                Bitmap Icon = new Icon(ex.GetIconAt(index), new Size(64, 64)).ToBitmap();

                {
                    this._image150FileName = null;
                    this.text150ImagePath.Text = "";
                    this.pictureBox150.Image = Icon;
                    this.pictureBox150.SizeMode = PictureBoxSizeMode.CenterImage;

                    this.image70FileName = null;
                    this.text70ImagePath.Text = "";
                    this.pictureBox70.Image = Icon;
                    this.pictureBox70.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
        }
    }
}
