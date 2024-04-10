using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// Thies example shows how to add watermark to supported files in all attachments in a PDF document.
    /// </summary>
    public static class PdfAddWatermarkToAllAttachments
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfAddWatermarkToAllAttachments).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            TextWatermark watermark = new TextWatermark("This is WaterMark on Attachment", new Font("Arial", 19));
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                foreach (PdfAttachment attachment in pdfContent.Attachments)
                {
                    // Check if the attached file is supported by GroupDocs.Watermark
                    IDocumentInfo info = attachment.GetDocumentInfo();
                    if (info.FileType != FileType.Unknown && !info.IsEncrypted)
                    {
                        // Load the attached document
                        using (Watermarker attachedWatermarker = attachment.CreateWatermarker())
                        {
                            // Add wateramrk
                            attachedWatermarker.Add(watermark);

                            // Save changes in the attached file
                            attachedWatermarker.Save();
                        }
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
