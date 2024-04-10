using GroupDocs.Watermark.Contents;
using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to search for particular header/footer.
    /// </summary>
    public static class WordProcessingFindWatermarkInHeaderFooter
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingFindWatermarkInHeaderFooter).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Initialize search criteria
                ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.LogoPng);
                TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                PossibleWatermarkCollection possibleWatermarks = content.Sections[0]
                                                                        .HeadersFooters[OfficeHeaderFooterType.HeaderPrimary]
                                                                        .Search(textSearchCriteria.Or(imageSearchCriteria));

                // Remove all found watermarks
                for (int i = possibleWatermarks.Count - 1; i >= 0; i--)
                {
                    possibleWatermarks.RemoveAt(i);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
