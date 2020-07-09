---
id: email-messages
url: watermark/net/email-messages
title: Email messages
weight: 2
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Modifying body and subject of email message

GroupDocs.Watermark also allows you to modify the body and subject of an email message. Below is the code sample to modify [body](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.email/emailcontent/properties/body) and [subject](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.email/emailcontent/properties/subject) of an email Message:

**AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments.EmailUpdateEmailBody**

```csharp
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
```

## Embedding image to email message body

GroupDocs.Watermark also provides the feature of embedding images in the body of the email message. Following is the code sample for embedding an image in an email:

**AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments.EmailAddEmbeddedImage**

```csharp
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
```

## Removing all embedded images from email message body

You can also remove the embedded images from the body of the email message. Below is the code for removing embedded images:

**AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments.EmailRemoveEmbeddedImages**

```csharp
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
```

## Searching text in email message body or subject

Using GroupDocs.Watermark, you can also search for a text in the subject as well as in the body of the email message. Following is the code sample for searching text in the email message:

**AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments.EmailSearchTextInBody**

```csharp
EmailLoadOptions loadOptions = new EmailLoadOptions();
// Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
{
    SearchCriteria criteria = new TextSearchCriteria("test", false);

    // Specify search locations
    watermarker.SearchableObjects.EmailSearchableObjects = EmailSearchableObjects.Subject | EmailSearchableObjects.HtmlBody | EmailSearchableObjects.PlainTextBody;

    // Note, search is performed only if you pass TextSearchCriteria instance to FindWatermarks method
    PossibleWatermarkCollection watermarks = watermarker.Search(criteria);

    // Remove found text fragments
    watermarks.Clear();

    // Save changes
    watermarker.Save(Constants.OutMessageMsg);
}
```

## Listing all message recipients

GroupDocs.Watermark also allows listing all the message recipients using properties [To](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.email/emailcontent/properties/to), [Cc](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.email/emailcontent/properties/cc) and [Bcc](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.email/emailcontent/properties/bcc) as shown in the following code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments.EmailListRecipients**

```csharp
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
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
