using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to set some additional options when adding shape watermark to a Word document.
    /// </summary>
    public static class WordProcessingAddWatermarkWithShapeSettings
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingAddWatermarkWithShapeSettings).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
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

                watermarker.Save(outputFileName);
            }
        }
    }
}
