---
id: groupdocs-watermark-for-net-17-10-0-release-notes
url: watermark/net/groupdocs-watermark-for-net-17-10-0-release-notes
title: GroupDocs.Watermark for .NET 17.10.0 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 17.10.0.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Ability to work with attachments in a PDF document.
*   Ability to work with attachments in an Excel document.

## All Changes

| Key  | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-686 | Implement the ability to work with attachments in a PDF document  | New Feature  |
| WATERMARKNET-687  | Implement the ability to work with attachments in an Excel document  | New Feature  |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 17.10. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermarkwhich may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### **Ability to work with attachments in a PDF document**

###### **Description**

This feature allows user to add, remove and edit attachments in **PDF** documents.

**Public API changes**

*Attachment* class has been added to *GroupDocs.Watermark* namespace.  
*PdfAttachment* class has been added to *GroupDocs.Watermark.Pdf* namespace.  
*PdfAttachmentCollection* class has been added to *GroupDocs.Watermark.Pdf* namespace.  
*PdfAttachedImagePossibleWatermark* class has been added to *GroupDocs.Watermark.Pdf* namespace.  
*AttachedImages* item has been added to *PdfSearchableObjects* enum.  
*Attachments* property has been added to *PdfDocument* class.

**Usage**

Extract all attachments from a PDF document.

**C#**

```csharp
string targetFolder = @"D:\attachments";
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\test.pdf"))
{
	foreach (PdfAttachment attachment in doc.Attachments)
	{
		Console.WriteLine("Name: {0}", attachment.Name);
		Console.WriteLine("Description: {0}", attachment.Description);
		Console.WriteLine("File format: {0}", attachment.DocumentInfo.FileFormat);

		// Save the attached file on disk
		File.WriteAllBytes(Path.Combine(targetFolder, attachment.Name), attachment.Content);
	}
}
Console.ReadKey();
```

Remove particular attachments from a PDF document.

**C#**

```csharp
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\test.pdf"))
{
	for (int i = doc.Attachments.Count - 1; i >= 0; i--)
	{
		PdfAttachment attachment = doc.Attachments[i];

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
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\test.pdf"))
{
	foreach (PdfAttachment attachment in doc.Attachments)
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

	// Save changes in the document
	doc.Save();
}
```

Search for images in the attached files using *FindImages* or *FindWatermarks* method.  
GroupDocs.Watermark provides the ability to search for images that are similar to a given sample image. This feature now works for the attached images in PDF documents.

**C#**

```csharp
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\test.pdf"))
{
	// Consider only the attached images
	doc.SearchableObjects.PdfSearchableObjects = PdfSearchableObjects.AttachedImages;

	// Specify sample image to compare document images with
	ImageSearchCriteria criteria = new ImageDctHashSearchCriteria(@"D:\sample.png");

	// Search for similar images
	PossibleWatermarkCollection possibleWatermarks = doc.FindWatermarks(criteria);

	// Remove or modify found image watermarks
}
```

Add an attachment to a PDF document.

**C#**

```csharp
string attachmentPath = @"D:\EULA.doc";
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\test.pdf"))
{
	// Add the attachment
	doc.Attachments.Add(File.ReadAllBytes(attachmentPath), "License Agreement.doc", "end-user license agreement");

	// Save changes
	doc.Save();
}
```

  

**Ability to work with attachments in an Excel document**

##### Description

This feature allows user to add, remove and edit attachments (OLE objects) in Excel documents.

##### Public API changes

*CellsAttachment* class has been added to *GroupDocs.Watermark.Office.Cells* namespace.  
*CellsAttachmentCollection* class has been added to *GroupDocs.Watermark.Office.Cells* namespace.  
*CellsAttachedImagePossibleWatermark* class has been added to *GroupDocs.Watermark.Office.Cells* namespace.  
*AttachedImages* item has been added to *CellsSearchableObjects* enum.  
*Attachments* property has been added to *CellsWorksheet* class.

##### Usage

Extract information about all attachments in an Excel document.

**C#**

