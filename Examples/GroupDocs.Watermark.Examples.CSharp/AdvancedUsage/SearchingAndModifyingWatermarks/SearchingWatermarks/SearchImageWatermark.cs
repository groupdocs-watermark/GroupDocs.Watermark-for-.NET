using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    /// <summary>
    /// This example shows how to searche for image watermarks that resemble with a particular image.
    /// </summary>
    public static class SearchImageWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SearchImageWatermark).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Initialize criteria with the image
                ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.WatermarkJpg);

                //Set maximum allowed difference between images
                imageSearchCriteria.MaxDifference = 0.9;

                PossibleWatermarkCollection possibleWatermarks = watermarker.Search(imageSearchCriteria);

                Console.WriteLine("Found {0} possible watermark(s).", possibleWatermarks.Count);
            }
        }
    }
}
