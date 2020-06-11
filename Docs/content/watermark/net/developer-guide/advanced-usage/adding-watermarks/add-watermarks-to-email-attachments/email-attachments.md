---
id: email-attachments
url: watermark/net/email-attachments
title: Email attachments
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Extracting all attachments from email message

GroupDocs.Watermark allows you to get the information about the [attachments](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.email/emailcontent/properties/attachments) in an email message. Below is the code snippet for extracting attachments from Email.

**AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments.EmailExtractAllAttachments**

```csharp
EmailLoadOptions loadOptions = new EmailLoadOptions();
// Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
{
    EmailContent content = watermarker.GetContent<EmailContent>();
    foreach (EmailAttachment attachment in content.Attachments)
    {
        Console.WriteLine("Name: {0}", attachment.Name);
        Console.WriteLine("File format: {0}", attachment.GetDocumentInfo().FileType);
        File.WriteAllBytes(Path.Combine(Constants.OutputPath, attachment.Name), attachment.Content);
    }
}
```

## Removing particular attachment from email message

Using GroupDocs.Watermark, you can [remove](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.common.removeonlylistbase/1/methods/removeat) any particular attachment from an email message. Below is the code for removing specific attachment:

**AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments.EmailRemoveAttachment**

```csharp
EmailLoadOptions loadOptions = new EmailLoadOptions();
// Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
{
    EmailContent content = watermarker.GetContent<EmailContent>();
    for (int i = content.Attachments.Count - 1; i >= 0; i--)
    {
        EmailAttachment attachment = content.Attachments[i];

        // Remove all attached files with a particular name and format
        if (attachment.Name.Contains("sample") && attachment.GetDocumentInfo().FileType == FileType.DOCX)
        {
            content.Attachments.RemoveAt(i);
        }
    }

    // Save changes
    watermarker.Save(Constants.OutMessageMsg);
}
```

## Adding attachment to email message

You can also [add](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.email/emailattachmentcollection/methods/add) attachments to the email messages using GroupDocs.Watermark. Following is the code sample for adding an attachment:

**AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments.EmailAddAttachment**

```csharp
EmailLoadOptions loadOptions = new EmailLoadOptions();
// Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
{
    EmailContent content = watermarker.GetContent<EmailContent>();
    content.Attachments.Add(File.ReadAllBytes(Constants.InSampleMsg), "sample.msg");

    // Save changes
    watermarker.Save(Constants.OutMessageMsg);
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
