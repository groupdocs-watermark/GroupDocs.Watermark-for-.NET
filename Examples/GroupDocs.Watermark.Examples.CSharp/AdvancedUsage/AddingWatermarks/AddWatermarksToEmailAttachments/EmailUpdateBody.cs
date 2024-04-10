using GroupDocs.Watermark.Contents.Email;
using GroupDocs.Watermark.Options.Email;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    /// <summary>
    /// This example shows how to modify the body and subject of an email message.
    /// </summary>
    public static class EmailUpdateBody
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(EmailUpdateBody).Name}\n");

            string documentPath = Constants.InMessageMsg;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new EmailLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                EmailContent content = watermarker.GetContent<EmailContent>();

                // Set the plain text body
                content.Body = "Test plain text body";

                // Set the html body
                content.HtmlBody = "<html><body>Test html body</body></html>";

                // Set the email subject
                content.Subject = "Test subject";

                // Save changes
                watermarker.Save(outputFileName);
            }
        }
    }
}
