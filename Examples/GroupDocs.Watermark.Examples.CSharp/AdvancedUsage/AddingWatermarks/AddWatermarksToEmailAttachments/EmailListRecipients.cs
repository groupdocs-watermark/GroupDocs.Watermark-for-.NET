using System;
using GroupDocs.Watermark.Contents.Email;
using GroupDocs.Watermark.Options.Email;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    /// <summary>
    /// This example shows how to list all the message recipients.
    /// </summary>
    public static class EmailListRecipients
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(EmailListRecipients).Name}\n");

            string documentPath = Constants.InMessageMsg;

            var loadOptions = new EmailLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
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
