using GroupDocs.Watermark.Contents;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to clear a particular header and footer.
    /// </summary>
    public static class SpreadsheetClearHeaderFooter
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

                foreach (SpreadsheetHeaderFooterSection section in content
                    .Worksheets[0].HeadersFooters[OfficeHeaderFooterType.HeaderPrimary]
                    .Sections)
                {
                    section.Script = null;
                    section.Image = null;
                }

                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}
