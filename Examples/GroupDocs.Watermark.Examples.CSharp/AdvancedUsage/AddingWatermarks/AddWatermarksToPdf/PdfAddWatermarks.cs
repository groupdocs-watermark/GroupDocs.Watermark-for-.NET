// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to add watermark to a particular page of a PDF document.
    /// </summary>
    public static class PdfAddWatermarks
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                // Add text watermark to the first page
                TextWatermark textWatermark = new TextWatermark("This is a test watermark", new Font("Arial", 8));
                PdfArtifactWatermarkOptions textWatermarkOptions = new PdfArtifactWatermarkOptions();
                textWatermarkOptions.PageIndex = 0;

                watermarker.Add(textWatermark, textWatermarkOptions);

                // Add image watermark to the second page
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.ProtectJpg))
                {
                    PdfArtifactWatermarkOptions imageWatermarkOptions = new PdfArtifactWatermarkOptions();
                    imageWatermarkOptions.PageIndex = 1;
                    watermarker.Add(imageWatermark, imageWatermarkOptions);
                }

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
