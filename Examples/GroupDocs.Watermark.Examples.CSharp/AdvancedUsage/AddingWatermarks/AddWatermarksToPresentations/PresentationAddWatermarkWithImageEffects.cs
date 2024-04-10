using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to apply image effects to the shape watermark.
    /// </summary>
    public static class PresentationAddWatermarkWithImageEffects
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PresentationAddWatermarkWithImageEffects).Name}\n");

            string documentPath = Constants.InPresentationPptx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PresentationLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                using (ImageWatermark watermark = new ImageWatermark(Constants.LogoPng))
                {
                    PresentationImageEffects effects = new PresentationImageEffects();
                    effects.Brightness = 0.7;
                    effects.Contrast = 0.6;
                    effects.ChromaKey = Color.Red;
                    effects.BorderLineFormat.Enabled = true;
                    effects.BorderLineFormat.Weight = 1;

                    PresentationWatermarkSlideOptions options = new PresentationWatermarkSlideOptions();
                    options.Effects = effects;

                    watermarker.Add(watermark, options);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
