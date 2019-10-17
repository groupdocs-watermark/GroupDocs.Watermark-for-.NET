// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using System.IO;
    using Watermarks;

    /// <summary>
    /// This example shows how to save the document to the underlying source.
    /// </summary>
    public static class SaveDocumentToTheSameFileOrStream
    {
        public static void Run()
        {
            // Constants.InTestDoc is an absolute or relative path to your document. Ex: @"C:\Docs\test.doc"
            File.Copy(Constants.InTestDoc, Constants.OutTestDoc);
            using (Watermarker watermarker = new Watermarker(Constants.OutTestDoc))
            {
                // watermarking goes here
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));
                watermarker.Add(watermark);

                // Saves the document to the underlying source (stream or file)
                watermarker.Save();
            }
        }
    }
}