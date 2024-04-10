using System.IO;
using System;
using System.Text.RegularExpressions;
using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Email;
using GroupDocs.Watermark.Options.Email;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    /// <summary>
    /// This example shows how to remove the embedded images from the body of the email message.
    /// </summary>
    public static class EmailRemoveEmbeddedImages
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(EmailRemoveEmbeddedImages).Name}\n");

            string documentPath = Constants.InMessageMsg;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new EmailLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                EmailContent content = watermarker.GetContent<EmailContent>();
                for (int i = content.EmbeddedObjects.Count - 1; i >= 0; i--)
                {
                    if (content.EmbeddedObjects[i].GetDocumentInfo().FileType == FileType.JPEG)
                    {
                        // Remove reference to the image from html body
                        string pattern = string.Format("<img[^>]*src=\"cid:{0}\"[^>]*>", content.EmbeddedObjects[i].ContentId);
                        content.HtmlBody = Regex.Replace(content.HtmlBody, pattern, string.Empty);

                        // Remove the image
                        content.EmbeddedObjects.RemoveAt(i);
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
