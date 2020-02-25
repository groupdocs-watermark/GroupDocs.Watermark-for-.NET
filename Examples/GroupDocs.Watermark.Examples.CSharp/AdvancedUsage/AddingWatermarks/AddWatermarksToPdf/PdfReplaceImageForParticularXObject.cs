// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    using System.IO;
    using Contents.Pdf;
    using Options.Pdf;

    /// <summary>
    /// This example shows how to replace the image of a particular XObject.
    /// </summary>
    public static class PdfReplaceImageForParticularXObject
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();

                // Replace image
                foreach (PdfXObject xObject in pdfContent.Pages[0].XObjects)
                {
                    if (xObject.Image != null)
                    {
                        xObject.Image = new PdfWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
                    }
                }

                // Save document
                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}