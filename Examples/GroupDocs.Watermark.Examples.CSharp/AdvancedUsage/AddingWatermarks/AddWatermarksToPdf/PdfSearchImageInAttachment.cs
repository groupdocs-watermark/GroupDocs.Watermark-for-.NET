// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    using System;
    using Contents.Image;
    using Options.Pdf;
    using Search.Objects;

    /// <summary>
    /// This example shows how to search for all the images attachments in a PDF document.
    /// </summary>
    public static class PdfSearchImageInAttachment
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                // Consider only the attached images
                watermarker.SearchableObjects.PdfSearchableObjects = PdfSearchableObjects.AttachedImages;

                // Search for similar images
                WatermarkableImageCollection possibleWatermarks = watermarker.GetImages();

                Console.WriteLine("Found {0} image(s).", possibleWatermarks.Count);
            }
        }
    }
}