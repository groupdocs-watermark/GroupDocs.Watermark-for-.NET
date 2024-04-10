using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Options.Spreadsheet;
using System;
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
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddAttachment).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
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
                watermarker.Save(outputFileName);
            }
        }
    }
}
