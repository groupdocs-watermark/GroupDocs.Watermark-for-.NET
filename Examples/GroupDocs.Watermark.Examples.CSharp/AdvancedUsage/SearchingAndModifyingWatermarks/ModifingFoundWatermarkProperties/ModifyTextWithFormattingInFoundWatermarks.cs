using System;
using System.IO;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.ModifingFoundWatermarkProperties
{
    /// <summary>
    /// This example shows how to replace the watermark's text with formatting.
    /// </summary>
    public static class ModifyTextWithFormattingInFoundWatermarks
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(ModifyTextWithFormattingInFoundWatermarks).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
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
                    catch (Exception)
                    {
                        // Found entity may not support text editing
                        // Passed arguments can have inappropriate value
                        // Process such cases here
                    }
                }

                // Save document
                watermarker.Save(outputFileName);
            }
        }
    }
}
