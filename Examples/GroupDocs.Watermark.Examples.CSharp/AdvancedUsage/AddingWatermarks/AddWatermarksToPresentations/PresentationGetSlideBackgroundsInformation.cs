using System;
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
            PresentationLoadOptions loadOptions = new PresentationLoadOptions();
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
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
