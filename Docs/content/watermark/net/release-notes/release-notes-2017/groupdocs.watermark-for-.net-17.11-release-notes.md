---
id: groupdocs-watermark-for-net-17-11-release-notes
url: watermark/net/groupdocs-watermark-for-net-17-11-release-notes
title: GroupDocs.Watermark for .NET 17.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 17.11.{{< /alert >}}

## Major Features

There are following features in this first release:

*   *   Add support for Email Formats
    *   Remove SlidesBaseSlide.BackgroundImage property (obsolete code)

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-513 | Add support for email formats | New Feature |
| WATERMARKNET-541 | Remove SlidesBaseSlide.BackgroundImage property (obsolete code) | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 17.11. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermark which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Add Support for Email Formats

##### Description

This enhancement provides new functionality for a user to work with stored email messages.

##### Public API changes

*GroupDocs.Watermark.Email* namespace has been introduced.  
*EmailDocument* class has been added to *GroupDocs.Watermark.Email* namespace.  
*EmailAttachmentBase* class has been added to *GroupDocs.Watermark.Email* namespace.  
*EmailAttachment* class has been added to *GroupDocs.Watermark.Email* namespace.  
*EmailEmbeddedObject* class has been added to *GroupDocs.Watermark.Email* namespace.  
*EmailAttachmentCollection* class has been added to *GroupDocs.Watermark.Email* namespace.  
*EmailEmbeddedObjectCollection* class has been added to *GroupDocs.Watermark.Email* namespace.  
*EmailAddress* class has been added to *GroupDocs.Watermark.Email* namespace.  
*EmailAddressCollection* class has been added to *GroupDocs.Watermark.Email* namespace.  
*EmailBodyType* enum has been added to *GroupDocs.Watermark.Email* namespace.  
*EmailSearchableObjects* enum has been added to *GroupDocs.Watermark.Search* namespace.  
*EmailSearchableObjects* property has been added to *SearchableObjects* class.

##### Usage

Load an email message.

**C#**

```csharp
using (EmailDocument doc = Document.Load<EmailDocument>(@"D:\test.eml"))
{
	// ...
}
```

{{< alert style="info" >}}EML and MSG email message formats are supported by GroupDocs.Watermark at this moment.{{< /alert >}}

Extract all attachments from an email message

**C#**

```csharp
string targetFolder = @"D:\attachments";
using (EmailDocument doc = Document.Load<EmailDocument>(@"D:\test.msg"))
{
	foreach (EmailAttachment attachment in doc.Attachments)
	{
		Console.WriteLine("Name: {0}", attachment.Name);
		Console.WriteLine("File format: {0}", attachment.DocumentInfo.FileFormat);
		File.WriteAllBytes(Path.Combine(targetFolder, attachment.Name), attachment.Content);
	}
} 
```

Remove particular attachments from an email message.

**C#**

```csharp
using (EmailDocument doc = Document.Load<EmailDocument>(@"D:\test.eml"))
{
	for (int i = doc.Attachments.Count - 1; i >= 0; i--)
	{
		EmailAttachment attachment = doc.Attachments[i];

		// Remove all attached pdf files with a particular name
		if (attachment.Name.Contains("EULA") && attachment.DocumentInfo.FileFormat == FileFormat.Pdf)
		{
			doc.Attachments.RemoveAt(i);
		}
	}

	// Save changes
	doc.Save();
}
```

Add watermark to all attached files of supported types.

**C#**

```csharp
TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));
using (EmailDocument doc = Document.Load<EmailDocument>(@"D:\test.msg"))
{
	foreach (EmailAttachment attachment in doc.Attachments)
	{
		// Check if the attached file is supported by GroupDocs.Watermark
		if (attachment.DocumentInfo.FileFormat != FileFormat.Undefined && !attachment.DocumentInfo.IsEncrypted)
		{
			// Load the attached document
			using (Document attachedDocument = attachment.LoadDocument())
			{
				// Add wateramrk
				attachedDocument.AddWatermark(watermark);

				// Save changes in the attached file
				attachedDocument.Save();
			}
		}
	}
	// Save changes
	doc.Save();
}
```

Add an attachment to an email message

**C#**

