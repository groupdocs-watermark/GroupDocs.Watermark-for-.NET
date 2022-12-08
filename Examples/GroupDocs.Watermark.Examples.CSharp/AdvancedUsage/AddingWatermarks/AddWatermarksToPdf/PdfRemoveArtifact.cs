// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to remove an artifact from a particular page of the PDF document.
    /// </summary>
    public static class PdfRemoveArtifact
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();

                // Remove Artifact by index
                pdfContent.Pages[0].Artifacts.RemoveAt(0);

                // Remove Artifact by reference
                pdfContent.Pages[0].Artifacts.Remove(pdfContent.Pages[0].Artifacts[0]);

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
