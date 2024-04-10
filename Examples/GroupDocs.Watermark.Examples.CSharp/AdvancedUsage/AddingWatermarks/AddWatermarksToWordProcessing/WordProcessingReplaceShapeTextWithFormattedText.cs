using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to replace the text of the shapes with formatted text.
    /// </summary>
    public static class WordProcessingReplaceShapeTextWithFormattedText
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingReplaceShapeTextWithFormattedText).Name}\n");

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
                        shape.FormattedTextFragments.Clear();
                        shape.FormattedTextFragments.Add("Another text", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
                    }
                }

                // Save document
                watermarker.Save(outputFileName);
            }
        }
    }
}
