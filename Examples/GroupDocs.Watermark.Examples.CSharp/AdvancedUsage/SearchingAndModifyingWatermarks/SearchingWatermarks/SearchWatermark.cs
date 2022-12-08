using GroupDocs.Watermark.Search;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    /// <summary>
    /// This example shows how to find and get all possible watermarks in a document.
    /// </summary>
    public static class SearchWatermark
    {
        public static void Run()
        {
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
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
