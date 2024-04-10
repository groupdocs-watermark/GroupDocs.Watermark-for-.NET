using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to remove watermarks from a particular page.
    /// </summary>
    public static class PdfRemoveWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfRemoveWatermark).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Initialize search criteria
                ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.LogoPng);
                TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                PossibleWatermarkCollection possibleWatermarks = pdfContent.Pages[0].Search(imageSearchCriteria.Or(textSearchCriteria));

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
