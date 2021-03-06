// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    using System.IO;
    using Contents.Email;
    using Options.Email;

    /// <summary>
    /// This example shows how to add attachments to the email messages.
    /// </summary>
    public static class EmailAddAttachment
    {
        public static void Run()
        {
            EmailLoadOptions loadOptions = new EmailLoadOptions();
            // Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
            using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
            {
                EmailContent content = watermarker.GetContent<EmailContent>();
                content.Attachments.Add(File.ReadAllBytes(Constants.InSampleMsg), "sample.msg");

                // Save changes
                watermarker.Save(Constants.OutMessageMsg);
            }
        }
    }
}