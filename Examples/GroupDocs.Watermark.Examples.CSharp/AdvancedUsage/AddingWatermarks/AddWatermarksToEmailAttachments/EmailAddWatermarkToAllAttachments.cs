using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Email;
using GroupDocs.Watermark.Options.Email;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    /// <summary>
    /// This example shows how to add watermark to all the attachments of supported types in an email message.
    /// </summary>
    public static class EmailAddWatermarkToAllAttachments
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(EmailAddWatermarkToAllAttachments).Name}\n");

            string documentPath = Constants.InMessageMsg;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new EmailLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));
                EmailContent content = watermarker.GetContent<EmailContent>();
                foreach (EmailAttachment attachment in content.Attachments)
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

                // Save changes
                watermarker.Save(outputFileName);
            }
        }
    }
}
