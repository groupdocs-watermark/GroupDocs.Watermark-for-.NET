// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    using Options.Spreadsheet;
    using Watermarks;

    /// <summary>
    /// This example show how to add background watermark to all worksheets of Excel document.
    /// </summary>
    public static class SpreadsheetAddWatermarkAsBackground
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                using (ImageWatermark watermark = new ImageWatermark(Constants.LogoGif))
                {
                    SpreadsheetBackgroundWatermarkOptions options = new SpreadsheetBackgroundWatermarkOptions();
                    watermarker.Add(watermark, options);
                }

                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }

    }
}