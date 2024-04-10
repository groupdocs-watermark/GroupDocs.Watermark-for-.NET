using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to replace text for particular shapes in an Excel Worksheet.
    /// </summary>
    public static class SpreadsheetReplaceTextForParticularShapes
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetReplaceTextForParticularShapes).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                foreach (SpreadsheetShape shape in content.Worksheets[0].Shapes)
                {
                    if (shape.Text == "© Aspose 2016")
                    {
                        shape.Text = "© GroupDocs 2017";
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
