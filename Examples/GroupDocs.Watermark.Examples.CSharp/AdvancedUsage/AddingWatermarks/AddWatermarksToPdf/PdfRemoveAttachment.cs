using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to remove attachments from the PDF document.
    /// </summary>
    public static class PdfRemoveAttachment
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfRemoveAttachment).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                for (int i = pdfContent.Attachments.Count - 1; i >= 0; i--)
                {
                    PdfAttachment attachment = pdfContent.Attachments[i];

                    // Remove all attached pdf files with a particular name
                    if (attachment.Name.Contains("sample") && attachment.GetDocumentInfo().FileType == FileType.DOCX)
                    {
                        pdfContent.Attachments.RemoveAt(i);
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
