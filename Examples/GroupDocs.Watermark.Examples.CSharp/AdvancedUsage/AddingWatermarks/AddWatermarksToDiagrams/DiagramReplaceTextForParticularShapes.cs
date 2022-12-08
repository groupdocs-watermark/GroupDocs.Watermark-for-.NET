// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to replace shapes' text.
    /// </summary>
    public static class DiagramReplaceTextForParticularShapes
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
                    if (shape.Text != null && shape.Text.Contains("© Aspose 2016"))
                    {
                        shape.Text = "© GroupDocs 2017";
                    }
                }

                // Save changes
                watermarker.Save(Constants.OutDiagramVsdx);
            }
        }
    }
}
