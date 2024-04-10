using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    /// <summary>
    /// This example shows how to skip unreadable characters when searching for the watermark.
    /// </summary>
    public static class SearchTextWatermarkSkippingUnreadableCharacters
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SearchTextWatermarkSkippingUnreadableCharacters).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                string watermarkText = "Company name";
                TextSearchCriteria criterion = new TextSearchCriteria(watermarkText);

                // Enable skipping of unreadable characters
                criterion.SkipUnreadableCharacters = true;

                PossibleWatermarkCollection result = watermarker.Search(criterion);

                // ...

                Console.WriteLine("Found {0} possible watermark(s).", result.Count);
            }
        }
    }
}
