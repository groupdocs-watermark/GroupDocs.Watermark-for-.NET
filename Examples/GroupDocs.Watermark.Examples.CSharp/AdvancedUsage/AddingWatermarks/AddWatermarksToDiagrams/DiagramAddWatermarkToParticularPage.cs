using GroupDocs.Watermark.Options.Diagram;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to add watermark to a particular page of the document.
    /// </summary>
    public static class DiagramAddWatermarkToParticularPage
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
                TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Calibri", 19));

                DiagramPageWatermarkOptions textWatermarkOptions = new DiagramPageWatermarkOptions();
                textWatermarkOptions.PageIndex = 0;

                // Add text watermark to the first page
                watermarker.Add(textWatermark, textWatermarkOptions);

                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.LogoJpg))
                {
                    DiagramPageWatermarkOptions imageWatermarkOptions = new DiagramPageWatermarkOptions();
                    imageWatermarkOptions.PageIndex = 1;

                    // Add image watermark to the second page
                    watermarker.Add(imageWatermark, imageWatermarkOptions);
                }

                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
