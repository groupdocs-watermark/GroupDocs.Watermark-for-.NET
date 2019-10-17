// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    using Contents.Diagram;
    using Options.Diagram;
    using Watermarks;

    /// <summary>
    /// This example shows how to replace the text with a formatted text.
    /// </summary>
    public static class DiagramReplaceTextWithFormatting
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
                        shape.FormattedTextFragments.Clear();
                        shape.FormattedTextFragments.Add("© GroupDocs 2017", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
                    }
                }

                // Save changes
                watermarker.Save(Constants.OutDiagramVsdx);
            }
        }
    }
}