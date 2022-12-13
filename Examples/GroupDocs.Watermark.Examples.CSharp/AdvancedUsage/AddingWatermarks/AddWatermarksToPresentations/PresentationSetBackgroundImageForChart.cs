using System.IO;
using GroupDocs.Watermark.Contents.Presentation;
using GroupDocs.Watermark.Options.Presentation;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to set the background image for a chart inside PowerPoint document.
    /// </summary>
    public static class PresentationSetBackgroundImageForChart
    {
        public static void Run()
        {
            PresentationLoadOptions loadOptions = new PresentationLoadOptions();
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
            {
                PresentationContent content = watermarker.GetContent<PresentationContent>();
                content.Slides[0].Charts[0].ImageFillFormat.BackgroundImage = new PresentationWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
                content.Slides[0].Charts[0].ImageFillFormat.Transparency = 0.5;
                content.Slides[0].Charts[0].ImageFillFormat.TileAsTexture = true;

                watermarker.Save(Constants.OutPresentationPptx);
            }
        }
    }
}
