/*
 *  AdobeColors.cs
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
/*****     Filename:          AdobeColors.cs                  *****/
/*****     Original Author:   Danny Blanchard                 *****/
/*****                        - scrabcakes@gmail.com          *****/
/*****     Updates:	                                          *****/
/*****      3/28/2005 - Initial Version : Danny Blanchard     *****/
/*****           2010 - Updated by OpenPainter.org            *****/
/*****                                                        *****/
/******************************************************************/

using System;
using static System.Math;
using System.Drawing;

namespace OpenPainter.ColorPicker
{
    #region Adobe Color Methods

    /// <summary>
    /// Collection of helper methods for working with AdobeColors and System.Drawing.Colors.
    /// </summary>
    public static class AdobeColors
    {


        /// <summary> 
        /// Sets the absolute brightness of a colour 
        /// </summary> 
        /// <param name="c">Original colour</param> 
        /// <param name="brightness">The luminance level to impose</param> 
        /// <returns>an adjusted colour</returns> 
        public static Color SetBrightness(this Color c, double brightness)
        {
            HSB hsl = c.ToHSB();
            hsl.B = brightness;
            return hsl.ToRGB();
        }


        /// <summary> 
        /// Modifies an existing brightness level 
        /// </summary> 
        /// <remarks> 
        /// To reduce brightness use a number smaller than 1. To increase brightness use a number larger tnan 1 
        /// </remarks> 
        /// <param name="c">The original colour</param> 
        /// <param name="brightness">The luminance delta</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color ModifyBrightness(this Color c, double brightness)
        {
            HSB hsl = c.ToHSB();
            hsl.B *= brightness;
            return hsl.ToRGB();
        }


        /// <summary> 
        /// Sets the absolute saturation level 
        /// </summary> 
        /// <remarks>Accepted values 0-1</remarks> 
        /// <param name="c">An original colour</param> 
        /// <param name="Saturation">The saturation value to impose</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color SetSaturation(this Color c, double Saturation)
        {
            HSB hsl = c.ToHSB();
            hsl.S = Saturation;
            return hsl.ToRGB();
        }


        /// <summary> 
        /// Modifies an existing Saturation level 
        /// </summary> 
        /// <remarks> 
        /// To reduce Saturation use a number smaller than 1. To increase Saturation use a number larger tnan 1 
        /// </remarks> 
        /// <param name="c">The original colour</param> 
        /// <param name="Saturation">The saturation delta</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color ModifySaturation(this Color c, double Saturation)
        {
            HSB hsl = c.ToHSB();
            hsl.S *= Saturation;
            return hsl.ToRGB();
        }


        /// <summary> 
        /// Sets the absolute Hue level 
        /// </summary> 
        /// <remarks>Accepted values 0-1</remarks> 
        /// <param name="c">An original colour</param> 
        /// <param name="Hue">The Hue value to impose</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color SetHue(this Color c, double Hue)
        {
            HSB hsl = c.ToHSB();
            hsl.H = Hue;
            return hsl.ToRGB();
        }


        /// <summary> 
        /// Modifies an existing Hue level 
        /// </summary> 
        /// <remarks> 
        /// To reduce Hue use a number smaller than 1. To increase Hue use a number larger tnan 1 
        /// </remarks> 
        /// <param name="c">The original colour</param> 
        /// <param name="Hue">The Hue delta</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color ModifyHue(this Color c, double Hue)
        {
            HSB hsl = c.ToHSB();
            hsl.H *= Hue;
            return hsl.ToRGB();
        }


        /// <summary> 
        /// Converts a colour from HSL to RGB 
        /// </summary> 
        /// <remarks>Adapted from the algoritm in Foley and Van-Dam</remarks> 
        /// <param name="hsb">The HSL value</param> 
        /// <returns>A Color structure containing the equivalent RGB values</returns> 
        public static Color ToRGB(this HSB hsb)
        {
            int Max, Mid, Min;
            double q;

            Max = (int)Round(hsb.B * 255);
            Min = (int)Round((1.0 - hsb.S) * (hsb.B / 1.0) * 255);
            q = (double)(Max - Min) / 255;

            if (hsb.H >= 0 && hsb.H <= (double)1 / 6)
            {
                Mid = (int)Round(((hsb.H - 0) * q) * 1530 + Min);
                return Color.FromArgb(Max, Mid, Min);
            }
            else if (hsb.H <= (double)1 / 3)
            {
                Mid = (int)Round(-((hsb.H - (double)1 / 6) * q) * 1530 + Max);
                return Color.FromArgb(Mid, Max, Min);
            }
            else if (hsb.H <= 0.5)
            {
                Mid = (int)Round(((hsb.H - (double)1 / 3) * q) * 1530 + Min);
                return Color.FromArgb(Min, Max, Mid);
            }
            else if (hsb.H <= (double)2 / 3)
            {
                Mid = (int)Round(-((hsb.H - 0.5) * q) * 1530 + Max);
                return Color.FromArgb(Min, Mid, Max);
            }
            else if (hsb.H <= (double)5 / 6)
            {
                Mid = (int)Round(((hsb.H - (double)2 / 3) * q) * 1530 + Min);
                return Color.FromArgb(Mid, Min, Max);
            }
            else if (hsb.H <= 1.0)
            {
                Mid = (int)Round(-((hsb.H - (double)5 / 6) * q) * 1530 + Max);
                return Color.FromArgb(Max, Min, Mid);
            }
            else return Color.FromArgb(0, 0, 0);
        }


