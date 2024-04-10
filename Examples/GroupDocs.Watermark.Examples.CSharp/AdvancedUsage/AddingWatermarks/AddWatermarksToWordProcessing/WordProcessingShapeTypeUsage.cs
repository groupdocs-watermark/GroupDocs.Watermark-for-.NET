using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example demonstrates the usage of WordProcessingShapeType enum.
    /// </summary>
    public static class WordProcessingShapeTypeUsage
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingShapeTypeUsage).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                foreach (WordProcessingSection section in content.Sections)
                {
                    foreach (WordProcessingShape shape in section.Shapes)
                    {
                        //Check for Diagonal Corners Rounded shapes
                        if (shape.ShapeType == WordProcessingShapeType.DiagonalCornersRounded)
                        {
                            Console.WriteLine("Diagonal Corners Rounded shape found");

                            //Write text on all Diagonal Corners Rounded shapes
                            shape.FormattedTextFragments.Add("I am Diagonal Corner Rounded", new Font("Calibri", 8, FontStyle.Bold), Color.Red, Color.Aqua);
                        }
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
