using System;
using System.IO;
using GroupDocs.Watermark.Contents.Email;
using GroupDocs.Watermark.Options.Email;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    /// <summary>
    /// This example shows how to get the information about the attachments in an email message.
    /// </summary>
    public static class EmailExtractAllAttachments
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(EmailExtractAllAttachments).Name}");

            string documentPath = Constants.InMessageMsg;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            var loadOptions = new EmailLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                EmailContent content = watermarker.GetContent<EmailContent>();
                foreach (EmailAttachment attachment in content.Attachments)
                {
                    Console.WriteLine("Name: {0}", attachment.Name);
                    Console.WriteLine("File format: {0}", attachment.GetDocumentInfo().FileType);
                    File.WriteAllBytes(Path.Combine(outputDirectory, attachment.Name), attachment.Content);
                }
            }

            Console.WriteLine($"Attachments extracted successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
