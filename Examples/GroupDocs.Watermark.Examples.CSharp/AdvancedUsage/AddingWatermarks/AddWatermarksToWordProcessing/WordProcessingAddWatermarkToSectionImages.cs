// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    using Common;
    using Contents.Image;
    using Contents.WordProcessing;
    using Options.WordProcessing;
    using Watermarks;

    /// <summary>
    /// This example shows how to add watermark to the images that belong to a particular section.
    /// </summary>
    public static class WordProcessingAddWatermarkToSectionImages
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.RotateAngle = 45;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;

                // Get all images belonging to the first section
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                WatermarkableImageCollection images = content.Sections[0].FindImages();

                // Add watermark to all found images
                foreach (WatermarkableImage image in images)
                {
                    image.Add(watermark);
                }

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}