// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    using System;
    using Contents.Pdf;
    using Options.Pdf;

    /// <summary>
    /// This example shows how to get the dimensions of the page in a PDF document.
    /// </summary>
    public static class PdfGetDimensions
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();

                Console.WriteLine(pdfContent.Pages[0].Width);
                Console.WriteLine(pdfContent.Pages[0].Height);
            }
        }
    }
}