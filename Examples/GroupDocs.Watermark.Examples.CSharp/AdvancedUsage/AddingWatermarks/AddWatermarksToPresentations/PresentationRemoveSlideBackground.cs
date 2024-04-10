using GroupDocs.Watermark.Contents.Presentation;
using GroupDocs.Watermark.Options.Presentation;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to remove the background image of a particular slide.
    /// </summary>
    public static class PresentationRemoveSlideBackground
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PresentationRemoveSlideBackground).Name}\n");

            string documentPath = Constants.InPresentationPptx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PresentationLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PresentationContent content = watermarker.GetContent<PresentationContent>();
                content.Slides[0].ImageFillFormat.BackgroundImage = null;

                watermarker.Save(outputFileName);
            }
        }
    }
}
