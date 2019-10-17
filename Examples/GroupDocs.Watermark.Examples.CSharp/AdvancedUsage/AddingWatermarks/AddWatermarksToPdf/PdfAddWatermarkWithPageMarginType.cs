// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    using Common;
    using Contents.Pdf;
    using Options.Pdf;
    using Watermarks;

    /// <summary>
    /// This example shows how to get watermark aligned to bleed box.
    /// </summary>
    public static class PdfAddWatermarkWithPageMarginType
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 42));
                watermark.HorizontalAlignment = HorizontalAlignment.Right;
                watermark.VerticalAlignment = VerticalAlignment.Top;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;

                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                pdfContent.PageMarginType = PdfPageMarginType.BleedBox;
                watermark.ConsiderParentMargins = true;

                watermarker.Add(watermark);
                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}