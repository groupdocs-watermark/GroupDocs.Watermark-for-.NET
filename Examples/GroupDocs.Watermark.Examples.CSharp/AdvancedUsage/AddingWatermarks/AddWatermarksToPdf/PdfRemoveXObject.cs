using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to remove an XObject from a particular page.
    /// </summary>
    public static class PdfRemoveXObject
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();

                // Remove XObject by index
                pdfContent.Pages[0].XObjects.RemoveAt(0);

                // Remove XObject by reference
                pdfContent.Pages[0].XObjects.Remove(pdfContent.Pages[0].XObjects[0]);

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
