using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example shows how to consider the size of the page/slide/frame on which a watermark will be placed.
    /// </summary>
    public static class AddWatermarkWithSizeType
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddWatermarkWithSizeType).Name}\n");

            string documentPath = Constants.InImagePng;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                Font font = new Font("Calibri", 12);
                TextWatermark watermark = new TextWatermark("This is a test watermark", font);

                // Set sizing type
                watermark.SizingType = SizingType.ScaleToParentDimensions;

                // Set watermark scale
                watermark.ScaleFactor = 0.5;

                watermarker.Add(watermark);
                watermarker.Save(outputFileName);
            }
        }
    }
}
