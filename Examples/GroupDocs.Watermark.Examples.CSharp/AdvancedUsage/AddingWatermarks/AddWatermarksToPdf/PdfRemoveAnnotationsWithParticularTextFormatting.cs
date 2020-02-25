// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    using Contents.Pdf;
    using Options.Pdf;
    using Search;

    /// <summary>
    /// This example shows how to find and remove all annotations containing text with a particular formatting from a PDF document.
    /// </summary>
    public static class PdfRemoveAnnotationsWithParticularTextFormatting
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
                    for (int i = page.Annotations.Count - 1; i >= 0; i--)
                    {
                        foreach (FormattedTextFragment fragment in page.Annotations[i].FormattedTextFragments)
                        {
                            if (fragment.Font.FamilyName == "Verdana")
                            {
                                page.Annotations.RemoveAt(i);
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