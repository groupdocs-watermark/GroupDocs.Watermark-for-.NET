using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to add watermark to a particular page of a Word document.
    /// </summary>
    public static class WordProcessingAddWatermarkToParticularPage
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingAddWatermarkToParticularPage).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark textWatermark = new TextWatermark("DRAFT", new Font("Arial", 42));

                // Add watermark to the last page
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                WordProcessingWatermarkPagesOptions options = new WordProcessingWatermarkPagesOptions();
                options.PageNumbers = new int[] {content.PageCount};

                watermarker.Add(textWatermark, options);
                watermarker.Save(outputFileName);
            }
        }
    }
}
