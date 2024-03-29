﻿using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    /// <summary>
    /// This example demontrates how to load an encrypted WordProcessing document using the password.
    /// </summary>
    public static class LoadPasswordProtectedWordProcessingDocument
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            loadOptions.Password = "P@$$w0rd";
            // Constants.InProtectedDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\protected-document.docx"
            string filePath = Constants.InProtectedDocumentDocx;
            using (Watermarker watermarker = new Watermarker(filePath, loadOptions))
            {
                // use watermarker methods to manage watermarks in the WordProcessing document
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));

                watermarker.Add(watermark);

                watermarker.Save(Constants.OutProtectedDocumentDocx);
            }
        }
    }
}
