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
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
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
