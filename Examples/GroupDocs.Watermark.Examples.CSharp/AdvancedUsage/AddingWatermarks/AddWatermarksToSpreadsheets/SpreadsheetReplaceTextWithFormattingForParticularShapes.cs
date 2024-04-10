using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to replace the text of the shapes with formatted text.
    /// </summary>
    public static class SpreadsheetReplaceTextWithFormattingForParticularShapes
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetReplaceTextWithFormattingForParticularShapes).Name}\n");

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
                        shape.FormattedTextFragments.Clear();
                        shape.FormattedTextFragments.Add("© GroupDocs 2017", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
