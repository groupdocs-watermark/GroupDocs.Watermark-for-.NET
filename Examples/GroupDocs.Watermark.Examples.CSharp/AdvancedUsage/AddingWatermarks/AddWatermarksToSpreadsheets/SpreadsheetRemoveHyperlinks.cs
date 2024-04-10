using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to remove/replace hyperlink associated with a particular shape or chart inside an Excel document.
    /// </summary>
    public static class SpreadsheetRemoveHyperlinks
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetRemoveWorksheetBackground).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

                // Replace hyperlink
                content.Worksheets[0].Charts[0].Hyperlink = "https://www.aspose.com/";
                content.Worksheets[0].Shapes[0].Hyperlink = "https://www.groupdocs.com/";

                // Remove hyperlink
                content.Worksheets[1].Charts[0].Hyperlink = null;
                content.Worksheets[1].Shapes[0].Hyperlink = null;

                watermarker.Save(outputFileName);
            }
        }
    }
}
