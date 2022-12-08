using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to add print only annotation watermark to the document.
    /// </summary>
    public static class PdfAddPrintOnlyAnnotationWatermark
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                TextWatermark textWatermark = new TextWatermark("This is a print only test watermark. It won't appear in view mode.", new Font("Arial", 8));
                bool isPrintOnly = true;

                // Annotation will be printed, but not displayed in pdf viewing application
                PdfAnnotationWatermarkOptions options = new PdfAnnotationWatermarkOptions();
                options.PageIndex = 0;
                options.PrintOnly = isPrintOnly;
                watermarker.Add(textWatermark, options);

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
