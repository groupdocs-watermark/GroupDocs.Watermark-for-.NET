// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to add watermark to all attachments in Excel document.
    /// </summary>
    public static class SpreadsheetAddWatermarkToAttachment
    {
        public static void Run()
        {
            TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                foreach (SpreadsheetWorksheet worksheet in content.Worksheets)
                {
                    foreach (SpreadsheetAttachment attachment in worksheet.Attachments)
                    {
                        // Check if the attached file is supported by GroupDocs.Watermark
                        IDocumentInfo info = attachment.GetDocumentInfo();
                        if (info.FileType != FileType.Unknown && !info.IsEncrypted)
                        {
                            // Load the attached document
                            using (Watermarker attachedWatermarker = attachment.CreateWatermarker())
                            {
                                // Add wateramrk
                                attachedWatermarker.Add(watermark);

                                // Save changes in the attached file
                                attachedWatermarker.Save();
                            }
                        }
                    }
                }

                // Save changes
                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}
