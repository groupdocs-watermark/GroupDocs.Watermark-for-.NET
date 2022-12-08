using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to add watermark to a particular page of a Word document.
    /// </summary>
    public static class WordProcessingAddWatermarkToParticularPage
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                TextWatermark textWatermark = new TextWatermark("DRAFT", new Font("Arial", 42));

                // Add watermark to the last page
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                WordProcessingWatermarkPagesOptions options = new WordProcessingWatermarkPagesOptions();
                options.PageNumbers = new int[] {content.PageCount};

                watermarker.Add(textWatermark, options);
                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}
