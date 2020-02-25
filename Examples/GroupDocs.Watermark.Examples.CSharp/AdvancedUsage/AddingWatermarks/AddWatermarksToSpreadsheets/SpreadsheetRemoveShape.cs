// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    using Contents.Spreadsheet;
    using Options.Spreadsheet;

    /// <summary>
    /// This example shows how to remove a particular shape from the worksheet.
    /// </summary>
    public static class SpreadsheetRemoveShape
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

                // Remove shape by index
                content.Worksheets[0].Shapes.RemoveAt(0);

                // Remove shape by reference
                content.Worksheets[0].Shapes.Remove(content.Worksheets[0].Shapes[0]);

                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}