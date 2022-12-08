using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to include unreadable characters in watermark text.
    /// </summary>
    public static class PresentationProtectWatermarkUsingUnreadableCharacters
    {
        public static void Run()
        {
            PresentationLoadOptions loadOptions = new PresentationLoadOptions();
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Watermark text", new Font("Arial", 19));

                PresentationWatermarkSlideOptions options = new PresentationWatermarkSlideOptions();
                options.IsLocked = true;
                options.ProtectWithUnreadableCharacters = true;

                // Add watermark
                watermarker.Add(watermark, options);

                // Save document
                watermarker.Save(Constants.OutPresentationPptx);
            }
        }
    }
}
