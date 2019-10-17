// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    using System;
    using Search;
    using Search.SearchCriteria;

    /// <summary>
    /// This example shows how to search watermark with the combination of different search criteria.
    /// </summary>
    public static class SearchWatermarkWithCombinedSearch
    {
        public static void Run()
        {
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.LogoPng);
                imageSearchCriteria.MaxDifference = 0.9;

                TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                RotateAngleSearchCriteria rotateAngleSearchCriteria = new RotateAngleSearchCriteria(30, 60);

                SearchCriteria combinedSearchCriteria = imageSearchCriteria.Or(textSearchCriteria).And(rotateAngleSearchCriteria);
                PossibleWatermarkCollection possibleWatermarks = watermarker.Search(combinedSearchCriteria);

                Console.WriteLine("Found {0} possible watermark(s).", possibleWatermarks.Count);
            }
        }
    }
}