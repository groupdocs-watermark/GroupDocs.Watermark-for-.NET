using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine($"[Example Advanced Usage] # {typeof(ModifyTextInFoundWatermarks).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                TextSearchCriteria searchCriteria = new TextSearchCriteria("test", false)
                {
                    Pages = new List<int> { 1, 3 }
                };
              
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
                watermarker.Save(outputFileName);
            }
        }
    }
}
