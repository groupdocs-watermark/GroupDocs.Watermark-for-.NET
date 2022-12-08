// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Email;
using GroupDocs.Watermark.Options.Email;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    /// <summary>
    /// This example shows how to remove any particular attachment from an email message.
    /// </summary>
    public static class EmailRemoveAttachment
    {
        public static void Run()
        {
            EmailLoadOptions loadOptions = new EmailLoadOptions();
            // Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
            using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
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
                watermarker.Save(Constants.OutMessageMsg);
            }
        }
    }
}
