using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
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
