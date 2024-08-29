using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to place the watermark on separate newly created background pages.
    /// </summary>
    public static class DiagramAddWatermarkToSeparateBackgroundPage
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(DiagramAddWatermarkToParticularPage).Name}");

            string documentPath = Constants.InDiagramVsdx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Initialize watermark of any supported type
                TextWatermark textWatermark = new TextWatermark("Test watermark 1", new Font("Calibri", 19));

                DiagramShapeWatermarkOptions options = new DiagramShapeWatermarkOptions();
                options.PlacementType = DiagramWatermarkPlacementType.SeparateBackgrounds;

                // Create separate background for each page where it is not set. Add watermark to it.
                watermarker.Add(textWatermark, options);

                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
