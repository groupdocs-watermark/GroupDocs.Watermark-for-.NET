// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.IO;
using GroupDocs.Watermark.Common;

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to get document information from the file stream.
    /// </summary>
    public static class GetDocumentInfoForTheFileFromStream
    {
        public static void Run()
        {
            // Constants.InSourceDocx is an absolute or relative path to your document. Ex: @"C:\Docs\source.docx"
            using (FileStream stream = File.OpenRead(Constants.InSourceDocx))
            {
                using (Watermarker watermarker = new Watermarker(stream))
                {
                    IDocumentInfo info = watermarker.GetDocumentInfo();
                    Console.WriteLine("File type: {0}", info.FileType);
                    Console.WriteLine("Number of pages: {0}", info.PageCount);
                    Console.WriteLine("Document size: {0} bytes", info.Size);
                }
            }
        }
    }
}
