// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// this example shows how to add watermark to a particular type of the pages.
    /// </summary>
    public static class DiagramAddWatermarkToAllPagesOfParticularType
    {
        public static void Run()
        {
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
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

                watermarker.Save(Constants.OutDiagramVsdx);
            }
        }
    }
}
