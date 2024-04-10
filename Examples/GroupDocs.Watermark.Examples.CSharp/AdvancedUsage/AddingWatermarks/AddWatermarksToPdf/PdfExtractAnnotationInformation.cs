using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to extract information about all the annotations in a PDF document.
    /// </summary>
    public static class PdfExtractAnnotationInformation
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfExtractAnnotationInformation).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
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
