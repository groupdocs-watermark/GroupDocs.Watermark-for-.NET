// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to extract attachments in Excel document.
    /// </summary>
    public static class SpreadsheetExtractAllAttachments
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                foreach (SpreadsheetWorksheet worksheet in content.Worksheets)
                {
                    foreach (SpreadsheetAttachment attachment in worksheet.Attachments)
                    {
                        Console.WriteLine("Alternative text: {0}", attachment.AlternativeText);
                        Console.WriteLine("Attachment frame x-coordinate: {0}", attachment.X);
                        Console.WriteLine("Attachment frame y-coordinate: {0}", attachment.Y);
                        Console.WriteLine("Attachment frame width: {0}", attachment.Width);
                        Console.WriteLine("Attachment frame height: {0}", attachment.Height);
                        Console.WriteLine("Preview image size: {0}", attachment.PreviewImageContent != null ? attachment.PreviewImageContent.Length : 0);

                        if (attachment.IsLink)
                        {
                            // The document contains only a link to the attached file
                            Console.WriteLine("Full path to the attached file: {0}", attachment.SourceFullName);
                        }
                        else
                        {
                            // The attached file is stored in the document
                            Console.WriteLine("File type: {0}", attachment.GetDocumentInfo().FileType);
                            Console.WriteLine("Name of the source file: {0}", attachment.SourceFullName);
                            Console.WriteLine("File size: {0}", attachment.Content.Length);
                        }
                    }
                }
            }
        }
    }
}
