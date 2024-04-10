using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to replace the image of particular shapes.
    /// </summary>
    public static class DiagramReplaceShapeImage
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(DiagramReplaceShapeImage).Name}\n");

            string documentPath = Constants.InDiagramVsdx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();
                foreach (DiagramShape shape in content.Pages[0].Shapes)
                {
                    if (shape.Image != null)
                    {
                        shape.Image = new DiagramWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
                    }
                }

                // Save changes
                watermarker.Save(outputFileName);
            }
        }
    }
}
