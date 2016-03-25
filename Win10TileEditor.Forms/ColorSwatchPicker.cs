using System;
using System.ComponentModel;
using System.Windows.Forms;

using Aga.Controls.Tree.NodeControls;
using Aga.Controls.Tree;
using OpenPainter.ColorPicker;
using System.Drawing;

namespace Win10TileEditor
{
    public class ColorSwatchPicker : UserControl
    {
        private OpenPainter.ColorPicker.ColorBox2D ctrl2DColorBox1;
        private OpenPainter.ColorPicker.VerticalColorSlider ctrlVerticalColorSlider2;
        private Label m_lbl_Primary_Color;
        private Label label2;
        private TabControl tcMain;
        private TabPage pageColor;
        private GroupBox gOtherColors;
        private GroupBox gNamedColors;
        private TabPage pageSwatch;
        private HSB _hsl;
        private Color _rgb;
        private CMYK _cmyk;

        public ColorSwatchPicker()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.m_lbl_Primary_Color = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.pageColor = new System.Windows.Forms.TabPage();
            this.ctrl2DColorBox1 = new OpenPainter.ColorPicker.ColorBox2D();
            this.ctrlVerticalColorSlider2 = new OpenPainter.ColorPicker.VerticalColorSlider();
            this.pageSwatch = new System.Windows.Forms.TabPage();
            this.gOtherColors = new System.Windows.Forms.GroupBox();
            this.gNamedColors = new System.Windows.Forms.GroupBox();
            this.tcMain.SuspendLayout();
            this.pageColor.SuspendLayout();
            this.pageSwatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lbl_Primary_Color
            // 
            this.m_lbl_Primary_Color.BackColor = System.Drawing.Color.White;
            this.m_lbl_Primary_Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lbl_Primary_Color.Location = new System.Drawing.Point(318, 67);
            this.m_lbl_Primary_Color.Name = "m_lbl_Primary_Color";
            this.m_lbl_Primary_Color.Size = new System.Drawing.Size(58, 58);
            this.m_lbl_Primary_Color.TabIndex = 37;
            this.m_lbl_Primary_Color.Click += new System.EventHandler(this.m_lbl_Primary_Color_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(318, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "click to edit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.pageColor);
            this.tcMain.Controls.Add(this.pageSwatch);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(393, 292);
            this.tcMain.TabIndex = 48;
            // 
            // pageColor
            // 
            this.pageColor.Controls.Add(this.ctrl2DColorBox1);
            this.pageColor.Controls.Add(this.label2);
            this.pageColor.Controls.Add(this.ctrlVerticalColorSlider2);
            this.pageColor.Controls.Add(this.m_lbl_Primary_Color);
            this.pageColor.Location = new System.Drawing.Point(4, 22);
            this.pageColor.Name = "pageColor";
            this.pageColor.Padding = new System.Windows.Forms.Padding(3);
            this.pageColor.Size = new System.Drawing.Size(385, 266);
            this.pageColor.TabIndex = 0;
            this.pageColor.Text = "Colors";
            // 
            // ctrl2DColorBox1
            // 
            this.ctrl2DColorBox1.BaseColorComponent = OpenPainter.ColorPicker.ColorComponent.Hue;
            this.ctrl2DColorBox1.Location = new System.Drawing.Point(3, 3);
            this.ctrl2DColorBox1.Name = "ctrl2DColorBox1";
            this.ctrl2DColorBox1.RGB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ctrl2DColorBox1.Size = new System.Drawing.Size(260, 260);
            this.ctrl2DColorBox1.TabIndex = 0;
            this.ctrl2DColorBox1.WebSafeColorsOnly = false;
            this.ctrl2DColorBox1.SelectionChanged += new System.EventHandler(this.ctrl2DColorBox1_SelectionChanged);
            // 
            // ctrlVerticalColorSlider2
            // 
            this.ctrlVerticalColorSlider2.BaseColorComponent = OpenPainter.ColorPicker.ColorComponent.Hue;
            this.ctrlVerticalColorSlider2.Location = new System.Drawing.Point(272, 0);
            this.ctrlVerticalColorSlider2.MinimumSize = new System.Drawing.Size(22, 25);
            this.ctrlVerticalColorSlider2.Name = "ctrlVerticalColorSlider2";
            this.ctrlVerticalColorSlider2.RGB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ctrlVerticalColorSlider2.Size = new System.Drawing.Size(40, 264);
            this.ctrlVerticalColorSlider2.TabIndex = 1;
            this.ctrlVerticalColorSlider2.WebSafeColorsOnly = false;
            this.ctrlVerticalColorSlider2.SelectionChanged += new System.EventHandler(this.ctrlVerticalColorSlider2_SelectionChanged);
            // 
            // pageSwatch
            // 
            this.pageSwatch.Controls.Add(this.gOtherColors);
            this.pageSwatch.Controls.Add(this.gNamedColors);
            this.pageSwatch.Location = new System.Drawing.Point(4, 22);
            this.pageSwatch.Name = "pageSwatch";
            this.pageSwatch.Padding = new System.Windows.Forms.Padding(3);
            this.pageSwatch.Size = new System.Drawing.Size(385, 266);
            this.pageSwatch.TabIndex = 1;
            this.pageSwatch.Text = "Swatches";
            this.pageSwatch.UseVisualStyleBackColor = true;
            // 
            // gOtherColors
            // 
            this.gOtherColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gOtherColors.Location = new System.Drawing.Point(3, 103);
            this.gOtherColors.Name = "gOtherColors";
            this.gOtherColors.Size = new System.Drawing.Size(379, 160);
            this.gOtherColors.TabIndex = 0;
            this.gOtherColors.TabStop = false;
            this.gOtherColors.Text = "Other Colors";
            // 
            // gNamedColors
            // 
            this.gNamedColors.Dock = System.Windows.Forms.DockStyle.Top;
            this.gNamedColors.Location = new System.Drawing.Point(3, 3);
            this.gNamedColors.Name = "gNamedColors";
            this.gNamedColors.Size = new System.Drawing.Size(379, 100);
            this.gNamedColors.TabIndex = 0;
            this.gNamedColors.TabStop = false;
            this.gNamedColors.Text = "Named Colors";
            // 
            // ColorSwatchPicker
            // 
            this.Controls.Add(this.tcMain);
            this.Name = "ColorSwatchPicker";
            this.Size = new System.Drawing.Size(393, 292);
            this.tcMain.ResumeLayout(false);
            this.pageColor.ResumeLayout(false);
            this.pageSwatch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void ctrl2DColorBox1_SelectionChanged(object sender, EventArgs e)
        {
            _hsl = ctrl2DColorBox1.HSB;
            _rgb = AdobeColors.ToRGB(_hsl);
            _cmyk = AdobeColors.ToCMYK(_rgb);

            //UpdateTextBoxes();

            this.ctrlVerticalColorSlider2.HSB = _hsl;

            m_lbl_Primary_Color.BackColor = _rgb;
            m_lbl_Primary_Color.Update();
        }
        
        private void ctrlVerticalColorSlider2_SelectionChanged(object sender, EventArgs e)
        {
            _hsl = ctrlVerticalColorSlider2.HSB;
            _rgb = AdobeColors.ToRGB(_hsl);
            _cmyk = AdobeColors.ToCMYK(_rgb);

            //UpdateTextBoxes();

            this.ctrl2DColorBox1.HSB = _hsl;

            m_lbl_Primary_Color.BackColor = _rgb;
            m_lbl_Primary_Color.Update();
        }
        
        private void m_lbl_Primary_Color_Click(object sender, EventArgs e)
        {
            ColorPickerForm p = new ColorPickerForm(Color.Wheat);
            p.ShowDialog();
            _rgb = m_lbl_Primary_Color.BackColor;
            _hsl = AdobeColors.ToHSB(_rgb);

            this.ctrl2DColorBox1.HSB = _hsl;
            this.ctrlVerticalColorSlider2.HSB = _hsl;

            _cmyk = AdobeColors.ToCMYK(_rgb);

            //UpdateTextBoxes();
        }
    }
}