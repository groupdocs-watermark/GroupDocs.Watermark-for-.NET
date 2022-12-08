using GroupDocs.Watermark.Contents.Presentation;
using GroupDocs.Watermark.Options.Presentation;
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
            PresentationLoadOptions loadOptions = new PresentationLoadOptions();
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
            {
                PresentationContent content = watermarker.GetContent<PresentationContent>();
                PresentationSlide slide = content.Slides[0];
                slide.ImageFillFormat.BackgroundImage = new PresentationWatermarkableImage(File.ReadAllBytes(Constants.BackgroundPng));
                slide.ImageFillFormat.TileAsTexture = true;
                slide.ImageFillFormat.Transparency = 0.5;

                watermarker.Save(Constants.OutPresentationPptx);
            }
        }
    }
}
