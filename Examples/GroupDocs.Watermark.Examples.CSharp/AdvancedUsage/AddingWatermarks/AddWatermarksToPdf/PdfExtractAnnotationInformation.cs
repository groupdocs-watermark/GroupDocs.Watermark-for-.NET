using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to extract information about all the annotations in a PDF document.
    /// </summary>
    public static class PdfExtractAnnotationInformation
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
                    foreach (PdfAnnotation annotation in page.Annotations)
                    {
                        Console.WriteLine(annotation.AnnotationType);
                        if (annotation.Image != null)
                        {
                            Console.WriteLine(annotation.Image.Width);
                            Console.WriteLine(annotation.Image.Height);
                            Console.WriteLine(annotation.Image.GetBytes().Length);
                        }

                        Console.WriteLine(annotation.Text);
                        Console.WriteLine(annotation.X);
                        Console.WriteLine(annotation.Y);
                        Console.WriteLine(annotation.Width);
                        Console.WriteLine(annotation.Height);
                        Console.WriteLine(annotation.RotateAngle);
                    }
                }
            }
        }
    }
}
