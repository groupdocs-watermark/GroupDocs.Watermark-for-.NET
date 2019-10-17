// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    using Contents.Diagram;
    using Options.Diagram;
    using Watermarks;

    /// <summary>
    /// This example shows how to place the watermark on separate newly created background pages.
    /// </summary>
    public static class DiagramAddWatermarkToSeparateBackgroundPage
    {
        public static void Run()
        {
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
            {
                // Initialize watermark of any supported type
                TextWatermark textWatermark = new TextWatermark("Test watermark 1", new Font("Calibri", 19));

                DiagramShapeWatermarkOptions options = new DiagramShapeWatermarkOptions();
                options.PlacementType = DiagramWatermarkPlacementType.SeparateBackgrounds;

                // Create separate background for each page where it is not set. Add watermark to it.
                watermarker.Add(textWatermark, options);

                watermarker.Save(Constants.OutDiagramVsdx);
            }
        }
    }
}