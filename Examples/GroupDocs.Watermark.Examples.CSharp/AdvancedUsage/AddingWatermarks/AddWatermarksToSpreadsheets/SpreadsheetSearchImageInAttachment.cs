using System;
using System.IO;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.Objects;
using GroupDocs.Watermark.Search.SearchCriteria;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to search for all the images and watermarkable attachments in Excel document.
    /// </summary>
    public static class SpreadsheetSearchImageInAttachment
    {
        public static void Run()
        {
            // Consider only the attached images
            WatermarkerSettings settings = new WatermarkerSettings();
            settings.SearchableObjects.SpreadsheetSearchableObjects = SpreadsheetSearchableObjects.AttachedImages;

            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetSearchImageInAttachment).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Specify sample image to compare document images with
                ImageSearchCriteria criteria = new ImageDctHashSearchCriteria(Constants.AttachmentPng);

                // Search for similar images
                PossibleWatermarkCollection possibleWatermarks = watermarker.Search(criteria);

                // Remove or modify found image watermarks
                // ...

                Console.WriteLine("Found {0} possible watermark(s).", possibleWatermarks.Count);
            }
        }
    }
}
