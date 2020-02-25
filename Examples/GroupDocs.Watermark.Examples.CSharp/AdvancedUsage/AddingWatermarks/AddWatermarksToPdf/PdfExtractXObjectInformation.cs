// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    using System;
    using Contents.Pdf;
    using Options.Pdf;

    /// <summary>
    /// This example shows how to extract information about all the XObjects in a PDF document.
    /// </summary>
    public static class PdfExtractXObjectInformation
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                foreach (PdfPage page in pdfContent.Pages)
                {
                    foreach (PdfXObject xObject in page.XObjects)
                    {
                        if (xObject.Image != null)
                        {
                            Console.WriteLine(xObject.Image.Width);
                            Console.WriteLine(xObject.Image.Height);
                            Console.WriteLine(xObject.Image.GetBytes().Length);
                        }

                        Console.WriteLine(xObject.Text);
                        Console.WriteLine(xObject.X);
                        Console.WriteLine(xObject.Y);
                        Console.WriteLine(xObject.Width);
                        Console.WriteLine(xObject.Height);
                        Console.WriteLine(xObject.RotateAngle);
                    }
                }
            }
        }
    }
}