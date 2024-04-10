using System;
using System.IO;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    /// <summary>
    /// This example shows how to search watermark with the combination of different search criteria.
    /// </summary>
    public static class SearchWatermarkWithCombinedSearch
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SearchWatermarkWithCombinedSearch).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.LogoPng);
                imageSearchCriteria.MaxDifference = 0.9;

                TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                RotateAngleSearchCriteria rotateAngleSearchCriteria = new RotateAngleSearchCriteria(30, 60);

                SearchCriteria combinedSearchCriteria = imageSearchCriteria.Or(textSearchCriteria).And(rotateAngleSearchCriteria);
                PossibleWatermarkCollection possibleWatermarks = watermarker.Search(combinedSearchCriteria);

                Console.WriteLine("Found {0} possible watermark(s).", possibleWatermarks.Count);
            }
        }
    }
}
