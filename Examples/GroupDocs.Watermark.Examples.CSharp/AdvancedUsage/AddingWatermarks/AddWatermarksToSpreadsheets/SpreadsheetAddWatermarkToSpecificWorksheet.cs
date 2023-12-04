using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to add watermark to particular worksheets.
    /// </summary>
    public static class SpreadsheetAddWatermarkToSpecificWorksheet
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
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

                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}