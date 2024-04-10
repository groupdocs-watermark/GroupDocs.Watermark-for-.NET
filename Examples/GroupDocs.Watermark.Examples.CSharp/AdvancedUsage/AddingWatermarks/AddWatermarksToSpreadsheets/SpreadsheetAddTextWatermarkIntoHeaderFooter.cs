using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to add text watermark in header or footer.
    /// </summary>
    public static class SpreadsheetAddTextWatermarkIntoHeaderFooter
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddTextWatermarkIntoHeaderFooter).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19, FontStyle.Bold));
                watermark.ForegroundColor = Color.Red;
                watermark.BackgroundColor = Color.Aqua;
                watermark.VerticalAlignment = VerticalAlignment.Top;
                watermark.HorizontalAlignment = HorizontalAlignment.Center;

                SpreadsheetWatermarkHeaderFooterOptions options = new SpreadsheetWatermarkHeaderFooterOptions();
                options.WorksheetIndex = 0;

                watermarker.Add(watermark, options);
                watermarker.Save(outputFileName);
            }
        }
    }
}
