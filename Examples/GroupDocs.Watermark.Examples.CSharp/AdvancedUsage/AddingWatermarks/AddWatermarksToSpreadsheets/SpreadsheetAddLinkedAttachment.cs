using System;
using System.IO;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to to add linked attachments in Excel document.
    /// </summary>
    public static class SpreadsheetAddLinkedAttachment
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddLinkedAttachment).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                SpreadsheetWorksheet worksheet = content.Worksheets[0];

                // Add the attachment
                worksheet.Attachments.AddLink(
                    Constants.InDocumentDocx, // Source file path
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
