// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// Thies example shows how to add watermark annotation to a PDF document.
    /// </summary>
    public static class PdfAddAnnotationWatermark
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                PdfAnnotationWatermarkOptions options = new PdfAnnotationWatermarkOptions();

                // Add text watermark
                TextWatermark textWatermark = new TextWatermark("This is a annotation watermark", new Font("Arial", 8));
                textWatermark.HorizontalAlignment = HorizontalAlignment.Left;
                textWatermark.VerticalAlignment = VerticalAlignment.Top;
                watermarker.Add(textWatermark, options);

                // Add image watermark
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.ProtectJpg))
                {
                    imageWatermark.HorizontalAlignment = HorizontalAlignment.Right;
                    imageWatermark.VerticalAlignment = VerticalAlignment.Top;
                    watermarker.Add(imageWatermark, options);
                }

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
