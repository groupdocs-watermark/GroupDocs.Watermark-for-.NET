using System;
using System.IO;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to set the background image for a chart inside an Excel document.
    /// </summary>
    public static class SpreadsheetSetBackgroundImageForChart
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetSetBackgroundImageForChart).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

                content.Worksheets[0].Charts[0].ImageFillFormat.BackgroundImage = new SpreadsheetWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
                content.Worksheets[0].Charts[0].ImageFillFormat.Transparency = 0.5;
                content.Worksheets[0].Charts[0].ImageFillFormat.TileAsTexture = true;

                watermarker.Save(outputFileName);
            }
        }
    }
}
