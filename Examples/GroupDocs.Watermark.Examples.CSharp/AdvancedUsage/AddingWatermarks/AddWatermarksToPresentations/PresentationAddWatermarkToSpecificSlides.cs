using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to add watermark to a particular slide of a PowerPoint presentation.
    /// </summary>
    public static class PresentationAddWatermarkToSpecificSlides
    {
        public static void Run()
        {
            PresentationLoadOptions loadOptions = new PresentationLoadOptions();
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
            {
                // Add text watermark to the first slide
                TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
                textWatermark.PagesSetup = new PagesSetup
                {
                    EvenPages = true
                };
                watermarker.Add(textWatermark);

                // Add image watermark to the second slide
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.LogoJpg))
                {
                    imageWatermark.PagesSetup = new PagesSetup
                    {
                        LastPage = true
                    };
                    watermarker.Add(imageWatermark);
                }

                watermarker.Save(@"d:\GroupDocs\_data\_test_results\WATERMARKNET-PageSetup\presentation.pptx");
            }
        }
    }
}