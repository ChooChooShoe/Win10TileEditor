using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace OpenPainter.ColorPicker
{
    partial class ColorPickerForm
    {


        #region Designer Generated Variables

        private System.Windows.Forms.Label m_pbx_BlankBox;
        private System.Windows.Forms.Button m_cmd_OK;
        private System.Windows.Forms.Button m_cmd_Cancel;
        private System.Windows.Forms.TextBox m_txt_Hue;
        private System.Windows.Forms.TextBox m_txt_Sat;
        private System.Windows.Forms.TextBox m_txt_Black;
        private System.Windows.Forms.TextBox m_txt_Red;
        private System.Windows.Forms.TextBox m_txt_Green;
        private System.Windows.Forms.TextBox m_txt_Blue;
        private System.Windows.Forms.TextBox m_txt_Lum;
        private System.Windows.Forms.TextBox m_txt_a;
        private System.Windows.Forms.TextBox m_txt_b;
        private System.Windows.Forms.TextBox textBoxCyan;
        private System.Windows.Forms.TextBox m_txt_Magenta;
        private System.Windows.Forms.TextBox m_txt_Yellow;
        private System.Windows.Forms.TextBox m_txt_K;
        private System.Windows.Forms.TextBox m_txt_Hex;
        private System.Windows.Forms.RadioButton radioButtonHue;
        private System.Windows.Forms.RadioButton radioButtonSat;
        private System.Windows.Forms.RadioButton radioButtonBlack;
        private System.Windows.Forms.RadioButton radioButtonRed;
        private System.Windows.Forms.RadioButton radioButtonGreen;
        private System.Windows.Forms.RadioButton radioButtonBlue;
        private System.Windows.Forms.CheckBox chkWebColorsOnly;
        private System.Windows.Forms.Label m_lbl_HexPound;
        private System.Windows.Forms.RadioButton radioButtonL;
        private System.Windows.Forms.RadioButton radioButtona;
        private System.Windows.Forms.RadioButton radioButtonb;
        private System.Windows.Forms.Label m_lbl_Cyan;
        private System.Windows.Forms.Label m_lbl_Magenta;
        private System.Windows.Forms.Label m_lbl_Yellow;
        private System.Windows.Forms.Label m_lbl_K;
        private System.Windows.Forms.Label m_lbl_Primary_Color;
        private System.Windows.Forms.Label m_lbl_Secondary_Color;
        private VerticalColorSlider m_ctrl_ThinBox;
        private ColorBox2D m_ctrl_BigBox;
        private System.Windows.Forms.Label m_lbl_Hue_Symbol;
        private System.Windows.Forms.Label m_lbl_Saturation_Symbol;
        private System.Windows.Forms.Label m_lbl_Black_Symbol;
        private System.Windows.Forms.Label m_lbl_Cyan_Symbol;
        private System.Windows.Forms.Label m_lbl_Magenta_Symbol;
        private System.Windows.Forms.Label m_lbl_Yellow_Symbol;
        private Label label1;
        private Label label2;
        private Label label3;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_pbx_BlankBox = new System.Windows.Forms.Label();
            this.m_cmd_OK = new System.Windows.Forms.Button();
            this.m_cmd_Cancel = new System.Windows.Forms.Button();
            this.m_txt_Hue = new System.Windows.Forms.TextBox();
            this.m_txt_Sat = new System.Windows.Forms.TextBox();
            this.m_txt_Black = new System.Windows.Forms.TextBox();
            this.m_txt_Red = new System.Windows.Forms.TextBox();
            this.m_txt_Green = new System.Windows.Forms.TextBox();
            this.m_txt_Blue = new System.Windows.Forms.TextBox();
            this.m_txt_Lum = new System.Windows.Forms.TextBox();
            this.m_txt_a = new System.Windows.Forms.TextBox();
            this.m_txt_b = new System.Windows.Forms.TextBox();
            this.textBoxCyan = new System.Windows.Forms.TextBox();
            this.m_txt_Magenta = new System.Windows.Forms.TextBox();
            this.m_txt_Yellow = new System.Windows.Forms.TextBox();
            this.m_txt_K = new System.Windows.Forms.TextBox();
            this.m_txt_Hex = new System.Windows.Forms.TextBox();
            this.radioButtonHue = new System.Windows.Forms.RadioButton();
            this.radioButtonSat = new System.Windows.Forms.RadioButton();
            this.radioButtonBlack = new System.Windows.Forms.RadioButton();
            this.radioButtonRed = new System.Windows.Forms.RadioButton();
            this.radioButtonGreen = new System.Windows.Forms.RadioButton();
            this.radioButtonBlue = new System.Windows.Forms.RadioButton();
            this.chkWebColorsOnly = new System.Windows.Forms.CheckBox();
            this.m_lbl_HexPound = new System.Windows.Forms.Label();
            this.radioButtonL = new System.Windows.Forms.RadioButton();
            this.radioButtona = new System.Windows.Forms.RadioButton();
            this.radioButtonb = new System.Windows.Forms.RadioButton();
            this.m_lbl_Cyan = new System.Windows.Forms.Label();
            this.m_lbl_Magenta = new System.Windows.Forms.Label();
            this.m_lbl_Yellow = new System.Windows.Forms.Label();
            this.m_lbl_K = new System.Windows.Forms.Label();
            this.m_lbl_Primary_Color = new System.Windows.Forms.Label();
            this.m_lbl_Secondary_Color = new System.Windows.Forms.Label();
            this.m_lbl_Hue_Symbol = new System.Windows.Forms.Label();
            this.m_lbl_Saturation_Symbol = new System.Windows.Forms.Label();
            this.m_lbl_Black_Symbol = new System.Windows.Forms.Label();
            this.m_lbl_Cyan_Symbol = new System.Windows.Forms.Label();
            this.m_lbl_Magenta_Symbol = new System.Windows.Forms.Label();
            this.m_lbl_Yellow_Symbol = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_ctrl_BigBox = new OpenPainter.ColorPicker.ColorBox2D();
            this.m_ctrl_ThinBox = new OpenPainter.ColorPicker.VerticalColorSlider();
            this.SuspendLayout();
            // 
            // m_pbx_BlankBox
            // 
            this.m_pbx_BlankBox.BackColor = System.Drawing.Color.Black;
            this.m_pbx_BlankBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_pbx_BlankBox.Location = new System.Drawing.Point(313, 45);
            this.m_pbx_BlankBox.Name = "m_pbx_BlankBox";
            this.m_pbx_BlankBox.Size = new System.Drawing.Size(63, 71);
            this.m_pbx_BlankBox.TabIndex = 3;
            // 
            // m_cmd_OK
            // 
            this.m_cmd_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmd_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_cmd_OK.Location = new System.Drawing.Point(415, 11);
            this.m_cmd_OK.Name = "m_cmd_OK";
            this.m_cmd_OK.Size = new System.Drawing.Size(112, 23);
            this.m_cmd_OK.TabIndex = 4;
            this.m_cmd_OK.Text = "OK";
            this.m_cmd_OK.Click += new System.EventHandler(this.m_cmd_OK_Click);
            // 
            // m_cmd_Cancel
            // 
            this.m_cmd_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmd_Cancel.Location = new System.Drawing.Point(415, 41);
            this.m_cmd_Cancel.Name = "m_cmd_Cancel";
            this.m_cmd_Cancel.Size = new System.Drawing.Size(112, 23);
            this.m_cmd_Cancel.TabIndex = 5;
            this.m_cmd_Cancel.Text = "Cancel";
            this.m_cmd_Cancel.Click += new System.EventHandler(this.m_cmd_Cancel_Click);
            // 
            // m_txt_Hue
            // 
            this.m_txt_Hue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Hue.Location = new System.Drawing.Point(355, 164);
            this.m_txt_Hue.Name = "m_txt_Hue";
            this.m_txt_Hue.Size = new System.Drawing.Size(33, 20);
            this.m_txt_Hue.TabIndex = 6;
            this.m_txt_Hue.Leave += new System.EventHandler(this.m_txt_Hue_Leave);
            // 
            // m_txt_Sat
            // 
            this.m_txt_Sat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Sat.Location = new System.Drawing.Point(355, 189);
            this.m_txt_Sat.Name = "m_txt_Sat";
            this.m_txt_Sat.Size = new System.Drawing.Size(33, 20);
            this.m_txt_Sat.TabIndex = 7;
            this.m_txt_Sat.Leave += new System.EventHandler(this.m_txt_Sat_Leave);
            // 
            // m_txt_Black
            // 
            this.m_txt_Black.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Black.Location = new System.Drawing.Point(355, 214);
            this.m_txt_Black.Name = "m_txt_Black";
            this.m_txt_Black.Size = new System.Drawing.Size(33, 20);
            this.m_txt_Black.TabIndex = 8;
            this.m_txt_Black.Leave += new System.EventHandler(this.m_txt_Black_Leave);
            // 
            // m_txt_Red
            // 
            this.m_txt_Red.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Red.Location = new System.Drawing.Point(355, 244);
            this.m_txt_Red.Name = "m_txt_Red";
            this.m_txt_Red.Size = new System.Drawing.Size(33, 20);
            this.m_txt_Red.TabIndex = 9;
            this.m_txt_Red.Leave += new System.EventHandler(this.m_txt_Red_Leave);
            // 
            // m_txt_Green
            // 
            this.m_txt_Green.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Green.Location = new System.Drawing.Point(355, 269);
            this.m_txt_Green.Name = "m_txt_Green";
            this.m_txt_Green.Size = new System.Drawing.Size(33, 20);
            this.m_txt_Green.TabIndex = 10;
            this.m_txt_Green.Leave += new System.EventHandler(this.m_txt_Green_Leave);
            // 
            // m_txt_Blue
            // 
            this.m_txt_Blue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Blue.Location = new System.Drawing.Point(355, 294);
            this.m_txt_Blue.Name = "m_txt_Blue";
            this.m_txt_Blue.Size = new System.Drawing.Size(33, 20);
            this.m_txt_Blue.TabIndex = 11;
            this.m_txt_Blue.Leave += new System.EventHandler(this.m_txt_Blue_Leave);
            // 
            // m_txt_Lum
            // 
            this.m_txt_Lum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Lum.Enabled = false;
            this.m_txt_Lum.Location = new System.Drawing.Point(467, 164);
            this.m_txt_Lum.Name = "m_txt_Lum";
            this.m_txt_Lum.Size = new System.Drawing.Size(42, 20);
            this.m_txt_Lum.TabIndex = 12;
            // 
            // m_txt_a
            // 
            this.m_txt_a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_a.Enabled = false;
            this.m_txt_a.Location = new System.Drawing.Point(467, 189);
            this.m_txt_a.Name = "m_txt_a";
            this.m_txt_a.Size = new System.Drawing.Size(42, 20);
            this.m_txt_a.TabIndex = 13;
            // 
            // m_txt_b
            // 
            this.m_txt_b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_b.Enabled = false;
            this.m_txt_b.Location = new System.Drawing.Point(467, 214);
            this.m_txt_b.Name = "m_txt_b";
            this.m_txt_b.Size = new System.Drawing.Size(42, 20);
            this.m_txt_b.TabIndex = 14;
            // 
            // textBoxCyan
            // 
            this.textBoxCyan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCyan.Location = new System.Drawing.Point(467, 244);
            this.textBoxCyan.Name = "textBoxCyan";
            this.textBoxCyan.Size = new System.Drawing.Size(33, 20);
            this.textBoxCyan.TabIndex = 15;
            this.textBoxCyan.Leave += new System.EventHandler(this.m_txt_Cyan_Leave);
            // 
            // m_txt_Magenta
            // 
            this.m_txt_Magenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Magenta.Location = new System.Drawing.Point(467, 269);
            this.m_txt_Magenta.Name = "m_txt_Magenta";
            this.m_txt_Magenta.Size = new System.Drawing.Size(33, 20);
            this.m_txt_Magenta.TabIndex = 16;
            this.m_txt_Magenta.Leave += new System.EventHandler(this.m_txt_Magenta_Leave);
            // 
            // m_txt_Yellow
            // 
            this.m_txt_Yellow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Yellow.Location = new System.Drawing.Point(467, 294);
            this.m_txt_Yellow.Name = "m_txt_Yellow";
            this.m_txt_Yellow.Size = new System.Drawing.Size(33, 20);
            this.m_txt_Yellow.TabIndex = 17;
            this.m_txt_Yellow.Leave += new System.EventHandler(this.m_txt_Yellow_Leave);
            // 
            // m_txt_K
            // 
            this.m_txt_K.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_K.Location = new System.Drawing.Point(467, 319);
            this.m_txt_K.Name = "m_txt_K";
            this.m_txt_K.Size = new System.Drawing.Size(33, 20);
            this.m_txt_K.TabIndex = 18;
            this.m_txt_K.Leave += new System.EventHandler(this.m_txt_K_Leave);
            // 
            // m_txt_Hex
            // 
            this.m_txt_Hex.Location = new System.Drawing.Point(327, 324);
            this.m_txt_Hex.MaxLength = 6;
            this.m_txt_Hex.Name = "m_txt_Hex";
            this.m_txt_Hex.Size = new System.Drawing.Size(61, 20);
            this.m_txt_Hex.TabIndex = 19;
            this.m_txt_Hex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txt_Hex_KeyPress);
            this.m_txt_Hex.Leave += new System.EventHandler(this.m_txt_Hex_Leave);
            // 
            // radioButtonHue
            // 
            this.radioButtonHue.AutoSize = true;
            this.radioButtonHue.Location = new System.Drawing.Point(314, 164);
            this.radioButtonHue.Name = "radioButtonHue";
            this.radioButtonHue.Size = new System.Drawing.Size(36, 17);
            this.radioButtonHue.TabIndex = 20;
            this.radioButtonHue.Text = "H:";
            this.radioButtonHue.CheckedChanged += new System.EventHandler(this.m_rbtn_Hue_CheckedChanged);
            // 
            // radioButtonSat
            // 
            this.radioButtonSat.AutoSize = true;
            this.radioButtonSat.Location = new System.Drawing.Point(314, 189);
            this.radioButtonSat.Name = "radioButtonSat";
            this.radioButtonSat.Size = new System.Drawing.Size(35, 17);
            this.radioButtonSat.TabIndex = 21;
            this.radioButtonSat.Text = "S:";
            this.radioButtonSat.CheckedChanged += new System.EventHandler(this.m_rbtn_Sat_CheckedChanged);
            // 
            // radioButtonBlack
            // 
            this.radioButtonBlack.AutoSize = true;
            this.radioButtonBlack.Location = new System.Drawing.Point(314, 214);
            this.radioButtonBlack.Name = "radioButtonBlack";
            this.radioButtonBlack.Size = new System.Drawing.Size(35, 17);
            this.radioButtonBlack.TabIndex = 22;
            this.radioButtonBlack.Text = "B:";
            this.radioButtonBlack.CheckedChanged += new System.EventHandler(this.m_rbtn_Black_CheckedChanged);
            // 
            // radioButtonRed
            // 
            this.radioButtonRed.AutoSize = true;
            this.radioButtonRed.Location = new System.Drawing.Point(314, 244);
            this.radioButtonRed.Name = "radioButtonRed";
            this.radioButtonRed.Size = new System.Drawing.Size(36, 17);
            this.radioButtonRed.TabIndex = 23;
            this.radioButtonRed.Text = "R:";
            this.radioButtonRed.CheckedChanged += new System.EventHandler(this.m_rbtn_Red_CheckedChanged);
            // 
            // radioButtonGreen
            // 
            this.radioButtonGreen.AutoSize = true;
            this.radioButtonGreen.Location = new System.Drawing.Point(314, 269);
            this.radioButtonGreen.Name = "radioButtonGreen";
            this.radioButtonGreen.Size = new System.Drawing.Size(36, 17);
            this.radioButtonGreen.TabIndex = 24;
            this.radioButtonGreen.Text = "G:";
            this.radioButtonGreen.CheckedChanged += new System.EventHandler(this.m_rbtn_Green_CheckedChanged);
            // 
            // radioButtonBlue
            // 
            this.radioButtonBlue.AutoSize = true;
            this.radioButtonBlue.Location = new System.Drawing.Point(314, 294);
            this.radioButtonBlue.Name = "radioButtonBlue";
            this.radioButtonBlue.Size = new System.Drawing.Size(35, 17);
            this.radioButtonBlue.TabIndex = 25;
            this.radioButtonBlue.Text = "B:";
            this.radioButtonBlue.CheckedChanged += new System.EventHandler(this.m_rbtn_Blue_CheckedChanged);
            // 
            // chkWebColorsOnly
            // 
            this.chkWebColorsOnly.AutoSize = true;
            this.chkWebColorsOnly.Location = new System.Drawing.Point(8, 298);
            this.chkWebColorsOnly.Name = "chkWebColorsOnly";
            this.chkWebColorsOnly.Size = new System.Drawing.Size(105, 17);
            this.chkWebColorsOnly.TabIndex = 26;
            this.chkWebColorsOnly.Text = "Only Web Colors";
            this.chkWebColorsOnly.CheckedChanged += new System.EventHandler(this.chkWebColorsOnly_CheckedChanged);
            // 
            // m_lbl_HexPound
            // 
            this.m_lbl_HexPound.Location = new System.Drawing.Point(313, 326);
            this.m_lbl_HexPound.Name = "m_lbl_HexPound";
            this.m_lbl_HexPound.Size = new System.Drawing.Size(19, 15);
            this.m_lbl_HexPound.TabIndex = 27;
            this.m_lbl_HexPound.Text = "#";
            // 
            // radioButtonL
            // 
            this.radioButtonL.AutoSize = true;
            this.radioButtonL.Enabled = false;
            this.radioButtonL.Location = new System.Drawing.Point(427, 164);
            this.radioButtonL.Name = "radioButtonL";
            this.radioButtonL.Size = new System.Drawing.Size(34, 17);
            this.radioButtonL.TabIndex = 28;
            this.radioButtonL.Text = "L:";
            // 
            // radioButtona
            // 
            this.radioButtona.AutoSize = true;
            this.radioButtona.Enabled = false;
            this.radioButtona.Location = new System.Drawing.Point(427, 189);
            this.radioButtona.Name = "radioButtona";
            this.radioButtona.Size = new System.Drawing.Size(34, 17);
            this.radioButtona.TabIndex = 29;
            this.radioButtona.Text = "a:";
            // 
            // radioButtonb
            // 
            this.radioButtonb.AutoSize = true;
            this.radioButtonb.Enabled = false;
            this.radioButtonb.Location = new System.Drawing.Point(427, 214);
            this.radioButtonb.Name = "radioButtonb";
            this.radioButtonb.Size = new System.Drawing.Size(34, 17);
            this.radioButtonb.TabIndex = 30;
            this.radioButtonb.Text = "b:";
            // 
            // m_lbl_Cyan
            // 
            this.m_lbl_Cyan.Location = new System.Drawing.Point(435, 249);
            this.m_lbl_Cyan.Name = "m_lbl_Cyan";
            this.m_lbl_Cyan.Size = new System.Drawing.Size(30, 18);
            this.m_lbl_Cyan.TabIndex = 31;
            this.m_lbl_Cyan.Text = "C:";
            this.m_lbl_Cyan.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lbl_Magenta
            // 
            this.m_lbl_Magenta.Location = new System.Drawing.Point(435, 273);
            this.m_lbl_Magenta.Name = "m_lbl_Magenta";
            this.m_lbl_Magenta.Size = new System.Drawing.Size(30, 18);
            this.m_lbl_Magenta.TabIndex = 32;
            this.m_lbl_Magenta.Text = "M:";
            this.m_lbl_Magenta.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lbl_Yellow
            // 
            this.m_lbl_Yellow.Location = new System.Drawing.Point(435, 297);
            this.m_lbl_Yellow.Name = "m_lbl_Yellow";
            this.m_lbl_Yellow.Size = new System.Drawing.Size(30, 18);
            this.m_lbl_Yellow.TabIndex = 33;
            this.m_lbl_Yellow.Text = "Y:";
            this.m_lbl_Yellow.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lbl_K
            // 
            this.m_lbl_K.Location = new System.Drawing.Point(435, 321);
            this.m_lbl_K.Name = "m_lbl_K";
            this.m_lbl_K.Size = new System.Drawing.Size(30, 18);
            this.m_lbl_K.TabIndex = 34;
            this.m_lbl_K.Text = "K:";
            this.m_lbl_K.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lbl_Primary_Color
            // 
            this.m_lbl_Primary_Color.BackColor = System.Drawing.Color.White;
            this.m_lbl_Primary_Color.Location = new System.Drawing.Point(315, 47);
            this.m_lbl_Primary_Color.Name = "m_lbl_Primary_Color";
            this.m_lbl_Primary_Color.Size = new System.Drawing.Size(58, 33);
            this.m_lbl_Primary_Color.TabIndex = 36;
            this.m_lbl_Primary_Color.Click += new System.EventHandler(this.m_lbl_Primary_Color_Click);
            // 
            // m_lbl_Secondary_Color
            // 
            this.m_lbl_Secondary_Color.BackColor = System.Drawing.Color.Silver;
            this.m_lbl_Secondary_Color.Location = new System.Drawing.Point(315, 80);
            this.m_lbl_Secondary_Color.Name = "m_lbl_Secondary_Color";
            this.m_lbl_Secondary_Color.Size = new System.Drawing.Size(58, 33);
            this.m_lbl_Secondary_Color.TabIndex = 37;
            this.m_lbl_Secondary_Color.Click += new System.EventHandler(this.m_lbl_Secondary_Color_Click);
            // 
            // m_lbl_Hue_Symbol
            // 
            this.m_lbl_Hue_Symbol.AutoSize = true;
            this.m_lbl_Hue_Symbol.Location = new System.Drawing.Point(387, 166);
            this.m_lbl_Hue_Symbol.Name = "m_lbl_Hue_Symbol";
            this.m_lbl_Hue_Symbol.Size = new System.Drawing.Size(11, 13);
            this.m_lbl_Hue_Symbol.TabIndex = 40;
            this.m_lbl_Hue_Symbol.Text = "°";
            // 
            // m_lbl_Saturation_Symbol
            // 
            this.m_lbl_Saturation_Symbol.AutoSize = true;
            this.m_lbl_Saturation_Symbol.Location = new System.Drawing.Point(387, 191);
            this.m_lbl_Saturation_Symbol.Name = "m_lbl_Saturation_Symbol";
            this.m_lbl_Saturation_Symbol.Size = new System.Drawing.Size(15, 13);
            this.m_lbl_Saturation_Symbol.TabIndex = 41;
            this.m_lbl_Saturation_Symbol.Text = "%";
            // 
            // m_lbl_Black_Symbol
            // 
            this.m_lbl_Black_Symbol.AutoSize = true;
            this.m_lbl_Black_Symbol.Location = new System.Drawing.Point(387, 216);
            this.m_lbl_Black_Symbol.Name = "m_lbl_Black_Symbol";
            this.m_lbl_Black_Symbol.Size = new System.Drawing.Size(15, 13);
            this.m_lbl_Black_Symbol.TabIndex = 42;
            this.m_lbl_Black_Symbol.Text = "%";
            // 
            // m_lbl_Cyan_Symbol
            // 
            this.m_lbl_Cyan_Symbol.AutoSize = true;
            this.m_lbl_Cyan_Symbol.Location = new System.Drawing.Point(499, 246);
            this.m_lbl_Cyan_Symbol.Name = "m_lbl_Cyan_Symbol";
            this.m_lbl_Cyan_Symbol.Size = new System.Drawing.Size(15, 13);
            this.m_lbl_Cyan_Symbol.TabIndex = 43;
            this.m_lbl_Cyan_Symbol.Text = "%";
            // 
            // m_lbl_Magenta_Symbol
            // 
            this.m_lbl_Magenta_Symbol.AutoSize = true;
            this.m_lbl_Magenta_Symbol.Location = new System.Drawing.Point(499, 271);
            this.m_lbl_Magenta_Symbol.Name = "m_lbl_Magenta_Symbol";
            this.m_lbl_Magenta_Symbol.Size = new System.Drawing.Size(15, 13);
            this.m_lbl_Magenta_Symbol.TabIndex = 44;
            this.m_lbl_Magenta_Symbol.Text = "%";
            // 
            // m_lbl_Yellow_Symbol
            // 
            this.m_lbl_Yellow_Symbol.AutoSize = true;
            this.m_lbl_Yellow_Symbol.Location = new System.Drawing.Point(499, 296);
            this.m_lbl_Yellow_Symbol.Name = "m_lbl_Yellow_Symbol";
            this.m_lbl_Yellow_Symbol.Size = new System.Drawing.Size(15, 13);
            this.m_lbl_Yellow_Symbol.TabIndex = 45;
            this.m_lbl_Yellow_Symbol.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(499, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "%";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(313, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "new";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(313, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "current";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_ctrl_BigBox
            // 
            this.m_ctrl_BigBox.BaseColorComponent = OpenPainter.ColorPicker.ColorComponent.Hue;
            this.m_ctrl_BigBox.Location = new System.Drawing.Point(8, 32);
            this.m_ctrl_BigBox.Name = "m_ctrl_BigBox";
            this.m_ctrl_BigBox.RGB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_ctrl_BigBox.Size = new System.Drawing.Size(260, 260);
            this.m_ctrl_BigBox.TabIndex = 39;
            this.m_ctrl_BigBox.WebSafeColorsOnly = false;
            this.m_ctrl_BigBox.SelectionChanged += new System.EventHandler(this.m_ctrl_BigBox_SelectionChanged);
            // 
            // m_ctrl_ThinBox
            // 
            this.m_ctrl_ThinBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctrl_ThinBox.BaseColorComponent = OpenPainter.ColorPicker.ColorComponent.Hue;
            this.m_ctrl_ThinBox.Location = new System.Drawing.Point(269, 30);
            this.m_ctrl_ThinBox.Name = "m_ctrl_ThinBox";
            this.m_ctrl_ThinBox.RGB = System.Drawing.Color.Red;
            this.m_ctrl_ThinBox.Size = new System.Drawing.Size(40, 264);
            this.m_ctrl_ThinBox.TabIndex = 38;
            this.m_ctrl_ThinBox.WebSafeColorsOnly = false;
            this.m_ctrl_ThinBox.SelectionChanged += new System.EventHandler(this.m_ctrl_ThinBox_SelectionChanged);
            // 
            // ColorPickerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.m_cmd_Cancel;
            this.ClientSize = new System.Drawing.Size(539, 357);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txt_Hex);
            this.Controls.Add(this.m_ctrl_BigBox);
            this.Controls.Add(this.m_ctrl_ThinBox);
            this.Controls.Add(this.m_lbl_Secondary_Color);
            this.Controls.Add(this.m_lbl_Primary_Color);
            this.Controls.Add(this.m_lbl_K);
            this.Controls.Add(this.m_lbl_Yellow);
            this.Controls.Add(this.m_lbl_Magenta);
            this.Controls.Add(this.m_lbl_Cyan);
            this.Controls.Add(this.radioButtonb);
            this.Controls.Add(this.radioButtona);
            this.Controls.Add(this.radioButtonL);
            this.Controls.Add(this.m_lbl_HexPound);
            this.Controls.Add(this.chkWebColorsOnly);
            this.Controls.Add(this.radioButtonBlue);
            this.Controls.Add(this.radioButtonGreen);
            this.Controls.Add(this.radioButtonRed);
            this.Controls.Add(this.radioButtonBlack);
            this.Controls.Add(this.radioButtonSat);
            this.Controls.Add(this.radioButtonHue);
            this.Controls.Add(this.m_txt_K);
            this.Controls.Add(this.m_txt_Yellow);
            this.Controls.Add(this.m_txt_Magenta);
            this.Controls.Add(this.textBoxCyan);
            this.Controls.Add(this.m_txt_b);
            this.Controls.Add(this.m_txt_a);
            this.Controls.Add(this.m_txt_Lum);
            this.Controls.Add(this.m_txt_Blue);
            this.Controls.Add(this.m_txt_Green);
            this.Controls.Add(this.m_txt_Red);
            this.Controls.Add(this.m_txt_Black);
            this.Controls.Add(this.m_txt_Sat);
            this.Controls.Add(this.m_txt_Hue);
            this.Controls.Add(this.m_cmd_Cancel);
            this.Controls.Add(this.m_cmd_OK);
            this.Controls.Add(this.m_pbx_BlankBox);
            this.Controls.Add(this.m_lbl_Black_Symbol);
            this.Controls.Add(this.m_lbl_Saturation_Symbol);
            this.Controls.Add(this.m_lbl_Hue_Symbol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_lbl_Yellow_Symbol);
            this.Controls.Add(this.m_lbl_Magenta_Symbol);
            this.Controls.Add(this.m_lbl_Cyan_Symbol);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorPickerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Color Picker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
