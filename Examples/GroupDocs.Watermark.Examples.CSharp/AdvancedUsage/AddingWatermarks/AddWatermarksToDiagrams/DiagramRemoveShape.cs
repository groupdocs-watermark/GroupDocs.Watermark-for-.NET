// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to remove a particular shape from a page.
    /// </summary>
    public static class DiagramRemoveShape
    {
        public static void Run()
        {
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();

                // Remove shape by index
                content.Pages[0].Shapes.RemoveAt(0);

                // Remove shape by reference
                content.Pages[0].Shapes.Remove(content.Pages[0].Shapes[0]);

                watermarker.Save(Constants.OutDiagramVsdx);
            }
        }
    }
}
