// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using System.IO;
    using Watermarks;

    /// <summary>
    /// This example shows how to save the document to the specified stream.
    /// </summary>
    public static class SaveDocumentToTheSpecifiedStream
    {
        public static void Run()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Constants.InTestDoc is an absolute or relative path to your document. Ex: @"C:\Docs\test.doc"
                using (Watermarker watermarker = new Watermarker(Constants.InTestDoc))
                {
                    // watermarking goes here
                    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));
                    watermarker.Add(watermark);

                    // Saves the document to the specified stream
                    watermarker.Save(stream);
                }
            }
        }
    }
}