using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to rasterize any particular page of the PDF document.
    /// </summary>
    public static class PdfRasterizePage
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfRasterizePage).Name}\n");

            string documentPath = Constants.SamplePdf;
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
                PdfArtifactWatermarkOptions options = new PdfArtifactWatermarkOptions();
                options.PageIndex = 0;
                watermarker.Add(watermark, options);

                // Rasterize the first page
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                pdfContent.Pages[0].Rasterize(100, 100, PdfImageConversionFormat.Png);

                // Content of the first page is replaced with raster image
                watermarker.Save(outputFileName);
            }
        }
    }
}
