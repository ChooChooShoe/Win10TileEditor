/*
 *  frmColorPicker.cs
 *  
 *  Copyright (c) 2016, Timothy Durbano (timothy.durbano@gmail.com),
 *                based on the work of:
 *                2007-2010, OpenPainter.org, and
 *                2005 Danny Blanchard (scrabcakes@gmail.com)
 *  
 *  The contents of this file are subject to the Mozilla Public License
 *  Version 1.1 (the "License"); you may not use this file except in
 *  compliance with the License. You may obtain a copy of the License at
 *  
 *  http://www.mozilla.org/MPL/
 *  
 *  Software distributed under the License is distributed on an "AS IS"
 *  basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See
 *  the License for the specific language governing rights and limitations
 *  under the License.
 *  
 *  The Original Code is OpenPainter.
 *  
 *  The Initial Developer of the Original Code is OpenPainter.org.
 *  All Rights Reserved.
 */

/******************************************************************/
/*****                                                        *****/
/*****     Project:           Adobe Color Picker Clone 1      *****/
/*****     Filename:          frmColorPicker.cs               *****/
/*****     Original Author:   Danny Blanchard                 *****/
/*****                        - scrabcakes@gmail.com          *****/
/*****     Updates:	                                          *****/
/*****      3/28/2005 - Initial Version : Danny Blanchard     *****/
/*****      July 2010 - Updated by OpenPainter.org            *****/
/*****      Feb  2016 - Updated by timothy.durbano@gmail.com  *****/
/*****                                                        *****/
/******************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace OpenPainter.ColorPicker
{
    /// <summary>
    /// Summary description for frmColorPicker.
    /// </summary>
    public partial class ColorPickerForm : Form
    {
        private Color firstColor;
        private HSB hsl;
        private Color rgb;
        private CMYK cmyk;

        public ColorPickerForm(Color startingColor)
        {
            firstColor = startingColor;
            rgb = startingColor;
            hsl = rgb.ToHSB();
            cmyk = rgb.ToCMYK();

            InitializeComponent();

            UpdateTextBoxes();

            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;

            m_lbl_Primary_Color.BackColor = startingColor;
            m_lbl_Secondary_Color.BackColor = startingColor;

            radioButtonHue.Checked = true;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ColorPickerForm(Color.White));
        }

        public Color PrimaryColor
        {
            get { return rgb; }
            set
            {
                rgb = value;
                hsl = rgb.ToHSB();

                UpdateTextBoxes();

                m_ctrl_BigBox.HSB = hsl;
                m_ctrl_ThinBox.HSB = hsl;

                m_lbl_Primary_Color.BackColor = rgb;
            }
        }

        public ColorComponent DrawStyle
        {
            get
            {
                if (radioButtonHue.Checked)
                    return ColorComponent.Hue;
                else if (radioButtonSat.Checked)
                    return ColorComponent.Saturation;
                else if (radioButtonBlack.Checked)
                    return ColorComponent.Brightness;
                else if (radioButtonRed.Checked)
                    return ColorComponent.Red;
                else if (radioButtonGreen.Checked)
                    return ColorComponent.Green;
                else if (radioButtonBlue.Checked)
                    return ColorComponent.Blue;
                else
                    return ColorComponent.Hue;
            }
            set
            {
                switch (value)
                {
                    case ColorComponent.Hue:
                        radioButtonHue.Checked = true;
                        break;
                    case ColorComponent.Saturation:
                        radioButtonSat.Checked = true;
                        break;
                    case ColorComponent.Brightness:
                        radioButtonBlack.Checked = true;
                        break;
                    case ColorComponent.Red:
                        radioButtonRed.Checked = true;
                        break;
                    case ColorComponent.Green:
                        radioButtonGreen.Checked = true;
                        break;
                    case ColorComponent.Blue:
                        radioButtonBlue.Checked = true;
                        break;
                    default:
                        radioButtonHue.Checked = true;
                        break;
                }
            }
        }
        #region Events Handlers

        #region General Events


        private void m_cmd_OK_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void m_cmd_Cancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.PrimaryColor = this.firstColor;
            this.Close();
        }


        #endregion

        #region Primary Picture Box (m_ctrl_BigBox)

        private void m_ctrl_BigBox_SelectionChanged(object sender, System.EventArgs e)
        {
            hsl = m_ctrl_BigBox.HSB;
            rgb = hsl.ToRGB();
            cmyk = rgb.ToCMYK();

            UpdateTextBoxes();

            m_ctrl_ThinBox.HSB = hsl;

            m_lbl_Primary_Color.BackColor = rgb;
            m_lbl_Primary_Color.Update();
        }

        #endregion

        #region Secondary Picture Box (m_ctrl_ThinBox)

        private void m_ctrl_ThinBox_SelectionChanged(object sender, System.EventArgs e)
        {
            hsl = m_ctrl_ThinBox.HSB;
            rgb = hsl.ToRGB();
            cmyk = rgb.ToCMYK();

            UpdateTextBoxes();

            m_ctrl_BigBox.HSB = hsl;

            m_lbl_Primary_Color.BackColor = rgb;
            m_lbl_Primary_Color.Update();
        }

        #endregion

        #region Hex Box (m_txt_Hex)

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
                WriteHexData(rgb);
                return;
            }

            rgb = ParseHexData(text);
            hsl = rgb.ToHSB();
            cmyk = rgb.ToCMYK();

            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;
            m_lbl_Primary_Color.BackColor = rgb;

            UpdateTextBoxes();
        }


        #endregion

        #region Color Boxes

        private void m_lbl_Primary_Color_Click(object sender, System.EventArgs e)
        {
            rgb = m_lbl_Primary_Color.BackColor;
            hsl = rgb.ToHSB();

            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;

            cmyk = rgb.ToCMYK();

            UpdateTextBoxes();
        }

        private void m_lbl_Secondary_Color_Click(object sender, System.EventArgs e)
        {
            rgb = m_lbl_Secondary_Color.BackColor;
            hsl = rgb.ToHSB();

            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;

            m_lbl_Primary_Color.BackColor = rgb;
            m_lbl_Primary_Color.Update();

            cmyk = rgb.ToCMYK();

            UpdateTextBoxes();
        }

        #endregion

        #region Radio Buttons

        private void m_rbtn_Hue_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonHue.Checked)
            {
                m_ctrl_ThinBox.BaseColorComponent = ColorComponent.Hue;
                m_ctrl_BigBox.BaseColorComponent = ColorComponent.Hue;
            }
        }

        private void m_rbtn_Sat_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonSat.Checked)
            {
                m_ctrl_ThinBox.BaseColorComponent = ColorComponent.Saturation;
                m_ctrl_BigBox.BaseColorComponent = ColorComponent.Saturation;
            }
        }

        private void m_rbtn_Black_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonBlack.Checked)
            {
                m_ctrl_ThinBox.BaseColorComponent = ColorComponent.Brightness;
                m_ctrl_BigBox.BaseColorComponent = ColorComponent.Brightness;
            }
        }

        private void m_rbtn_Red_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonRed.Checked)
            {
                m_ctrl_ThinBox.BaseColorComponent = ColorComponent.Red;
                m_ctrl_BigBox.BaseColorComponent = ColorComponent.Red;
            }
        }

        private void m_rbtn_Green_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonGreen.Checked)
            {
                m_ctrl_ThinBox.BaseColorComponent = ColorComponent.Green;
                m_ctrl_BigBox.BaseColorComponent = ColorComponent.Green;
            }
        }

        private void m_rbtn_Blue_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonBlue.Checked)
            {
                m_ctrl_ThinBox.BaseColorComponent = ColorComponent.Blue;
                m_ctrl_BigBox.BaseColorComponent = ColorComponent.Blue;
            }
        }

        #endregion

        #region Text Boxes

        private void m_txt_Hue_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Hue.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                MessageBox.Show("Hue must be a number value between 0 and 360");
                UpdateTextBoxes();
                return;
            }

            int hue = int.Parse(text);

            if (hue < 0)
            {
                MessageBox.Show("An integer between 0 and 360 is required.\nClosest value inserted.");
                m_txt_Hue.Text = "0";
                hsl.H = 0.0;
            }
            else if (hue > 360)
            {
                MessageBox.Show("An integer between 0 and 360 is required.\nClosest value inserted.");
                m_txt_Hue.Text = "360";
                hsl.H = 1.0;
            }
            else
            {
                hsl.H = (double)hue / 360;
            }

            rgb = hsl.ToRGB();
            cmyk = rgb.ToCMYK();
            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;
            m_lbl_Primary_Color.BackColor = rgb;

            UpdateTextBoxes();
        }

        private void m_txt_Sat_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Sat.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                MessageBox.Show("Saturation must be a number value between 0 and 100");
                UpdateTextBoxes();
                return;
            }

            int sat = int.Parse(text);

            if (sat < 0)
            {
                MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
                m_txt_Sat.Text = "0";
                hsl.S = 0.0;
            }
            else if (sat > 100)
            {
                MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
                m_txt_Sat.Text = "100";
                hsl.S = 1.0;
            }
            else
            {
                hsl.S = (double)sat / 100;
            }

            rgb = hsl.ToRGB();
            cmyk = rgb.ToCMYK();
            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;
            m_lbl_Primary_Color.BackColor = rgb;

            UpdateTextBoxes();
        }

        private void m_txt_Black_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Black.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                MessageBox.Show("Brightness must be a number value between 0 and 100.");
                UpdateTextBoxes();
                return;
            }

            int lum = int.Parse(text);

            if (lum < 0)
            {
                MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
                m_txt_Black.Text = "0";
                hsl.B = 0.0;
            }
            else if (lum > 100)
            {
                MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
                m_txt_Black.Text = "100";
                hsl.B = 1.0;
            }
            else
            {
                hsl.B = (double)lum / 100;
            }

            rgb = hsl.ToRGB();
            cmyk = rgb.ToCMYK();
            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;
            m_lbl_Primary_Color.BackColor = rgb;

            UpdateTextBoxes();
        }

        private void m_txt_Red_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Red.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                MessageBox.Show("Red must be a number value between 0 and 255");
                UpdateTextBoxes();
                return;
            }

            int red = int.Parse(text);

            if (red < 0)
            {
                MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
                m_txt_Sat.Text = "0";
                rgb = Color.FromArgb(0, rgb.G, rgb.B);
            }
            else if (red > 255)
            {
                MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
                m_txt_Sat.Text = "255";
                rgb = Color.FromArgb(255, rgb.G, rgb.B);
            }
            else
            {
                rgb = Color.FromArgb(red, rgb.G, rgb.B);
            }

            hsl = rgb.ToHSB();
            cmyk = rgb.ToCMYK();
            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;
            m_lbl_Primary_Color.BackColor = rgb;

            UpdateTextBoxes();
        }

        private void m_txt_Green_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Green.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                MessageBox.Show("Green must be a number value between 0 and 255");
                UpdateTextBoxes();
                return;
            }

            int green = int.Parse(text);

            if (green < 0)
            {
                MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
                m_txt_Green.Text = "0";
                rgb = Color.FromArgb(rgb.R, 0, rgb.B);
            }
            else if (green > 255)
            {
                MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
                m_txt_Green.Text = "255";
                rgb = Color.FromArgb(rgb.R, 255, rgb.B);
            }
            else
            {
                rgb = Color.FromArgb(rgb.R, green, rgb.B);
            }

            hsl = rgb.ToHSB();
            cmyk = rgb.ToCMYK();
            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;
            m_lbl_Primary_Color.BackColor = rgb;

            UpdateTextBoxes();
        }

        private void m_txt_Blue_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Blue.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                MessageBox.Show("Blue must be a number value between 0 and 255");
                UpdateTextBoxes();
                return;
            }

            int blue = int.Parse(text);

            if (blue < 0)
            {
                MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
                m_txt_Blue.Text = "0";
                rgb = Color.FromArgb(rgb.R, rgb.G, 0);
            }
            else if (blue > 255)
            {
                MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
                m_txt_Blue.Text = "255";
                rgb = Color.FromArgb(rgb.R, rgb.G, 255);
            }
            else
            {
                rgb = Color.FromArgb(rgb.R, rgb.G, blue);
            }

            hsl = rgb.ToHSB();
            cmyk = rgb.ToCMYK();
            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;
            m_lbl_Primary_Color.BackColor = rgb;

            UpdateTextBoxes();
        }

        private void m_txt_Cyan_Leave(object sender, System.EventArgs e)
        {
            string text = textBoxCyan.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                MessageBox.Show("Cyan must be a number value between 0 and 100");
                UpdateTextBoxes();
                return;
            }

            int cyan = int.Parse(text);

            if (cyan < 0)
            {
                MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
                cmyk.C = 0.0;
            }
            else if (cyan > 100)
            {
                MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
                cmyk.C = 1.0;
            }
            else
            {
                cmyk.C = (double)cyan / 100;
            }

            rgb = cmyk.ToRGB();
            hsl = rgb.ToHSB();
            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;
            m_lbl_Primary_Color.BackColor = rgb;

            UpdateTextBoxes();
        }

        private void m_txt_Magenta_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Magenta.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                MessageBox.Show("Magenta must be a number value between 0 and 100");
                UpdateTextBoxes();
                return;
            }

            int magenta = int.Parse(text);

            if (magenta < 0)
            {
                MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
                m_txt_Magenta.Text = "0";
                cmyk.M = 0.0;
            }
            else if (magenta > 100)
            {
                MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
                m_txt_Magenta.Text = "100";
                cmyk.M = 1.0;
            }
            else
            {
                cmyk.M = (double)magenta / 100;
            }

            rgb = cmyk.ToRGB();
            hsl = rgb.ToHSB();
            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;
            m_lbl_Primary_Color.BackColor = rgb;

            UpdateTextBoxes();
        }

        private void m_txt_Yellow_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Yellow.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                MessageBox.Show("Yellow must be a number value between 0 and 100");
                UpdateTextBoxes();
                return;
            }

            int yellow = int.Parse(text);

            if (yellow < 0)
            {
                MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
                m_txt_Yellow.Text = "0";
                cmyk.Y = 0.0;
            }
            else if (yellow > 100)
            {
                MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
                m_txt_Yellow.Text = "100";
                cmyk.Y = 1.0;
            }
            else
            {
                cmyk.Y = (double)yellow / 100;
            }

            rgb = cmyk.ToRGB();
            hsl = rgb.ToHSB();
            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;
            m_lbl_Primary_Color.BackColor = rgb;

            UpdateTextBoxes();
        }

        private void m_txt_K_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_K.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                MessageBox.Show("Key must be a number value between 0 and 100");
                UpdateTextBoxes();
                return;
            }

            int key = int.Parse(text);

            if (key < 0)
            {
                MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
                m_txt_K.Text = "0";
                cmyk.K = 0.0;
            }
            else if (key > 100)
            {
                MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
                m_txt_K.Text = "100";
                cmyk.K = 1.0;
            }
            else
            {
                cmyk.K = (double)key / 100;
            }

            rgb = cmyk.ToRGB();
            hsl = rgb.ToHSB();
            m_ctrl_BigBox.HSB = hsl;
            m_ctrl_ThinBox.HSB = hsl;
            m_lbl_Primary_Color.BackColor = rgb;

            UpdateTextBoxes();
        }

        #endregion

        private void chkWebColorsOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWebColorsOnly.Checked)
            {
                rgb = rgb.GetNearestWebSafeColor();
                hsl = rgb.ToHSB();
                cmyk = rgb.ToCMYK();

                m_ctrl_BigBox.HSB = hsl;
                m_ctrl_ThinBox.HSB = hsl;
                m_lbl_Primary_Color.BackColor = rgb;

                UpdateTextBoxes();
            }

            m_ctrl_BigBox.WebSafeColorsOnly = chkWebColorsOnly.Checked;
            m_ctrl_ThinBox.WebSafeColorsOnly = chkWebColorsOnly.Checked;
        }

        #endregion

        #region Private Functions

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

        public event ColorChangeEventHandler ColorChange;
        public EventArgs e = EventArgs.Empty;
        public delegate void ColorChangeEventHandler(ColorPickerForm colorPicker, EventArgs e);

        private void UpdateTextBoxes()
        {
            m_txt_Hue.Text = ((int)Math.Round(hsl.H * 360)).ToString();
            m_txt_Sat.Text = ((int)Math.Round(hsl.S * 100)).ToString();
            m_txt_Black.Text = ((int)Math.Round(hsl.B * 100)).ToString();

            m_txt_Red.Text = rgb.R.ToString();
            m_txt_Green.Text = rgb.G.ToString();
            m_txt_Blue.Text = rgb.B.ToString();

            textBoxCyan.Text = ((int)Math.Round(cmyk.C * 100)).ToString();
            m_txt_Magenta.Text = ((int)Math.Round(cmyk.M * 100)).ToString();
            m_txt_Yellow.Text = ((int)Math.Round(cmyk.Y * 100)).ToString();
            m_txt_K.Text = ((int)Math.Round(cmyk.K * 100)).ToString();

            m_txt_Hue.Update();
            m_txt_Sat.Update();
            m_txt_Black.Update();

            m_txt_Red.Update();
            m_txt_Green.Update();
            m_txt_Blue.Update();

            textBoxCyan.Update();
            m_txt_Magenta.Update();
            m_txt_Yellow.Update();
            m_txt_K.Update();

            WriteHexData(rgb);
            if (ColorChange != null)
                ColorChange(this, e);
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}
