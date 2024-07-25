using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example shows how to add text watermark to a document.
    /// </summary>
    public static class ReviewResultAboutAddedWatermarks
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(ReviewResultAboutAddedWatermarks).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Initialize the font to be used for watermark
                Font font = new Font("Arial", 19, FontStyle.Bold | FontStyle.Italic);

                // Create the watermark object
                TextWatermark watermark = new TextWatermark("Test watermark", font);

                // Set watermark properties
                watermark.ForegroundColor = Color.Red;
                watermark.BackgroundColor = Color.Blue;
                watermark.TextAlignment = TextAlignment.Right;
                watermark.Opacity = 0.5;

                // Add watermark
                var result =  watermarker.Add(watermark);
                foreach(var item in  result.Succeeded) 
                {
                    Console.WriteLine("WatermarkId: {0}", item.WatermarkId);
                    Console.WriteLine("WatermarkType: {0}", item.WatermarkType);
                    Console.WriteLine("PageNumber: {0}", item.PageNumber);
                    Console.WriteLine("WatermarkPosition: {0}", item.WatermarkPosition);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
