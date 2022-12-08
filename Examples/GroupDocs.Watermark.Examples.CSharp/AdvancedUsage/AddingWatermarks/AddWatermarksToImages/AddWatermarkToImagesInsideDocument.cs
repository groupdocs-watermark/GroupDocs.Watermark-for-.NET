// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Image;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToImages
{
    /// <summary>
    /// This example shows how to add watermark to images inside a document.
    /// </summary>
    public static class AddWatermarkToImagesInsideDocument
    {
        public static void Run()
        {
            //// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                // Initialize text watermark
                TextWatermark textWatermark = new TextWatermark("Protected image", new Font("Arial", 8));
                textWatermark.HorizontalAlignment = HorizontalAlignment.Center;
                textWatermark.VerticalAlignment = VerticalAlignment.Center;
                textWatermark.RotateAngle = 45;
                textWatermark.SizingType = SizingType.ScaleToParentDimensions;
                textWatermark.ScaleFactor = 1;

                // Initialize image watermark
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.ProtectJpg))
                {
                    imageWatermark.HorizontalAlignment = HorizontalAlignment.Center;
                    imageWatermark.VerticalAlignment = VerticalAlignment.Center;
                    imageWatermark.RotateAngle = -45;
                    imageWatermark.SizingType = SizingType.ScaleToParentDimensions;
                    imageWatermark.ScaleFactor = 1;

                    // Find all images in a document
                    WatermarkableImageCollection images = watermarker.GetImages();

                    for (int i = 0; i < images.Count; i++)
                    {
                        if (images[i].Width > 100 && images[i].Height > 100)
                        {
                            if (i % 2 == 0)
                            {
                                images[i].Add(textWatermark);
                            }
                            else
                            {
                                images[i].Add(imageWatermark);
                            }
                        }
                    }
                }

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
