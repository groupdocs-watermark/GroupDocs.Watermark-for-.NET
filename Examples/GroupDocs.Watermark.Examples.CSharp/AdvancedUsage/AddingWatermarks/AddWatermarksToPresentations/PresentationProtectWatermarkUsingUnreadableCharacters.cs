using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to include unreadable characters in watermark text.
    /// </summary>
    public static class PresentationProtectWatermarkUsingUnreadableCharacters
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PresentationProtectWatermarkUsingUnreadableCharacters).Name}\n");

            string documentPath = Constants.InPresentationPptx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PresentationLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Watermark text", new Font("Arial", 19));

                PresentationWatermarkSlideOptions options = new PresentationWatermarkSlideOptions();
                options.IsLocked = true;
                options.ProtectWithUnreadableCharacters = true;

                // Add watermark
                watermarker.Add(watermark, options);

                // Save document
                watermarker.Save(outputFileName);
            }
        }
    }
}
