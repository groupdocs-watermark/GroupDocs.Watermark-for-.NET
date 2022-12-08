using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to remove hyperlink associated with a particular shape.
    /// </summary>
    public static class DiagramRemoveHyperlinks
    {
        public static void Run()
        {
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();
                DiagramShape shape = content.Pages[0].Shapes[0];
                for (int i = shape.Hyperlinks.Count - 1; i >= 0; i--)
                {
                    if (shape.Hyperlinks[i].Address.Contains("http://someurl.com"))
                    {
                        shape.Hyperlinks.RemoveAt(i);
                    }
                }

                watermarker.Save(Constants.OutDiagramVsdx);
            }
        }
    }
}
