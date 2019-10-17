// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    using Common;
    using Contents.Email;
    using Options.Email;
    using Watermarks;

    /// <summary>
    /// This example shows how to add watermark to all the attachments of supported types in an email message.
    /// </summary>
    public static class EmailAddWatermarkToAllAttachments
    {
        public static void Run()
        {
            TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));
            EmailLoadOptions loadOptions = new EmailLoadOptions();
            // Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
            using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
            {
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
                watermarker.Save(Constants.OutMessageMsg);
            }
        }
    }
}