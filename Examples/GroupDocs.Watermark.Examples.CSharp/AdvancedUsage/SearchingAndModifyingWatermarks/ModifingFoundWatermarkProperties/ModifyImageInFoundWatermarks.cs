// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.IO;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.ModifingFoundWatermarkProperties
{
    /// <summary>
    /// This example shows how to replace the image of the found watermarks.
    /// </summary>
    public static class ModifyImageInFoundWatermarks
    {
        public static void Run()
        {
            byte[] imageData = File.ReadAllBytes(Constants.ImagePng);

            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                // Search watermark matching a particular image
                SearchCriteria searchCriteria = new ImageDctHashSearchCriteria(Constants.LogoBmp);
                PossibleWatermarkCollection watermarks = watermarker.Search(searchCriteria);
                foreach (PossibleWatermark watermark in watermarks)
                {
                    try
                    {
                        // Replace image
                        watermark.ImageData = imageData;
                    }
                    catch (Exception e)
                    {
                        // Found entity may not support image replacment
                        // Passed image can have inappropriate format
                        // Process such cases here
                    }
                }

                // Save document
                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
