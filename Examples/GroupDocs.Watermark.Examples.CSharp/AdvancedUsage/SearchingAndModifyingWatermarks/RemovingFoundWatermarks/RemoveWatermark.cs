using GroupDocs.Watermark.Search;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.RemovingFoundWatermarks
{
    /// <summary>
    /// This example shows how to find and remove a particular watermark from a document.
    /// </summary>
    public static class RemoveWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(RemoveWatermark).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                PossibleWatermarkCollection possibleWatermarks = watermarker.Search();

                // Remove possible watermark at the specified index from the document.
                possibleWatermarks.RemoveAt(0);

                // Remove specified possible watermark from the document.
                possibleWatermarks.Remove(possibleWatermarks[0]);

                watermarker.Save(outputFileName);
            }
        }
    }
}
