using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to replace shapes' text.
    /// </summary>
    public static class DiagramReplaceTextForParticularShapes
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(DiagramReplaceTextForParticularShapes).Name}\n");

            string documentPath = Constants.InDiagramVsdx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();
                foreach (DiagramShape shape in content.Pages[0].Shapes)
                {
                    if (shape.Text != null && shape.Text.Contains("© Aspose 2016"))
                    {
                        shape.Text = "© GroupDocs 2017";
                    }
                }

                // Save changes
                watermarker.Save(outputFileName);
            }
        }
    }
}
