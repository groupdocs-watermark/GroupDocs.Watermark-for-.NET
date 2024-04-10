using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Image;
using GroupDocs.Watermark.Contents.Presentation;
using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to add watermark to the images inside a particular PowerPoint slide.
    /// </summary>
    public static class PresentationAddWatermarkToSlideImages
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PresentationAddWatermarkToSlideImages).Name}\n");

            string documentPath = Constants.InPresentationPptx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PresentationLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.RotateAngle = 45;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;

                // Get all images from the first slide
                PresentationContent content = watermarker.GetContent<PresentationContent>();
                WatermarkableImageCollection images = content.Slides[0].FindImages();

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
