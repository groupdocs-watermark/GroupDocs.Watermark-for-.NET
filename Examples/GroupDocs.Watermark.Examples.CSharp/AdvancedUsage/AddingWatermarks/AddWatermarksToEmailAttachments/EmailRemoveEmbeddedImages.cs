// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    using System.Text.RegularExpressions;
    using Common;
    using Contents.Email;
    using Options.Email;

    /// <summary>
    /// This example shows how to remove the embedded images from the body of the email message.
    /// </summary>
    public static class EmailRemoveEmbeddedImages
    {
        public static void Run()
        {
            EmailLoadOptions loadOptions = new EmailLoadOptions();
            // Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
            using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
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

                watermarker.Save(Constants.OutMessageMsg);
            }
        }
    }
}