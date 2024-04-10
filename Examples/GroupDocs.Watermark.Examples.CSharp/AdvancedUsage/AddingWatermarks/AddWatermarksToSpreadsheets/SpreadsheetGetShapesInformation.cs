using System;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to get information about all the shapes in an Excel document.
    /// </summary>
    public static class SpreadsheetGetShapesInformation
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetGetShapesInformation).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                foreach (SpreadsheetWorksheet worksheet in content.Worksheets)
                {
                    foreach (SpreadsheetShape shape in worksheet.Shapes)
                    {
                        Console.WriteLine(shape.AutoShapeType);
                        Console.WriteLine(shape.MsoDrawingType);
                        Console.WriteLine(shape.Text);
                        if (shape.Image != null)
                        {
                            Console.WriteLine(shape.Image.Width);
                            Console.WriteLine(shape.Image.Height);
                            Console.WriteLine(shape.Image.GetBytes().Length);
                        }

                        Console.WriteLine(shape.Id);
                        Console.WriteLine(shape.AlternativeText);
                        Console.WriteLine(shape.X);
                        Console.WriteLine(shape.Y);
                        Console.WriteLine(shape.Width);
                        Console.WriteLine(shape.Height);
                        Console.WriteLine(shape.RotateAngle);
                        Console.WriteLine(shape.IsWordArt);
                        Console.WriteLine(shape.Name);
                    }
                }
            }
        }
    }
}
