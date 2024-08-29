using GroupDocs.Watermark.Watermarks;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingImageWatermarks
{
    /// <summary>
    /// This example shows how to an image watermark from stream.
    /// </summary>
    public static class AddImageWatermarkUsingStream
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddImageWatermarkUsingStream).Name}");

            string documentPath = Constants.WatermarkJpg;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Stream watermarkStream = File.OpenRead(documentPath))
            {
                using (Watermarker watermarker = new Watermarker(Constants.InImagePng))
                {
                    // Use stream containing an image as constructor parameter
                    using (ImageWatermark watermark = new ImageWatermark(watermarkStream))
                    {
                        // Add watermark to the document
                        watermarker.Add(watermark);

                        watermarker.Save(outputFileName);
                    }
                }
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
