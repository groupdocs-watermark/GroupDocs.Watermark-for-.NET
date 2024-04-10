using GroupDocs.Watermark.Contents;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to clear a particular header and footer.
    /// </summary>
    public static class SpreadsheetClearHeaderFooter
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

                foreach (SpreadsheetHeaderFooterSection section in content
                    .Worksheets[0].HeadersFooters[OfficeHeaderFooterType.HeaderPrimary]
                    .Sections)
                {
                    section.Script = null;
                    section.Image = null;
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
