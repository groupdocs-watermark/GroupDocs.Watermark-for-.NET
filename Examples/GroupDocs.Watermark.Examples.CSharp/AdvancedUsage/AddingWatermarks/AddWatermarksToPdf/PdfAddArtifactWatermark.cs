// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// Thies example shows how to add an artifact watermark to a document.
    /// </summary>
    public static class PdfAddArtifactWatermark
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                PdfArtifactWatermarkOptions options = new PdfArtifactWatermarkOptions();

                // Add text watermark
                TextWatermark textWatermark = new TextWatermark("This is an artifact watermark", new Font("Arial", 8));
                textWatermark.HorizontalAlignment = HorizontalAlignment.Right;
                watermarker.Add(textWatermark, options);

                // Add image watermark
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.LogoBmp))
                {
                    watermarker.Add(imageWatermark, options);
                }

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
