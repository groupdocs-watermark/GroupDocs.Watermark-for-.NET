using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to modify properties of particular shapes in a Word document.
    /// </summary>
    public static class WordProcessingModifyShapeProperties
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingModifyShapeProperties).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                // Change shape properties
                foreach (WordProcessingShape shape in content.Sections[0].Shapes)
                {
                    if (shape.Text.Contains("Some text"))
                    {
                        shape.AlternativeText = "watermark";
                        shape.RotateAngle = 30;
                        shape.X = 200;
                        shape.Y = 200;
                        shape.Height = 100;
                        shape.Width = 400;
                        shape.BehindText = false;
                    }
                }

                // Save document
                watermarker.Save(outputFileName);
            }
        }
    }
}
