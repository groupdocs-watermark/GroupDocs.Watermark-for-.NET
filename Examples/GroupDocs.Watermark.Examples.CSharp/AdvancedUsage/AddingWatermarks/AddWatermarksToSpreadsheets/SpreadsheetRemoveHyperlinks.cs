// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to remove/replace hyperlink associated with a particular shape or chart inside an Excel document.
    /// </summary>
    public static class SpreadsheetRemoveHyperlinks
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

                // Replace hyperlink
                content.Worksheets[0].Charts[0].Hyperlink = "https://www.aspose.com/";
                content.Worksheets[0].Shapes[0].Hyperlink = "https://www.groupdocs.com/";

                // Remove hyperlink
                content.Worksheets[1].Charts[0].Hyperlink = null;
                content.Worksheets[1].Shapes[0].Hyperlink = null;

                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}
