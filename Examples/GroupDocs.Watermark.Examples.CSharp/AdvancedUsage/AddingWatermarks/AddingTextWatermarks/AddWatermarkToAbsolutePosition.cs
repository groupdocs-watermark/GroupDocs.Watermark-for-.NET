using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example shows how to add a text watermark with absolute positioning.
    /// </summary>
    public static class AddWatermarkToAbsolutePosition
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddWatermarkToAbsolutePosition).Name}\n");

            string documentPath = Constants.InImagePng;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                Font font = new Font("Times New Roman", 8);
                TextWatermark watermark = new TextWatermark("Test watermark", font);

                // Set watermark coordinates
                watermark.X = 10;
                watermark.Y = 20;

                // Set watermark size
                watermark.Width = 100;
                watermark.Height = 40;

                watermarker.Add(watermark);
                watermarker.Save(outputFileName);
            }
        }
    }
}