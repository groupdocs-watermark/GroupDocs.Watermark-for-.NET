using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// Thies example shows how to rasterize the PDF document to protect added watermarks. 
    /// </summary>
    public static class PdfRasterizeDocument
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
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
                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
