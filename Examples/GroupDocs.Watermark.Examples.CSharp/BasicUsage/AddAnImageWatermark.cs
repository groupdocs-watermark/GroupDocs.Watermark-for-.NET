using System.IO;
using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to add an image watermark to a document from a stream.
    /// </summary>
    public static class AddAnImageWatermark
    {
        public static void Run()
        {
            // Constants.InDocumentXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\document.xlsx"
            using (FileStream stream = File.Open(Constants.InDocumentPdf, FileMode.Open, FileAccess.ReadWrite))
            {
                using (Watermarker watermarker = new Watermarker(stream))
                {
                    using (ImageWatermark watermark = new ImageWatermark(Constants.LogoPng))
                    {
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermarker.Add(watermark);
                    }

                    watermarker.Save(Constants.OutDocumentPdf);
                }
            }
        }
    }
}
