// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// Thies example shows how to add watermark to supported files in all attachments in a PDF document.
    /// </summary>
    public static class PdfAddWatermarkToAllAttachments
    {
        public static void Run()
        {
            TextWatermark watermark = new TextWatermark("This is WaterMark on Attachment", new Font("Arial", 19));
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
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

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
