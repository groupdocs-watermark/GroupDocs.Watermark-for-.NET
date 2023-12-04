using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to add watermark to particular pages of a PDF document.
    /// </summary>
    public static class PdfAddWatermarksToSpecificPages
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                // Add text watermark to the odd pages
                TextWatermark textWatermark = new TextWatermark("This is a test watermark", new Font("Arial", 8));
                textWatermark.PagesSetup = new PagesSetup
                {
                    OddPages = true
                };
                
                PdfArtifactWatermarkOptions textWatermarkOptions = new PdfArtifactWatermarkOptions();

                watermarker.Add(textWatermark, textWatermarkOptions);

                // Add image watermark to the first page
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.ProtectJpg))
                {
                    imageWatermark.PagesSetup = new PagesSetup
                    {
                        FirstPage = true
                    };
                    
                    PdfArtifactWatermarkOptions imageWatermarkOptions = new PdfArtifactWatermarkOptions();
                    watermarker.Add(imageWatermark, imageWatermarkOptions);
                }

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}