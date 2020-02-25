// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.ModifingFoundWatermarkProperties
{
    using System;
    using Search;
    using Search.SearchCriteria;
    using Watermarks;

    /// <summary>
    /// This example shows how to replace the watermark's text with formatting.
    /// </summary>
    public static class ModifyTextWithFormattingInFoundWatermarks
    {
        public static void Run()
        {
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                TextSearchCriteria searchCriteria = new TextSearchCriteria("test", false);
                PossibleWatermarkCollection watermarks = watermarker.Search(searchCriteria);
                foreach (PossibleWatermark watermark in watermarks)
                {
                    try
                    {
                        // Edit text 
                        watermark.FormattedTextFragments.Clear();
                        watermark.FormattedTextFragments.Add("passed", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
                    }
                    catch (Exception e)
                    {
                        // Found entity may not support text editing
                        // Passed arguments can have inappropriate value
                        // Process such cases here
                    }
                }

                // Save document
                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}