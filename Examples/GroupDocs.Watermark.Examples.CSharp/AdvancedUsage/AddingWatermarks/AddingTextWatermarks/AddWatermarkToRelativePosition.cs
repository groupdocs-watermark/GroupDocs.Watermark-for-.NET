using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example shows how to align the watermark vertically and horizontally.
    /// </summary>
    public static class AddWatermarkToRelativePosition
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddWatermarkToRelativePosition).Name}\n");

            string documentPath = Constants.InImagePng;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                Font font = new Font("Calibri", 12);
                TextWatermark watermark = new TextWatermark("Test watermark", font);
                watermark.HorizontalAlignment = HorizontalAlignment.Right;
                watermark.VerticalAlignment = VerticalAlignment.Bottom;

                // Set absolute margins. Values are measured in document units.
                watermark.Margins.Right = 10;
                watermark.Margins.Bottom = 5;

                watermarker.Add(watermark);
                watermarker.Save(outputFileName);
            }
        }
    }
}
