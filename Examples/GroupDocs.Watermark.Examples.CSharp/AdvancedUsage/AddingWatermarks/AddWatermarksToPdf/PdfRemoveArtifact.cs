using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to remove an artifact from a particular page of the PDF document.
    /// </summary>
    public static class PdfRemoveArtifact
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfRemoveArtifact).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();

                // Remove Artifact by index
                pdfContent.Pages[0].Artifacts.RemoveAt(0);

                // Remove Artifact by reference
                pdfContent.Pages[0].Artifacts.Remove(pdfContent.Pages[0].Artifacts[0]);

                watermarker.Save(outputFileName);
            }
        }
    }
}
