// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    using Options.Spreadsheet;
    using Watermarks;

    /// <summary>
    /// This example shows how to add modern WordArt watermark to Excel document worksheet.
    /// </summary>
    public static class SpreadsheetAddModernWordArtWatermark
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
                SpreadsheetWatermarkModernWordArtOptions options = new SpreadsheetWatermarkModernWordArtOptions();
                options.WorksheetIndex = 0;

                watermarker.Add(textWatermark, options);
                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}