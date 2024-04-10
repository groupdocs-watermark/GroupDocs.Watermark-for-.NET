using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to extract information about all the XObjects in a PDF document.
    /// </summary>
    public static class PdfExtractXObjectInformation
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfExtractXObjectInformation).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
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
