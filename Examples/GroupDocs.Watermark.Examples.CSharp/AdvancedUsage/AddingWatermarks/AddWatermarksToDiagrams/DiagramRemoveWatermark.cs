// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    using Contents.Diagram;
    using Options.Diagram;
    using Search;
    using Search.SearchCriteria;

    /// <summary>
    /// This example shows how to remove watermark from a particular page.
    /// </summary>
    public static class DiagramRemoveWatermark
    {
        public static void Run()
        {
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();

                // Initialize search criteria
                ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.LogoPng);
                TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                // Call FindWatermarks method for the first page
                PossibleWatermarkCollection possibleWatermarks = content.Pages[0].Search(textSearchCriteria.Or(imageSearchCriteria));

                // Remove all found watermarks
                possibleWatermarks.Clear();

                watermarker.Save(Constants.OutDiagramVsdx);
            }
        }
    }
}