using System;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to extract information about all the headers and footers in an Excel document.
    /// </summary>
    public static class SpreadsheetGetHeaderFooterInformation
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetGetHeaderFooterInformation).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

                foreach (SpreadsheetWorksheet worksheet in content.Worksheets)
                {
                    foreach (SpreadsheetHeaderFooter headerFooter in worksheet.HeadersFooters)
                    {
                        Console.WriteLine(headerFooter.HeaderFooterType);
                        foreach (SpreadsheetHeaderFooterSection section in headerFooter.Sections)
                        {
                            Console.WriteLine(section.SectionType);
                            if (section.Image != null)
                            {
                                Console.WriteLine(section.Image.Width);
                                Console.WriteLine(section.Image.Height);
                                Console.WriteLine(section.Image.GetBytes().Length);
                            }

                            Console.WriteLine(section.Script);
                        }
                    }
                }
            }
        }
    }
}
