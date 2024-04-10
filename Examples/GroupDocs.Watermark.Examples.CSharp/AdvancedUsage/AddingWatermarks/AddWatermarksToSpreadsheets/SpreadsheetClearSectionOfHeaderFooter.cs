using GroupDocs.Watermark.Contents;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to  clear a particular section of header and footer.
    /// </summary>
    public static class SpreadsheetClearSectionOfHeaderFooter
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddWatermarkToImagesInHeaderFooter).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

                SpreadsheetHeaderFooterSection section = content.Worksheets[0]
                    .HeadersFooters[OfficeHeaderFooterType.HeaderEven]
                    .Sections[SpreadsheetHeaderFooterSectionType.Left];
                section.Image = null;
                section.Script = null;

                watermarker.Save(outputFileName);
            }
        }
    }
}
