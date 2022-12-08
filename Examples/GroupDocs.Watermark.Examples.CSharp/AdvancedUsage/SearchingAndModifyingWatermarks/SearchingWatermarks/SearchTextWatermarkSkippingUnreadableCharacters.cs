// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    /// <summary>
    /// This example shows how to skip unreadable characters when searching for the watermark.
    /// </summary>
    public static class SearchTextWatermarkSkippingUnreadableCharacters
    {
        public static void Run()
        {
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                string watermarkText = "Company name";
                TextSearchCriteria criterion = new TextSearchCriteria(watermarkText);

                // Enable skipping of unreadable characters
                criterion.SkipUnreadableCharacters = true;

                PossibleWatermarkCollection result = watermarker.Search(criterion);

                // ...

                Console.WriteLine("Found {0} possible watermark(s).", result.Count);
            }
        }
    }
}
