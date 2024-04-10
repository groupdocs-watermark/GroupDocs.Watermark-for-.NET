using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to set some additional options when adding shape watermark to Excel worksheet.
    /// </summary>
    public static class SpreadsheetAddWatermarkUsingShapeSettings
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddWatermarkUsingShapeSettings).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));
                SpreadsheetWatermarkShapeOptions options = new SpreadsheetWatermarkShapeOptions();

                // Set the shape name
                options.Name = "Shape 1";

                // Set the descriptive (alternative) text that will be associated with the shape
                options.AlternativeText = "Test watermark";

                // Editing of the shape in Excel is forbidden
                options.IsLocked = true;

                watermarker.Add(watermark, options);
                watermarker.Save(outputFileName);
            }
        }
    }
}
