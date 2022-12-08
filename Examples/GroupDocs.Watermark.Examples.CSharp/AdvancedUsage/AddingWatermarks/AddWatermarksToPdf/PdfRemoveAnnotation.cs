using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to remove a particular annotation from a PDF document.
    /// </summary>
    public static class PdfRemoveAnnotation
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();

                // Remove Annotation by index
                pdfContent.Pages[0].Annotations.RemoveAt(0);

                // Remove Annotation by reference
                pdfContent.Pages[0].Annotations.Remove(pdfContent.Pages[0].Annotations[0]);

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
