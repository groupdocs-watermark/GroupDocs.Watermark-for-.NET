using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.QuickStart
{
    public static class HelloWorld
    {
        public static void Run()
        {
            string documentPath = Constants.InDocumentPdf; // NOTE: Put here actual path for your document
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 36, FontStyle.Bold | FontStyle.Italic));
                PdfXObjectWatermarkOptions options = new PdfXObjectWatermarkOptions();
                options.PageIndex = 0;

                watermarker.Add(watermark, options);
                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
