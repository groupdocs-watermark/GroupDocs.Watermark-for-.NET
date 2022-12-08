// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.Email;
using GroupDocs.Watermark.Options.Email;
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
            EmailLoadOptions loadOptions = new EmailLoadOptions();
            // Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
            using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
            {
                EmailContent content = watermarker.GetContent<EmailContent>();
                content.EmbeddedObjects.Add(File.ReadAllBytes(Constants.SampleJpg), "sample.jpg");
                EmailEmbeddedObject embeddedObject = content.EmbeddedObjects[content.EmbeddedObjects.Count - 1];
                content.HtmlBody = string.Format("<html><body>This is an embedded image: <img src=\"cid:{0}\"></body></html>", embeddedObject.ContentId);
                watermarker.Save(Constants.OutMessageMsg);
            }
        }
    }
}
