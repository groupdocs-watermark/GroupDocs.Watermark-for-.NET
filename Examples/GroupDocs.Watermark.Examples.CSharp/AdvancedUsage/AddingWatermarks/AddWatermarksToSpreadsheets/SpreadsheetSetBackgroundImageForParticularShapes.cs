using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to set the background image for the particular shapes in an Excel Worksheet.
    /// </summary>
    public static class SpreadsheetSetBackgroundImageForParticularShapes
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetSetBackgroundImageForParticularShapes).Name}\n");

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
                        shape.ImageFillFormat.BackgroundImage = new SpreadsheetWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
                        shape.ImageFillFormat.Transparency = 0.5;
                        shape.ImageFillFormat.TileAsTexture = true;
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
