using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to modify properties of particular shapes in an Excel Worksheet.
    /// </summary>
    public static class SpreadsheetUpdateShapeProperties
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetUpdateShapeProperties).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                foreach (SpreadsheetShape shape in content.Worksheets[0].Shapes)
                {
                    if (shape.Text == "© Aspose 2019")
                    {
                        shape.AlternativeText = "watermark";
                        shape.RotateAngle = 30;
                        shape.X = 200;
                        shape.Y = 200;
                        shape.Width = 400;
                        shape.Height = 100;
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
