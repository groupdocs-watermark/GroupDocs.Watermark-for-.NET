// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    using System.IO;
    using Contents.Diagram;
    using Options.Diagram;

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