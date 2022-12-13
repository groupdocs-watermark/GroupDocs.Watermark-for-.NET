using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to add watermark to the headers of a particular section.
    /// </summary>
    public static class WordProcessingAddWatermarkToSection
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

                // Add watermark to all headers of the first section
                WordProcessingWatermarkSectionOptions options = new WordProcessingWatermarkSectionOptions();
                options.SectionIndex = 0;
                watermarker.Add(watermark, options);

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}
