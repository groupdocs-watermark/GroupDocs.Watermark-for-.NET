using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to add watermark to particular worksheets.
    /// </summary>
    public static class SpreadsheetAddWatermarkToSpecificWorksheet
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddWatermarkToSpecificWorksheet).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Add text watermark to the last worksheet
                TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
                textWatermark.PagesSetup = new PagesSetup
                { 
                    LastPage = true
                };
                watermarker.Add(textWatermark);

                // Add image watermark to the first worksheet
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.LogoJpg))
                {
                    imageWatermark.PagesSetup = new PagesSetup
                    { 
                        FirstPage = true
                    };
                    watermarker.Add(imageWatermark);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}