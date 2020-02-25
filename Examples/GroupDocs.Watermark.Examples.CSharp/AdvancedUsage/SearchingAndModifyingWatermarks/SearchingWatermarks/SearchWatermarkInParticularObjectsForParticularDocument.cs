// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    using System;
    using Search;
    using Search.Objects;

    /// <summary>
    /// This example shows how to set searchable objects for a particular Watermarker instance.
    /// </summary>
    public static class SearchWatermarkInParticularObjectsForParticularDocument
    {
        public static void Run()
        {
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                // Search for hyperlinks only.
                watermarker.SearchableObjects.PdfSearchableObjects = PdfSearchableObjects.Hyperlinks;
                PossibleWatermarkCollection watermarks = watermarker.Search();

                // The code for working with found watermarks goes here.

                Console.WriteLine("Found {0} hyperlink watermark(s).", watermarks.Count);
            }
        }
    }
}