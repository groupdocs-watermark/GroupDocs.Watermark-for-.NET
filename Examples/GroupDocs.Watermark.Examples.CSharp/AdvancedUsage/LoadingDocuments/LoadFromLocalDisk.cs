// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    public static class LoadFromLocalDisk
    {
        /// <summary>
        /// This example demontrates how to create a watermarker for a local filesystem document.
        /// </summary>
        public static void Run()
        {
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            string filePath = Constants.InDocumentDocx;
            using (Watermarker watermarker = new Watermarker(filePath))
            {
                // use watermarker methods to manage watermarks
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));

                watermarker.Add(watermark);
                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}