```csharp
using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\test.xlsx"))
{
	foreach (CellsWorksheet worksheet in doc.Worksheets)
	{
		foreach (CellsAttachment attachment in worksheet.Attachments)
		{
			Console.WriteLine("Alternative text: {0}", attachment.AlternativeText);
			Console.WriteLine("Attachment frame x-coordinate: {0}", attachment.X);
			Console.WriteLine("Attachment frame y-coordinate: {0}", attachment.Y);
			Console.WriteLine("Attachment frame width: {0}", attachment.Width);
			Console.WriteLine("Attachment frame height: {0}", attachment.Height);
			Console.WriteLine("Preview image size: {0}", attachment.PreviewImageContent != null ? attachment.PreviewImageContent.Length : 0);

			if (attachment.IsLink)
			{
				// The document contains only a link to the attached file
				Console.WriteLine("Full path to the attached file: {0}", attachment.SourceFullName);
			}
			else
			{
				// The attached file is stored in the document
               			Console.WriteLine("File format: {0}", attachment.DocumentInfo.FileFormat);
				Console.WriteLine("Name of the source file: {0}", attachment.SourceFullName);
				Console.WriteLine("File size: {0}", attachment.Content.Length);
			}
		}
	}
}
Console.ReadKey();
```

Remove particular attachments from an Excel document.

**C#**

```csharp
using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\test.xlsx"))
{
	foreach (CellsWorksheet worksheet in doc.Worksheets)
	{
		for (int i = worksheet.Attachments.Count - 1; i >= 0; i--)
		{
			CellsAttachment attachment = worksheet.Attachments[i];
			if (attachment.IsLink && !File.Exists(attachment.SourceFullName) || // Linked file that is not available at this moment
				attachment.DocumentInfo.IsEncrypted) // Attached file protected with a password
			{
				// Remove the file if it meets at least one of the conditions above
				worksheet.Attachments.RemoveAt(i);
			}
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

using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\test.xlsx"))
{
	foreach (CellsWorksheet worksheet in doc.Worksheets)
	{
		foreach (CellsAttachment attachment in worksheet.Attachments)
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
	}

	// Save changes in the document
	doc.Save();
}
```

{{< alert style="warning" >}}The code snippet above does not affect attached files that are not stored within a document. You can check CellsAttachment.IsLink property to determine such files. True means that a document contains only a full path to the file, but not its content. In this case, CellsAttachment.SourceFullName property can be used to locate linked file on disk.{{< /alert >}}

Search for images in the attached files using *FindImages* or *FindWatermarks* method.  
GroupDocs.Watermark provides the ability to search for images that are similar to a given sample image. This feature now works for the attached images in Excel documents.

**C#**

```csharp
using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\test.xlsx"))
{
	// Consider only the attached images
	doc.SearchableObjects.CellsSearchableObjects = CellsSearchableObjects.AttachedImages;

	// Specify sample image to compare document images with
	ImageSearchCriteria criteria = new ImageDctHashSearchCriteria(@"D:\sample.png");

	// Search for similar images
	PossibleWatermarkCollection possibleWatermarks = doc.FindWatermarks(criteria);

	// Remove or modify found image watermarks
}
```

Add an attachment to an Excel document.

**C#**

```csharp
string attachmentPath = @"D:\EULA.doc";
string previewImagePath = @"D:\preview.png";

using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\test.xlsx"))
{
	CellsWorksheet worksheet = doc.Worksheets[0];

	// Add the attachment
	worksheet.Attachments.AddAttachment(
		File.ReadAllBytes(attachmentPath), // File content
		attachmentPath, // Source file full name (the extension is used to determine appropriate application to open the file) 
		File.ReadAllBytes(previewImagePath), // Preview image content
		50, // X-coordinate of the attachment frame
		100, // Y-coordinate of the attachment frame
		200, // Attachment frame width
		400); // Attachment frame height

	// Save changes
	doc.Save();
}
```

Add a linked file to an Excel document

**C#**

```csharp
string attachmentPath = @"D:\EULA.doc";
string previewImagePath = @"D:\preview.png";

using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\test.xlsx"))
{
	CellsWorksheet worksheet = doc.Worksheets[0];

	// Add the attachment
	worksheet.Attachments.AddLink(
		attachmentPath, // Source file path
		File.ReadAllBytes(previewImagePath), // Preview image content
		50, // X-coordinate of the attachment frame
		100, // Y-coordinate of the attachment frame
		200, // Attachment frame width
		400); // Attachment frame height

	// Save changes
	doc.Save();
}
```
