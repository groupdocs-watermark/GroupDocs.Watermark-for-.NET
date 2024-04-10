using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to remove a particular shape from a Word document.
    /// </summary>
    public static class WordProcessingRemoveShape
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingRemoveShape).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                // Remove shape by index
                content.Sections[0].Shapes.RemoveAt(0);

                // Remove shape by reference
                content.Sections[0].Shapes.Remove(content.Sections[0].Shapes[0]);

                watermarker.Save(outputFileName);
            }
        }
    }
}
