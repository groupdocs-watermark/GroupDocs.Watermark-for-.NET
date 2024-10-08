using GroupDocs.Watermark.Watermarks;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingImageWatermarks
{
    /// <summary>
    /// This example shows how to add image watermark from a local file.
    /// </summary>
    public static class AddImageTiledWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddImageTiledWatermark).Name}");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Use path to the image as constructor parameter
                using (ImageWatermark watermark = new ImageWatermark(Constants.ProtectJpg))
                {
                    // Configure tile options with Offset style
                    watermark.TileOptions = new TileOptions()
                    {
                        TileType = TileType.Offset,
                        LineSpacing = new MeasureValue()
                        {
                            MeasureType = TileMeasureType.Percent,
                            Value = 12
                        },
                        WatermarkSpacing = new MeasureValue()
                        {
                            MeasureType = TileMeasureType.Percent,
                            Value = 10
                        },
                    };

                    watermark.RotateAngle = -30;

                    // Add watermark to the document
                    watermarker.Add(watermark);

                    watermarker.Save(outputFileName);
                }
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
