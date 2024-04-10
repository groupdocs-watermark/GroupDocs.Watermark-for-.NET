using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// Thies example shows how to rasterize the PDF document to protect added watermarks. 
    /// </summary>
    public static class PdfRasterizeDocument
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfRasterizeDocument).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Initialize image or text watermark
                TextWatermark watermark = new TextWatermark("Do not copy", new Font("Arial", 8));
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.RotateAngle = 45;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;
                watermark.Opacity = 0.5;

                // Add watermark of any type first
                watermarker.Add(watermark);

                PdfContent pdfContent = watermarker.GetContent<PdfContent>();

                // Rasterize all pages
                pdfContent.Rasterize(100, 100, PdfImageConversionFormat.Png);

                // Content of all pages is replaced with raster images
                watermarker.Save(outputFileName);
            }
        }
    }
}
