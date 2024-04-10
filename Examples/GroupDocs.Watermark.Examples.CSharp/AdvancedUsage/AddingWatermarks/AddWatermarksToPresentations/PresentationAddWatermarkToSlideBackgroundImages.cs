using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Presentation;
using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to add watermark to the background images that belong to a PowerPoint document.
    /// </summary>
    public static class PresentationAddWatermarkToSlideBackgroundImages
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PresentationAddWatermarkToSlideBackgroundImages).Name}\n");

            string documentPath = Constants.InPresentationPptx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PresentationLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Initialize image or text watermark
                TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.RotateAngle = 45;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;

                PresentationContent content = watermarker.GetContent<PresentationContent>();
                foreach (PresentationSlide slide in content.Slides)
                {
                    if (slide.ImageFillFormat.BackgroundImage != null)
                    {
                        // Add watermark to the image
                        slide.ImageFillFormat.BackgroundImage.Add(watermark);
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
