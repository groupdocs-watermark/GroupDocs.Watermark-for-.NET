using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to add modern WordArt watermark to Excel document worksheet.
    /// </summary>
    public static class SpreadsheetAddModernWordArtWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddModernWordArtWatermark).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
                SpreadsheetWatermarkModernWordArtOptions options = new SpreadsheetWatermarkModernWordArtOptions();
                options.WorksheetIndex = 0;

                watermarker.Add(textWatermark, options);
                watermarker.Save(outputFileName);
            }
        }
    }
}
