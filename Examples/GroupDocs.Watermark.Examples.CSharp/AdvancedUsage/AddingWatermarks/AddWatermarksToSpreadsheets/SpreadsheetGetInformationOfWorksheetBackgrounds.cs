using System;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to extract information about all the worksheet backgrounds in an Excel document.
    /// </summary>
    public static class SpreadsheetGetInformationOfWorksheetBackgrounds
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetGetInformationOfWorksheetBackgrounds).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                foreach (SpreadsheetWorksheet worksheet in content.Worksheets)
                {
                    if (worksheet.BackgroundImage != null)
                    {
                        Console.WriteLine(worksheet.BackgroundImage.Width);
                        Console.WriteLine(worksheet.BackgroundImage.Height);
                        Console.WriteLine(worksheet.BackgroundImage.GetBytes().Length);
                    }
                }
            }
        }
    }
}
