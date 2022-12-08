// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to define the size of the background image on which your watermark will be drawn.
    /// </summary>
    public static class SpreadsheetAddWatermarkAsBackgroundWithRelativeSizeAndPosition
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
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

                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}
