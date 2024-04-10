using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to add text watermark as background.
    /// </summary>
    public static class SpreadsheetAddTextWatermarkAsBackground
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddModernWordArtWatermark).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.RotateAngle = 45;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 0.5;
                watermark.Opacity = 0.5;

                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                SpreadsheetBackgroundWatermarkOptions options = new SpreadsheetBackgroundWatermarkOptions();
                options.BackgroundWidth = content.Worksheets[0].ContentAreaWidthPx; /* set background width */
                options.BackgroundHeight = content.Worksheets[0].ContentAreaHeightPx; /* set background height */
                watermarker.Add(watermark, options);

                watermarker.Save(outputFileName);
            }
        }
    }
}
