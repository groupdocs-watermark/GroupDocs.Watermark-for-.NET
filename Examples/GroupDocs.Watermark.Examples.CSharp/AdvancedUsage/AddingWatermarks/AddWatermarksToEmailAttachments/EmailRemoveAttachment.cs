using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Email;
using GroupDocs.Watermark.Options.Email;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    /// <summary>
    /// This example shows how to remove any particular attachment from an email message.
    /// </summary>
    public static class EmailRemoveAttachment
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(EmailRemoveAttachment).Name}\n");

            string documentPath = Constants.InMessageMsg;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new EmailLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                EmailContent content = watermarker.GetContent<EmailContent>();
                for (int i = content.Attachments.Count - 1; i >= 0; i--)
                {
                    EmailAttachment attachment = content.Attachments[i];

                    // Remove all attached files with a particular name and format
                    if (attachment.Name.Contains("sample") && attachment.GetDocumentInfo().FileType == FileType.DOCX)
                    {
                        content.Attachments.RemoveAt(i);
                    }
                }

                // Save changes
                watermarker.Save(outputFileName);
            }
        }
    }
}
