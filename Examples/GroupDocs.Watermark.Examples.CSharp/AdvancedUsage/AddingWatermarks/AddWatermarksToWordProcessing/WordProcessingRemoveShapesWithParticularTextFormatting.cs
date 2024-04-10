using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to find and remove the shapes with a particular text formatting.
    /// </summary>
    public static class WordProcessingRemoveShapesWithParticularTextFormatting
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingRemoveShapesWithParticularTextFormatting).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                foreach (WordProcessingSection section in content.Sections)
                {
                    for (int i = section.Shapes.Count - 1; i >= 0; i--)
                    {
                        foreach (FormattedTextFragment fragment in section.Shapes[i].FormattedTextFragments)
                        {
                            if (fragment.ForegroundColor.Equals(Color.Red) && fragment.Font.FamilyName == "Arial")
                            {
                                section.Shapes.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
