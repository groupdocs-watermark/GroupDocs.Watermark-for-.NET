using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Watermarks;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demostrates how to add a text watermark to a local document.
    /// </summary>
    public static class AddTextWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Basic Usage] # {typeof(AddTextWatermark).Name}");

            string documentPath = Constants.SampleDocx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                TextWatermark watermark = new TextWatermark("TOP SECRET\nDo not distribute", new Font("Arial", 36));
                watermark.ForegroundColor = Color.Red;
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.Y = 200;
                watermark.TextAlignment = TextAlignment.Center;
                watermark.Opacity = 0.5;
                watermarker.Add(watermark);
                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
