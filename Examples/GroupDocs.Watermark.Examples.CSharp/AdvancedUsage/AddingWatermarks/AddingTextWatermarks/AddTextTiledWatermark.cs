using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example shows how to add text watermark to a document.
    /// </summary>
    public static class AddTextTiledWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddTextTiledWatermark).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Initialize the font to be used for watermark
                Font font = new Font("Arial", 19, FontStyle.Bold | FontStyle.Italic);

                // Create the watermark object
                TextWatermark watermark = new TextWatermark("Test watermark", font);

                // Configure tile options
                watermark.TileOptions = new TileOptions()
                {
                    LineSpacing = new MeasureValue()
                    {
                        MeasureType = TileMeasureType.Percent,
                        Value = 12
                    },
                    WatermarkSpacing = new MeasureValue()
                    {
                        MeasureType = TileMeasureType.Percent,
                        Value = 10
                    },
                };

                // Set watermark properties
                watermark.ForegroundColor = Color.Red;
                watermark.BackgroundColor = Color.Blue;
                watermark.TextAlignment = TextAlignment.Right;
                watermark.Opacity = 0.5;

                // Add watermark
                watermarker.Add(watermark);

                watermarker.Save(outputFileName);
            }
        }
    }
}
