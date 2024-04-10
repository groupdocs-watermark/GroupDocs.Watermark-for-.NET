using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to remove a particular shape from a page.
    /// </summary>
    public static class DiagramRemoveShape
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(DiagramRemoveShape).Name}\n");

            string documentPath = Constants.InDiagramVsdx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();

                // Remove shape by index
                content.Pages[0].Shapes.RemoveAt(0);

                // Remove shape by reference
                content.Pages[0].Shapes.Remove(content.Pages[0].Shapes[0]);

                watermarker.Save(outputFileName);
            }
        }
    }
}
