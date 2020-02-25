// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    using Common;
    using Watermarks;

    /// <summary>
    /// This example demostrates how to add a text watermark to a local document.
    /// </summary>
    public static class AddATextWatermark
    {
        public static void Run()
        {
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                TextWatermark watermark = new TextWatermark("top secret", new Font("Arial", 36));
                watermark.ForegroundColor = Color.Red;
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermarker.Add(watermark);
                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}