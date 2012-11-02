﻿/*
 * Piczard Examples | ExampleSet -A- C#
 * Copyright 2011-2012 Sergio Turolla - All Rights Reserved.
 * Author: Sergio Turolla
 * <codecarvings.com>
 *  
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF 
 * ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
 * TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT 
 * SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR 
 * ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN 
 * ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE 
 * OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

using CodeCarvings.Piczard;
using CodeCarvings.Piczard.Processing;
using CodeCarvings.Piczard.Helpers;

// Custom ImageProcessingFilter (Used by Example A.401)
// NOTE: This filter does not implement JSON serialziation
// (Please see the the "MyRotationFilter" class for a JSON serialization example)
[Serializable]
public class MyCustomFilter1
    : ImageProcessingFilter
{

    #region Constructors

    public MyCustomFilter1()
        : base()
    {
    }

    #endregion

    #region Overriedes

    protected override void Apply(ImageProcessingActionExecuteArgs args)
    {
        Bitmap result = null;
        try
        {
            // Create the result image
            result = new Bitmap(350, 350, CodeCarvings.Piczard.CommonData.DefaultPixelFormat);

            // Set the right image resolution (DPI)
            ImageHelper.SetImageResolution(result, args.ImageProcessingJob.OutputResolution);

            using (Graphics g = Graphics.FromImage(result))
            {
                // Use the max quality
                ImageHelper.SetGraphicsMaxQuality(g);

                if ((args.IsLastAction) && (!args.AppliedImageBackColorValue.HasValue))
                {
                    // Optimization (not mandatory)
                    // This is the last filter action and the ImageBackColor has not been yet applied...
                    // Apply the ImageBackColor now to save RAM & CPU
                    args.ApplyImageBackColor(g);
                }

                using (ImageAttributes imageAttributes = new ImageAttributes())
                {
                    // Important
                    imageAttributes.SetWrapMode(WrapMode.TileFlipXY);

                    // Draw the scaled image
                    Rectangle destinationRectangle = new Rectangle(75, 52, 200, 200);
                    using (Image resizedImage = new FixedCropConstraint(GfxUnit.Pixel, destinationRectangle.Size).GetProcessedImage(args.Image))
                    {
                        g.DrawImage(resizedImage, destinationRectangle, 0, 0, resizedImage.Width, resizedImage.Height, GraphicsUnit.Pixel, imageAttributes);

                        // Draw the reflection
                        destinationRectangle = new Rectangle(75, 252, 200, 98);
                        using (Image flippedImage = ImageTransformation.FlipVertical.GetProcessedImage(resizedImage))
                        {
                            g.DrawImage(flippedImage, destinationRectangle, 0, 0, flippedImage.Width, flippedImage.Height, GraphicsUnit.Pixel, imageAttributes);
                        }
                    }

                    // Draw the mask
                    destinationRectangle = new Rectangle(0, 0, result.Width, result.Height);
                    using (LoadedImage loadedImage = ImageArchiver.LoadImage("~/repository/filters/MyCustomFilter1Mask.png"))
                    {
                        g.DrawImage(loadedImage.Image, destinationRectangle, 0, 0, loadedImage.Size.Width, loadedImage.Size.Height, GraphicsUnit.Pixel, imageAttributes);
                    }
                }

                // Draw the text
                string text = "Generated by 'MyCustomFilter1' on " + DateTime.Now.ToString();
                FontDefinition fontDefinition = new FontDefinition();
                fontDefinition.Size = 12; //12px
                using (Font font = fontDefinition.GetFont())
                {
                    // Setup the custom parameters
                    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    using (StringFormat stringFormat = new StringFormat())
                    {
                        SizeF textSize = g.MeasureString(text, font, int.MaxValue, stringFormat);
                        Size pixelTextSize = new Size(Convert.ToInt32(Math.Round(textSize.Width)), Convert.ToInt32(Math.Round(textSize.Height)));

                        // Calculate the text position
                        Point location = new Point((result.Width - pixelTextSize.Width) / 2, result.Height - 14 - pixelTextSize.Height);

                        // Draw the text
                        using (Brush brush = new SolidBrush(ColorTranslator.FromHtml("#5b615d")))
                        {
                            g.DrawString(text, font, brush, location, stringFormat);
                        }
                    }
                }
            }

            // Return the image
            args.Image = result;
        }
        catch
        {
            // An error has occurred...

            // Release the resources
            if (result != null)
            {
                result.Dispose();
                result = null;
            }

            // Re-throw the exception
            throw;
        }
    }

    #endregion

}