        /// <summary> 
        /// Converts RGB to HSL 
        /// </summary> 
        /// <remarks>Takes advantage of whats already built in to .NET by using the Color.GetHue, Color.GetSaturation and Color.GetBrightness methods</remarks> 
        /// <param name="c">A Color to convert</param> 
        /// <returns>An HSL value</returns> 
        public static HSB ToHSB(this Color c)
        {
            HSB hsl = new HSB();

            int Max, Min, Diff, Sum;

            //	Of our RGB values, assign the highest value to Max, and the Smallest to Min
            if (c.R > c.G) { Max = c.R; Min = c.G; }
            else { Max = c.G; Min = c.R; }
            if (c.B > Max) Max = c.B;
            else if (c.B < Min) Min = c.B;

            Diff = Max - Min;
            Sum = Max + Min;

            //	Luminance - a.k.a. Brightness - Adobe photoshop uses the logic that the
            //	site VBspeed regards (regarded) as too primitive = superior decides the 
            //	level of brightness.
            hsl.B = (double)Max / 255;

            //	Saturation
            if (Max == 0) hsl.S = 0;    //	Protecting from the impossible operation of division by zero.
            else hsl.S = (double)Diff / Max;    //	The logic of Adobe Photoshops is this simple.

            //	Hue		R is situated at the angel of 360 eller noll degrees; 
            //			G vid 120 degrees
            //			B vid 240 degrees
            double q;
            if (Diff == 0) q = 0; // Protecting from the impossible operation of division by zero.
            else q = (double)60 / Diff;

            if (Max == c.R)
            {
                if (c.G < c.B) hsl.H = (double)(360 + q * (c.G - c.B)) / 360;
                else hsl.H = (double)(q * (c.G - c.B)) / 360;
            }
            else if (Max == c.G) hsl.H = (double)(120 + q * (c.B - c.R)) / 360;
            else if (Max == c.B) hsl.H = (double)(240 + q * (c.R - c.G)) / 360;
            else hsl.H = 0.0;

            return hsl;
        }

        /// <summary>
        /// Converts RGB to CMYK
        /// </summary>
        /// <param name="rgb">A color to convert.</param>
        /// <returns>A CMYK object</returns>
        public static CMYK ToCMYK(this Color rgb)
        {
            double c = 1 - (rgb.R / 255.0);
            double m = 1 - (rgb.G / 255.0);
            double y = 1 - (rgb.B / 255.0);

            double K = Min(c, Min(m, y));

            if (K == 1)
            {
                return CMYK.Black;
            }
            else
            {
                var nK = 1 - K;
                return new CMYK((c - K) / nK, (m - K) / nK, (y - K) / nK, K);
            }
        }


        /// <summary>
        /// Converts CMYK to RGB
        /// </summary>
        /// <param name="cmyk">A color to convert</param>
        /// <returns>A Color object</returns>
        public static Color ToRGB(this CMYK cmyk)
        {         
            int r = (int)Round(255 * (1 - cmyk.C) * (1 - cmyk.K));
            int g = (int)Round(255 * (1 - cmyk.M) * (1 - cmyk.K));
            int b = (int)Round(255 * (1 - cmyk.Y) * (1 - cmyk.K));
            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Get nearest web safe color based on the given RGB color.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color GetNearestWebSafeColor(this Color color)
        {
            int r = (int)(Round(color.R / 255.0 * 5) / 5 * 255);
            int g = (int)(Round(color.G / 255.0 * 5) / 5 * 255);
            int b = (int)(Round(color.B / 255.0 * 5) / 5 * 255);

            return Color.FromArgb(r, g, b);
        }

        public static bool isRgbComponent(this ColorComponent c)
        {
            return c == ColorComponent.Red || c == ColorComponent.Green || c == ColorComponent.Blue;
        }

        public static bool isHsbComponent(this ColorComponent c)
        {
            return c == ColorComponent.Hue || c == ColorComponent.Saturation || c == ColorComponent.Brightness;
        }
    }

    #endregion

    #region HSB Color Struct

    public struct HSB
    {
        private double h, s, b;
        public HSB(double h, double s, double b)
        {
            this.h = h;
            this.s = s;
            this.b = b;
        }

        public double H
        {
            get { return h; }
            set { h = value.LimitInRange(0, 1); }
        }

        public double S
        {
            get { return s; }
            set { s = value.LimitInRange(0, 1); }
        }

        public double B
        {
            get { return b; }
            set { b = value.LimitInRange(0, 1); }
        }
    }

    #endregion

    #region CMYK Color Struct

    public struct CMYK
    {
        public static CMYK Black { get { return new CMYK(0, 0, 0, 1); } }

        private double c, m, y, k;

        /// <summary>
        /// For CMYK colors: cyan, magenta, yellow, and key (black)
        /// </summary>
        public CMYK(double c, double m, double y, double k)
        {
            this.c = c;
            this.m = m;
            this.y = y;
            this.k = k;
        }

        public double C
        {
            get { return c; }
            set { c = value.LimitInRange(0, 1); }
        }

        public double M
        {
            get { return m; }
            set { m = value.LimitInRange(0, 1); }
        }

        public double Y
        {
            get { return y; }
            set { y = value.LimitInRange(0, 1); }
        }

        public double K
        {
            get { return k; }
            set { k = value.LimitInRange(0, 1); }
        }
    }

    #endregion

    public enum ColorComponent { Hue, Saturation, Brightness, Red, Green, Blue, HSB, RGB }

    public static class MathExtensions
    {
        public static int LimitInRange(this int value, int min, int max)
        {
            if (value <= min)
                return min;
            else if (value >= max)
                return max;
            else
                return value;
        }
        public static double LimitInRange(this double value, double min, double max)
        {
            if (value < min)
            {
                Console.WriteLine("LimitInRange: Min {0} from value {1} ", min, value);
                return min;
            }
            else if (value > max)
            {
                Console.WriteLine("LimitInRange: Max {0} from value {1} ", max, value);
                return max;
            }
            else
                return value;
        }
    }
}
