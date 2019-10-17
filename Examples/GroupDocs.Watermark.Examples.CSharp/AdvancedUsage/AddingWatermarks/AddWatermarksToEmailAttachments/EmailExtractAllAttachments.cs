// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    using System;
    using System.IO;
    using Contents.Email;
    using Options.Email;

    /// <summary>
    /// This example shows how to get the information about the attachments in an email message.
    /// </summary>
    public static class EmailExtractAllAttachments
    {
        public static void Run()
        {
            EmailLoadOptions loadOptions = new EmailLoadOptions();
            // Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
            using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
            {
                EmailContent content = watermarker.GetContent<EmailContent>();
                foreach (EmailAttachment attachment in content.Attachments)
                {
                    Console.WriteLine("Name: {0}", attachment.Name);
                    Console.WriteLine("File format: {0}", attachment.GetDocumentInfo().FileType);
                    File.WriteAllBytes(Path.Combine(Constants.OutputPath, attachment.Name), attachment.Content);
                }
            }
        }
    }
}