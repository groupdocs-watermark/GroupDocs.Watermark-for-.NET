// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to replace the image of particular shapes.
    /// </summary>
    public static class DiagramReplaceShapeImage
    {
        public static void Run()
        {
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();
                foreach (DiagramShape shape in content.Pages[0].Shapes)
                {
                    if (shape.Image != null)
                    {
                        shape.Image = new DiagramWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
                    }
                }

                // Save changes
                watermarker.Save(Constants.OutDiagramVsdx);
            }
        }
    }
}
