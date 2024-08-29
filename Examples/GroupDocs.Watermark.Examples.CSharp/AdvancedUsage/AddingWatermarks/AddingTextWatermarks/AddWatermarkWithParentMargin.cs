using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Watermarks;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example shows how to consider parent margins.
    /// </summary>
    public static class AddWatermarkWithParentMargin
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddWatermarkWithParentMargin).Name}");

            string documentPath = Constants.InInputVsdx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 42));
                watermark.HorizontalAlignment = HorizontalAlignment.Right;
                watermark.VerticalAlignment = VerticalAlignment.Top;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;
                watermark.RotateAngle = 45;
                watermark.ForegroundColor = Color.Red;
                watermark.BackgroundColor = Color.Aqua;

                // Add watermark considering parent margins
                watermark.ConsiderParentMargins = true;

                watermarker.Add(watermark);
                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
