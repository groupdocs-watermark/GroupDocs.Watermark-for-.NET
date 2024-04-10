using System;
using System.IO;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    /// <summary>
    /// This example shows how to search for the watermarks that meet a particular text criterion.
    /// </summary>
    public static class SearchWatermarkWithSearchString
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SearchWatermarkWithSearchString).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Search by exact string
                TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Â© 2017");

                // Find all possible watermarks containing some specific text
                PossibleWatermarkCollection possibleWatermarks = watermarker.Search(textSearchCriteria);

                Console.WriteLine("Found {0} possible watermark(s)", possibleWatermarks.Count);
            }
        }
    }
}
