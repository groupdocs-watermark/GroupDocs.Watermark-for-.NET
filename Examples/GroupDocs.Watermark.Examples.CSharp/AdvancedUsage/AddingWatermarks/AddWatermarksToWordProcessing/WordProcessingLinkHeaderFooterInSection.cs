using GroupDocs.Watermark.Contents;
using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to link the header/footer.
    /// </summary>
    public static class WordProcessingLinkHeaderFooterInSection
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingLinkHeaderFooterInSection).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                // Link footer for even numbered pages to corresponding footer in previous section
                content.Sections[1].HeadersFooters[OfficeHeaderFooterType.FooterEven].IsLinkedToPrevious = true;

                watermarker.Save(outputFileName);
            }
        }
    }
}
