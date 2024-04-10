using System;
using System.IO;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This examples shows how to replace the image of the particular shapes in an Excel Worksheet.
    /// </summary>
    public static class SpreadsheetReplaceImageOfParticularShapes
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetReplaceImageOfParticularShapes).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                foreach (SpreadsheetShape shape in content.Worksheets[0].Shapes)
                {
                    if (shape.Image != null)
                    {
                        shape.Image = new SpreadsheetWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
