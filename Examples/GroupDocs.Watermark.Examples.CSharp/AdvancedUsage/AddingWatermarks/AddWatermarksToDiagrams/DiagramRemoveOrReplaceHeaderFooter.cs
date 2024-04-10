using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to remove and replace a particular header and footer in a Diagram document.
    /// </summary>
    public static class DiagramRemoveOrReplaceHeaderFooter
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(DiagramRemoveOrReplaceHeaderFooter).Name}\n");

            string documentPath = Constants.InDiagramVsdx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();

                // Remove header
                content.HeaderFooter.HeaderCenter = null;

                // Replace footer
                content.HeaderFooter.FooterCenter = "Footer center";
                content.HeaderFooter.Font.Size = 19;
                content.HeaderFooter.Font.FamilyName = "Calibri";
                content.HeaderFooter.TextColor = Color.Red;

                watermarker.Save(outputFileName);
            }
        }
    }
}
