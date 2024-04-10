using System;
using System.IO;
using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to extract attachments in PDF document.
    /// </summary>
    public static class PdfExtractAllAttachments
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfExtractAllAttachments).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                foreach (PdfAttachment attachment in pdfContent.Attachments)
                {
                    Console.WriteLine("Name: {0}", attachment.Name);
                    Console.WriteLine("Description: {0}", attachment.Description);
                    Console.WriteLine("File type: {0}", attachment.GetDocumentInfo().FileType);

                    // Save the attached file on disk
                    File.WriteAllBytes(Path.Combine(Constants.OutputPath, attachment.Name), attachment.Content);
                }
            }
        }
    }
}
