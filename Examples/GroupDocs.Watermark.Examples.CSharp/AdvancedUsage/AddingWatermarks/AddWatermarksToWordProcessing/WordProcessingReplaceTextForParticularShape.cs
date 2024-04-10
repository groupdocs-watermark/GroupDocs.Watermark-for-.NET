using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to replace text for particular shapes in a Word document.
    /// </summary>
    public static class WordProcessingReplaceTextForParticularShape
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingReplaceTextForParticularShape).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                // Set shape's text
                foreach (WordProcessingShape shape in content.Sections[0].Shapes)
                {
                    if (shape.Text.Contains("Some text"))
                    {
                        shape.Text = "Another text";
                    }
                }

                // Save document
                watermarker.Save(outputFileName);
            }
        }
    }
}
