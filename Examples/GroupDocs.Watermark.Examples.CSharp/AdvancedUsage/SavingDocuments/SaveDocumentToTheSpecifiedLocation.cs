// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using Watermarks;

    /// <summary>
    /// This example shows how to save the document to the specified location.
    /// </summary>
    public static class SaveDocumentToTheSpecifiedLocation
    {
        public static void Run()
        {
            // Constants.InTestDoc is an absolute or relative path to your document. Ex: @"C:\Docs\test.doc"
            using (Watermarker watermarker = new Watermarker(Constants.InTestDoc))
            {
                // watermarking goes here
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));
                watermarker.Add(watermark);

                // Saves the document to the specified location
                watermarker.Save(Constants.OutTestDoc);
            }
        }
    }
}