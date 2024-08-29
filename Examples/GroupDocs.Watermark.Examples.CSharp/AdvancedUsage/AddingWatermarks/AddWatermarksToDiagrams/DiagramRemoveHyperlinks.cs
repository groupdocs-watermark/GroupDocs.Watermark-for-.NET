using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to remove hyperlink associated with a particular shape.
    /// </summary>
    public static class DiagramRemoveHyperlinks
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(DiagramRemoveHyperlinks).Name}");

            string documentPath = Constants.InDiagramVsdx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();
                DiagramShape shape = content.Pages[0].Shapes[0];
                for (int i = shape.Hyperlinks.Count - 1; i >= 0; i--)
                {
                    if (shape.Hyperlinks[i].Address.Contains("http://someurl.com"))
                    {
                        shape.Hyperlinks.RemoveAt(i);
                    }
                }

                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Watermark removed successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
