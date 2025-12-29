using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example shows how to add text watermark to a document.
    /// </summary>
    public static class AddTextTiledWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddTextTiledWatermark).Name}");

            string documentPath = Constants.SamplePdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Initialize the font to be used for watermark
                Font font = new Font("Arial", 10, FontStyle.Italic);

                string userEmail = "useremail@mail.com";
                string fileId = "1234-4a04-935f-3c83c3079a47";
                string disclaimer = "Confidential - Do not distribute - Subject to NDA";

                var watermarkText = $"{userEmail}\n{fileId}\n{disclaimer}";

                // Create the watermark object
                TextWatermark watermark = new TextWatermark(watermarkText, font);

                // Configure tile options
                watermark.TileOptions = new TileOptions()
                {
                    TileType = TileType.Straight,
                    RotateAroundOrigin = true,
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
                watermark.ForegroundColor = Color.Gray;
                watermark.Opacity = 0.4f;
                watermark.RotateAngle = -45.0;
                watermark.TextAlignment = TextAlignment.Center;

                // Add watermark
                watermarker.Add(watermark);

                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
