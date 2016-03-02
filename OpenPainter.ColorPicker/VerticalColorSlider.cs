/*
 *  ctrlVerticalColorSlider.cs
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
/*****     Filename:          ctrlVerticalColorSlider.cs      *****/
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
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace OpenPainter.ColorPicker
{
	/// <summary>
	/// A vertical slider control that shows a range for a color property (a.k.a. Hue, Saturation, Brightness,
	/// Red, Green, Blue) and sends an event when the slider is changed.
	/// </summary>
	public class VerticalColorSlider : UserControl
	{
		public VerticalColorSlider()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			//	Initialize Colors
			hsb = new HSB(1.0, 1.0, 1.0);
			rgb = hsb.ToRGB();
			baseColorComponent = ColorComponent.Hue;
		}

        private ColorComponent baseColorComponent;
		/// <summary>
        /// Gets or sets the base color component which is fixed.
        /// </summary>
		public ColorComponent BaseColorComponent
		{
			get
			{
				return baseColorComponent;
			}
			set
			{
				baseColorComponent = value;

				//	Redraw the control based on the new ColorComponent
				SetSliderToContolColors(false);
				RedrawAll(CreateGraphics());
			}
		}

        private HSB	hsb;
		/// <summary>
        /// Gets or sets the color in HSB mode. <see cref="RGB"/> property will be accordingly updated.
        /// </summary>
		public HSB HSB
		{
			get
			{
				return hsb;
			}
			set
			{
				hsb = value;
				rgb = AdobeColors.ToRGB(hsb);

				//	Redraw the control based on the new color.
				SetSliderToContolColors(true);
                DrawContent(CreateGraphics());
            }
		}

        private Color rgb;
		/// <summary>
        /// Gets or sets the color in RGB mode. <see cref="HSB"/> property will be accordingly updated.
        /// </summary>
        public Color RGB
        {
            get
            {
                return rgb;
            }
            set
            {
                rgb = value;
                hsb = AdobeColors.ToHSB(rgb);

                //	Redraw the control based on the new color.
                SetSliderToContolColors(true);
                DrawContent(CreateGraphics());
            }
        }

        private bool webSafeColorsOnly = false;
        /// <summary>
        /// Gets or sets a boolean value that indicates where only the web colors are available.
        /// </summary>
        public bool WebSafeColorsOnly
        {
            get
            {
                return webSafeColorsOnly;
            }
            set
            {
                webSafeColorsOnly = value;
                RedrawAll(CreateGraphics());
            }
        }

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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // VerticalColorSlider
            // 
            this.MinimumSize = new System.Drawing.Size(22, 25);
            this.Name = "VerticalColorSlider";
            this.Size = new System.Drawing.Size(40, 264);
            //this.Load += new System.EventHandler(this.VerticalColorSlider_RedrawAll);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VerticalColorSlider_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VerticalColorSlider_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VerticalColorSlider_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VerticalColorSlider_MouseUp);
            this.Resize += new System.EventHandler(this.VerticalColorSlider_RedrawAll);
            this.ResumeLayout(false);

        }

        private void VerticalColorSlider_RedrawAll(object sender, EventArgs e)
        {
            Console.WriteLine("Redraw all event");
            RedrawAll(CreateGraphics());
        }
        private void VerticalColorSlider_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("Paint event");
            RedrawAll(e.Graphics);
        }

        #endregion

        #region User Input

        private int markerStartY = 0;
        private bool isDragging = false;

        private void VerticalColorSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                isDragging = true;
                SliderMoved(e.Y);
            }
        }
        private void VerticalColorSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                SliderMoved(e.Y);
            }
        }

        private void VerticalColorSlider_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                isDragging = false;
                SliderMoved(e.Y);
            }
        }

        private void SliderMoved(int y)
        {
            y -= 4;
            y = y.LimitInRange(0, this.Height - 9);

            if (y == markerStartY)
                return;

            DrawSlider(y, false, CreateGraphics()); //	Redraw the slider if needed
            
            //Updates the rgb / hsb color to the new location.

            double height = this.Height - 9;

            switch (baseColorComponent)
            {
                case ColorComponent.Hue:
                    hsb.H = 1.0 - (double)markerStartY / height;
                    rgb = hsb.ToRGB();
                    break;
                case ColorComponent.Saturation:
                    hsb.S = 1.0 - (double)markerStartY / height;
                    rgb = hsb.ToRGB();
                    break;
                case ColorComponent.Brightness:
                    hsb.B = 1.0 - (double)markerStartY / height;
                    rgb = hsb.ToRGB();
                    break;
                case ColorComponent.Red:
                    rgb = Color.FromArgb(255 - (int)Math.Round(255 * (double)markerStartY / height), rgb.G, rgb.B);
                    hsb = rgb.ToHSB();
                    break;
                case ColorComponent.Green:
                    rgb = Color.FromArgb(rgb.R, 255 - (int)Math.Round(255 * (double)markerStartY / height), rgb.B);
                    hsb = rgb.ToHSB();
                    break;
                case ColorComponent.Blue:
                    rgb = Color.FromArgb(rgb.R, rgb.G, 255 - (int)Math.Round(255 * (double)markerStartY / height));
                    hsb = rgb.ToHSB();
                    break;
            }

            OnSelectionChanged(EventArgs.Empty);
        }

        #endregion

        #region Rendering

        /// <summary>
        /// Redraws the background over the slider area on both sides of the control
        /// </summary>
        /// <param name="g">The Graphics to use when drawing</param>
        private void ClearSlider(Graphics g)
		{
			Brush brush = new SolidBrush(BackColor);
			g.FillRectangle(brush, 0, 0, 8, this.Height);				//	clear left hand slider
			g.FillRectangle(brush, this.Width - 8, 0, 8, this.Height);	//	clear right hand slider
		}

        /// <summary>
        /// Draws the slider arrows on both sides of the control.
        /// </summary>
        /// <param name="position">position value of the slider, lowest being at the bottom.  The range
        /// is between 0 and the controls height-9.  The values will be adjusted if too large/small</param>
        /// <param name="force">If force is true, the slider always drawn even if it has not moved since last draw.</param>
        /// <param name="g">The Graphics to use when drawing</param>
        private void DrawSlider(int position, bool force, Graphics g)
        {
            position = position.LimitInRange(0, this.Height - 9);

            if (markerStartY == position && !force)
                return;
            
            // Update the controls marker position.
            markerStartY = position;
            
            // Remove old slider.
            this.ClearSlider(g);		
            
            Pen pen = new Pen(Color.FromArgb(116, 114, 106));

            Point[] arrow = new Point[7];				//	 GGG
            arrow[0] = new Point(1, position);			//	G   G
            arrow[1] = new Point(3, position);			//	G    G
            arrow[2] = new Point(7, position + 4);		//	G     G
            arrow[3] = new Point(3, position + 8);		//	G      G
            arrow[4] = new Point(1, position + 8);		//	G     G
            arrow[5] = new Point(0, position + 7);		//	G    G
            arrow[6] = new Point(0, position + 1);		//	G   G
                                                        //	 GGG

            g.FillPolygon(Brushes.White, arrow);	//	Fill left arrow with white
            g.DrawPolygon(pen, arrow);	//	Draw left arrow border with gray

                                                                //	    GGG
            arrow[0] = new Point(this.Width - 2, position);		//	   G   G
            arrow[1] = new Point(this.Width - 4, position);		//	  G    G
            arrow[2] = new Point(this.Width - 8, position + 4);	//	 G     G
            arrow[3] = new Point(this.Width - 4, position + 8);	//	G      G
            arrow[4] = new Point(this.Width - 2, position + 8);	//	 G     G
            arrow[5] = new Point(this.Width - 1, position + 7);	//	  G    G
            arrow[6] = new Point(this.Width - 1, position + 1);	//	   G   G
                                                                //	    GGG

            g.FillPolygon(Brushes.White, arrow);	//	Fill right arrow with white
            g.DrawPolygon(pen, arrow);	//	Draw right arrow border with gray
        }

        /// <summary>
        /// Draws the border around the control, in this case the border around the content area between
        /// the slider arrows.
        /// </summary>
        /// <param name="g">The Graphics to use when drawing</param>
        private void DrawBorder(Graphics g)
        {
            //	To make the control look like Adobe Photoshop's the border around the control will be a gray line
            //	on the top and left side, a white line on the bottom and right side, and a black rectangle (line) 
            //	inside the gray/white rectangle

            Pen pen = new Pen(Color.FromArgb(172, 168, 153));	//	The same gray color used by Photoshop
            g.DrawLine(pen, this.Width - 10, 2, 9, 2);	//	Draw top line
            g.DrawLine(pen, 9, 2, 9, this.Height - 4);	//	Draw left hand line

            pen = new Pen(Color.White);
            g.DrawLine(pen, this.Width - 9, 2, this.Width - 9, this.Height - 3);	//	Draw right hand line
            g.DrawLine(pen, this.Width - 9, this.Height - 3, 9, this.Height - 3);	//	Draw bottome line

            pen = new Pen(Color.Black);
            g.DrawRectangle(pen, 10, 3, this.Width - 20, this.Height - 7);	//	Draw inner black rectangle
        }

        /// <summary>
        /// Evaluates the DrawStyle of the control and calls the appropriate
        /// drawing function for content
        /// </summary>
        /// <param name="g">The Graphics to use when drawing</param>
        private void DrawContent(Graphics g)
		{
            //40-21, 264-8
            Rectangle rect = new Rectangle(0, 0, Width - 21, 256);
            Bitmap map = GetColorStripBitmap(rect, baseColorComponent);
            
            g.DrawImage(map, 11, 4, Width-21, Height-8);

            map.Dispose();
        }

        private Bitmap GetColorStripBitmap(Rectangle rect, ColorComponent comp)
        {
            Bitmap map = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);
            BitmapData mapData = map.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            
            unsafe
            {
                byte* pt0 = (byte*)mapData.Scan0;

                Parallel.For(rect.Top, rect.Bottom, y =>
                {
                    double dy =(double)y / 256.0;

                    Color color;
                    switch (comp)
                    {
                        case ColorComponent.Hue:
                            color = new HSB(1.0 - dy, 1, 1).ToRGB();
                            break;
                        case ColorComponent.Saturation:
                            color = new HSB(hsb.H, 1.0 - dy, hsb.B).ToRGB();
                            break;
                        case ColorComponent.Brightness:
                            color = new HSB(hsb.H, hsb.S, 1.0 - dy).ToRGB();
                            break;
                        case ColorComponent.Red:
                            color = Color.FromArgb(255 - (int)Math.Round(255 * dy), rgb.G, rgb.B);
                            break;
                        case ColorComponent.Green:
                            color = Color.FromArgb(rgb.R, 255 - (int)Math.Round(255 * dy), rgb.B);
                            break;
                        case ColorComponent.Blue:
                            color = Color.FromArgb(rgb.R, rgb.G, 255 - (int)Math.Round(255 * dy));
                            break;
                        default:
                            throw new ArgumentException();
                    }

                    if (webSafeColorsOnly)
                        color = color.GetNearestWebSafeColor();

                    int bitmapY = y - rect.Top;
                    for (int x = 0; x < rect.Width; x++)
                    {
                        byte* pt = pt0 + mapData.Stride * bitmapY + 3 * x;
                        pt[2] = color.R;
                        pt[1] = color.G;
                        pt[0] = color.B;
                    }
                });
            }

            map.UnlockBits(mapData);
            return map;
        }
        
		private void RedrawAll(Graphics g)
		{
			DrawSlider(markerStartY, true, g);
            DrawContent(g);
            DrawBorder(g);
		}

		/// <summary>
		/// Resets the vertical position of the slider to match the controls color.  Gives the option of redrawing the slider.
		/// </summary>
		/// <param name="redraw">Set to true if you want the function to redraw the slider after determining the best position</param>
        private void SetSliderToContolColors(bool redraw)
        {
            int height = this.Height - 9;
            double val = 0;

            switch (baseColorComponent)
            {
                case ColorComponent.Hue:
                    val = hsb.H;
                    break;
                case ColorComponent.Saturation:
                    val = hsb.S;
                    break;
                case ColorComponent.Brightness:
                    val = hsb.B;
                    break;
                case ColorComponent.Red:
                    val = rgb.R / 255.0;
                    break;
                case ColorComponent.Green:
                    val = rgb.G / 255.0;
                    break;
                case ColorComponent.Blue:
                    val = rgb.B / 255.0;
                    break;
            }
            int lastMarkerStartY = markerStartY;
            markerStartY = height - (int)Math.Round(height * val);

            //Only force a redraw if the maker has moved
            if (redraw)
                DrawSlider(markerStartY, lastMarkerStartY != markerStartY, CreateGraphics());
        }

        

        #endregion

    }
}
