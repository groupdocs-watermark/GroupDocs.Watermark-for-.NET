using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;
using GroupDocs.Watermark.Common;

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example shows how to add text watermark with a custom font to a document.
    /// </summary>
    public static class AddTextWatermarkWithCustomFont
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddTextWatermarkWithCustomFont).Name}");

            string documentPath = Constants.InImagePng;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));
            string fontsFolder = Path.GetFullPath(Constants.FontsPath);

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Initialize the font to be used for watermark
                Font font = new Font("OT Chekharda Bold Italic", fontsFolder, 36);

                // Create the watermark object
                TextWatermark watermark = new TextWatermark("Test watermark", font);

                // Set watermark properties
                watermark.ForegroundColor = Color.Blue;                
                watermark.Opacity = 0.4;

                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;

                // Add watermark
                watermarker.Add(watermark);

                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
