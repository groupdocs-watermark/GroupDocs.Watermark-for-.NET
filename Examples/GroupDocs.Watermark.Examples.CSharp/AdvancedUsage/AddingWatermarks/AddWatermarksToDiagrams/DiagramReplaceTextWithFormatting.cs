using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to replace the text with a formatted text.
    /// </summary>
    public static class DiagramReplaceTextWithFormatting
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(DiagramReplaceTextWithFormatting).Name}\n");

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
                        shape.FormattedTextFragments.Clear();
                        shape.FormattedTextFragments.Add("© GroupDocs 2017", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
                    }
                }

                // Save changes
                watermarker.Save(outputFileName);
            }
        }
    }
}
