using System;
using System.IO;
using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to replace the image of a particular XObject.
    /// </summary>
    public static class PdfReplaceImageForParticularXObject
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfReplaceImageForParticularXObject).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
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
                watermarker.Save(outputFileName);
            }
        }
    }
}
