using System;
using System.IO;
using GroupDocs.Watermark.Contents.Image;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Search.Objects;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to search for all the images attachments in a PDF document.
    /// </summary>
    public static class PdfSearchImageInAttachment
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfSearchImageInAttachment).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Consider only the attached images
                watermarker.SearchableObjects.PdfSearchableObjects = PdfSearchableObjects.AttachedImages;

                // Search for similar images
                WatermarkableImageCollection possibleWatermarks = watermarker.GetImages();

                Console.WriteLine("Found {0} image(s).", possibleWatermarks.Count);
            }
        }
    }
}
