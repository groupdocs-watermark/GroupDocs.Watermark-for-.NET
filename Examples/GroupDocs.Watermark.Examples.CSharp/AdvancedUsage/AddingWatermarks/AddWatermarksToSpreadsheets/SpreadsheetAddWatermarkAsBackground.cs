using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example show how to add background watermark to all worksheets of Excel document.
    /// </summary>
    public static class SpreadsheetAddWatermarkAsBackground
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddWatermarkAsBackground).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                using (ImageWatermark watermark = new ImageWatermark(Constants.LogoGif))
                {
                    SpreadsheetBackgroundWatermarkOptions options = new SpreadsheetBackgroundWatermarkOptions();
                    watermarker.Add(watermark, options);
                }

                watermarker.Save(outputFileName);
            }
        }

    }
}
