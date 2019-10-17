// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    using System;
    using System.Text.RegularExpressions;
    using Search;
    using Search.SearchCriteria;

    /// <summary>
    /// This example shows how to use a regular expression to search for watermarks.
    /// </summary>
    public static class SearchWatermarkWithRegularExpression
    {
        public static void Run()
        {
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                Regex regex = new Regex(@"^Â© \d{4}$");

                // Search by regular expression
                TextSearchCriteria textSearchCriteria = new TextSearchCriteria(regex);

                // Find possible watermarks using regular expression
                PossibleWatermarkCollection possibleWatermarks = watermarker.Search(textSearchCriteria);

                Console.WriteLine("Found {0} possible watermark(s).", possibleWatermarks.Count);
            }
        }
    }
}