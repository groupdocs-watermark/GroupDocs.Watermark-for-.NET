using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Watermarks;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to add an image watermark to a document from a stream.
    /// </summary>
    public static class AddImageWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Basic Usage] # {typeof(AddImageWatermark).Name}");

            string documentPath = Constants.SampleXlsx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (FileStream stream = File.Open(documentPath, FileMode.Open, FileAccess.ReadWrite))
            {
                using (Watermarker watermarker = new Watermarker(stream))
                {
                    ImageWatermark watermark = new ImageWatermark(Constants.LogoPng)
                    {
                        Opacity = 0.25,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,

                        SizingType = SizingType.ScaleToParentDimensions,
                        ScaleFactor = 1   // 30% of page size – good default
                    };

                    // Add watermark
                    watermarker.Add(watermark);

                    watermarker.Save(outputFileName);
                }
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
