using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Image;
using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to add watermark to the images that belong to a particular section.
    /// </summary>
    public static class WordProcessingAddWatermarkToSectionImages
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingAddWatermarkToSectionImages).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.RotateAngle = 45;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;

                // Get all images belonging to the first section
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                WatermarkableImageCollection images = content.Sections[0].FindImages();

                // Add watermark to all found images
                foreach (WatermarkableImage image in images)
                {
                    image.Add(watermark);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
