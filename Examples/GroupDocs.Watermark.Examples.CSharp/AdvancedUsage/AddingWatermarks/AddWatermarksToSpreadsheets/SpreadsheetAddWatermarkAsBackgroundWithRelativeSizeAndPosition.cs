using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to define the size of the background image on which your watermark will be drawn.
    /// </summary>
    public static class SpreadsheetAddWatermarkAsBackgroundWithRelativeSizeAndPosition
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddWatermarkAsBackgroundWithRelativeSizeAndPosition).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                using (ImageWatermark watermark = new ImageWatermark(Constants.LogoGif))
                {
                    watermark.HorizontalAlignment = HorizontalAlignment.Center;
                    watermark.VerticalAlignment = VerticalAlignment.Center;
                    watermark.RotateAngle = 90;
                    watermark.SizingType = SizingType.ScaleToParentDimensions;
                    watermark.ScaleFactor = 0.5;

                    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                    SpreadsheetBackgroundWatermarkOptions options = new SpreadsheetBackgroundWatermarkOptions();
                    options.BackgroundWidth = content.Worksheets[0].ContentAreaWidthPx; /* set background width */
                    options.BackgroundHeight = content.Worksheets[0].ContentAreaHeightPx; /* set background height */
                    watermarker.Add(watermark, options);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
