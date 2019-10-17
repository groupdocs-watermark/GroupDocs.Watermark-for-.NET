// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    using System;
    using Common;

    /// <summary>
    /// This example demostrates how to get document information from the local file.
    /// </summary>
    public static class GetDocumentInfoForTheFileFromLocalDisk
    {
        public static void Run()
        {
            // Constants.InSourceDocx is an absolute or relative path to your document. Ex: @"C:\Docs\source.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InSourceDocx))
            {
                IDocumentInfo info = watermarker.GetDocumentInfo();
                Console.WriteLine("File type: {0}", info.FileType);
                Console.WriteLine("Number of pages: {0}", info.PageCount);
                Console.WriteLine("Document size: {0} bytes", info.Size);
            }
        }
    }
}