using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to remove an XObject from a particular page.
    /// </summary>
    public static class PdfRemoveXObject
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfRemoveXObject).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();

                // Remove XObject by index
                pdfContent.Pages[0].XObjects.RemoveAt(0);

                // Remove XObject by reference
                pdfContent.Pages[0].XObjects.Remove(pdfContent.Pages[0].XObjects[0]);

                watermarker.Save(outputFileName);
            }
        }
    }
}
