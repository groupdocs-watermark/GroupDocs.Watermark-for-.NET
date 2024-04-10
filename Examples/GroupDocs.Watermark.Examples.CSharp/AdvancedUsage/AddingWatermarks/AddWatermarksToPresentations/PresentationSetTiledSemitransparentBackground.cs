using GroupDocs.Watermark.Contents.Presentation;
using GroupDocs.Watermark.Options.Presentation;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to tile the picture across slide's background and make the image semi-transparent.
    /// </summary>
    public static class PresentationSetTiledSemitransparentBackground
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PresentationSetTiledSemitransparentBackground).Name}\n");

            string documentPath = Constants.InPresentationPptx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PresentationLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PresentationContent content = watermarker.GetContent<PresentationContent>();
                PresentationSlide slide = content.Slides[0];
                slide.ImageFillFormat.BackgroundImage = new PresentationWatermarkableImage(File.ReadAllBytes(Constants.BackgroundPng));
                slide.ImageFillFormat.TileAsTexture = true;
                slide.ImageFillFormat.Transparency = 0.5;

                watermarker.Save(outputFileName);
            }
        }
    }
}
