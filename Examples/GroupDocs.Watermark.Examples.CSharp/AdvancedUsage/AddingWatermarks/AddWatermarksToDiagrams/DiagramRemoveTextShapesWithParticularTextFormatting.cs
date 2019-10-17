// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    using Contents.Diagram;
    using Options.Diagram;
    using Search;
    using Watermarks;

    /// <summary>
    /// This example shows how to find and remove the shapes with a particular text formatting.
    /// </summary>
    public static class DiagramRemoveTextShapesWithParticularTextFormatting
    {
        public static void Run()
        {
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();
                foreach (DiagramPage page in content.Pages)
                {
                    for (int i = page.Shapes.Count - 1; i >= 0; i--)
                    {
                        foreach (FormattedTextFragment fragment in page.Shapes[i].FormattedTextFragments)
                        {
                            if (fragment.ForegroundColor == Color.Red && fragment.Font.FamilyName == "Arial")
                            {
                                page.Shapes.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }

                watermarker.Save(Constants.OutDiagramVsdx);
            }
        }
    }
}