using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// this example shows how to add watermark to a particular type of the pages.
    /// </summary>
    public static class DiagramAddWatermarkToAllPagesOfParticularType
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(DiagramAddWatermarkToAllPagesOfParticularType).Name}");

            string documentPath = Constants.InDiagramVsdx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));
            
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Initialize text watermark
                TextWatermark textWatermark = new TextWatermark("Test watermark 1", new Font("Calibri", 19));

                DiagramShapeWatermarkOptions textWatermarkOptions = new DiagramShapeWatermarkOptions();
                textWatermarkOptions.PlacementType = DiagramWatermarkPlacementType.BackgroundPages;

                // Add text watermark to all background pages
                watermarker.Add(textWatermark, textWatermarkOptions);

                // Initialize image watermark
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.LogoJpg))
                {
                    DiagramShapeWatermarkOptions imageWatermarkOptions = new DiagramShapeWatermarkOptions();
                    imageWatermarkOptions.PlacementType = DiagramWatermarkPlacementType.ForegroundPages;

                    // Add image watermark to all foreground pages
                    watermarker.Add(imageWatermark, imageWatermarkOptions);
                }

                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
