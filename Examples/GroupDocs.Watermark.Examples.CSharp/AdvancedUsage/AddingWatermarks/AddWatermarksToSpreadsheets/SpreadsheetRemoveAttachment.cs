// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using System.IO;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to remove attachments in Excel document.
    /// </summary>
    public static class SpreadsheetRemoveAttachment
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
                    for (int i = worksheet.Attachments.Count - 1; i >= 0; i--)
                    {
                        SpreadsheetAttachment attachment = worksheet.Attachments[i];
                        if (attachment.IsLink &&
                            !File.Exists(attachment.SourceFullName) || // Linked file that is not available at this moment
                            attachment.GetDocumentInfo().IsEncrypted) // Attached file protected with a password
                        {
                            // Remove the file if it meets at least one of the conditions above
                            worksheet.Attachments.RemoveAt(i);
                        }
                    }
                }

                // Save changes
                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}
