// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    using Contents.Diagram;
    using Options.Diagram;
    using Watermarks;

    /// <summary>
    /// This example shows how to remove and replace a particular header and footer in a Diagram document.
    /// </summary>
    public static class DiagramRemoveOrReplaceHeaderFooter
    {
        public static void Run()
        {
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();

                // Remove header
                content.HeaderFooter.HeaderCenter = null;

                // Replace footer
                content.HeaderFooter.FooterCenter = "Footer center";
                content.HeaderFooter.Font.Size = 19;
                content.HeaderFooter.Font.FamilyName = "Calibri";
                content.HeaderFooter.TextColor = Color.Red;

                watermarker.Save(Constants.OutDiagramVsdx);
            }
        }
    }
}