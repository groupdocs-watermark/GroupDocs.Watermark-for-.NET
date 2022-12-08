using System;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to get the size of the content area (range of cells which contains data).
    /// </summary>
    public static class SpreadsheetGetContentAreaDimensions
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

                // Get the size of content area
                Console.WriteLine(content.Worksheets[0].ContentAreaHeight);
                Console.WriteLine(content.Worksheets[0].ContentAreaWidth);

                // Get the size of particular cell
                Console.WriteLine(content.Worksheets[0].GetColumnWidth(0));
                Console.WriteLine(content.Worksheets[0].GetRowHeight(0));
            }
        }
    }
}
