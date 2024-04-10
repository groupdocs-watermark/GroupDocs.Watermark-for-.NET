using System;
using System.IO;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.Objects;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    /// <summary>
    /// This example shows how to set searchable objects for a particular Watermarker instance.
    /// </summary>
    public static class SearchWatermarkInParticularObjectsForParticularDocument
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SearchWatermarkInParticularObjectsForParticularDocument).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Search for hyperlinks only.
                watermarker.SearchableObjects.PdfSearchableObjects = PdfSearchableObjects.Hyperlinks;
                PossibleWatermarkCollection watermarks = watermarker.Search();

                // The code for working with found watermarks goes here.

                Console.WriteLine("Found {0} hyperlink watermark(s).", watermarks.Count);
            }
        }
    }
}
