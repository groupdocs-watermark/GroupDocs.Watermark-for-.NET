using System;
using System.IO;
using GroupDocs.Watermark.Contents.Presentation;
using GroupDocs.Watermark.Options.Presentation;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to extract information about all the slide backgrounds in a PowerPoint document.
    /// </summary>
    public static class PresentationGetSlideBackgroundsInformation
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PresentationGetSlideBackgroundsInformation).Name}\n");

            string documentPath = Constants.InPresentationPptx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PresentationLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PresentationContent content = watermarker.GetContent<PresentationContent>();
                foreach (PresentationSlide slide in content.Slides)
                {
                    if (slide.ImageFillFormat.BackgroundImage != null)
                    {
                        Console.WriteLine(slide.ImageFillFormat.BackgroundImage.Width);
                        Console.WriteLine(slide.ImageFillFormat.BackgroundImage.Height);
                        Console.WriteLine(slide.ImageFillFormat.BackgroundImage.GetBytes().Length);
                    }
                }
            }
        }
    }
}
