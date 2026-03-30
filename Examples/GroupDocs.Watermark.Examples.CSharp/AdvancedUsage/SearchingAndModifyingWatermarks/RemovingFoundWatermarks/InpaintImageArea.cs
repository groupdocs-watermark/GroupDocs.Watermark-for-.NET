using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Search.Watermarks;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.RemovingFoundWatermarks
{
    /// <summary>
    /// This example demonstrates how to inpaint a specified rectangular area in an image.
    /// </summary>
    public static class InpaintImageArea
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(InpaintImageArea).Name}\n");

            string documentPath = Constants.SampleJpg;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                var possibleWatermark = new ImageInpaintingPossibleWatermark()
                {
                    Rectangles = new[] { new GroupDocs.Watermark.Common.Rectangle(200, 180, 260, 60) },
                    Method = InpaintingMethod.PatchBased,
                    PatchSize = 9
                };

                watermarker.Remove(possibleWatermark);
                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Image inpainted successfully.\nCheck the output in {outputDirectory}\n");
        }
    }
}
