// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to set some additional options when adding shape watermark to a Word document.
    /// </summary>
    public static class WordProcessingAddWatermarkWithShapeSettings
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

                //Some settings for watermark
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.RotateAngle = 25.0;
                watermark.ForegroundColor = Color.Red;
                watermark.Opacity = 1.0;

                WordProcessingWatermarkSectionOptions options = new WordProcessingWatermarkSectionOptions();

                // Set the shape name
                options.Name = "Shape 1";

                // Set the descriptive (alternative) text that will be associated with the shape
                options.AlternativeText = "Test watermark";

                watermarker.Add(watermark, options);

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}
