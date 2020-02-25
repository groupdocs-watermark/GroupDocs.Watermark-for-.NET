// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    using System;
    using Contents.Email;
    using Options.Email;

    /// <summary>
    /// This example shows how to list all the message recipients.
    /// </summary>
    public static class EmailListRecipients
    {
        public static void Run()
        {
            EmailLoadOptions loadOptions = new EmailLoadOptions();
            // Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
            using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
            {
                EmailContent content = watermarker.GetContent<EmailContent>();

                // List all direct recipients
                foreach (EmailAddress address in content.To)
                {
                    Console.WriteLine(address.Address);
                }

                // List all CC recipients
                foreach (EmailAddress address in content.Cc)
                {
                    Console.WriteLine(address.Address);
                }

                // List all BCC recipients
                foreach (EmailAddress address in content.Bcc)
                {
                    Console.WriteLine(address.Address);
                }
            }
        }
    }
}