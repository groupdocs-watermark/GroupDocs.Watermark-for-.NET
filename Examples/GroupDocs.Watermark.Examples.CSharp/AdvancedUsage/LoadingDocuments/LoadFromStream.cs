// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using System.IO;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    /// <summary>
    /// This example democtrates how to create a watermarker for a document stream:
    /// </summary>
    public static class LoadFromStream
    {
        public static void Run()
        {
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Stream document = File.OpenRead(Constants.InDocumentDocx))
            using (Watermarker watermarker = new Watermarker(document))
            {
                // use watermarker methods to manage watermarks
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));

                watermarker.Add(watermark);

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}
