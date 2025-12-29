using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Watermarks;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.QuickStart
{
    public static class HelloWorld
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Quick start] # HelloWorld");

            string documentPath = Constants.SamplePdf; // NOTE: Put here actual path for your document

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Big bold font for a strong, visible watermark
                Font font = new Font("Arial", 72, FontStyle.Bold);

                // Create text watermark
                TextWatermark watermark = new TextWatermark("CONFIDENTIAL", font)
                {
                    // Appearance
                    ForegroundColor = Color.Red,
                    Opacity = 0.2,          // 0 = fully transparent, 1 = solid
                    RotateAngle = 55,           // diagonal

                    // Positioning
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    SizingType = SizingType.ScaleToParentDimensions,
                    ScaleFactor = 1           // cover most of the page
                };

                watermarker.Add(watermark);
                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
