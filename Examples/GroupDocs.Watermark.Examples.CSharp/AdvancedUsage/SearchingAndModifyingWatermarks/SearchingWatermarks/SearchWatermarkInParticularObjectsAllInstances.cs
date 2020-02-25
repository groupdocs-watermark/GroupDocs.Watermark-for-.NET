// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    using System;
    using System.IO;
    using Search;
    using Search.Objects;

    /// <summary>
    /// This example shows how to set searchable objects globally (for all documents that will be created after that).
    /// </summary>
    public static class SearchWatermarkInParticularObjectsAllInstances
    {
        public static void Run()
        {
            WatermarkerSettings settings = new WatermarkerSettings();
            settings.SearchableObjects = new SearchableObjects
                                         {
                                             WordProcessingSearchableObjects = WordProcessingSearchableObjects.Hyperlinks | WordProcessingSearchableObjects.Text,
                                             SpreadsheetSearchableObjects = SpreadsheetSearchableObjects.HeadersFooters,
                                             PresentationSearchableObjects = PresentationSearchableObjects.SlidesBackgrounds | PresentationSearchableObjects.Shapes,
                                             DiagramSearchableObjects = DiagramSearchableObjects.None,
                                             PdfSearchableObjects = PdfSearchableObjects.All
                                         };

            string[] files = { Constants.InDocumentDocx, Constants.InSpreadsheetXlsx, Constants.InPresentationPptx,
                               Constants.InDiagramVsdx, Constants.InDocumentPdf };

            foreach (string file in files)
            {
                using (Watermarker watermarker = new Watermarker(file, settings))
                {
                    PossibleWatermarkCollection watermarks = watermarker.Search();

                    // The code for working with found watermarks goes here.

                    Console.WriteLine("In {0} found {1} possible watermark(s).", Path.GetFileName(file), watermarks.Count);
                }
            }
        }
    }
}