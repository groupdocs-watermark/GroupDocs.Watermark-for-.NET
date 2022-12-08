using System;
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

            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions, settings))
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
