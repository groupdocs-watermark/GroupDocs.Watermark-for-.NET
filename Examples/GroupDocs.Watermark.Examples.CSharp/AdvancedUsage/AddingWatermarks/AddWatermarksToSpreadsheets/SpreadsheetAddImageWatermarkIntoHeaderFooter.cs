using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to add watermark to worksheet's header or footer.
    /// </summary>
    public static class SpreadsheetAddImageWatermarkIntoHeaderFooter
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddImageWatermarkIntoHeaderFooter).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                using (ImageWatermark watermark = new ImageWatermark(Constants.LogoPng))
                {
                    watermark.VerticalAlignment = VerticalAlignment.Top;
                    watermark.HorizontalAlignment = HorizontalAlignment.Center;
                    watermark.SizingType = SizingType.ScaleToParentDimensions;
                    watermark.ScaleFactor = 1;

                    SpreadsheetWatermarkHeaderFooterOptions options = new SpreadsheetWatermarkHeaderFooterOptions();
                    options.WorksheetIndex = 0;

                    watermarker.Add(watermark, options);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
