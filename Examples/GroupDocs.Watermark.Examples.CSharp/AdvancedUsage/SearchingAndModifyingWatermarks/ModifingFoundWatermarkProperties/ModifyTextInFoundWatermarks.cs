using System;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.ModifingFoundWatermarkProperties
{
    /// <summary>
    /// This example shows how to replace text of the found watermarks.
    /// </summary>
    public static class ModifyTextInFoundWatermarks
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
                        watermark.Text = "passed";
                    }
                    catch (Exception e)
                    {
                        // Found entity may not support text editing
                        // Passed argument can have inappropriate value
                        // Process such cases here
                    }
                }

                // Save document
                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
