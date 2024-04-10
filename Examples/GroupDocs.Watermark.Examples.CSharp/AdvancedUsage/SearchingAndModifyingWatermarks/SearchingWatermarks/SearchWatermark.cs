using GroupDocs.Watermark.Search;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    /// <summary>
    /// This example shows how to find and get all possible watermarks in a document.
    /// </summary>
    public static class SearchWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SearchWatermark).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                PossibleWatermarkCollection possibleWatermarks = watermarker.Search();
                foreach (PossibleWatermark possibleWatermark in possibleWatermarks)
                {
                    if (possibleWatermark.ImageData != null)
                    {
                        Console.WriteLine(possibleWatermark.ImageData.Length);
                    }

                    Console.WriteLine(possibleWatermark.Text);
                    Console.WriteLine(possibleWatermark.X);
                    Console.WriteLine(possibleWatermark.Y);
                    Console.WriteLine(possibleWatermark.RotateAngle);
                    Console.WriteLine(possibleWatermark.Width);
                    Console.WriteLine(possibleWatermark.Height);
                }
            }
        }
    }
}
