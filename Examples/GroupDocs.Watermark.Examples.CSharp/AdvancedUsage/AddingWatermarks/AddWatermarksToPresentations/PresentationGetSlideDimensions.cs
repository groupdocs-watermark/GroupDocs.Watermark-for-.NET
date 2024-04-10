using System;
using System.IO;
using GroupDocs.Watermark.Contents.Presentation;
using GroupDocs.Watermark.Options.Presentation;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to get the dimensions of a particular slide.
    /// </summary>
    public static class PresentationGetSlideDimensions
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PresentationGetSlideDimensions).Name}\n");

            string documentPath = Constants.InPresentationPptx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PresentationLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PresentationContent content = watermarker.GetContent<PresentationContent>();

                Console.WriteLine(content.SlideWidth);
                Console.WriteLine(content.SlideHeight);
            }
        }
    }
}
