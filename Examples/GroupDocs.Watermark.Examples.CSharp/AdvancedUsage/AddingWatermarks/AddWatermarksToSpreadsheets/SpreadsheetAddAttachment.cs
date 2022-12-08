using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example show how to add attachments in Excel document.
    /// </summary>
    public static class SpreadsheetAddAttachment
    {
        public static void Run()
        {
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                SpreadsheetWorksheet worksheet = content.Worksheets[0];

                // Add the attachment
                worksheet.Attachments.AddAttachment(
                    File.ReadAllBytes(Constants.InDocumentDocx), // File content
                    "sample document.docx", // Source file full name (the extension is used
                                            // to determine appropriate application to open
                                            // the file) 
                    File.ReadAllBytes(Constants.DocumentPreviewPng), // Preview image content
                    50, // X-coordinate of the attachment frame
                    100, // Y-coordinate of the attachment frame
                    200, // Attachment frame width
                    400); // Attachment frame height

                // Save changes
                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}
