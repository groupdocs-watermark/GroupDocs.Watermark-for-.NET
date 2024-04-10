using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to apply image effects to the shape watermark.
    /// </summary>
    public static class SpreadsheetAddWatermarkWithImageEffects
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddWatermarkWithImageEffects).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                using (ImageWatermark watermark = new ImageWatermark(Constants.LogoPng))
                {
                    SpreadsheetImageEffects effects = new SpreadsheetImageEffects();
                    effects.Brightness = 0.7;
                    effects.Contrast = 0.6;
                    effects.ChromaKey = Color.Red;
                    effects.BorderLineFormat.Enabled = true;
                    effects.BorderLineFormat.Weight = 1;

                    SpreadsheetWatermarkShapeOptions options = new SpreadsheetWatermarkShapeOptions();
                    options.Effects = effects;

                    watermarker.Add(watermark, options);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
