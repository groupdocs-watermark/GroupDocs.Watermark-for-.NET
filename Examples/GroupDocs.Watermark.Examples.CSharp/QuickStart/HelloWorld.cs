// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.QuickStart
{
    using Options.Pdf;
    using Watermarks;

    public static class HelloWorld
    {
        public static void Run()
        {
            string documentPath = Constants.InDocumentPdf; // NOTE: Put here actual path for your document
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 36, FontStyle.Bold | FontStyle.Italic));
                PdfXObjectWatermarkOptions options = new PdfXObjectWatermarkOptions();
                options.PageIndex = 0;

                watermarker.Add(watermark, options);
                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}