using System;
using System.IO;
using System.Text.RegularExpressions;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    /// <summary>
    /// This example shows how to use a regular expression to search for watermarks.
    /// </summary>
    public static class SearchWatermarkWithRegularExpression
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SearchWatermarkWithRegularExpression).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                Regex regex = new Regex(@"^Â© \d{4}$");

                // Search by regular expression
                TextSearchCriteria textSearchCriteria = new TextSearchCriteria(regex);

                // Find possible watermarks using regular expression
                PossibleWatermarkCollection possibleWatermarks = watermarker.Search(textSearchCriteria);

                Console.WriteLine("Found {0} possible watermark(s).", possibleWatermarks.Count);
            }
        }
    }
}
