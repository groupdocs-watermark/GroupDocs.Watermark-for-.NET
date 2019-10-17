// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    using Contents.Pdf;
    using Options.Pdf;

    /// <summary>
    /// This example shows how to replace the text of the particular artifacts.
    /// </summary>
    public static class PdfReplaceTextForParticularArtifact
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                foreach (PdfArtifact artifact in pdfContent.Pages[0].Artifacts)
                {
                    // Replace text
                    if (artifact.Text.Contains("Test"))
                    {
                        artifact.Text = "Passed";
                    }
                }

                // Save document
                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}