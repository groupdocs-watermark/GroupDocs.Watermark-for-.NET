using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to add watermark to all image XObjects in a PDF document.
    /// </summary>
    public static class PdfAddWatermarkToXObjects
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfAddWatermarkToXObjects).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();

                // Initialize image or text watermark
                TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.RotateAngle = 45;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;

                foreach (PdfPage page in pdfContent.Pages)
                {
                    foreach (PdfXObject xObject in page.XObjects)
                    {
                        if (xObject.Image != null)
                        {
                            // Add watermark to the image
                            xObject.Image.Add(watermark);
                        }
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
