using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to find and remove the shapes with a particular text formatting.
    /// </summary>
    public static class DiagramRemoveTextShapesWithParticularTextFormatting
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(DiagramRemoveTextShapesWithParticularTextFormatting).Name}\n");

            string documentPath = Constants.InDiagramVsdx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();
                foreach (DiagramPage page in content.Pages)
                {
                    for (int i = page.Shapes.Count - 1; i >= 0; i--)
                    {
                        foreach (FormattedTextFragment fragment in page.Shapes[i].FormattedTextFragments)
                        {
                            if (fragment.ForegroundColor.Equals(Color.Red) && fragment.Font.FamilyName == "Arial")
                            {
                                page.Shapes.RemoveAt(i);
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
