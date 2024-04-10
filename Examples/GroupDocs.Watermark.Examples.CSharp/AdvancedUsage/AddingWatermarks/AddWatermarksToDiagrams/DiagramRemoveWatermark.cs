using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to remove watermark from a particular page.
    /// </summary>
    public static class DiagramRemoveWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(DiagramRemoveWatermark).Name}\n");

            string documentPath = Constants.InDiagramVsdx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();

                // Initialize search criteria
                ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.LogoPng);
                TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                // Call FindWatermarks method for the first page
                PossibleWatermarkCollection possibleWatermarks = content.Pages[0].Search(textSearchCriteria.Or(imageSearchCriteria));

                // Remove all found watermarks
                possibleWatermarks.Clear();

                watermarker.Save(outputFileName);
            }
        }
    }
}
