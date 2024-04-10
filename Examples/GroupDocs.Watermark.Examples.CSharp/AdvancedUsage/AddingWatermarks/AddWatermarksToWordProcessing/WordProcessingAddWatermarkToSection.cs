using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to add watermark to the headers of a particular section.
    /// </summary>
    public static class WordProcessingAddWatermarkToSection
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingAddWatermarkToSection).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

                // Add watermark to all headers of the first section
                WordProcessingWatermarkSectionOptions options = new WordProcessingWatermarkSectionOptions();
                options.SectionIndex = 0;
                watermarker.Add(watermark, options);

                watermarker.Save(outputFileName);
            }
        }
    }
}
