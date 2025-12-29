using GroupDocs.Watermark.Watermarks;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example shows how to add image watermark from a local file.
    /// </summary>
    public static class AddImageTiledWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddImageTiledWatermark).Name}");

            string documentPath = Constants.SamplePdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Create image watermark
                ImageWatermark watermark = new ImageWatermark(Constants.LogoPng)
                {
                    Opacity = 0.25,
                    RotateAngle = -30,
                    IsBackground = true,

                    TileOptions = new TileOptions()
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
                    }
                };

                // Add watermark
                watermarker.Add(watermark);

                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
