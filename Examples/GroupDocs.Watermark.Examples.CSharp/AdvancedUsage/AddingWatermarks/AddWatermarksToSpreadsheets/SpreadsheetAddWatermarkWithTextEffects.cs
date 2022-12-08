using GroupDocs.Watermark.Contents;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to apply text effects when adding shape watermark in Excel worksheet.
    /// </summary>
    public static class SpreadsheetAddWatermarkWithTextEffects
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
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
                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}
