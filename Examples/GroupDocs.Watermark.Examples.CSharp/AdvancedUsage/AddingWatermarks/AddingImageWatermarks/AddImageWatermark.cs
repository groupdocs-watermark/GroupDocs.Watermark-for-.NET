using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingImageWatermarks
{
    /// <summary>
    /// This example shows how to add image watermark from a local file.
    /// </summary>
    public static class AddImageWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddImageWatermark).Name}\n");

            string documentPath = Constants.InPresentationPptx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Use path to the image as constructor parameter
                using (ImageWatermark watermark = new ImageWatermark(Constants.WatermarkJpg))
                {
                    // Add watermark to the document
                    watermarker.Add(watermark);

                    watermarker.Save(outputFileName);
                }
            }
        }
    }
}
