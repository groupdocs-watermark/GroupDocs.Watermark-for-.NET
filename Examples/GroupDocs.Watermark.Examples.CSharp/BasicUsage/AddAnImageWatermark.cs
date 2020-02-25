// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    using System.IO;
    using Common;
    using Options.Spreadsheet;
    using Watermarks;

    /// <summary>
    /// This example demonstrates how to add an image watermark to a document from a stream.
    /// </summary>
    public static class AddAnImageWatermark
    {
        public static void Run()
        {
            // Constants.InDocumentXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\document.xlsx"
            using (FileStream stream = File.Open(Constants.InDocumentXlsx, FileMode.Open, FileAccess.ReadWrite))
            {
                using (Watermarker watermarker = new Watermarker(stream, new SpreadsheetLoadOptions()))
                {
                    using (ImageWatermark watermark = new ImageWatermark(Constants.LogoPng))
                    {
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermarker.Add(watermark);
                    }

                    watermarker.Save(Constants.OutDocumentXlsx);
                }
            }
        }
    }
}