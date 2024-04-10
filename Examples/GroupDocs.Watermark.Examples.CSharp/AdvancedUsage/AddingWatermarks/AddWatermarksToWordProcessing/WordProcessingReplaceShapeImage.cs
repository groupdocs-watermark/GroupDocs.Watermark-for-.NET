using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to replace the image of the particular shapes in a Word document.
    /// </summary>
    public static class WordProcessingReplaceShapeImage
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingReplaceShapeImage).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                // Set shape image
                foreach (WordProcessingShape shape in content.Sections[0].Shapes)
                {
                    if (shape.Image != null)
                    {
                        shape.Image = new WordProcessingWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
                    }
                }

                // Save document
                watermarker.Save(outputFileName);
            }
        }
    }
}
