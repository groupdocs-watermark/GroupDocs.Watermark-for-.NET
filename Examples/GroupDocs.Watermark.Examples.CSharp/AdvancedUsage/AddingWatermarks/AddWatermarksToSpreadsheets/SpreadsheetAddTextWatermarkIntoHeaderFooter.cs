using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to add text watermark in header or footer.
    /// </summary>
    public static class SpreadsheetAddTextWatermarkIntoHeaderFooter
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19, FontStyle.Bold));
                watermark.ForegroundColor = Color.Red;
                watermark.BackgroundColor = Color.Aqua;
                watermark.VerticalAlignment = VerticalAlignment.Top;
                watermark.HorizontalAlignment = HorizontalAlignment.Center;

                SpreadsheetWatermarkHeaderFooterOptions options = new SpreadsheetWatermarkHeaderFooterOptions();
                options.WorksheetIndex = 0;

                watermarker.Add(watermark, options);
                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}
