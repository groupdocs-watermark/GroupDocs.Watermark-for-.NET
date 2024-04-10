using GroupDocs.Watermark.Contents;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to apply text effects when adding shape watermark in Excel worksheet.
    /// </summary>
    public static class SpreadsheetAddWatermarkWithTextEffects
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddWatermarkWithTextEffects).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));

                SpreadsheetTextEffects effects = new SpreadsheetTextEffects();
                effects.LineFormat.Enabled = true;
                effects.LineFormat.Color = Color.Red;
                effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot;
                effects.LineFormat.LineStyle = OfficeLineStyle.Triple;
                effects.LineFormat.Weight = 1;

                SpreadsheetWatermarkShapeOptions options = new SpreadsheetWatermarkShapeOptions();
                options.Effects = effects;

                watermarker.Add(watermark, options);
                watermarker.Save(outputFileName);
            }
        }
    }
}
