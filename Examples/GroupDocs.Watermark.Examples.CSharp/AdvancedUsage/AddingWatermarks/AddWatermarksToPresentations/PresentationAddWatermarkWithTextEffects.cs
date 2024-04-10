using GroupDocs.Watermark.Contents;
using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to apply text effects when adding shape watermark to a PowerPoint slide.
    /// </summary>
    public static class PresentationAddWatermarkWithTextEffects
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PresentationAddWatermarkWithTextEffects).Name}\n");

            string documentPath = Constants.InPresentationPptx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PresentationLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));

                PresentationTextEffects effects = new PresentationTextEffects();
                effects.LineFormat.Enabled = true;
                effects.LineFormat.Color = Color.Red;
                effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot;
                effects.LineFormat.LineStyle = OfficeLineStyle.Triple;
                effects.LineFormat.Weight = 1;

                PresentationWatermarkSlideOptions options = new PresentationWatermarkSlideOptions();
                options.Effects = effects;

                watermarker.Add(watermark, options);
                watermarker.Save(outputFileName);
            }
        }
    }
}