```csharp
string attachmentPath = @"D:\logo.gif";
using (EmailDocument doc = Document.Load<EmailDocument>(@"D:\test.eml"))
{
	doc.Attachments.Add(File.ReadAllBytes(attachmentPath), "test_logo.gif");
	
	// Save changes
	doc.Save();
}
```

Modify email message body and subject.

**C#**

```csharp
using (EmailDocument doc = Document.Load<EmailDocument>(@"D:\test.eml"))
{
	// Set the plain text body
	doc.Body = "Test plain text body";

	// Set the html body
	doc.HtmlBody = "<html><body>Test html body</body></html>";

	// Set the email subject
	doc.Subject = "Test subject";

	// Save changes
	doc.Save();
}
```

Sometimes, attached files can appear in email message body as embedded objects. Attachments of such type can be accessed through *EmailDocument.EmbeddedObjects* property.

Remove all embedded jpeg images from an email message

**C#**

```csharp
using (EmailDocument doc = Document.Load<EmailDocument>(@"D:\test.eml"))
{
	for (int i = doc.EmbeddedObjects.Count - 1; i >= 0; i--)
	{
		if (doc.EmbeddedObjects[i].DocumentInfo.FileFormat == FileFormat.Jpeg)
		{
			// Remove reference to the image from html body
			string pattern = string.Format("<img[^>]*src=\"cid:{0}\"[^>]*>", doc.EmbeddedObjects[i].ContentId);
			doc.HtmlBody = Regex.Replace(doc.HtmlBody, pattern, string.Empty);

			// Remove the image
			doc.EmbeddedObjects.RemoveAt(i);
		}
	}
	doc.Save();
}
```

Embed image into email message body.

**C#**

```csharp
using (EmailDocument doc = Document.Load<EmailDocument>(@"D:\test.eml"))
{
	string imagePath = @"D:\test.png";
	doc.EmbeddedObjects.Add(File.ReadAllBytes(imagePath), imagePath);
	EmailEmbeddedObject embeddedObject = doc.EmbeddedObjects[doc.EmbeddedObjects.Count - 1];
	doc.HtmlBody = string.Format("<html><body>This is an embedded image: <img src=\"cid:{0}\"></body></html>", embeddedObject.ContentId);
	doc.Save();
}
```

List all message recipients.

**C#**

```csharp
using (EmailDocument doc = Document.Load<EmailDocument>(@"D:\test.msg"))
{
	// List all direct recipients
	foreach (EmailAddress address in doc.To)
	{
		Console.WriteLine(address.Address);
	}

	// List all CC recipients
	foreach (EmailAddress address in doc.Cc)
	{
		Console.WriteLine(address.Address);
	}

	// List all BCC recipients
	foreach (EmailAddress address in doc.Bcc)
	{
		Console.WriteLine(address.Address);
	}
}
```

Find particular text fragments in email message body/subject.

**C#**

```csharp
using (EmailDocument doc = Document.Load<EmailDocument>(@"D:\test.msg"))
{
	SearchCriteria criteria = new TextSearchCriteria("test", false);

	// Specify search locations
	doc.SearchableObjects.EmailSearchableObjects = EmailSearchableObjects.Subject | EmailSearchableObjects.HtmlBody | EmailSearchableObjects.PlainTextBody;

	// Note, search is performed only if you pass TextSearchCriteria instance to FindWatermarks method
	PossibleWatermarkCollection watermarks = doc.FindWatermarks(criteria);

	// Remove found text fragments
	watermarks.Clear();

	// Save changes
	doc.Save();
}
```

{{< alert style="warning" >}}At this moment GroupDocs.Watermark does not support adding watermarks to email message body. So, EmailDocument.AddWatermark method throws NotSupportedException.{{< /alert >}}

### Remove SlidesBaseSlide.BackgroundImage property (obsolete code)

##### Description

Obsolete *SlidesBaseSlide.BackgroundImage* property has been removed from public API.

##### Public API changes

*BackgroundImage* property has been removed from *SlidesBaseSlide* class.

##### Usage

Use *SlidesBaseSlide.ImageFillFormat.BackgroundImage* property instead.

**C#**

```csharp
using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\test.pptx"))
{
	doc.Slides[0].ImageFillFormat.BackgroundImage = new SlidesWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));

        doc.Save(@"D:\result.pptx");
}
```
