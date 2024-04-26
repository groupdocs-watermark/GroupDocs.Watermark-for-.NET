using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example shows how to add text watermark with a custom font to a document.
    /// </summary>
    public static class AddTextWatermarkWithCustomFont
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddTextWatermarkWithCustomFont).Name}\n");

            string documentPath = Constants.InImagePng;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));
            string fontsFolder = Path.GetFullPath(Constants.FontsPath);

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Initialize the font to be used for watermark
                Font font = new Font("OT Chekharda Bold Italic", fontsFolder, 36);

                // Create the watermark object
                TextWatermark watermark = new TextWatermark("Test watermark", font);

                // Set watermark properties
                watermark.ForegroundColor = Color.Blue;                
                watermark.Opacity = 0.5;

                watermark.X = 10;
                watermark.Y = 10;

                // Add watermark
                watermarker.Add(watermark);

                watermarker.Save(outputFileName);
            }
        }
    }
}
