using GroupDocs.Watermark.Contents;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to apply some text effects to the shape watermarks.
    /// </summary>
    public static class WordProcessingAddWatermarkWithTextEffects
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingAddWatermarkWithTextEffects).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

                WordProcessingTextEffects effects = new WordProcessingTextEffects();
                effects.LineFormat.Enabled = true;
                effects.LineFormat.Color = Color.Red;
                effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot;
                effects.LineFormat.LineStyle = OfficeLineStyle.Triple;
                effects.LineFormat.Weight = 1;

                WordProcessingWatermarkSectionOptions options = new WordProcessingWatermarkSectionOptions();
                options.Effects = effects;

                watermarker.Add(watermark, options);
                watermarker.Save(outputFileName);
            }
        }
    }
}
