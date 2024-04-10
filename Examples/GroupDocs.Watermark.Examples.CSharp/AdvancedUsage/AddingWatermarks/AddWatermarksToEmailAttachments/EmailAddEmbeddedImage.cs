using GroupDocs.Watermark.Contents.Email;
using GroupDocs.Watermark.Options.Email;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    /// <summary>
    /// This example shows how to embed images in the body of the email message.
    /// </summary>
    public static class EmailAddEmbeddedImage
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(EmailAddEmbeddedImage).Name}\n");

            string documentPath = Constants.InMessageMsg;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new EmailLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                EmailContent content = watermarker.GetContent<EmailContent>();
                content.EmbeddedObjects.Add(File.ReadAllBytes(Constants.SampleJpg), "sample.jpg");
                EmailEmbeddedObject embeddedObject = content.EmbeddedObjects[content.EmbeddedObjects.Count - 1];
                content.HtmlBody = string.Format("<html><body>This is an embedded image: <img src=\"cid:{0}\"></body></html>", embeddedObject.ContentId);
                watermarker.Save(outputFileName);
            }
        }
    }
}
