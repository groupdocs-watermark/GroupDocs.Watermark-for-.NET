using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to remove attachments from the PDF document.
    /// </summary>
    public static class PdfRemoveAttachment
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                for (int i = pdfContent.Attachments.Count - 1; i >= 0; i--)
                {
                    PdfAttachment attachment = pdfContent.Attachments[i];

                    // Remove all attached pdf files with a particular name
                    if (attachment.Name.Contains("sample") && attachment.GetDocumentInfo().FileType == FileType.DOCX)
                    {
                        pdfContent.Attachments.RemoveAt(i);
                    }
                }

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
