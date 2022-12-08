// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    /// <summary>
    /// This example shows how to search for the watermarks that meet a particular text criterion.
    /// </summary>
    public static class SearchWatermarkWithSearchString
    {
        public static void Run()
        {
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                // Search by exact string
                TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Â© 2017");

                // Find all possible watermarks containing some specific text
                PossibleWatermarkCollection possibleWatermarks = watermarker.Search(textSearchCriteria);

                Console.WriteLine("Found {0} possible watermark(s)", possibleWatermarks.Count);
            }
        }
    }
}
