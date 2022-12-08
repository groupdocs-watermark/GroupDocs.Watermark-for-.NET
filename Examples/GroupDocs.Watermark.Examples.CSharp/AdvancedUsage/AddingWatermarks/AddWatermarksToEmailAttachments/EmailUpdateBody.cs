// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.Email;
using GroupDocs.Watermark.Options.Email;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    /// <summary>
    /// This example shows how to modify the body and subject of an email message.
    /// </summary>
    public static class EmailUpdateBody
    {
        public static void Run()
        {
            EmailLoadOptions loadOptions = new EmailLoadOptions();
            // Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
            using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
            {
                EmailContent content = watermarker.GetContent<EmailContent>();

                // Set the plain text body
                content.Body = "Test plain text body";

                // Set the html body
                content.HtmlBody = "<html><body>Test html body</body></html>";

                // Set the email subject
                content.Subject = "Test subject";

                // Save changes
                watermarker.Save(Constants.OutMessageMsg);
            }
        }
    }
}
