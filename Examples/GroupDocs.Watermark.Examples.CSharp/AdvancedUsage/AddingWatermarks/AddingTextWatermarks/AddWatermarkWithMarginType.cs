using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example shows how to set relative margins for a watermark.
    /// </summary>
    public static class AddWatermarkWithMarginType
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddWatermarkWithMarginType).Name}");

            string documentPath = Constants.InImagePng;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                Font font = new Font("Calibri", 12);
                TextWatermark watermark = new TextWatermark("Test watermark", font);
                watermark.HorizontalAlignment = HorizontalAlignment.Right;
                watermark.VerticalAlignment = VerticalAlignment.Bottom;

                // Set relative margins. Margin value will be interpreted as a portion
                // of appropriate parent dimension. If this type is chosen, margin value
                // must be between 0.0 and 1.0.
                watermark.Margins.MarginType = MarginType.RelativeToParentDimensions;
                watermark.Margins.Right = 0.1;
                watermark.Margins.Bottom = 0.2;

                watermarker.Add(watermark);
                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
