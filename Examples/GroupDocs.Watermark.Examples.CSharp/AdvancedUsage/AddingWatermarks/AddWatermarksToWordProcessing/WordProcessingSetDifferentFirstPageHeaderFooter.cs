using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to set different headers/footers for even/odd numbered pages and for the first page of the document
    /// </summary>
    public static class WordProcessingSetDifferentFirstPageHeaderFooter
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                content.Sections[0].PageSetup.DifferentFirstPageHeaderFooter = true;
                content.Sections[0].PageSetup.OddAndEvenPagesHeaderFooter = true;

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}
