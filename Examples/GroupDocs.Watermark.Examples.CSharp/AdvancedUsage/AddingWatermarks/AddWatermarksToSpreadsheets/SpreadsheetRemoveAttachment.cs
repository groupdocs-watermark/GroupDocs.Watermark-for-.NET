using System;
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
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetRemoveWorksheetBackground).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
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
                watermarker.Save(outputFileName);
            }
        }
    }
}
