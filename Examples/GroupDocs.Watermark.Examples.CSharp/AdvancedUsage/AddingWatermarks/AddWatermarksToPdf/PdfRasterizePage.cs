// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    using Common;
    using Contents.Pdf;
    using Options.Pdf;
    using Watermarks;

    /// <summary>
    /// This example shows how to rasterize any particular page of the PDF document.
    /// </summary>
    public static class PdfRasterizePage
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
                PdfArtifactWatermarkOptions options = new PdfArtifactWatermarkOptions();
                options.PageIndex = 0;
                watermarker.Add(watermark, options);

                // Rasterize the first page
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                pdfContent.Pages[0].Rasterize(100, 100, PdfImageConversionFormat.Png);

                // Content of the first page is replaced with raster image
                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}