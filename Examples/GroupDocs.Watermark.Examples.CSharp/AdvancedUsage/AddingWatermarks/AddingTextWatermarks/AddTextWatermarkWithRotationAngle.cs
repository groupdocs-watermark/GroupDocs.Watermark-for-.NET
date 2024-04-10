using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example show how to rotate a watermark.
    /// </summary>
    public static class AddTextWatermarkWithRotationAngle
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddTextWatermarkWithRotationAngle).Name}\n");

            string documentPath = Constants.InTestDocx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                Font font = new Font("Calibri", 8);
                TextWatermark watermark = new TextWatermark("Test watermark", font);
                watermark.HorizontalAlignment = HorizontalAlignment.Right;
                watermark.VerticalAlignment = VerticalAlignment.Top;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 0.5;

                // Set rotation angle
                watermark.RotateAngle = 45;

                watermarker.Add(watermark);
                watermarker.Save(outputFileName);
            }
        }
    }
}
