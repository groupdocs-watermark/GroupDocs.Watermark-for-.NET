// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Search;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to find and remove all artifacts containing text with a particular formatting from a PDF document.
    /// </summary>
    public static class PdfRemoveArtifactsWithParticularTextFormatting
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                foreach (PdfPage page in pdfContent.Pages)
                {
                    for (int i = page.Artifacts.Count - 1; i >= 0; i--)
                    {
                        foreach (FormattedTextFragment fragment in page.Artifacts[i].FormattedTextFragments)
                        {
                            if (fragment.Font.Size > 42)
                            {
                                page.Artifacts.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
