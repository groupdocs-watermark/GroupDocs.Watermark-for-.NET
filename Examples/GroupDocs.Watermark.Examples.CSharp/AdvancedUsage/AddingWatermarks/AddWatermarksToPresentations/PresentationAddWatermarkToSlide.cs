using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to add watermark to a particular slide of a PowerPoint presentation.
    /// </summary>
    public static class PresentationAddWatermarkToSlide
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PresentationAddWatermarkToSlide).Name}\n");

            string documentPath = Constants.SamplePptx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PresentationLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Add text watermark to the first slide
                TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
                PresentationWatermarkSlideOptions textWatermarkOptions = new PresentationWatermarkSlideOptions();
                textWatermarkOptions.SlideIndex = 0;
                watermarker.Add(textWatermark, textWatermarkOptions);

                // Add image watermark to the second slide
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.LogoJpg))
                {
                    PresentationWatermarkSlideOptions imageWatermarkOptions = new PresentationWatermarkSlideOptions();
                    imageWatermarkOptions.SlideIndex = 1;
                    watermarker.Add(imageWatermark, imageWatermarkOptions);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
