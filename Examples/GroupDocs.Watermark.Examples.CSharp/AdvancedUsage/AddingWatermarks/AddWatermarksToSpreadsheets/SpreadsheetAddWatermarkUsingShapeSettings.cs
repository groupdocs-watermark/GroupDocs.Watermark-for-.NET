// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    using Options.Spreadsheet;
    using Watermarks;

    /// <summary>
    /// This example shows how to set some additional options when adding shape watermark to Excel worksheet.
    /// </summary>
    public static class SpreadsheetAddWatermarkUsingShapeSettings
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));
                SpreadsheetWatermarkShapeOptions options = new SpreadsheetWatermarkShapeOptions();

                // Set the shape name
                options.Name = "Shape 1";

                // Set the descriptive (alternative) text that will be associated with the shape
                options.AlternativeText = "Test watermark";

                // Editing of the shape in Excel is forbidden
                options.IsLocked = true;

                watermarker.Add(watermark, options);
                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}