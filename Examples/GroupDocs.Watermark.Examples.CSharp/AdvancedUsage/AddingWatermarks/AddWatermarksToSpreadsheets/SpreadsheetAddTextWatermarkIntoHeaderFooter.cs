// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    using Common;
    using Options.Spreadsheet;
    using Watermarks;

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