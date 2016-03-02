/*
 *  ctrl2DColorBox.cs
 *  
 *  Copyright (c) 2007-2010, OpenPainter.org, and based on the work of
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
/*****     Filename:          ctrl2DColorBox.cs               *****/
/*****     Original Author:   Danny Blanchard                 *****/
/*****                        - scrabcakes@gmail.com          *****/
/*****     Updates:	                                          *****/
/*****      3/28/2005 - Initial Version : Danny Blanchard     *****/
/*****      July 2010 - Updated by OpenPainter.org            *****/
/*****                                                        *****/
/******************************************************************/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace OpenPainter.ColorPicker
{
    /// <summary>
    /// The 2D Square with a circle marker for selecting colors.
    /// </summary>
    public class ColorBox2D : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorBox2D"/> class.
        /// </summary>
		public ColorBox2D()
        {
            this.Name = "ColorBox2D";
            this.Size = new Size(260, 260);

            //	Initialize Colors
            hsb = new HSB(1, 1, 1);
            rgb = hsb.ToRGB();

            baseColorComponent = ColorComponent.Hue;
        }

        private ColorComponent baseColorComponent = ColorComponent.Hue;
        /// <summary>
        /// Gets or sets the base color component which is fixed.
        /// </summary>
        public ColorComponent BaseColorComponent
        {
            get { return baseColorComponent; }
            set
            {
                baseColorComponent = value;

                // Redraw the control based on the new color component.
                ResetMarker(true);
                RedrawAll();
            }
        }

        private HSB hsb;
        /// <summary>
        /// Gets or sets the color in HSB mode. <see cref="RGB"/> property will be accordingly updated.
        /// </summary>
        public HSB HSB
        {
            get { return hsb; }
            set
            {
                hsb = value;
                rgb = hsb.ToRGB();

                //	Redraw the control based on the new color.
                ResetMarker(true);
                RedrawAll();
            }
        }

        private Color rgb;
        /// <summary>
        /// Gets or sets the color in RGB mode. <see cref="HSB"/> property will be accordingly updated.
        /// </summary>
        public Color RGB
        {
            get { return rgb; }
            set
            {
                rgb = value;
                hsb = rgb.ToHSB();

                //	Redraw the control based on the new color.
                ResetMarker(true);
                RedrawAll();
            }
        }

        private bool webSafeColorsOnly = false;
        /// <summary>
        /// Gets or sets a boolean value that indicates where only the web colors are available.
        /// </summary>
        public bool WebSafeColorsOnly
        {
            get { return webSafeColorsOnly; }
            set
            {
                webSafeColorsOnly = value;
                RedrawAll();
            }
        }

        #region User Input

        private int lastMarkerX = 0;
        private int lastMarkerY = 0;
        private bool isDragging = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button.HasFlag(MouseButtons.Left))
            {
                isDragging = true;
                MarkerMoved(e.X - 2, e.Y - 2);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (isDragging)
            {
                MarkerMoved(e.X - 2, e.Y - 2);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button.HasFlag(MouseButtons.Left) && isDragging)
            {
                isDragging = false;
                MarkerMoved(e.X - 2, e.Y - 2);
            }
        }

        private void MarkerMoved(int x, int y)
        {
            x = x.LimitInRange(0, 255);
            y = y.LimitInRange(0, 255);

            if (x == lastMarkerX && y == lastMarkerY)
            {
                //	If the marker hasn't moved, no need to redraw it.
                //	or send a scroll notification
                return;
            }

            // Redraw the marker.
            DrawMarker(x, y, true);
            // Reset the color.
            ResetHSLRGB();

            OnSelectionChanged(EventArgs.Empty);
        }

        #endregion

        #region Control Event Overrides
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            RedrawAll();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the selected color has been changed.
        /// </summary>
        public event EventHandler SelectionChanged;

        /// <summary>
        /// Raises the <see cref="SelectionChanged"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnSelectionChanged(EventArgs e)
        {
            if (SelectionChanged != null)
                SelectionChanged(this, e);
        }

        #endregion

        #region Rendering

        private void ClearMarker()
        {
            int x1 = lastMarkerX - 5;
            int y1 = lastMarkerY - 5;
            int x2 = lastMarkerX + 5;
            int y2 = lastMarkerY + 5;

            x1 = Math.Max(0, x1);
            y1 = Math.Max(0, y1);
            x2 = Math.Min(x2, 255);
            y2 = Math.Min(y2, 255);

            Rectangle rect = new Rectangle(
                x1,
                y1,
                x2 - x1 + 1,
                y2 - y1 + 1);

            Bitmap map = GetColorPlaneBitmap(rect, baseColorComponent);

            Graphics g = this.CreateGraphics();
            g.DrawImageUnscaled(map, x1 + 2, y1 + 2);

            map.Dispose();
        }

        private void DrawMarker(int x, int y, bool force)
        {
            x = x.LimitInRange(0, 255);
            y = y.LimitInRange(0, 255);

            if (lastMarkerY == y && lastMarkerX == x && !force)
            {
                return;
            }

            ClearMarker();

            lastMarkerX = x;
            lastMarkerY = y;

            Graphics g = this.CreateGraphics();

            //	The selected color determines the color of the marker drawn over
            //	it (black or white)
            Pen pen;
            HSB _hsl = GetColor(x, y);
            if (_hsl.B < (double)200 / 255)
            {
                pen = new Pen(Color.White);									//	White marker if selected color is dark
            }
            else if (_hsl.H < (double)26 / 360 || _hsl.H > (double)200 / 360)
            {
                if (_hsl.S > (double)70 / 255)
                {
                    pen = new Pen(Color.White);
                }
                else
                {
                    pen = new Pen(Color.Black);								//	Else use a black marker for lighter colors
                }
            }
            else
            {
                pen = new Pen(Color.Black);
            }

            g.DrawEllipse(pen, x - 3, y - 3, 10, 10);                       //	Draw the marker : 11 x 11 circle

            DrawBorder();       //	Force the border to be redrawn, just in case the marker has been drawn over it.
        }

        private void DrawBorder()
        {
            Graphics g = this.CreateGraphics();

            Pen pencil;

            //	To make the control look like Adobe Photoshop's the border around the control will be a gray line
            //	on the top and left side, a white line on the bottom and right side, and a black rectangle (line) 
            //	inside the gray/white rectangle

            pencil = new Pen(Color.FromArgb(172, 168, 153));	//	The same gray color used by Photoshop
            g.DrawLine(pencil, this.Width - 2, 0, 0, 0);	//	Draw top line
            g.DrawLine(pencil, 0, 0, 0, this.Height - 2);	//	Draw left hand line

            pencil = new Pen(Color.White);
            g.DrawLine(pencil, this.Width - 1, 0, this.Width - 1, this.Height - 1);	//	Draw right hand line
            g.DrawLine(pencil, this.Width - 1, this.Height - 1, 0, this.Height - 1);	//	Draw bottome line

            pencil = new Pen(Color.Black);
            g.DrawRectangle(pencil, 1, 1, this.Width - 3, this.Height - 3);	//	Draw inner black rectangle
        }

        private void DrawContent()
        {
            Rectangle rect = new Rectangle(0, 0, 256, 256);
            Bitmap map = GetColorPlaneBitmap(rect, baseColorComponent);

            Graphics g = this.CreateGraphics();
            g.DrawImageUnscaled(map, 2, 2);

            map.Dispose();
        }

        private Bitmap GetColorPlaneBitmap(Rectangle rect, ColorComponent comp)
        {
            Bitmap map = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);
            BitmapData mapData = map.LockBits(
                new Rectangle(0, 0, map.Width, map.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* pt0 = (byte*)mapData.Scan0;

                Parallel.For(rect.Top, rect.Bottom, y =>
                {
                    int bitmapY = y - rect.Top;

                    for (int x = rect.Left; x < rect.Right; x++)
                    {
                        int bitmapX = x - rect.Left;

                        Color color;
                        switch (comp)
                        {
                            case ColorComponent.Hue:
                                color = AdobeColors.ToRGB(new HSB(
                                    hsb.H,
                                    x / 255.0,
                                    1 - y / 255.0));
                                break;

                            case ColorComponent.Saturation:
                                color = AdobeColors.ToRGB(new HSB(
                                    x / 255.0,
                                    hsb.S,
                                    1 - y / 255.0));
                                break;

                            case ColorComponent.Brightness:
                                color = AdobeColors.ToRGB(new HSB(
                                    x / 255.0,
                                    1 - y / 255.0,
                                    hsb.B));
                                break;

                            case ColorComponent.Red:
                                color = Color.FromArgb(
                                    rgb.R,
                                    x,
                                    255 - y);
                                break;

                            case ColorComponent.Green:
                                color = Color.FromArgb(
                                    x,
                                    rgb.G,
                                    255 - y);
                                break;

                            case ColorComponent.Blue:
                                color = Color.FromArgb(
                                    x,
                                    255 - y,
                                    rgb.B);
                                break;

                            default:
                                throw new ArgumentException();
                        }

                        if (webSafeColorsOnly)
                        {
                            color = color.GetNearestWebSafeColor();
                        }

                        byte* pt = pt0 + mapData.Stride * bitmapY + 3 * bitmapX;
                        pt[2] = color.R;
                        pt[1] = color.G;
                        pt[0] = color.B;
                    }
                });
            }

            map.UnlockBits(mapData);
            return map;
        }

        private void RedrawAll()
        {
            DrawBorder();
            DrawContent();
            DrawMarker(lastMarkerX, lastMarkerY, true);
        }

        private void ResetMarker(bool redraw)
        {
            switch (baseColorComponent)
            {
                case ColorComponent.Hue:
                    lastMarkerX = (int)Math.Round(255 * hsb.S);
                    lastMarkerY = (int)Math.Round(255 * (1.0 - hsb.B));
                    break;

                case ColorComponent.Saturation:
                    lastMarkerX = (int)Math.Round(255 * hsb.H);
                    lastMarkerY = (int)Math.Round(255 * (1.0 - hsb.B));
                    break;

                case ColorComponent.Brightness:
                    lastMarkerX = (int)Math.Round(255 * hsb.H);
                    lastMarkerY = (int)Math.Round(255 * (1.0 - hsb.S));
                    break;

                case ColorComponent.Red:
                    lastMarkerX = rgb.B;
                    lastMarkerY = 255 - rgb.G;
                    break;

                case ColorComponent.Green:
                    lastMarkerX = rgb.B;
                    lastMarkerY = 255 - rgb.R;
                    break;

                case ColorComponent.Blue:
                    lastMarkerX = rgb.R;
                    lastMarkerY = 255 - rgb.G;
                    break;
            }

            if (redraw)
            {
                DrawMarker(lastMarkerX, lastMarkerY, true);
            }
        }

        private void ResetHSLRGB()
        {
            switch (baseColorComponent)
            {
                case ColorComponent.Hue:
                    hsb.S = lastMarkerX / 255.0;
                    hsb.B = 1.0 - lastMarkerY / 255.0;
                    rgb = hsb.ToRGB();
                    break;

                case ColorComponent.Saturation:
                    hsb.H = lastMarkerX / 255.0;
                    hsb.B = 1.0 - lastMarkerY / 255.0;
                    rgb = hsb.ToRGB();
                    break;

                case ColorComponent.Brightness:
                    hsb.H = lastMarkerX / 255.0;
                    hsb.S = 1.0 - lastMarkerY / 255.0;
                    rgb = hsb.ToRGB();
                    break;

                case ColorComponent.Red:
                    rgb = Color.FromArgb(rgb.R, 255 - lastMarkerY, lastMarkerX);
                    hsb = rgb.ToHSB();
                    break;

                case ColorComponent.Green:
                    rgb = Color.FromArgb(255 - lastMarkerY, rgb.G, lastMarkerX);
                    hsb = rgb.ToHSB();
                    break;

                case ColorComponent.Blue:
                    rgb = Color.FromArgb(lastMarkerX, 255 - lastMarkerY, rgb.B);
                    hsb = rgb.ToHSB();
                    break;
            }
        }

        private HSB GetColor(int x, int y)
        {
            HSB _hsb = new HSB();

            switch (baseColorComponent)
            {
                case ColorComponent.Hue:
                    _hsb.H = _hsb.H;
                    _hsb.S = x / 255.0;
                    _hsb.B = 1.0 - y / 255.0;
                    break;

                case ColorComponent.Saturation:
                    _hsb.S = _hsb.S;
                    _hsb.H = x / 255.0;
                    _hsb.B = 1.0 - (double)y / 255;
                    break;

                case ColorComponent.Brightness:
                    _hsb.B = _hsb.B;
                    _hsb.H = x / 255.0;
                    _hsb.S = 1.0 - (double)y / 255;
                    break;

                case ColorComponent.Red:
                    _hsb = AdobeColors.ToHSB(Color.FromArgb(rgb.R, 255 - y, x));
                    break;

                case ColorComponent.Green:
                    _hsb = AdobeColors.ToHSB(Color.FromArgb(255 - y, rgb.G, x));
                    break;

                case ColorComponent.Blue:
                    _hsb = AdobeColors.ToHSB(Color.FromArgb(x, 255 - y, rgb.B));
                    break;
            }

            return _hsb;
        }

        #endregion
    }
}
