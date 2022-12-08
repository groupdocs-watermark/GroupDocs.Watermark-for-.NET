// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    /// <summary>
    /// This example shows how to searche for image watermarks that resemble with a particular image.
    /// </summary>
    public static class SearchImageWatermark
    {
        public static void Run()
        {
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                // Initialize criteria with the image
                ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.WatermarkJpg);

                //Set maximum allowed difference between images
                imageSearchCriteria.MaxDifference = 0.9;

                PossibleWatermarkCollection possibleWatermarks = watermarker.Search(imageSearchCriteria);

                Console.WriteLine("Found {0} possible watermark(s).", possibleWatermarks.Count);
            }
        }
    }
}
