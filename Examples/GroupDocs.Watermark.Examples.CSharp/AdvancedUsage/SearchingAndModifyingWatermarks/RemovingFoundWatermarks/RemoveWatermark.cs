using GroupDocs.Watermark.Search;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.RemovingFoundWatermarks
{
    /// <summary>
    /// This example shows how to find and remove a particular watermark from a document.
    /// </summary>
    public static class RemoveWatermark
    {
        public static void Run()
        {
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                PossibleWatermarkCollection possibleWatermarks = watermarker.Search();

                // Remove possible watermark at the specified index from the document.
                possibleWatermarks.RemoveAt(0);

                // Remove specified possible watermark from the document.
                possibleWatermarks.Remove(possibleWatermarks[0]);

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
