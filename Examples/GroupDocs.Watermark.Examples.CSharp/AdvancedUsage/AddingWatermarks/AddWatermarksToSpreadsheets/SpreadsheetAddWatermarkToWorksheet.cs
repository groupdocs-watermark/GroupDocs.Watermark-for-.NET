using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to add watermark to a particular worksheet.
    /// </summary>
    public static class SpreadsheetAddWatermarkToWorksheet
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddWatermarkToWorksheet).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Add text watermark to the first worksheet
                TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
                SpreadsheetWatermarkShapeOptions textWatermarkOptions = new SpreadsheetWatermarkShapeOptions();
                textWatermarkOptions.WorksheetIndex = 0;
                watermarker.Add(textWatermark, textWatermarkOptions);

                // Add image watermark to the second worksheet
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.LogoJpg))
                {
                    SpreadsheetWatermarkShapeOptions imageWatermarkOptions = new SpreadsheetWatermarkShapeOptions();
                    imageWatermarkOptions.WorksheetIndex = 1;
                    watermarker.Add(imageWatermark, imageWatermarkOptions);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
