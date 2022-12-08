using System;
using System.Text.RegularExpressions;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.RemovingFoundWatermarks
{
    /// <summary>
    /// This example shows how to search and remove hyperlinks in a document of any supported format.
    /// </summary>
    public static class RemoveHyperlinksWithParticularUrl
    {
        public static void Run()
        {
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                PossibleWatermarkCollection watermarks = watermarker.Search(new TextSearchCriteria(new Regex(@"someurl\.com")));
                for (int i = watermarks.Count - 1; i >= 0; i--)
                {
                    // Ensure that only hyperlinks will be removed.
                    if (watermarks[i] is HyperlinkPossibleWatermark)
                    {
                        // Output the full url of the hyperlink
                        Console.WriteLine(watermarks[i].Text);

                        // Remove hyperlink from the document
                        watermarks.RemoveAt(i);
                    }
                }

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
