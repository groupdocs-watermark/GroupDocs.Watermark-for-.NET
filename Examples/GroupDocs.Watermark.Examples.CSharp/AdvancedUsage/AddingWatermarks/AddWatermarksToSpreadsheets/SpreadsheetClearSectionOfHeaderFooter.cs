// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    using Contents;
    using Contents.Spreadsheet;
    using Options.Spreadsheet;

    /// <summary>
    /// This example shows how to  clear a particular section of header and footer.
    /// </summary>
    public static class SpreadsheetClearSectionOfHeaderFooter
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

                SpreadsheetHeaderFooterSection section = content.Worksheets[0]
                                                                .HeadersFooters[OfficeHeaderFooterType.HeaderEven]
                                                                .Sections[SpreadsheetHeaderFooterSectionType.Left];
                section.Image = null;
                section.Script = null;

                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}